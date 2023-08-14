<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CameraForm
    Inherits Wisej.Web.Form

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Wisej Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Wisej Designer
    'It can be modified using the Wisej Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Camera = New Wisej.Web.Ext.Camera.Camera()
        Me.ToolBar = New Wisej.Web.ToolBar()
        Me.tbPhoto = New Wisej.Web.ToolBarButton()
        Me.tbVideo = New Wisej.Web.ToolBarButton()
        Me.tbAudio = New Wisej.Web.ToolBarControl()
        Me.tbMaxRecordTime = New Wisej.Web.ToolBarControl()
        Me.sep2 = New Wisej.Web.ToolBarButton()
        Me.tbFacing = New Wisej.Web.ToolBarControl()
        Me.tbResolution = New Wisej.Web.ToolBarControl()
        Me.sep3 = New Wisej.Web.ToolBarButton()
        Me.tbGetFromCamera = New Wisej.Web.ToolBarButton()
        Me.sep1 = New Wisej.Web.ToolBarButton()
        Me.tbClose = New Wisej.Web.ToolBarButton()
        Me.cmbResolution = New Wisej.Web.ComboBox()
        Me.cmbFacing = New Wisej.Web.ComboBox()
        Me.chkAudio = New Wisej.Web.CheckBox()
        Me.StatusBar = New Wisej.Web.StatusBar()
        Me.Timer = New Wisej.Web.Timer(Me.components)
        Me.txt_MaxRecordTime = New Wisej.Web.TextBox()
        Me.SuspendLayout()
        '
        'Camera
        '
        Me.Camera.Anchor = CType((((Wisej.Web.AnchorStyles.Top Or Wisej.Web.AnchorStyles.Bottom) _
            Or Wisej.Web.AnchorStyles.Left) _
            Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.Camera.FacingMode = Wisej.Web.Ext.Camera.Camera.VideoFacingMode.Environment
        Me.Camera.Location = New System.Drawing.Point(3, 60)
        Me.Camera.Name = "Camera"
        Me.Camera.Size = New System.Drawing.Size(309, 367)
        Me.Camera.TabIndex = 0
        Me.Camera.Text = "Camera"
        '
        'ToolBar
        '
        Me.ToolBar.AutoSize = False
        Me.ToolBar.BorderStyle = Wisej.Web.BorderStyle.Solid
        Me.ToolBar.Buttons.AddRange(New Wisej.Web.ToolBarButton() {Me.tbPhoto, Me.tbVideo, Me.tbAudio, Me.tbMaxRecordTime, Me.sep2, Me.tbFacing, Me.tbResolution, Me.sep3, Me.tbGetFromCamera, Me.sep1, Me.tbClose})
        Me.ToolBar.Font = New System.Drawing.Font("default", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.Size = New System.Drawing.Size(699, 57)
        Me.ToolBar.TabIndex = 2
        Me.ToolBar.TabStop = False
        '
        'tbPhoto
        '
        Me.tbPhoto.Name = "tbPhoto"
        Me.tbPhoto.Text = "Photo"
        '
        'tbVideo
        '
        Me.tbVideo.Name = "tbVideo"
        Me.tbVideo.Text = "Video"
        '
        'tbAudio
        '
        Me.tbAudio.Name = "tbAudio"
        '
        'tbMaxRecordTime
        '
        Me.tbMaxRecordTime.Name = "tbMaxRecordTime"
        Me.tbMaxRecordTime.Text = "Max Rec. Time"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        Me.sep2.Style = Wisej.Web.ToolBarButtonStyle.Separator
        '
        'tbFacing
        '
        Me.tbFacing.Name = "tbFacing"
        Me.tbFacing.Text = "Facing"
        '
        'tbResolution
        '
        Me.tbResolution.Name = "tbResolution"
        Me.tbResolution.Text = "Resolution"
        '
        'sep3
        '
        Me.sep3.Name = "sep3"
        Me.sep3.Style = Wisej.Web.ToolBarButtonStyle.Separator
        '
        'tbGetFromCamera
        '
        Me.tbGetFromCamera.Name = "tbGetFromCamera"
        Me.tbGetFromCamera.Text = "Take Photo"
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        Me.sep1.Style = Wisej.Web.ToolBarButtonStyle.Separator
        '
        'tbClose
        '
        Me.tbClose.Name = "tbClose"
        Me.tbClose.SizeMode = Wisej.Web.ToolBarButtonSizeMode.Fill
        Me.tbClose.Text = "Cancel"
        '
        'cmbResolution
        '
        Me.cmbResolution.AutoSize = False
        Me.cmbResolution.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList
        Me.cmbResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbResolution.Items.AddRange(New Object() {"640x480", "800x600", "1024x768", "1280x1024", "1600x1200", "1920x1080", "2048x1536", "2560x1920", "2816x2112", "3264x2468", "4200x2800"})
        Me.cmbResolution.Location = New System.Drawing.Point(599, 92)
        Me.cmbResolution.Name = "cmbResolution"
        Me.cmbResolution.Size = New System.Drawing.Size(97, 30)
        Me.cmbResolution.TabIndex = 3
        '
        'cmbFacing
        '
        Me.cmbFacing.AutoSize = False
        Me.cmbFacing.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList
        Me.cmbFacing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbFacing.Items.AddRange(New Object() {"User", "Environment", "Left", "Right"})
        Me.cmbFacing.Location = New System.Drawing.Point(599, 128)
        Me.cmbFacing.Name = "cmbFacing"
        Me.cmbFacing.Size = New System.Drawing.Size(97, 30)
        Me.cmbFacing.TabIndex = 4
        '
        'chkAudio
        '
        Me.chkAudio.Font = New System.Drawing.Font("default", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.chkAudio.Location = New System.Drawing.Point(601, 66)
        Me.chkAudio.Name = "chkAudio"
        Me.chkAudio.Size = New System.Drawing.Size(59, 20)
        Me.chkAudio.TabIndex = 6
        Me.chkAudio.Text = "Audio"
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 430)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(699, 22)
        Me.StatusBar.TabIndex = 7
        Me.StatusBar.Text = "Camera is in view mode"
        '
        'Timer
        '
        '
        'txt_MaxRecordTime
        '
        Me.txt_MaxRecordTime.InputType.Max = "60"
        Me.txt_MaxRecordTime.InputType.Min = "1"
        Me.txt_MaxRecordTime.InputType.Mode = Wisej.Web.TextBoxMode.Numeric
        Me.txt_MaxRecordTime.InputType.Step = 1.0R
        Me.txt_MaxRecordTime.InputType.Type = Wisej.Web.TextBoxType.Number
        Me.txt_MaxRecordTime.Location = New System.Drawing.Point(503, 209)
        Me.txt_MaxRecordTime.Name = "txt_MaxRecordTime"
        Me.txt_MaxRecordTime.Size = New System.Drawing.Size(60, 30)
        Me.txt_MaxRecordTime.TabIndex = 8
        Me.txt_MaxRecordTime.Text = "5"
        '
        'CameraForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 19.0!)
        Me.AutoScaleMode = Wisej.Web.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 452)
        Me.Controls.Add(Me.txt_MaxRecordTime)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.chkAudio)
        Me.Controls.Add(Me.cmbFacing)
        Me.Controls.Add(Me.cmbResolution)
        Me.Controls.Add(Me.ToolBar)
        Me.Controls.Add(Me.Camera)
        Me.Name = "CameraForm"
        Me.StartPosition = Wisej.Web.FormStartPosition.CenterScreen
        Me.Text = "Camera View"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Camera As Ext.Camera.Camera
    Friend WithEvents ToolBar As ToolBar

    Friend WithEvents tbFacing As ToolBarControl
    Friend WithEvents tbResolution As ToolBarControl
    Friend WithEvents cmbResolution As ComboBox
    Friend WithEvents cmbFacing As ComboBox
    Friend WithEvents tbPhoto As ToolBarButton
    Friend WithEvents tbVideo As ToolBarButton

    Friend WithEvents tbGetFromCamera As ToolBarButton
    Friend WithEvents tbAudio As ToolBarControl
    Friend WithEvents chkAudio As CheckBox
    Friend WithEvents sep2 As ToolBarButton
    Friend WithEvents sep3 As ToolBarButton
    Friend WithEvents StatusBar As StatusBar
    Friend WithEvents Timer As Timer
    Friend WithEvents tbMaxRecordTime As ToolBarControl
    Friend WithEvents txt_MaxRecordTime As TextBox
    Friend WithEvents tbClose As ToolBarButton
    Friend WithEvents sep1 As ToolBarButton
End Class
