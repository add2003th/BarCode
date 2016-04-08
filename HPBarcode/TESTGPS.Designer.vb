<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TESTGPS
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
        Me.TxtMacCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtLatitude = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtLongtitude = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtOrgCode = New System.Windows.Forms.TextBox
        Me.BtnSave = New System.Windows.Forms.Button
        Me.LblCount = New System.Windows.Forms.Label
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnClear = New System.Windows.Forms.Button
        Me.BtnLast = New System.Windows.Forms.Button
        Me.BtnFirst = New System.Windows.Forms.Button
        Me.TxtPrevious = New System.Windows.Forms.Button
        Me.BtnNext = New System.Windows.Forms.Button
        Me.TxtCusName = New System.Windows.Forms.TextBox
        Me.TxtCusCode = New System.Windows.Forms.TextBox
        Me.TxtOrgName = New System.Windows.Forms.TextBox
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsBarcode = New HPBarcode.DsBarcode
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
        'TxtMacCode
        '
        Me.TxtMacCode.Location = New System.Drawing.Point(89, 14)
        Me.TxtMacCode.Name = "TxtMacCode"
        Me.TxtMacCode.Size = New System.Drawing.Size(148, 21)
        Me.TxtMacCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 21)
        Me.Label1.Text = "MachineCode :"
        '
        'TxtLatitude
        '
        Me.TxtLatitude.Location = New System.Drawing.Point(89, 113)
        Me.TxtLatitude.Name = "TxtLatitude"
        Me.TxtLatitude.Size = New System.Drawing.Size(148, 21)
        Me.TxtLatitude.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 21)
        Me.Label2.Text = "Latitude :"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 21)
        Me.Label3.Text = "Longtitude :"
        '
        'TxtLongtitude
        '
        Me.TxtLongtitude.Location = New System.Drawing.Point(89, 147)
        Me.TxtLongtitude.Name = "TxtLongtitude"
        Me.TxtLongtitude.Size = New System.Drawing.Size(148, 21)
        Me.TxtLongtitude.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(25, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 21)
        Me.Label4.Text = "Company :"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 21)
        Me.Label5.Text = "Organization :"
        '
        'TxtOrgCode
        '
        Me.TxtOrgCode.Location = New System.Drawing.Point(89, 80)
        Me.TxtOrgCode.Name = "TxtOrgCode"
        Me.TxtOrgCode.Size = New System.Drawing.Size(148, 21)
        Me.TxtOrgCode.TabIndex = 14
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(165, 180)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 20)
        Me.BtnSave.TabIndex = 19
        Me.BtnSave.Text = "Save"
        '
        'LblCount
        '
        Me.LblCount.BackColor = System.Drawing.Color.Silver
        Me.LblCount.Location = New System.Drawing.Point(7, 237)
        Me.LblCount.Name = "LblCount"
        Me.LblCount.Size = New System.Drawing.Size(51, 20)
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(7, 180)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 20)
        Me.BtnAdd.TabIndex = 51
        Me.BtnAdd.Text = "Add"
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(86, 209)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(72, 20)
        Me.BtnClear.TabIndex = 59
        Me.BtnClear.Text = "Delete"
        '
        'BtnLast
        '
        Me.BtnLast.Location = New System.Drawing.Point(197, 237)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(40, 20)
        Me.BtnLast.TabIndex = 63
        Me.BtnLast.Text = ">|"
        '
        'BtnFirst
        '
        Me.BtnFirst.Location = New System.Drawing.Point(62, 237)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(40, 20)
        Me.BtnFirst.TabIndex = 62
        Me.BtnFirst.Text = "|<"
        '
        'TxtPrevious
        '
        Me.TxtPrevious.Location = New System.Drawing.Point(107, 237)
        Me.TxtPrevious.Name = "TxtPrevious"
        Me.TxtPrevious.Size = New System.Drawing.Size(40, 20)
        Me.TxtPrevious.TabIndex = 61
        Me.TxtPrevious.Text = "<"
        '
        'BtnNext
        '
        Me.BtnNext.Location = New System.Drawing.Point(152, 237)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(40, 20)
        Me.BtnNext.TabIndex = 60
        Me.BtnNext.Text = ">"
        '
        'TxtCusName
        '
        Me.TxtCusName.Location = New System.Drawing.Point(89, 47)
        Me.TxtCusName.Name = "TxtCusName"
        Me.TxtCusName.Size = New System.Drawing.Size(148, 21)
        Me.TxtCusName.TabIndex = 70
        '
        'TxtCusCode
        '
        Me.TxtCusCode.Location = New System.Drawing.Point(89, 47)
        Me.TxtCusCode.Name = "TxtCusCode"
        Me.TxtCusCode.Size = New System.Drawing.Size(148, 21)
        Me.TxtCusCode.TabIndex = 71
        '
        'TxtOrgName
        '
        Me.TxtOrgName.Location = New System.Drawing.Point(89, 80)
        Me.TxtOrgName.Name = "TxtOrgName"
        Me.TxtOrgName.Size = New System.Drawing.Size(148, 21)
        Me.TxtOrgName.TabIndex = 72
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "TbGPS"
        Me.BindingSource1.DataSource = Me.DsBarcode
        '
        'DsBarcode
        '
        Me.DsBarcode.DataSetName = "DsBarcode"
        Me.DsBarcode.Prefix = ""
        Me.DsBarcode.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BtnUpload
        '
        Me.BtnUpload.Location = New System.Drawing.Point(165, 209)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(72, 20)
        Me.BtnUpload.TabIndex = 79
        Me.BtnUpload.Text = "Upload"
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(86, 180)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(72, 20)
        Me.BtnEdit.TabIndex = 86
        Me.BtnEdit.Text = "Edit"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(7, 209)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 20)
        Me.BtnCancel.TabIndex = 87
        Me.BtnCancel.Text = "Cancel"
        '
        'TESTGPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnUpload)
        Me.Controls.Add(Me.TxtOrgName)
        Me.Controls.Add(Me.TxtCusName)
        Me.Controls.Add(Me.TxtCusCode)
        Me.Controls.Add(Me.BtnLast)
        Me.Controls.Add(Me.BtnFirst)
        Me.Controls.Add(Me.TxtPrevious)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.LblCount)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtOrgCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtLongtitude)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtLatitude)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMacCode)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "TESTGPS"
        Me.Text = "TESTGPS"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents TxtMacCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtLatitude As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtLongtitude As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtOrgCode As System.Windows.Forms.TextBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DsBarcode As HPBarcode.DsBarcode
    Friend WithEvents LblCount As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents BtnLast As System.Windows.Forms.Button
    Friend WithEvents BtnFirst As System.Windows.Forms.Button
    Friend WithEvents TxtPrevious As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents TxtCusName As System.Windows.Forms.TextBox
    Friend WithEvents TxtCusCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtOrgName As System.Windows.Forms.TextBox
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
