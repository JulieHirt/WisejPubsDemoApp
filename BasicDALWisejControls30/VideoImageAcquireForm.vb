Imports System
Imports Wisej.Web
Imports Wisej.Web.Ext.Camera


Public Class VideoImageAcquireForm

    Private mIsOk As Boolean = False
    Private mFile_AcquiredObjectType As AcquiredObjectTypes = AcquiredObjectTypes.Null
    Private mCamera_AcquiredObjectType As AcquiredObjectTypes = AcquiredObjectTypes.Null
    Private mWeb_AcquiredObjectType As AcquiredObjectTypes = AcquiredObjectTypes.Null
    Private mFile_FileName As String = ""
    Private mFile_RealFileName As String = ""
    Private mCamera_FileName As String = ""
    Private mCamera_RealFileName As String = ""
    Private mWeb_FileName As String = ""
    Private mWeb_RealFileName As String = ""
    Private mCamera_ContentType As String = ""
    Private mFile_ContentType As String = ""
    Private mWeb_ContentType As String = ""
    Private mFile_ContentLenght As Integer = 0
    Private mCamera_ContentLenght As Integer = 0
    Private mWeb_ContentLenght As Integer = 0



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal CallerForm As Form)
        ' This call is required by the designer.
        InitializeComponent()
        Me.CallerForm = CallerForm
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Enum AcquiredObjectTypes As Integer
        Null = 0
        Image = 1
        Video = 2
    End Enum
    Public Enum ObjectTypesToAcquire As Integer
        Image = 1
        Video = 2
        ImageOrVideo = 3
    End Enum


    Private mAcquiredObjectType As AcquiredObjectTypes = AcquiredObjectTypes.Null
    Public Property AcquiredObjectType() As AcquiredObjectTypes
        Get
            Return mAcquiredObjectType
        End Get
        Set(ByVal value As AcquiredObjectTypes)
            mAcquiredObjectType = value
        End Set
    End Property

    Private mObjectTypeToAcquire As ObjectTypesToAcquire = ObjectTypesToAcquire.ImageOrVideo
    Public Property ObjectTypeToAcquire() As ObjectTypesToAcquire
        Get
            Return mObjectTypeToAcquire
        End Get
        Set(ByVal value As ObjectTypesToAcquire)
            mObjectTypeToAcquire = value
        End Set
    End Property


    Private mCallerForm As Form = Nothing

    Public Property CallerForm() As Form
        Get
            Return mCallerForm
        End Get
        Set(ByVal value As Form)
            mCallerForm = value
            If (mCallerForm IsNot Nothing) Then
                mCallerForm.Enabled = False
            End If
        End Set
    End Property

    Private mApplicationTempPath As String
    Public Property ApplicationTempPath() As String
        Get
            Return mApplicationTempPath
        End Get
        Set(ByVal value As String)
            mApplicationTempPath = value
        End Set
    End Property


    Private mImageFormat As Drawing.Imaging.ImageFormat = Drawing.Imaging.ImageFormat.Jpeg
    Public Property ImageFormat() As Drawing.Imaging.ImageFormat
        Get
            Return mImageFormat
        End Get
        Set(ByVal value As Drawing.Imaging.ImageFormat)
            mImageFormat = value
        End Set
    End Property

    Private mAllowedFileType As String = ""
    Public Property AllowedFileType() As String
        Get
            Return Me.mAllowedFileType
        End Get
        Set(ByVal value As String)
            Me.mAllowedFileType = value
            If Me.mAllowedFileType <> "" Then
                Select Case Me.mObjectTypeToAcquire
                    Case ObjectTypesToAcquire.Image
                        Me.Upload1.AllowedFileTypes = "image/*"
                    Case ObjectTypesToAcquire.Video
                        Me.Upload1.AllowedFileTypes = "video/*"
                    Case ObjectTypesToAcquire.ImageOrVideo
                        Me.Upload1.AllowedFileTypes = "image/*,video/*"
                End Select
            End If
        End Set
    End Property


    Private mFileName As String
    Public Property FileName() As String
        Get
            Return mFileName
        End Get
        Set(ByVal value As String)
            mFileName = value
        End Set
    End Property


    Private mRealFileName As String
    Public Property RealFileName() As String
        Get
            Return mRealFileName
        End Get
        Set(ByVal value As String)
            mRealFileName = value
        End Set
    End Property

    Private mVideoSourceURL As String
    Public Property VideoSourceURL() As String
        Get
            Return mVideoSourceURL
        End Get
        Set(ByVal value As String)
            mVideoSourceURL = value
        End Set
    End Property
    Private mContentType As String
    Public Property ContentType() As String
        Get
            Return mContentType
        End Get
        Set(ByVal value As String)
            mContentType = value
        End Set
    End Property

    Private mContentLenght As Integer
    Public Property ContentLenght() As Integer
        Get
            Return mContentLenght
        End Get
        Set(ByVal value As Integer)
            mContentLenght = value
        End Set
    End Property

    Public Enum Sources As Integer
        File = 1
        Camera = 2
        FileAndCamera = 3
        Web = 4
    End Enum

    Public Function ImageToByteArray() As Byte()
        Return BasicDAL.Utilities.SystemDrawingHelper.imageToByteArray(Me.PictureBoxFile.Image)

    End Function

    Public Function ImageStream() As System.IO.Stream
        Dim stream As System.IO.Stream = Nothing
        Me.PictureBoxFile.Image.Save(stream, Me.mImageFormat)
        Return stream
    End Function

    Private mSource As Sources = Sources.Camera + Sources.File

    Public Property Source() As Sources
        Get
            Return mSource
        End Get
        Set(ByVal value As Sources)
            mSource = value
            If mSource And Sources.File Then
                Me.TabPageFromFile.Hidden = False
            Else
                Me.TabPageFromFile.Hidden = True
            End If
            If mSource And Sources.Camera Then
                Me.TabPageFromCamera.Hidden = False
            Else
                Me.TabPageFromCamera.Hidden = True
            End If

        End Set
    End Property

    Private Function DownloadFileFromWeb(ByVal URL As String) As Boolean

        If URL = "" Then
            Return False
        End If

        Me.mWeb_ContentLenght = 0
        Me.mWeb_ContentType = ""
        Me.mWeb_RealFileName = ""
        Me.mWeb_FileName = ""

        ContentLenght = 0
        FileName = ""

        'Dim uriResult As System.Uri = Nothing
        'Dim result = System.Uri.TryCreate(URL, System.UriKind.Absolute, uriResult) AndAlso (uriResult.Scheme = System.Uri.UriSchemeHttp OrElse uriResult.Scheme = System.Uri.UriSchemeHttps)
        Dim request As Net.WebRequest

        Dim response As Net.WebResponse

        Try
            request = Net.WebRequest.Create(URL)
            response = request.GetResponse()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text)
            Return False
        End Try

        'response = TryCast(request.GetResponse(), Net.HttpWebResponse)
        If response IsNot Nothing Then
            If response.ContentLength > 0 Then
                Me.mWeb_ContentType = response.ContentType
                Me.mWeb_ContentLenght = response.ContentLength
                Me.mWeb_FileName = response.ResponseUri.Segments.Last()
                Me.mWeb_RealFileName = Application.MapPath(Me.mApplicationTempPath) + "\" + System.Guid.NewGuid.ToString() + System.IO.Path.GetExtension(Me.mWeb_FileName)
                Try
                    Using client As New Net.WebClient()
                        client.DownloadFile(URL, Me.mWeb_RealFileName)
                    End Using

                    If Me.mWeb_ContentType.StartsWith("image") Then
                        Me.mWeb_AcquiredObjectType = AcquiredObjectTypes.Image
                        Me.PictureBoxWeb.Image = Me.SafeImageFromFile(Me.mWeb_RealFileName)
                        Me.PictureBoxWeb.Visible = True
                    End If

                    If Me.mFile_ContentType.StartsWith("video") Then
                        Me.mWeb_AcquiredObjectType = AcquiredObjectTypes.Video
                        Me.VideoWeb.SourceURL = Me.ApplicationTempPath + "/" + System.IO.Path.GetFileName(Me.mWeb_RealFileName)
                        Me.VideoWeb.Visible = True
                    End If


                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text)
                    Return False
                End Try
            End If
        End If

        Return False


    End Function

    Private Sub ImageAcquire_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If Me.CallerForm IsNot Nothing Then
            Me.CallerForm.Enabled = False
        End If
        Me.btn_OpenCamera.Location = Me.btn_Upload.Location
        Me.btn_OpenCamera.Visible = False
        Me.btn_WebDownload.Location = Me.btn_Upload.Location
        Me.btn_WebDownload.Visible = False


        Me.VideoFile.Visible = False
        Me.VideoFile.Dock = DockStyle.Fill
        Me.PictureBoxFile.Visible = False
        Me.PictureBoxFile.Dock = DockStyle.Fill


        Me.VideoCamera.Visible = False
        Me.VideoCamera.Dock = DockStyle.Fill
        Me.PictureBoxCamera.Visible = False
        Me.PictureBoxCamera.Dock = DockStyle.Fill

        Me.VideoWeb.Visible = False
        Me.VideoWeb.Dock = DockStyle.Fill
        Me.PictureBoxWeb.Visible = False
        Me.PictureBoxWeb.Dock = DockStyle.Fill


        Me.TabControl.SelectedIndex = 0

    End Sub

    Private Sub Upload1_Uploaded(sender As Object, e As UploadedEventArgs) Handles Upload1.Uploaded

        Me.PictureBoxFile.Visible = False
        Me.VideoFile.Visible = False


        Me.mFile_ContentType = e.Files(0).ContentType
        Me.mFile_ContentLenght = e.Files(0).ContentLength
        Me.mFile_FileName = e.Files(0).FileName
        Me.mFile_RealFileName = Application.MapPath(Me.mApplicationTempPath) + "\" + System.Guid.NewGuid.ToString() + System.IO.Path.GetExtension(Me.mFile_FileName)

        e.Files(0).SaveAs(Me.mFile_RealFileName)

        If Me.mFile_ContentType.StartsWith("image") Then
            Me.mFile_AcquiredObjectType = AcquiredObjectTypes.Image
            Me.PictureBoxFile.Image = System.Drawing.Image.FromStream(e.Files(0).InputStream)
            Me.PictureBoxFile.Dock = DockStyle.Fill
            Me.PictureBoxFile.Visible = True
        End If

        If Me.mFile_ContentType.StartsWith("video") Then
            Me.mFile_AcquiredObjectType = AcquiredObjectTypes.Video
            Me.VideoFile.SourceURL = Me.ApplicationTempPath + "/" + System.IO.Path.GetFileName(Me.mFile_RealFileName)
            Me.VideoFile.Visible = True

        End If


    End Sub

    Private Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        If Me.AllowedFileType = "" Then
            Select Case Me.mObjectTypeToAcquire
                Case ObjectTypesToAcquire.Image
                    Me.Upload1.AllowedFileTypes = "image/*"
                Case ObjectTypesToAcquire.Video
                    Me.Upload1.AllowedFileTypes = "video/*"
                Case ObjectTypesToAcquire.ImageOrVideo
                    Me.Upload1.AllowedFileTypes = "image/*,video/*"
            End Select
        End If

        Me.Upload1.AllowMultipleFiles = False
        Me.Upload1.UploadFiles()
    End Sub

    Private Sub ImageAcquire_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Me.VideoFile.Dispose()
        Me.PictureBoxFile.Image = Nothing

        If Me.CallerForm IsNot Nothing Then
            Me.CallerForm.Enabled = True
            Me.CallerForm.Focus()
        End If

        Me.Dispose()

    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        Select Case Me.TabControl.SelectedTab.Name

            Case Me.TabPageFromFile.Name
                Me.mAcquiredObjectType = Me.mFile_AcquiredObjectType
                Me.mFileName = Me.mFile_FileName
                Me.mRealFileName = Me.mFile_RealFileName
                Me.mContentType = Me.mFile_ContentType
                Me.mContentLenght = Me.mFile_ContentLenght
                Me.mVideoSourceURL = Me.VideoFile.SourceURL
            Case Me.TabPageFromCamera.Name
                Me.mAcquiredObjectType = Me.mCamera_AcquiredObjectType
                Me.mFileName = Me.mCamera_FileName
                Me.mRealFileName = Me.mCamera_RealFileName
                Me.mContentType = Me.mCamera_ContentType
                Me.mContentLenght = Me.mCamera_ContentLenght
                Me.mVideoSourceURL = Me.VideoCamera.SourceURL
            Case Me.TabPageFromWeb.Name
                Me.mAcquiredObjectType = Me.mWeb_AcquiredObjectType
                Me.mFileName = Me.mWeb_FileName
                Me.mRealFileName = Me.mWeb_RealFileName
                Me.mContentType = Me.mWeb_ContentType
                Me.mContentLenght = Me.mWeb_ContentLenght
                Me.mVideoSourceURL = Me.VideoWeb.SourceURL

            Case Else
        End Select

        Select Case Me.mAcquiredObjectType
            Case AcquiredObjectTypes.Video
                mIsOk = True
            Case AcquiredObjectTypes.Image
                mIsOk = True
            Case Else
                mIsOk = False
        End Select

        Me.Close()

    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click

        mIsOk = False
        Me.Close()

    End Sub



    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged


        Select Case Me.TabControl.SelectedTab.Name
            Case Me.TabPageFromFile.Name
                Me.btn_OpenCamera.Visible = False
                Me.btn_Upload.Visible = True
                Me.btn_WebDownload.Visible = False


            Case Me.TabPageFromCamera.Name
                Me.btn_OpenCamera.Visible = True
                Me.btn_Upload.Visible = False
                Me.btn_WebDownload.Visible = False

            Case Me.TabPageFromWeb.Name
                Me.btn_OpenCamera.Visible = False
                Me.btn_Upload.Visible = False
                Me.btn_WebDownload.Visible = True
            Case Else

        End Select

    End Sub
    Private Sub ciao()

    End Sub
    Private Sub btn_OpenCamera_Click(sender As Object, e As EventArgs) Handles btn_OpenCamera.Click
        Dim CameraForm As New CameraForm

        If Me.mFileName = "" Then
            Me.mFileName = System.Guid.NewGuid().ToString()
        End If

        CameraForm.MaxRecordTime = 5
        CameraForm.FileName = Me.mFileName
        CameraForm.RealFileName = "" ' Me.mRealFileName
        CameraForm.ObjectTypeToAcquire = Me.mObjectTypeToAcquire


        CameraForm.ShowDialog()

        Me.PictureBoxCamera.Visible = False

        If CameraForm.AcquiredObjectType <> AcquiredObjectTypes.Null Then

            Me.mCamera_FileName = CameraForm.FileName
            Me.mCamera_RealFileName = CameraForm.RealFileName
            Me.mCamera_ContentType = CameraForm.ContentType
            Me.mCamera_ContentLenght = CameraForm.ContentLenght

            Select Case CameraForm.AcquiredObjectType
                Case CameraForm.AcquiredObjectTypes.Video
                    Me.PictureBoxCamera.Visible = False
                    Me.PictureBoxCamera.Image = Nothing
                    Me.mCamera_AcquiredObjectType = AcquiredObjectTypes.Video
                    Me.VideoCamera.SourceURL = CameraForm.VideoSourceURL
                    Me.VideoCamera.Visible = True
                Case CameraForm.AcquiredObjectTypes.Image
                    Me.VideoCamera.Visible = False
                    Me.VideoCamera.SourceURL = ""
                    Me.mCamera_AcquiredObjectType = AcquiredObjectTypes.Image
                    Me.PictureBoxCamera.Image = Me.SafeImageFromFile(CameraForm.RealFileName)
                    Me.PictureBoxCamera.SizeMode = PictureBoxSizeMode.Zoom
                    Me.PictureBoxCamera.Visible = True
                Case Else

            End Select

        Else
            Me.VideoCamera.Visible = False
            Me.mCamera_AcquiredObjectType = AcquiredObjectTypes.Null
            Me.PictureBoxCamera.Image = Nothing
            Me.PictureBoxCamera.Visible = False
            Me.VideoCamera.SourceURL = ""
            Me.mCamera_FileName = ""
            Me.mCamera_ContentLenght = 0
            Me.mCamera_ContentType = ""
            Me.mCamera_RealFileName = ""
        End If

        CameraForm.Dispose()

    End Sub

    Private Function SafeImageFromFile(ByVal path As String) As System.Drawing.Image

        Dim bytesArr() As Byte = Nothing
        If System.IO.File.Exists(path) = False Then
            Return Nothing
        End If
        bytesArr = System.IO.File.ReadAllBytes(path)

        Dim memstr As New System.IO.MemoryStream(bytesArr)
        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(memstr)
        Return img
    End Function

    Private Sub CameraAcquire_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If mIsOk = False Then
            If Me.mRealFileName <> "" Then
                If System.IO.File.Exists(Me.mRealFileName) Then
                    System.IO.File.Delete(Me.mRealFileName)
                End If
                Me.mRealFileName = ""
            End If

        End If
    End Sub

    Private Sub TextBox1_ToolClick(sender As Object, e As ToolClickEventArgs) Handles txt_SourceURL.ToolClick
        Me.txt_SourceURL.Text = ""
        Me.PictureBoxWeb.Image = Nothing
        Me.mWeb_RealFileName = ""
        Me.mWeb_FileName = ""
        Me.mWeb_ContentType = ""
        Me.mWeb_ContentLenght = 0
        Me.mWeb_AcquiredObjectType = AcquiredObjectTypes.Null
        Me.VideoWeb.SourceURL = ""

    End Sub

    Private Sub btn_WebDownload_Click(sender As Object, e As EventArgs) Handles btn_WebDownload.Click

        Me.DownloadFileFromWeb(Me.txt_SourceURL.Text)


    End Sub
End Class
