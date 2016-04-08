Imports System.Data
Imports System.IO
Imports System.Web.Services
Public Class TESTGPS
    Private pointer As CurrencyManager
    Private WithEvents GPS As New GPSSerial.SerialGPS("COM6")
    Delegate Sub DLG_UPTEXT(ByVal lat As String, ByVal lon As String)
    Private Flag As String
    Private DSLocation As New DataSet
    Private DTLocation As DataTable
    Private DV As DataView

    Sub UPTEXT(ByVal lat As String, ByVal lon As String)
        Me.TxtLatitude.Text = lat
        Me.TxtLongtitude.Text = lon
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Try
            GPS.Close()
        Catch ex As Exception
            Me.Text = "GPS NOT OPEN"
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
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

    Private Sub EnableText()
        TxtMacCode.Enabled = True
        TxtCusCode.Enabled = True
        TxtCusName.Enabled = True
        TxtOrgCode.Enabled = True
        TxtOrgName.Enabled = True
        TxtLatitude.Enabled = True
        TxtLongtitude.Enabled = True
    End Sub

    Private Sub DisableText()
        TxtMacCode.Enabled = False
        TxtCusCode.Enabled = False
        TxtCusName.Enabled = False
        TxtOrgCode.Enabled = False
        TxtOrgName.Enabled = False
        TxtLatitude.Enabled = False
        TxtLongtitude.Enabled = False
    End Sub

    Private Sub TESTGPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        Me.DSLocation.ReadXml("\Storage Card\DataLocation.xml", XmlReadMode.ReadSchema)
        DTLocation = DSLocation.Tables(0)

        Me.DsBarcode.Clear()
        Me.DsBarcode.ReadXml("\Storage Card\GPS.xml", XmlReadMode.ReadSchema)
        If Me.DsBarcode.Tables("TbGPS").Rows.Count = 0 Then
            Try
                Flag = "Add"
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnCancel.Enabled = False
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
                BtnAdd.Enabled = True
                BtnEdit.Enabled = True
                BtnClear.Enabled = True
                BtnUpload.Enabled = True
                BtnSave.Enabled = False
                BtnCancel.Enabled = False
                DisableText()
                GPS.Close()
            Catch ex As Exception

            End Try
        End If
        pointer = Me.BindingContext(DsBarcode, "TbGPS")
        ClearAllBinding()
        MakeAllBinding()
        showPosition()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If TxtMacCode.Text = "" Then
                MsgBox("Please insert MachineCode", MsgBoxStyle.Critical)
            Else
                GPS.Close()
                Cursor.Current = Cursors.WaitCursor
                Dim dr As DataRow
                pointer.Position = 0
                dr = Me.DsBarcode.Tables("TbGPS").NewRow()
                dr.Item("MACHINE_CODE") = TxtMacCode.Text.Trim()
                dr.Item("CUSTOMER_CODE") = TxtCusCode.Text
                dr.Item("CUSTOMER_NAME") = TxtCusName.Text
                dr.Item("ORGANIZATION_CODE") = TxtOrgCode.Text
                dr.Item("ORGANIZATION_NAME") = TxtOrgName.Text
                dr.Item("LATITUDE") = TxtLatitude.Text.Trim()
                dr.Item("LONGTITUDE") = TxtLongtitude.Text.Trim()
                If Flag = "Add" Then Me.DsBarcode.Tables("TbGPS").Rows.Add(dr)
                Flag = "Edit"
                Me.DsBarcode.WriteXml("\Storage Card\GPS.xml", XmlWriteMode.WriteSchema)
                ClearText()
                ClearAllBinding()
                MakeAllBinding()
                showPosition()
                'GPS.Close()
                BtnAdd.Enabled = True
                BtnEdit.Enabled = True
                BtnClear.Enabled = True
                BtnUpload.Enabled = True
                BtnSave.Enabled = False
                BtnCancel.Enabled = False
                Cursor.Current = Cursors.Default
                DisableText()
                MsgBox("Ok")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ClearText()
        TxtMacCode.Text = ""
        TxtCusCode.Text = ""
        TxtCusName.Text = ""
        TxtOrgCode.Text = ""
        TxtOrgName.Text = ""
        TxtLatitude.Text = ""
        TxtLongtitude.Text = ""
    End Sub

    Sub showPosition()
        LblCount.Text = (pointer.Position + 1) & "/" & DsBarcode.Tables("TbGPS").Rows.Count
    End Sub

    Sub ClearAllBinding()
        TxtMacCode.DataBindings.Clear()
        TxtCusCode.DataBindings.Clear()
        TxtCusName.DataBindings.Clear()
        TxtOrgCode.DataBindings.Clear()
        TxtOrgName.DataBindings.Clear()
        TxtLatitude.DataBindings.Clear()
        TxtLongtitude.DataBindings.Clear()
    End Sub

    Sub MakeAllBinding()
        TxtMacCode.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS.MACHINE_CODE"))
        TxtCusCode.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS.CUSTOMER_CODE"))
        TxtCusName.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS.CUSTOMER_NAME"))
        TxtOrgCode.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS.ORGANIZATION_CODE"))
        TxtOrgName.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS.ORGANIZATION_NAME"))
        TxtLatitude.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS.LATITUDE"))
        TxtLongtitude.DataBindings.Add(New Binding("Text", DsBarcode, "TbGPS.LONGTITUDE"))
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor.Current = Cursors.WaitCursor
        OPENCOM()
        Flag = "Add"
        BtnEdit.Enabled = False
        BtnClear.Enabled = False
        BtnUpload.Enabled = False
        BtnSave.Enabled = True
        BtnCancel.Enabled = True
        EnableText()
        ClearText()
        ClearAllBinding()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        If MsgBox("Do you really want to delete data ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Cursor.Current = Cursors.WaitCursor
            Me.DsBarcode.Tables("TbGPS").Rows(pointer.Position).Delete()
            If Me.DsBarcode.Tables("TbGPS").Rows.Count = 0 Then
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
                    GPS.Close()
                    Flag = "Edit"
                    BtnEdit.Enabled = True
                    DisableText()
                Catch ex As Exception

                End Try
            End If
            Me.DsBarcode.WriteXml("\Storage Card\GPS.xml", XmlWriteMode.WriteSchema)
            MsgBox("Ok")
            ClearText()
            ClearAllBinding()
            MakeAllBinding()
            showPosition()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            pointer.Position = DsBarcode.Tables("TbGPS").Rows.Count
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
            TxtCusCode.Text = ""
            TxtCusName.Text = ""
            TxtOrgCode.Text = ""
            TxtOrgName.Text = ""
            If Not IsNothing(DTLocation) Then
                For Each DR As DataRow In DTLocation.Rows
                    If Not (DR.Item("MACHINE_CODE")) Is DBNull.Value AndAlso DR.Item("MACHINE_CODE") = TxtMacCode.Text Then
                        TxtCusCode.Text = DR.Item("CUSTOMER_CODE")
                        TxtCusName.Text = DR.Item("CUSTOMER_NAME")
                        TxtOrgCode.Text = DR.Item("ORGANIZATION_CODE")
                        TxtOrgName.Text = DR.Item("ORGANIZATION_NAME")
                        Exit For
                    End If
                Next
            End If
            If TxtOrgCode.Text = "" Then
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

    Private Sub DownloadFile()
        Dim objFile As File, objStream As StreamWriter, objFstream As FileStream
        Dim service As New Ftp.Ftp
        Dim CheckFile As String = "\Storage Card\DataLocation.xml"
        Try
            If IO.File.Exists(CheckFile) Then
                IO.File.Delete(CheckFile)
            End If
            Dim b As Byte() = service.GetFile("Vending\StockSpares\WebApp\UploadFile", "DataLocation.xml")
            objFstream = File.Open(CheckFile, FileMode.Create, FileAccess.Write)
            Dim lngLen As Long = b.Length
            objFstream.Write(b, 0, CInt(lngLen))
            objFstream.Flush()
            objFstream.Close()
        Finally
            If Not objFstream Is Nothing Then
                objFstream.Close()
            End If
        End Try
    End Sub

    Private Sub BtnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpload.Click
        If MsgBox("Do you really want to upload data ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Try
                Cursor.Current = Cursors.WaitCursor
                Dim webservice As New Ftp.Ftp
                Dim GPS As New GPS.CustomerGPS
                Dim b As Byte() = ReadFile("\Storage Card\GPS.xml")
                webservice.UploadFile("Vending\StockSpares\WebApp\UploadFile", "GPS.xml", b)
                GPS.UpdateGPS()
                Me.DsBarcode.Tables("TbGPS").Clear()
                Me.DsBarcode.WriteXml("\Storage Card\GPS.xml", XmlWriteMode.WriteSchema)
                DownloadFile()
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
            Me.DsBarcode.ReadXml("\Storage Card\GPS.xml", XmlReadMode.ReadSchema)
            pointer = Me.BindingContext(DsBarcode, "TbGPS")
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
End Class