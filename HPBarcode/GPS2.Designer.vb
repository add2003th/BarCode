<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class GPS2
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
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnEdit = New System.Windows.Forms.Button
        Me.BtnUpload = New System.Windows.Forms.Button
        Me.BtnLast = New System.Windows.Forms.Button
        Me.BtnFirst = New System.Windows.Forms.Button
        Me.TxtPrevious = New System.Windows.Forms.Button
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnClear = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.LblCount = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtLongtitude = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtLatitude = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtMacCode = New System.Windows.Forms.TextBox
        Me.CmbCompany = New System.Windows.Forms.ComboBox
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsBarcode = New HPBarcode.DsBarcode
        Me.CmbOrg = New System.Windows.Forms.ComboBox
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
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(7, 208)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 20)
        Me.BtnCancel.TabIndex = 110
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(86, 179)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(72, 20)
        Me.BtnEdit.TabIndex = 109
        Me.BtnEdit.Text = "Edit"
        '
        'BtnUpload
        '
        Me.BtnUpload.Location = New System.Drawing.Point(165, 208)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(72, 20)
        Me.BtnUpload.TabIndex = 108
        Me.BtnUpload.Text = "Upload"
        '
        'BtnLast
        '
        Me.BtnLast.Location = New System.Drawing.Point(197, 236)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(40, 20)
        Me.BtnLast.TabIndex = 104
        Me.BtnLast.Text = ">|"
        '
        'BtnFirst
        '
        Me.BtnFirst.Location = New System.Drawing.Point(62, 236)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(40, 20)
        Me.BtnFirst.TabIndex = 103
        Me.BtnFirst.Text = "|<"
        '
        'TxtPrevious
        '
        Me.TxtPrevious.Location = New System.Drawing.Point(107, 236)
        Me.TxtPrevious.Name = "TxtPrevious"
        Me.TxtPrevious.Size = New System.Drawing.Size(40, 20)
        Me.TxtPrevious.TabIndex = 102
        Me.TxtPrevious.Text = "<"
        '
        'BtnNext
        '
        Me.BtnNext.Location = New System.Drawing.Point(152, 236)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(40, 20)
        Me.BtnNext.TabIndex = 101
        Me.BtnNext.Text = ">"
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(86, 208)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(72, 20)
        Me.BtnClear.TabIndex = 100
        Me.BtnClear.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(7, 179)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 20)
        Me.BtnAdd.TabIndex = 99
        Me.BtnAdd.Text = "Add"
        '
        'LblCount
        '
        Me.LblCount.BackColor = System.Drawing.Color.Silver
        Me.LblCount.Location = New System.Drawing.Point(7, 236)
        Me.LblCount.Name = "LblCount"
        Me.LblCount.Size = New System.Drawing.Size(51, 20)
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(165, 179)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 20)
        Me.BtnSave.TabIndex = 98
        Me.BtnSave.Text = "Save"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 21)
        Me.Label5.Text = "Organization :"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(25, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 21)
        Me.Label4.Text = "Company :"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 21)
        Me.Label3.Text = "Longtitude :"
        '
        'TxtLongtitude
        '
        Me.TxtLongtitude.Location = New System.Drawing.Point(89, 146)
        Me.TxtLongtitude.Name = "TxtLongtitude"
        Me.TxtLongtitude.Size = New System.Drawing.Size(148, 21)
        Me.TxtLongtitude.TabIndex = 96
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 21)
        Me.Label2.Text = "Latitude :"
        '
        'TxtLatitude
        '
        Me.TxtLatitude.Location = New System.Drawing.Point(89, 112)
        Me.TxtLatitude.Name = "TxtLatitude"
        Me.TxtLatitude.Size = New System.Drawing.Size(148, 21)
        Me.TxtLatitude.TabIndex = 95
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 21)
        Me.Label1.Text = "MachineCode :"
        '
        'TxtMacCode
        '
        Me.TxtMacCode.Location = New System.Drawing.Point(89, 13)
        Me.TxtMacCode.Name = "TxtMacCode"
        Me.TxtMacCode.Size = New System.Drawing.Size(148, 21)
        Me.TxtMacCode.TabIndex = 94
        '
        'CmbCompany
        '
        Me.CmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CmbCompany.Location = New System.Drawing.Point(89, 46)
        Me.CmbCompany.Name = "CmbCompany"
        Me.CmbCompany.Size = New System.Drawing.Size(148, 22)
        Me.CmbCompany.TabIndex = 117
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "TbGPS2"
        Me.BindingSource1.DataSource = Me.DsBarcode
        '
        'DsBarcode
        '
        Me.DsBarcode.DataSetName = "DsBarcode"
        Me.DsBarcode.Prefix = ""
        Me.DsBarcode.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CmbOrg
        '
        Me.CmbOrg.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BindingSource1, "ORGANIZATION_CODE", True))
        Me.CmbOrg.Location = New System.Drawing.Point(89, 79)
        Me.CmbOrg.Name = "CmbOrg"
        Me.CmbOrg.Size = New System.Drawing.Size(148, 22)
        Me.CmbOrg.TabIndex = 124
        '
        'GPS2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmbOrg)
        Me.Controls.Add(Me.CmbCompany)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnUpload)
        Me.Controls.Add(Me.BtnLast)
        Me.Controls.Add(Me.BtnFirst)
        Me.Controls.Add(Me.TxtPrevious)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.LblCount)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtLongtitude)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtLatitude)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMacCode)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "GPS2"
        Me.Text = "GPS2"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
    Friend WithEvents BtnLast As System.Windows.Forms.Button
    Friend WithEvents BtnFirst As System.Windows.Forms.Button
    Friend WithEvents TxtPrevious As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents LblCount As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtLongtitude As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtLatitude As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMacCode As System.Windows.Forms.TextBox
    Friend WithEvents CmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DsBarcode As HPBarcode.DsBarcode
    Friend WithEvents CmbOrg As System.Windows.Forms.ComboBox
End Class
