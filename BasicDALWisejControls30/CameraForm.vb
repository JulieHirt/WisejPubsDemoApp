Imports System
Imports Wisej.Web

Public Class CameraForm

    Public CameraImage As System.Drawing.Image
    Public CameraVideo As System.IO.StreamWriter
    Public RealFileName As String
    Public FileName As String
    Public ContentType As String = "image/jpeg"
    Public ContentLenght As Integer = 0
    Public VideoSourceURL As String = ""
    Public AcquiredObjectType As AcquiredObjectTypes = AcquiredObjectTypes.Null
    Public ObjectTypeToAcquire As ObjectTypesToAcquire = ObjectTypesToAcquire.ImageOrVideo
    Public ApplicationTempPath As String = "temp"
    Public MaxRecordTime As Integer = 5
    Private mtbVideoForeColor As System.Drawing.Color
    Private mtbPhotoForeColor As System.Drawing.Color
    Private mCameraRecording As Boolean = False
    Private mTakePhoto As String = "Take Photo"
    Private mStartRecordVideo As String = "Record Video"
    Private mStopRecordVideo As String = "Stop Record Video"
    Private mStartRecordTime As DateTime

    Private IsOk As Boolean = False
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


    Private Async Sub GetImage()
        Me.ContentType = "image/jpeg"

        If FileName = "" Then
            FileName = System.Guid.NewGuid.ToString() + ".jpg"
        Else
            Dim ext As String = System.IO.Path.GetExtension(FileName)
            If ext = "" Then
                FileName = FileName + ".jpg"
            Else
                FileName.Replace(ext, ".jpg")
            End If
        End If


        CameraImage = Await Me.Camera.GetImageAsync()
        Me.RealFileName = Application.MapPath(ApplicationTempPath + "\" + FileName)
        If System.IO.File.Exists(Me.RealFileName) Then
            System.IO.File.Delete(Me.RealFileName)
        End If
        CameraImage.Save(Me.RealFileName)
        Me.ContentLenght = FileLen(Me.RealFileName)
        AcquiredObjectType = AcquiredObjectTypes.Image
        Me.IsOk = True
        Me.Close()


    End Sub

    Private Sub StarRecordingVideo()


        Dim minutes = 0
        Me.mStartRecordTime = Now
        Me.Timer.Enabled = True
        Me.Timer.Start()
        Me.Camera.StartRecording(Me.ContentType,, 1000)



    End Sub
    Private Sub CameraImagePreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Camera.Width = Me.Width

        Me.txt_MaxRecordTime.Text = Me.MaxRecordTime.ToString()
        Me.tbFacing.Control = Me.cmbFacing
        Me.tbResolution.Control = Me.cmbResolution
        Me.tbAudio.Control = Me.chkAudio
        Me.tbMaxRecordTime.Control = Me.txt_MaxRecordTime

        Me.mtbVideoForeColor = Me.tbVideo.ForeColor
        Me.mtbPhotoForeColor = Me.tbPhoto.ForeColor

        Select Case Me.ObjectTypeToAcquire
            Case ObjectTypesToAcquire.Video
                Me.tbVideo.Visible = True
                Me.tbPhoto.Visible = False
                Me.tbVideo.PerformClick()

            Case ObjectTypesToAcquire.Image
                Me.tbVideo.Visible = False
                Me.tbPhoto.Visible = True
                Me.tbPhoto.PerformClick()
            Case ObjectTypesToAcquire.ImageOrVideo
                Me.tbVideo.Visible = True
                Me.tbPhoto.Visible = True
                Me.tbPhoto.PerformClick()
            Case Else
                Me.Close()
        End Select


        Me.Camera.ObjectFit = ObjectFit.Contain


        Dim x As String = Me.Camera.WidthCapture.ToString() + "x" + Me.Camera.HeightCapture.ToString()
        If Me.cmbResolution.Items.Contains(x) = False Then
            Me.cmbResolution.Items.Add(x)
        End If
        Me.cmbResolution.SelectedIndex = Me.cmbResolution.Items.IndexOf(x)
        Me.cmbFacing.SelectedIndex = 1

    End Sub

    Private Sub cmbFacing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFacing.SelectedIndexChanged
        Me.Camera.FacingMode = Me.cmbFacing.SelectedIndex
    End Sub

    Private Sub cmbResolution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbResolution.SelectedIndexChanged
        SetCamera()

    End Sub

    Private Sub SetCameraResolution()
        Dim res() As String
        Dim Item As String = Me.cmbResolution.SelectedItem
        If Item <> "" Then
            res = Split(Item, "x")
            Me.Camera.HeightCapture = res(1)
            Me.Camera.WidthCapture = res(0)
        End If

    End Sub


    Private Sub SetCamera(Optional ByVal audio As Boolean = False)
        Dim res() As String
        Dim Item As String = Me.cmbResolution.SelectedItem

        If Item <> "" Then
            res = Split(Item, "x")
            Me.Camera.HeightCapture = res(1)
            Me.Camera.WidthCapture = res(0)
            Me.Camera.FacingMode = Me.cmbFacing.SelectedIndex
            Me.Camera.Audio = audio
        End If

    End Sub
    Private Sub ManageToolBarControls(ByVal Enabled As Boolean)

        Me.tbAudio.Enabled = Enabled
        Me.tbFacing.Enabled = Enabled
        Me.tbPhoto.Enabled = Enabled
        Me.tbVideo.Enabled = False
        Me.tbResolution.Enabled = False
        Me.tbMaxRecordTime.Enabled = Enabled
        Me.tbClose.Enabled = Enabled


    End Sub

    Private Sub tbGetFromCamera_Click(sender As Object, e As EventArgs) Handles tbGetFromCamera.Click

        Me.ManageGetFromCameraClick()


    End Sub

    Private Sub ManageGetFromCameraClick()

        If Me.tbPhoto.Pushed Then
            GetImage()
        End If
        If Me.tbVideo.Pushed Then
            If Me.mCameraRecording Then
                Me.Timer.Stop()
                Me.Timer.Enabled = False
                Me.Camera.StopRecording()
                Me.mCameraRecording = False
                Me.tbGetFromCamera.Text = mStartRecordVideo
                Me.StatusBar.Text = "Camera is in view mode"
                Me.Camera.Audio = False
                Me.Camera.Visible = False
                'Me.Video.Visible = True

                Me.ManageToolBarControls(True)

            Else
                Me.ManageToolBarControls(False)
                Me.tbGetFromCamera.Text = mStopRecordVideo
                Me.StatusBar.Text = "Camera is recording video."
                Me.mCameraRecording = True
                ' Me.Video.Visible = False
                Me.Camera.FacingMode = Me.cmbFacing.SelectedIndex
                Me.SetCameraResolution()
                Me.Camera.Audio = Me.chkAudio.Checked
                Me.Camera.Visible = True
                StarRecordingVideo()
            End If
        End If
    End Sub

    Private Sub tbPhoto_Click(sender As Object, e As EventArgs) Handles tbPhoto.Click
        ManagePhotoClick()
    End Sub
    Private Sub ManagePhotoClick()
        Me.tbPhoto.Pushed = True
        Me.tbVideo.Pushed = False
        Me.tbPhoto.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.tbVideo.ForeColor = Me.mtbVideoForeColor
        Me.tbGetFromCamera.Text = mTakePhoto
        'Me.Video.Visible = False
        Me.tbAudio.Visible = False
        Me.tbMaxRecordTime.Visible = False
        Me.Camera.FacingMode = Me.cmbFacing.SelectedIndex
        Me.Camera.Audio = False
        Me.SetCameraResolution()
        Me.Camera.Visible = True
        Me.AcquiredObjectType = AcquiredObjectTypes.Image
    End Sub

    Private Sub tbVideo_Click(sender As Object, e As EventArgs) Handles tbVideo.Click
        Me.ManageVideoClick()
    End Sub
    Private Sub ManageVideoClick()
        Me.Camera.FacingMode = Me.cmbFacing.SelectedIndex
        Me.Camera.Audio = Me.chkAudio.Checked
        Me.SetCameraResolution()

        'Me.Video.Visible = False
        Me.Camera.Visible = True
        Me.tbAudio.Visible = True
        Me.tbMaxRecordTime.Visible = True
        Me.tbPhoto.Pushed = False
        Me.tbVideo.Pushed = True
        Me.tbPhoto.ForeColor = Me.mtbPhotoForeColor
        Me.tbVideo.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.tbGetFromCamera.Text = mStartRecordVideo
        Me.AcquiredObjectType = AcquiredObjectTypes.Video
    End Sub

    Private Sub CameraImagePreview_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Me.AcquiredObjectType = AcquiredObjectTypes.Video Then
            Me.Timer.Stop()
            Me.Timer.Enabled = False
            Me.Camera.StopRecording()
        End If
        If Me.RealFileName = "" Then
            Me.AcquiredObjectType = AcquiredObjectTypes.Null
            IsOk = False
        End If

        If IsOk = False Then
            If Me.RealFileName <> "" Then
                If System.IO.File.Exists(Me.RealFileName) Then
                    System.IO.File.Delete(Me.RealFileName)
                End If
                Me.AcquiredObjectType = AcquiredObjectTypes.Null
                Me.RealFileName = ""
                Me.VideoSourceURL = ""
            End If

        End If
        Me.Camera.Dispose()
    End Sub

    Private Sub Camera_Error(sender As Object, e As Ext.Camera.CameraErrorEventArgs) Handles Camera.Error
        MessageBox.Show("Error on Camera" + vbCrLf + e.Message)
    End Sub

    Private Sub Camera_Uploaded(sender As Object, e As UploadedEventArgs) Handles Camera.Uploaded

        Me.RealFileName = ""
        Me.VideoSourceURL = ""
        If FileName = "" Then
            FileName = System.Guid.NewGuid.ToString() + ".webm"
        Else
            Dim ext As String = System.IO.Path.GetExtension(FileName)
            If ext = "" Then
                FileName = FileName + ".webm"
            Else
                FileName.Replace(ext, ".webm")
            End If
        End If

        Dim path As String = Application.MapPath(ApplicationTempPath + "\" + FileName)
        Me.RealFileName = path
        If System.IO.File.Exists(path) Then
            System.IO.File.Delete(path)
        End If

        Using stream = New IO.StreamWriter(path)
            e.Files(0).InputStream.CopyTo(stream.BaseStream)
        End Using
        Me.ContentType = "video/webm"
        Me.ContentLenght = FileLen(path)

        Me.VideoSourceURL = ApplicationTempPath + "\" + FileName
        Me.Camera.Visible = False
        Me.chkAudio.Checked = False
        Me.AcquiredObjectType = AcquiredObjectTypes.Video
        IsOk = True
        Me.Close()

    End Sub

    Private Sub UpdateRecordingTime()
        Dim diff As TimeSpan = Now.Subtract(Me.mStartRecordTime)


        If diff.TotalSeconds > 0 Then
            Me.StatusBar.Text = "Recording Time " + String.Format("{0:D2}:{1:D2}:{2:D2}", diff.Hours, diff.Minutes, diff.Seconds)
        Else
            StatusBar.Text = "00:00:00"
        End If

        If diff.Minutes >= CInt(Me.txt_MaxRecordTime.Text) Then
            Me.ManageGetFromCameraClick()
        End If
    End Sub

    Private Sub chkAudio_CheckedChanged(sender As Object, e As EventArgs) Handles chkAudio.CheckedChanged

        Me.Camera.Audio = Me.chkAudio.Checked

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Me.UpdateRecordingTime()

    End Sub

    Private Sub tbClose_Click(sender As Object, e As EventArgs) Handles tbClose.Click
        IsOk = False
        Me.AcquiredObjectType = AcquiredObjectTypes.Null
        Me.Close()

    End Sub


End Class
