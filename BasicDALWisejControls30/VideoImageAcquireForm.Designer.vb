<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VideoImageAcquireForm
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
        Dim ComponentTool1 As Wisej.Web.ComponentTool = New Wisej.Web.ComponentTool()
        Me.PictureBoxFile = New Wisej.Web.PictureBox()
        Me.btn_Upload = New Wisej.Web.Button()
        Me.Upload1 = New Wisej.Web.Upload()
        Me.btn_OK = New Wisej.Web.Button()
        Me.btn_Cancel = New Wisej.Web.Button()
        Me.TabControl = New Wisej.Web.TabControl()
        Me.TabPageFromFile = New Wisej.Web.TabPage()
        Me.VideoFile = New Wisej.Web.Video()
        Me.TabPageFromCamera = New Wisej.Web.TabPage()
        Me.VideoCamera = New Wisej.Web.Video()
        Me.PictureBoxCamera = New Wisej.Web.PictureBox()
        Me.TabPageFromWeb = New Wisej.Web.TabPage()
        Me.PanelFromWeb = New Wisej.Web.Panel()
        Me.VideoWeb = New Wisej.Web.Video()
        Me.PictureBoxWeb = New Wisej.Web.PictureBox()
        Me.txt_SourceURL = New Wisej.Web.TextBox()
        Me.btn_OpenCamera = New Wisej.Web.Button()
        Me.btn_WebDownload = New Wisej.Web.Button()
        CType(Me.PictureBoxFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.TabPageFromFile.SuspendLayout()
        Me.TabPageFromCamera.SuspendLayout()
        CType(Me.PictureBoxCamera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageFromWeb.SuspendLayout()
        Me.PanelFromWeb.SuspendLayout()
        CType(Me.PictureBoxWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxFile
        '
        Me.PictureBoxFile.BorderStyle = Wisej.Web.BorderStyle.Solid
        Me.PictureBoxFile.Location = New System.Drawing.Point(3, 3)
        Me.PictureBoxFile.Name = "PictureBoxFile"
        Me.PictureBoxFile.Size = New System.Drawing.Size(206, 155)
        Me.PictureBoxFile.SizeMode = Wisej.Web.PictureBoxSizeMode.Zoom
        '
        'btn_Upload
        '
        Me.btn_Upload.Anchor = CType((Wisej.Web.AnchorStyles.Bottom Or Wisej.Web.AnchorStyles.Left), Wisej.Web.AnchorStyles)
        Me.btn_Upload.ImageSource = "icon-upload"
        Me.btn_Upload.Location = New System.Drawing.Point(5, 440)
        Me.btn_Upload.Name = "btn_Upload"
        Me.btn_Upload.Size = New System.Drawing.Size(96, 30)
        Me.btn_Upload.TabIndex = 1
        Me.btn_Upload.Text = "Get File"
        '
        'Upload1
        '
        Me.Upload1.Anchor = CType((Wisej.Web.AnchorStyles.Bottom Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.Upload1.HideValue = True
        Me.Upload1.Location = New System.Drawing.Point(408, 439)
        Me.Upload1.Name = "Upload1"
        Me.Upload1.Size = New System.Drawing.Size(47, 30)
        Me.Upload1.TabIndex = 2
        Me.Upload1.Text = "Upload from files"
        Me.Upload1.Visible = False
        '
        'btn_OK
        '
        Me.btn_OK.Anchor = CType((Wisej.Web.AnchorStyles.Bottom Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.btn_OK.Location = New System.Drawing.Point(567, 440)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(100, 30)
        Me.btn_OK.TabIndex = 5
        Me.btn_OK.Text = "OK"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((Wisej.Web.AnchorStyles.Bottom Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.btn_Cancel.DialogResult = Wisej.Web.DialogResult.Cancel
        Me.btn_Cancel.Location = New System.Drawing.Point(461, 440)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(100, 30)
        Me.btn_Cancel.TabIndex = 4
        Me.btn_Cancel.Text = "Cancel"
        '
        'TabControl
        '
        Me.TabControl.Anchor = CType((((Wisej.Web.AnchorStyles.Top Or Wisej.Web.AnchorStyles.Bottom) _
            Or Wisej.Web.AnchorStyles.Left) _
            Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.TabControl.Controls.Add(Me.TabPageFromFile)
        Me.TabControl.Controls.Add(Me.TabPageFromCamera)
        Me.TabControl.Controls.Add(Me.TabPageFromWeb)
        Me.TabControl.Location = New System.Drawing.Point(4, 4)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.PageInsets = New Wisej.Web.Padding(1, 40, 1, 1)
        Me.TabControl.Size = New System.Drawing.Size(668, 431)
        Me.TabControl.TabIndex = 1
        '
        'TabPageFromFile
        '
        Me.TabPageFromFile.Controls.Add(Me.VideoFile)
        Me.TabPageFromFile.Controls.Add(Me.PictureBoxFile)
        Me.TabPageFromFile.ImageSource = "icon-file"
        Me.TabPageFromFile.Location = New System.Drawing.Point(1, 40)
        Me.TabPageFromFile.Name = "TabPageFromFile"
        Me.TabPageFromFile.Size = New System.Drawing.Size(666, 390)
        Me.TabPageFromFile.Text = "From File"
        '
        'VideoFile
        '
        Me.VideoFile.Location = New System.Drawing.Point(224, 3)
        Me.VideoFile.Name = "VideoFile"
        Me.VideoFile.Size = New System.Drawing.Size(214, 155)
        Me.VideoFile.TabIndex = 2
        Me.VideoFile.Volume = 0.5R
        '
        'TabPageFromCamera
        '
        Me.TabPageFromCamera.Controls.Add(Me.VideoCamera)
        Me.TabPageFromCamera.Controls.Add(Me.PictureBoxCamera)
        Me.TabPageFromCamera.ImageSource = "window-icon"
        Me.TabPageFromCamera.Location = New System.Drawing.Point(1, 40)
        Me.TabPageFromCamera.Name = "TabPageFromCamera"
        Me.TabPageFromCamera.Size = New System.Drawing.Size(666, 390)
        Me.TabPageFromCamera.Text = "From Camera"
        '
        'VideoCamera
        '
        Me.VideoCamera.Location = New System.Drawing.Point(337, 118)
        Me.VideoCamera.Name = "VideoCamera"
        Me.VideoCamera.Size = New System.Drawing.Size(214, 155)
        Me.VideoCamera.TabIndex = 4
        Me.VideoCamera.Volume = 0.5R
        '
        'PictureBoxCamera
        '
        Me.PictureBoxCamera.BorderStyle = Wisej.Web.BorderStyle.Solid
        Me.PictureBoxCamera.Location = New System.Drawing.Point(116, 118)
        Me.PictureBoxCamera.Name = "PictureBoxCamera"
        Me.PictureBoxCamera.Size = New System.Drawing.Size(206, 155)
        Me.PictureBoxCamera.SizeMode = Wisej.Web.PictureBoxSizeMode.Zoom
        '
        'TabPageFromWeb
        '
        Me.TabPageFromWeb.Controls.Add(Me.PanelFromWeb)
        Me.TabPageFromWeb.Controls.Add(Me.txt_SourceURL)
        Me.TabPageFromWeb.ImageSource = "icon-calendar"
        Me.TabPageFromWeb.Location = New System.Drawing.Point(1, 40)
        Me.TabPageFromWeb.Name = "TabPageFromWeb"
        Me.TabPageFromWeb.Size = New System.Drawing.Size(666, 390)
        Me.TabPageFromWeb.Text = "From Web"
        '
        'PanelFromWeb
        '
        Me.PanelFromWeb.Controls.Add(Me.VideoWeb)
        Me.PanelFromWeb.Controls.Add(Me.PictureBoxWeb)
        Me.PanelFromWeb.Location = New System.Drawing.Point(4, 54)
        Me.PanelFromWeb.Name = "PanelFromWeb"
        Me.PanelFromWeb.Size = New System.Drawing.Size(658, 333)
        Me.PanelFromWeb.TabIndex = 1
        '
        'VideoWeb
        '
        Me.VideoWeb.Location = New System.Drawing.Point(333, 89)
        Me.VideoWeb.Name = "VideoWeb"
        Me.VideoWeb.Size = New System.Drawing.Size(214, 155)
        Me.VideoWeb.TabIndex = 4
        Me.VideoWeb.Volume = 0.5R
        '
        'PictureBoxWeb
        '
        Me.PictureBoxWeb.BorderStyle = Wisej.Web.BorderStyle.Solid
        Me.PictureBoxWeb.Location = New System.Drawing.Point(112, 89)
        Me.PictureBoxWeb.Name = "PictureBoxWeb"
        Me.PictureBoxWeb.Size = New System.Drawing.Size(206, 155)
        Me.PictureBoxWeb.SizeMode = Wisej.Web.PictureBoxSizeMode.Zoom
        '
        'txt_SourceURL
        '
        Me.txt_SourceURL.Label.Font = New System.Drawing.Font("default", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txt_SourceURL.Label.Padding = New Wisej.Web.Padding(0)
        Me.txt_SourceURL.LabelText = "Source URL"
        Me.txt_SourceURL.Location = New System.Drawing.Point(4, 4)
        Me.txt_SourceURL.Name = "txt_SourceURL"
        Me.txt_SourceURL.Size = New System.Drawing.Size(658, 45)
        Me.txt_SourceURL.TabIndex = 0
        ComponentTool1.ImageSource = "window-close"
        ComponentTool1.Name = "clear"
        Me.txt_SourceURL.Tools.AddRange(New Wisej.Web.ComponentTool() {ComponentTool1})
        Me.txt_SourceURL.Watermark = "Source URL"
        '
        'btn_OpenCamera
        '
        Me.btn_OpenCamera.Anchor = CType((Wisej.Web.AnchorStyles.Bottom Or Wisej.Web.AnchorStyles.Left), Wisej.Web.AnchorStyles)
        Me.btn_OpenCamera.Location = New System.Drawing.Point(107, 440)
        Me.btn_OpenCamera.Name = "btn_OpenCamera"
        Me.btn_OpenCamera.Size = New System.Drawing.Size(96, 30)
        Me.btn_OpenCamera.TabIndex = 2
        Me.btn_OpenCamera.Text = "Open Camera"
        '
        'btn_WebDownload
        '
        Me.btn_WebDownload.Anchor = CType((Wisej.Web.AnchorStyles.Bottom Or Wisej.Web.AnchorStyles.Left), Wisej.Web.AnchorStyles)
        Me.btn_WebDownload.Location = New System.Drawing.Point(209, 440)
        Me.btn_WebDownload.Name = "btn_WebDownload"
        Me.btn_WebDownload.Size = New System.Drawing.Size(96, 30)
        Me.btn_WebDownload.TabIndex = 3
        Me.btn_WebDownload.Text = "Download"
        '
        'VideoImageAcquireForm
        '
        Me.ClientSize = New System.Drawing.Size(675, 477)
        Me.Controls.Add(Me.btn_WebDownload)
        Me.Controls.Add(Me.btn_OpenCamera)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.btn_Upload)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Upload1)
        Me.Controls.Add(Me.btn_OK)
        Me.Name = "VideoImageAcquireForm"
        Me.StartPosition = Wisej.Web.FormStartPosition.CenterParent
        Me.Text = "Image Acquire"
        CType(Me.PictureBoxFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.TabPageFromFile.ResumeLayout(False)
        Me.TabPageFromCamera.ResumeLayout(False)
        CType(Me.PictureBoxCamera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageFromWeb.ResumeLayout(False)
        Me.TabPageFromWeb.PerformLayout()
        Me.PanelFromWeb.ResumeLayout(False)
        CType(Me.PictureBoxWeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBoxFile As PictureBox
    Friend WithEvents btn_Upload As Button
    Friend WithEvents Upload1 As Upload
    Friend WithEvents btn_OK As Button
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPageFromFile As TabPage
    Friend WithEvents TabPageFromCamera As TabPage
    Friend WithEvents btn_OpenCamera As Button
    Friend WithEvents VideoFile As Video
    Friend WithEvents TabPageFromWeb As TabPage
    Friend WithEvents PanelFromWeb As Panel
    Friend WithEvents txt_SourceURL As TextBox
    Friend WithEvents btn_WebDownload As Button
    Friend WithEvents VideoCamera As Video
    Friend WithEvents PictureBoxCamera As PictureBox
    Friend WithEvents VideoWeb As Video
    Friend WithEvents PictureBoxWeb As PictureBox
End Class
