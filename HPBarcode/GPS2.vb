Imports System.Data
Imports System.Web.Services
Imports System.IO
Public Class GPS2
    Private pointer As CurrencyManager
    Private WithEvents GPS As New GPSSerial.SerialGPS("COM8")
    Delegate Sub DLG_UPTEXT(ByVal lat As String, ByVal lon As String)
    Private Flag As String
    Private DSLocation As New DataSet
    Private DTLocation As DataTable
    Private DV As DataView

    Sub UPTEXT(ByVal lat As String, ByVal lon As String)
        Me.TxtLatitude.Text = lat
        Me.TxtLongtitude.Text = lon
    End Sub

    Private Sub GPS_PositionReceived(ByVal latitude As String, ByVal longtitude As String) Handles GPS.PositionReceived
        Me.Invoke(New DLG_UPTEXT(AddressOf UPTEXT), New Object() {latitude, longtitude})
    End Sub

    Sub OPENCOM()
        Try
            GPS.Close()
        Catch ex As Exception

        End Try
        Try
            GPS.Open()
            Me.Text = "GPS ON"
        Catch ex As Exception
            MsgBox("GPS NOT OPEN" & ex.ToString)
        End Try
    End Sub

    Sub LoadCmborg()
        Dim dt As New DataTable("OrgData")
        Dim dc As DataColumn
        dc = New DataColumn("Orgvalue", GetType(String))
        dt.Columns.Add(dc)
        dc = New DataColumn("OrgDisplay", GetType(String))
        dt.Columns.Add(dc)

        Dim dr As DataRow
        dr = dt.NewRow
        dr.Item("Orgvalue") = "0"
        dr.Item("OrgDisplay") = "กรุณาเลือกสาขา"
        dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr.Item("Orgvalue") = "CEN"
        'dr.Item("Orgdisplay") = "Stock"
        'dt.Rows.Add(dr)

        dr = dt.NewRow
        dr.Item("Orgvalue") = "SAT"
        dr.Item("OrgDisplay") = "Sathupradit"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr.Item("Orgvalue") = "SRC"
        dr.Item("OrgDisplay") = "Cholburi"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr.Item("Orgvalue") = "WAN"
        dr.Item("OrgDisplay") = "Wangnoi"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr.Item("Orgvalue") = "SLG"
        dr.Item("OrgDisplay") = "Bangkapi"
        dt.Rows.Add(dr)

        Me.CmbOrg.DisplayMember = "OrgDisplay"
        Me.CmbOrg.ValueMember = "Orgvalue"
        Me.CmbOrg.DataSource = dt
        Me.CmbOrg.SelectedValue = 0
    End Sub

    Sub LoadCmbCompany()
        Me.DSLocation.ReadXml("\Storage Card\DataLocation.xml", XmlReadMode.ReadSchema)
        DTLocation = DSLocation.Tables(0)
        Dim DR As DataRow
        DR = DTLocation.NewRow
        DR.Item("CUSTOMER_CODE") = "0"
        DR.Item("CUSTOMER_NAME") = "กรุณาเลือกลูกค้า"
        DTLocation.Rows.Add(DR)
        DV = DTLocation.DefaultView
        DV.Sort = "CUSTOMER_CODE "
        DTLocation = DV.ToTable

        Me.CmbCompany.DisplayMember = "CUSTOMER_NAME"
        Me.CmbCompany.ValueMember = "CUSTOMER_CODE"
        Me.CmbCompany.DataSource = DTLocation
        Me.CmbCompany.SelectedValue = 0
    End Sub

    Private Sub EnableText()
        Me.TxtMacCode.Enabled = True
        Me.CmbCompany.Enabled = True
        Me.CmbOrg.Enabled = True
        Me.TxtLatitude.Enabled = True
        Me.TxtLongtitude.Enabled = True
    End Sub

    Private Sub DisableText()
        Me.TxtMacCode.Enabled = False
        Me.CmbCompany.Enabled = False
        Me.CmbOrg.Enabled = False
        Me.TxtLatitude.Enabled = False
        Me.TxtLongtitude.Enabled = False
    End Sub

    Private Sub GPS2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        LoadCmborg()
        LoadCmbCompany()

        Me.DsBarcode.Clear()
        Me.DsBarcode.ReadXml("\Storage Card\GPS2.xml", XmlReadMode.ReadSchema)
        If Me.DsBarcode.Tables("TbGPS2").Rows.Count = 0 Then
            Try
                Flag = "Add"
                EnableText()
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnCancel.Enabled = False
                BtnClear.Enabled = False
                BtnUpload.Enabled = False
                GPS.Open()
                Me.Text = "GPS ON"
            Catch ex As Exception
                MsgBox("GPS NOT OPEN" & ex.ToString)
            End Try
        Else
            Try
                Flag = "Edit"
                DisableText()
                BtnAdd.Enabled = True
                BtnEdit.Enabled = True
                BtnClear.Enabled = True
                BtnUpload.Enabled = True
                BtnSave.Enabled = False
                BtnCancel.Enabled = False
                GPS.Close()
            Catch ex As Exception

            End Try
        End If
        pointer = Me.BindingContext(DsBarcode, "TbGPS2")
        ClearAllBinding()
        MakeAllBinding()
        showPosition()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Try
            GPS.Close()
        Catch ex As Exception
            Me.Text = "GPS NOT OPEN"
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Sub ClearText()
        Me.TxtMacCode.Text = ""
        Me.CmbCompany.SelectedValue = 0
        Me.CmbOrg.SelectedValue = 0
        Me.TxtLatitude.Text = ""
        Me.TxtLongtitude.Text = ""
    End Sub

    Sub showPosition()
        Me.LblCount.Text = (pointer.Position + 1) & "/" & DsBarcode.Tables("TbGPS2").Rows.Count
    End Sub

    Sub ClearAllBinding()
        Me.TxtMacCode.DataBindings.Clear()
        Me.CmbCompany.DataBindings.Clear()
        Me.CmbOrg.DataBindings.Clear()
        Me.TxtLatitude.DataBindings.Clear()
        Me.TxtLongtitude.DataBindings.Clear()
    End Sub

    Sub MakeAllBinding()
        Me.TxtMacCode.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS2.MACHINE_CODE"))
        Me.CmbCompany.DataBindings.Add(New Binding("SelectedValue", DsBarcode, "TbGPS2.CUSTOMER_CODE"))
        Me.CmbCompany.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS2.CUSTOMER_NAME"))
        Me.CmbOrg.DataBindings.Add(New Binding("SelectedValue", DsBarcode, "TbGPS2.ORGANIZATION_CODE"))
        Me.TxtLatitude.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS2.LATITUDE"))
        Me.TxtLongtitude.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS2.LONGTITUDE"))
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor.Current = Cursors.WaitCursor
        OPENCOM()
        'LoadCmbCompany()
        Flag = "Add"
        EnableText()
        CmbCompany.SelectedValue = 0
        BtnEdit.Enabled = False
        BtnClear.Enabled = False
        BtnUpload.Enabled = False
        BtnSave.Enabled = True
        BtnCancel.Enabled = True
        ClearText()
        ClearAllBinding()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        If MsgBox("Do you really want to delete data ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Cursor.Current = Cursors.WaitCursor
            Me.DsBarcode.Tables("TbGPS2").Rows(pointer.Position).Delete()
            If Me.DsBarcode.Tables("TbGPS2").Rows.Count = 0 Then
                Try
                    Flag = "Add"
                    BtnAdd.Enabled = False
                    BtnEdit.Enabled = False
                    BtnSave.Enabled = True
                    BtnClear.Enabled = False
                    BtnUpload.Enabled = False
                    EnableText()
                    GPS.Open()
                    Me.Text = "GPS ON"
                Catch ex As Exception
                    MsgBox("GPS NOT OPEN" & ex.ToString)
                End Try
            Else
                Try
                    Flag = "Edit"
                    DisableText()
                    BtnEdit.Enabled = True
                    GPS.Close()
                Catch ex As Exception

                End Try
            End If
            Me.DsBarcode.WriteXml("\Storage Card\GPS2.xml", XmlWriteMode.WriteSchema)
            MsgBox("Ok")
            ClearText()
            CmbCompany.SelectedValue = 0
            'If DsBarcode.Tables("TbGPS2").Rows.Count = 0 Then LoadCmbCompany()
            ClearAllBinding()
            MakeAllBinding()
            showPosition()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            pointer.Position = DsBarcode.Tables("TbGPS2").Rows.Count
            showPosition()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Try
            pointer.Position += 1
            showPosition()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrevious.Click
        Try
            pointer.Position -= 1
            showPosition()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirst.Click
        Try
            pointer.Position = 0
            showPosition()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtMacCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMacCode.KeyPress
        If e.KeyChar = Chr(13) Then
            Cursor.Current = Cursors.WaitCursor
            CmbCompany.SelectedValue = 0
            CmbOrg.SelectedValue = 0
            If Not IsNothing(DTLocation) Then
                For Each DR As DataRow In DTLocation.Rows
                    If Not (DR.Item("MACHINE_CODE")) Is DBNull.Value AndAlso DR.Item("MACHINE_CODE") = TxtMacCode.Text Then
                        CmbCompany.SelectedValue = DR.Item("CUSTOMER_CODE")
                        CmbOrg.SelectedValue = DR.Item("ORGANIZATION_CODE")
                        Exit For
                    End If
                Next
            End If
            If CmbOrg.SelectedValue = 0 Then
                MsgBox("No Data")
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Function ReadFile(ByVal FilePath As String) As Byte()
        Dim fs As FileStream
        Try
            'Read file and return contents
            fs = File.Open(FilePath, FileMode.Open, FileAccess.Read)
            Dim lngLen As Long = fs.Length
            Dim abytBuffer(CInt(lngLen - 1)) As Byte
            fs.Read(abytBuffer, 0, CInt(lngLen))
            Return abytBuffer
        Catch exp As Exception
            Return Nothing
        Finally
            If Not fs Is Nothing Then
                fs.Close()
            End If
        End Try
    End Function

    Private Sub BtnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpload.Click
        If MsgBox("Do you really want to upload data ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Try
                Cursor.Current = Cursors.WaitCursor
                Dim webservice As New Ftp.Ftp
                Dim GPSRIVAL As New GPSRIVAL.GPSRIVAL
                Dim b As Byte() = ReadFile("\Storage Card\GPS2.xml")
                webservice.UploadFile("Vending\StockSpares\WebApp\UploadFile", "GPS2.xml", b)
                GPSRIVAL.UpdateGPSRIVAL()
                Me.DsBarcode.Tables("TbGPS2").Clear()
                Me.DsBarcode.WriteXml("\Storage Card\GPS2.xml", XmlWriteMode.WriteSchema)
                MsgBox("Upload Success")
                Flag = "Add"
                ClearText()
                ClearAllBinding()
                MakeAllBinding()
                showPosition()
                EnableText()
                Cursor.Current = Cursors.Default
            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor.Current = Cursors.WaitCursor
        OPENCOM()
        Flag = "Edit"
        EnableText()
        BtnAdd.Enabled = False
        BtnSave.Enabled = True
        BtnUpload.Enabled = False
        BtnClear.Enabled = False
        BtnCancel.Enabled = True
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            GPS.Close()
            Me.DsBarcode.Clear()
            Me.DsBarcode.ReadXml("\Storage Card\GPS2.xml", XmlReadMode.ReadSchema)
            pointer = Me.BindingContext(DsBarcode, "TbGPS2")
            ClearAllBinding()
            MakeAllBinding()
            showPosition()
            If Flag = "Add" Then
                BtnEdit.Enabled = True
            ElseIf Flag = "Edit" Then
                BtnAdd.Enabled = True
            End If
            BtnClear.Enabled = True
            BtnUpload.Enabled = True
            BtnSave.Enabled = False
            BtnCancel.Enabled = False
            DisableText()
            Cursor.Current = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            GPS.Close()
            Cursor.Current = Cursors.WaitCursor
            Dim dr As DataRow
            pointer.Position = 0
            dr = Me.DsBarcode.Tables("TbGPS2").NewRow()
            dr.Item("MACHINE_CODE") = TxtMacCode.Text.Trim()
            dr.Item("CUSTOMER_NAME") = CmbCompany.Text
            dr.Item("CUSTOMER_CODE") = CmbCompany.SelectedValue
            dr.Item("ORGANIZATION_CODE") = CmbOrg.SelectedValue
            dr.Item("LATITUDE") = TxtLatitude.Text
            dr.Item("LONGTITUDE") = TxtLongtitude.Text
            If Flag = "Add" Then Me.DsBarcode.Tables("TbGPS2").Rows.Add(dr)
            Flag = "Edit"
            Me.DsBarcode.WriteXml("\Storage Card\GPS2.xml", XmlWriteMode.WriteSchema)
            ClearText()
            ClearAllBinding()
            MakeAllBinding()
            showPosition()
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnClear.Enabled = True
            BtnUpload.Enabled = True
            BtnSave.Enabled = False
            BtnCancel.Enabled = False
            DisableText()
            Cursor.Current = Cursors.Default
            MsgBox("Ok")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class