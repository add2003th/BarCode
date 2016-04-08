<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class COINMAC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.CmbOrg = New System.Windows.Forms.ComboBox
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsBarcode = New HPBarcode.DsBarcode
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtModel = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtBarcode = New System.Windows.Forms.TextBox
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSerialNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtMacCode = New System.Windows.Forms.TextBox
        Me.TxtMacSerial = New System.Windows.Forms.TextBox
        Me.BtnNext = New System.Windows.Forms.Button
        Me.TxtPrevious = New System.Windows.Forms.Button
        Me.BtnFirst = New System.Windows.Forms.Button
        Me.BtnLast = New System.Windows.Forms.Button
        Me.LblCount = New System.Windows.Forms.Label
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnClear = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.BtnUpload = New System.Windows.Forms.Button
        Me.BtnEdit = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Exit"
        '
        'CmbOrg
        '
        Me.CmbOrg.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BindingSource1, "ORGANIZATION_CODE", True))
        Me.CmbOrg.Location = New System.Drawing.Point(48, 7)
        Me.CmbOrg.Name = "CmbOrg"
        Me.CmbOrg.Size = New System.Drawing.Size(189, 22)
        Me.CmbOrg.TabIndex = 0
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "TbBarcode"
        Me.BindingSource1.DataSource = Me.DsBarcode
        '
        'DsBarcode
        '
        Me.DsBarcode.DataSetName = "DsBarcode"
        Me.DsBarcode.Prefix = ""
        Me.DsBarcode.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 22)
        Me.Label1.Text = "Org :"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.Text = "MachineModel :"
        '
        'TxtModel
        '
        Me.TxtModel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "MACHINEMODEL", True))
        Me.TxtModel.Location = New System.Drawing.Point(102, 158)
        Me.TxtModel.Name = "TxtModel"
        Me.TxtModel.Size = New System.Drawing.Size(135, 21)
        Me.TxtModel.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.Text = "Barcode :"
        '
        'TxtBarcode
        '
        Me.TxtBarcode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "BARCODE", True))
        Me.TxtBarcode.Location = New System.Drawing.Point(71, 38)
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Size = New System.Drawing.Size(166, 21)
        Me.TxtBarcode.TabIndex = 6
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(165, 188)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 20)
        Me.BtnSave.TabIndex = 10
        Me.BtnSave.Text = "Save"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.Text = "SerialNo :"
        '
        'TxtSerialNo
        '
        Me.TxtSerialNo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "SERIALNO", True))
        Me.TxtSerialNo.Location = New System.Drawing.Point(71, 68)
        Me.TxtSerialNo.Name = "TxtSerialNo"
        Me.TxtSerialNo.Size = New System.Drawing.Size(166, 21)
        Me.TxtSerialNo.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.Text = "MachineCode :"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.Text = "MachineSerial :"
        '
        'TxtMacCode
        '
        Me.TxtMacCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "MACHINE_CODE", True))
        Me.TxtMacCode.Location = New System.Drawing.Point(102, 98)
        Me.TxtMacCode.Name = "TxtMacCode"
        Me.TxtMacCode.Size = New System.Drawing.Size(135, 21)
        Me.TxtMacCode.TabIndex = 18
        '
        'TxtMacSerial
        '
        Me.TxtMacSerial.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "MACHINE_SERIAL", True))
        Me.TxtMacSerial.Location = New System.Drawing.Point(102, 128)
        Me.TxtMacSerial.Name = "TxtMacSerial"
        Me.TxtMacSerial.Size = New System.Drawing.Size(135, 21)
        Me.TxtMacSerial.TabIndex = 19
        '
        'BtnNext
        '
        Me.BtnNext.Location = New System.Drawing.Point(152, 242)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(40, 20)
        Me.BtnNext.TabIndex = 26
        Me.BtnNext.Text = ">"
        '
        'TxtPrevious
        '
        Me.TxtPrevious.Location = New System.Drawing.Point(107, 242)
        Me.TxtPrevious.Name = "TxtPrevious"
        Me.TxtPrevious.Size = New System.Drawing.Size(40, 20)
        Me.TxtPrevious.TabIndex = 33
        Me.TxtPrevious.Text = "<"
        '
        'BtnFirst
        '
        Me.BtnFirst.Location = New System.Drawing.Point(62, 242)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(40, 20)
        Me.BtnFirst.TabIndex = 41
        Me.BtnFirst.Text = "|<"
        '
        'BtnLast
        '
        Me.BtnLast.Location = New System.Drawing.Point(197, 242)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(40, 20)
        Me.BtnLast.TabIndex = 42
        Me.BtnLast.Text = ">|"
        '
        'LblCount
        '
        Me.LblCount.BackColor = System.Drawing.Color.Silver
        Me.LblCount.Location = New System.Drawing.Point(5, 242)
        Me.LblCount.Name = "LblCount"
        Me.LblCount.Size = New System.Drawing.Size(51, 20)
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(5, 188)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 20)
        Me.BtnAdd.TabIndex = 50
        Me.BtnAdd.Text = "Add"
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(85, 215)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(72, 20)
        Me.BtnClear.TabIndex = 58
        Me.BtnClear.Text = "Delete"
        '
        'SerialPort1
        '
        '
        'BtnUpload
        '
        Me.BtnUpload.Location = New System.Drawing.Point(165, 215)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(72, 20)
        Me.BtnUpload.TabIndex = 66
        Me.BtnUpload.Text = "Upload"
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(85, 188)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(72, 20)
        Me.BtnEdit.TabIndex = 110
        Me.BtnEdit.Text = "Edit"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(5, 215)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 20)
        Me.BtnCancel.TabIndex = 111
        Me.BtnCancel.Text = "Cancel"
        '
        'COINMAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnUpload)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.LblCount)
        Me.Controls.Add(Me.BtnLast)
        Me.Controls.Add(Me.BtnFirst)
        Me.Controls.Add(Me.TxtPrevious)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.TxtMacSerial)
        Me.Controls.Add(Me.TxtMacCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSerialNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TxtBarcode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtModel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbOrg)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "COINMAC"
        Me.Text = "Form1"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbOrg As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtModel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtMacCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtMacSerial As System.Windows.Forms.TextBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DsBarcode As HPBarcode.DsBarcode
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents TxtPrevious As System.Windows.Forms.Button
    Friend WithEvents BtnFirst As System.Windows.Forms.Button
    Friend WithEvents BtnLast As System.Windows.Forms.Button
    Friend WithEvents LblCount As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button

End Class
