Public Class Camera

    Public Sub New(Optional ByVal CallerForm As Form = Nothing)

        Me.CallerForm = CallerForm

    End Sub

    Public Sub Acquire()

        Dim CameraAcquire As New VideoImageAcquireForm
        CameraAcquire.Source = Me.mSource
        CameraAcquire.ApplicationTempPath = Me.mApplicationTempPath
        CameraAcquire.FileName = Me.mFileName
        CameraAcquire.RealFileName = Me.mRealFileName
        CameraAcquire.ImageFormat = Me.ImageFormat
        CameraAcquire.CallerForm = Me.CallerForm
        CameraAcquire.ShowDialog()

        If CameraAcquire.AcquiredObjectType <> VideoImageAcquireForm.AcquiredObjectTypes.Null Then
            If (CameraAcquire.RealFileName <> Nothing) Then
                Me.mFileName = CameraAcquire.FileName
                Me.mRealFileName = CameraAcquire.RealFileName
                Me.AcquiredObjectType = CameraAcquire.AcquiredObjectType
                Me.mVideoSourceURL = CameraAcquire.VideoSourceURL
                Me.mContentType = CameraAcquire.ContentType
                Me.ContentLenght = CameraAcquire.ContentLenght
            End If
        End If
        CameraAcquire.Dispose()
    End Sub

    Private mVideoSourceURL As String
    Public ReadOnly Property VideoSourceURL() As String
        Get
            Return Me.mVideoSourceURL
        End Get

    End Property

    Public ReadOnly Property Image() As System.Drawing.Image
        Get
            Return Me.SafeImageFromFile(Me.mRealFileName)
        End Get

    End Property


    Private mSource As Sources = Sources.Camera
    Public Property Source() As Sources
        Get
            Return mSource
        End Get
        Set(ByVal value As Sources)
            mSource = value
        End Set
    End Property

    Private mAcquiredObjectType As AcquiredObjectTypes = AcquiredObjectTypes.Image
    Public Property AcquiredObjectType() As AcquiredObjectTypes
        Get
            Return mAcquiredObjectType
        End Get
        Set(ByVal value As AcquiredObjectTypes)
            mAcquiredObjectType = value
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

    Private mApplicationTempPath As String = ""
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


    Private mFileName As String = ""
    Public Property FileName() As String
        Get
            Return mFileName
        End Get
        Set(ByVal value As String)
            mFileName = value
        End Set
    End Property


    Private mRealFileName As String = ""
    Public Property RealFileName() As String
        Get
            Return mRealFileName
        End Get
        Set(ByVal value As String)
            mRealFileName = value
        End Set
    End Property
    Private mContentType As String = ""
    Public Property ContentType() As String
        Get
            Return mContentType
        End Get
        Set(ByVal value As String)
            mContentType = value
        End Set
    End Property

    Private mContentLenght As Integer = 0
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
    Public Enum AcquiredObjectTypes As Integer
        Null = 0
        Image = 1
        Video = 2
    End Enum

    Public Function ImageToByteArray(ByVal Image As System.Drawing.Image) As Byte()
        Return BasicDAL.Utilities.SystemDrawingHelper.imageToByteArray(Image)

    End Function

    Public Function ImageStream(ByVal Image As System.Drawing.Image) As System.IO.Stream
        Dim stream As System.IO.Stream = Nothing
        Image.Save(stream, Me.mImageFormat)
        Return stream
    End Function
    Public Function SafeImageFromFile(ByVal path As String) As System.Drawing.Image

        Dim bytesArr() As Byte = Nothing
        If System.IO.File.Exists(path) = False Then
            Return Nothing
        End If
        bytesArr = System.IO.File.ReadAllBytes(path)

        Dim memstr As New System.IO.MemoryStream(bytesArr)
        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(memstr)
        Return img
    End Function

End Class
