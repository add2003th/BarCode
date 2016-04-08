Imports System.Data
Imports System.IO
Imports System.Web.Services
Public Class COINMAC
    Private pointer As CurrencyManager
    Private Flag As String

    Private Sub EnableText()
        CmbOrg.Enabled = True
        TxtBarcode.Enabled = True
        TxtSerialNo.Enabled = True
        TxtMacCode.Enabled = True
        TxtMacSerial.Enabled = True
        TxtModel.Enabled = True
    End Sub

    Private Sub DisableText()
        CmbOrg.Enabled = False
        TxtBarcode.Enabled = False
        TxtSerialNo.Enabled = False
        TxtMacCode.Enabled = False
        TxtMacSerial.Enabled = False
        TxtModel.Enabled = False
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        LoadCmborg()

        Me.DsBarcode.Clear()
        Me.DsBarcode.ReadXml("\Storage Card\Barcode.xml", XmlReadMode.ReadSchema)
        If Me.DsBarcode.Tables("TbBarcode").Rows.Count = 0 Then
            Try
                Flag = "Add"
                EnableText()
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnCancel.Enabled = False
                BtnClear.Enabled = False
                BtnUpload.Enabled = False
            Catch ex As Exception

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
            Catch ex As Exception

            End Try
        End If
        pointer = Me.BindingContext(DsBarcode, "TbBarcode")
        ClearAllBinding()
        MakeAllBinding()
        showPosition()
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub OPENCOM()
        Try
            If Me.SerialPort1.IsOpen Then Me.SerialPort1.Close()
        Catch ex As Exception
        End Try
        Me.SerialPort1.BaudRate = 9600
        Me.SerialPort1.PortName = "COM5"
        Me.SerialPort1.Parity = IO.Ports.Parity.None
        Me.SerialPort1.StopBits = IO.Ports.StopBits.One
        Me.SerialPort1.ReadTimeout = 100
        Try
            Me.SerialPort1.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
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

    End Sub

    Sub showPosition()
        LblCount.Text = (pointer.Position + 1) & "/" & DsBarcode.Tables("TbBarcode").Rows.Count
    End Sub

    Sub ClearAllBinding()
        CmbOrg.DataBindings.Clear()
        TxtBarcode.DataBindings.Clear()
        TxtSerialNo.DataBindings.Clear()
        TxtMacCode.DataBindings.Clear()
        TxtMacSerial.DataBindings.Clear()
        TxtModel.DataBindings.Clear()
    End Sub

    Sub MakeAllBinding()
        CmbOrg.DataBindings.Add(New Binding("SelectedValue", DsBarcode, "TbBarcode.ORGANIZATION_CODE"))
        TxtBarcode.DataBindings.Add(New Binding("Text", DsBarcode, "TbBarcode.BARCODE"))
        TxtSerialNo.DataBindings.Add(New Binding("Text", DsBarcode, "TbBarcode.SERIALNO"))
        TxtMacCode.DataBindings.Add(New Binding("Text", DsBarcode, "TbBarcode.MACHINE_CODE"))
        TxtMacSerial.DataBindings.Add(New Binding("Text", DsBarcode, "TbBarcode.MACHINE_SERIAL"))
        TxtModel.DataBindings.Add(New Binding("Text", DsBarcode, "TbBarcode.MACHINEMODEL"))
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            If TxtBarcode.Text = "" Then
                MsgBox("Please insert Barcode", MsgBoxStyle.Critical)
                'ElseIf TxtMacCode.Text = "" Then
                '    MsgBox("Please insert MachineCode", MsgBoxStyle.Critical)
            Else
                Dim dr As DataRow
                pointer.Position = 0
                dr = Me.DsBarcode.Tables("TbBarcode").NewRow()
                dr.Item("BARCODE") = TxtBarcode.Text.Trim()
                dr.Item("ORGANIZATION_CODE") = CmbOrg.SelectedValue
                dr.Item("MACHINEMODEL") = TxtModel.Text.Trim()
                dr.Item("SERIALNO") = TxtSerialNo.Text.Trim()
                dr.Item("MACHINE_CODE") = TxtMacCode.Text.Trim()
                dr.Item("MACHINE_SERIAL") = TxtMacSerial.Text.Trim()
                If Flag = "Add" Then Me.DsBarcode.Tables("TbBarcode").Rows.Add(dr)
                Flag = "Edit"
                'Me.DsBarcode.WriteXml("\Barcode.xml", XmlWriteMode.WriteSchema)
                Me.DsBarcode.WriteXml("\Storage Card\Barcode.xml", XmlWriteMode.WriteSchema)
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
                MsgBox("Ok")
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ClearText()
        TxtBarcode.Text = ""
        TxtSerialNo.Text = ""
        TxtMacCode.Text = ""
        TxtMacSerial.Text = ""
        TxtModel.Text = ""
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

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            pointer.Position = DsBarcode.Tables("TbBarcode").Rows.Count
            showPosition()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor.Current = Cursors.WaitCursor
        Flag = "Add"
        EnableText()
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
            Me.DsBarcode.Tables("TbBarcode").Rows(pointer.Position).Delete()
            If Me.DsBarcode.Tables("TbBarcode").Rows.Count = 0 Then
                Try
                    Flag = "Add"
                    EnableText()
                    BtnAdd.Enabled = False
                    BtnEdit.Enabled = False
                    BtnSave.Enabled = True
                    BtnClear.Enabled = False
                    BtnUpload.Enabled = False
                Catch ex As Exception

                End Try
            Else
                Try
                    Flag = "Edit"
                    DisableText()
                    BtnEdit.Enabled = True
                Catch ex As Exception

                End Try
            End If
            Me.DsBarcode.WriteXml("\Storage Card\Barcode.xml", XmlWriteMode.WriteSchema)
            MsgBox("Ok")
            LoadCmborg()
            ClearText()
            ClearAllBinding()
            MakeAllBinding()
            showPosition()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Delegate Sub dlg_Updatetext(ByVal msg As String)
    Sub updatetext(ByVal msg As String)
        Me.TxtBarcode.Text = msg
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Threading.Thread.Sleep(100)
        Dim Rdata As String = Me.SerialPort1.ReadExisting
        Me.Invoke(New dlg_Updatetext(AddressOf updatetext), New Object() {Rdata})
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If Me.SerialPort1.IsOpen Then Me.SerialPort1.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
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
                Dim Stock As New StockSpares.StockSpares
                Dim b As Byte() = ReadFile("\Storage Card\Barcode.xml")
                webservice.UploadFile("Vending\StockSpares\WebApp\UploadFile", "Barcode.xml", b)
                'If Stock.UpdateDatabase = True Then
                Stock.UpdateDatabase()
                Me.DsBarcode.Tables("TbBarcode").Clear()
                Me.DsBarcode.WriteXml("\Storage Card\Barcode.xml", XmlWriteMode.WriteSchema)
                MsgBox("Upload Success")
                'Else
                'MsgBox("Upload Fail")
                'End If
                Flag = "Add"
                LoadCmborg()
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
            Me.DsBarcode.Clear()
            Me.DsBarcode.ReadXml("\Storage Card\Barcode.xml", XmlReadMode.ReadSchema)
            pointer = Me.BindingContext(DsBarcode, "TbBarcode")
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
