using System;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Wisej.Web;

namespace BasicDALWisejControls
{
    public partial class CameraForm
    {
        public System.Drawing.Image CameraImage;
        public System.IO.StreamWriter CameraVideo;
        public string RealFileName;
        public string FileName;
        public string ContentType = "image/jpeg";
        public int ContentLenght = 0;
        public string VideoSourceURL = "";
        public AcquiredObjectTypes AcquiredObjectType = AcquiredObjectTypes.Null;
        public ObjectTypesToAcquire ObjectTypeToAcquire = ObjectTypesToAcquire.ImageOrVideo;
        public string ApplicationTempPath = "temp";
        public int MaxRecordTime = 5;
        private System.Drawing.Color mtbVideoForeColor;
        private System.Drawing.Color mtbPhotoForeColor;
        private bool mCameraRecording = false;
        private string mTakePhoto = "Take Photo";
        private string mStartRecordVideo = "Record Video";
        private string mStopRecordVideo = "Stop Record Video";
        private DateTime mStartRecordTime;
        private bool IsOk = false;

        public enum AcquiredObjectTypes : int
        {
            Null = 0,
            Image = 1,
            Video = 2
        }

        public enum ObjectTypesToAcquire : int
        {
            Image = 1,
            Video = 2,
            ImageOrVideo = 3
        }

        public CameraForm()
        {
            InitializeComponent();
        }

        private async void GetImage()
        {
            ContentType = "image/jpeg";
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = Guid.NewGuid().ToString() + ".jpg";
            }
            else
            {
                string ext = System.IO.Path.GetExtension(FileName);
                if (string.IsNullOrEmpty(ext))
                {
                    FileName = FileName + ".jpg";
                }
                else
                {
                    FileName.Replace(ext, ".jpg");
                }
            }

            CameraImage = await this.Camera.GetImageAsync();
            RealFileName = Application.MapPath(ApplicationTempPath + @"\" + FileName);
            if (System.IO.File.Exists(RealFileName))
            {
                System.IO.File.Delete(RealFileName);
            }

            CameraImage.Save(RealFileName);
            ContentLenght = (int)FileSystem.FileLen(RealFileName);
            AcquiredObjectType = AcquiredObjectTypes.Image;
            IsOk = true;
            this.Close();
        }

        private void StarRecordingVideo()
        {
            int minutes = 0;
            mStartRecordTime = DateTime.Now;
            this.Timer.Enabled = true;
            this.Timer.Start();
            this.Camera.StartRecording(ContentType, updateInterval: 1000);
        }

        private void CameraImagePreview_Load(object sender, EventArgs e)
        {
            this.Camera.Width = this.Width;
            this.txt_MaxRecordTime.Text = MaxRecordTime.ToString();
            this.tbFacing.Control = this.cmbFacing;
            this.tbResolution.Control = this.cmbResolution;
            this.tbAudio.Control = this.chkAudio;
            this.tbMaxRecordTime.Control = this.txt_MaxRecordTime;
            mtbVideoForeColor = this.tbVideo.ForeColor;
            mtbPhotoForeColor = this.tbPhoto.ForeColor;
            switch (ObjectTypeToAcquire)
            {
                case ObjectTypesToAcquire.Video:
                    {
                        this.tbVideo.Visible = true;
                        this.tbPhoto.Visible = false;
                        this.tbVideo.PerformClick();
                        break;
                    }

                case ObjectTypesToAcquire.Image:
                    {
                        this.tbVideo.Visible = false;
                        this.tbPhoto.Visible = true;
                        this.tbPhoto.PerformClick();
                        break;
                    }

                case ObjectTypesToAcquire.ImageOrVideo:
                    {
                        this.tbVideo.Visible = true;
                        this.tbPhoto.Visible = true;
                        this.tbPhoto.PerformClick();
                        break;
                    }

                default:
                    {
                        this.Close();
                        break;
                    }
            }

            this.Camera.ObjectFit = ObjectFit.Contain;
            string x = this.Camera.WidthCapture.ToString() + "x" + this.Camera.HeightCapture.ToString();
            if (this.cmbResolution.Items.Contains(x) == false)
            {
                this.cmbResolution.Items.Add(x);
            }

            this.cmbResolution.SelectedIndex = this.cmbResolution.Items.IndexOf(x);
            this.cmbFacing.SelectedIndex = 1;
        }

        private void cmbFacing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Camera.FacingMode = (Wisej.Web.Ext.Camera.Camera.VideoFacingMode)this.cmbFacing.SelectedIndex;
        }

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCamera();
        }

        private void SetCameraResolution()
        {
            string[] res;
            string Item = Conversions.ToString(this.cmbResolution.SelectedItem);
            if (!string.IsNullOrEmpty(Item))
            {
                res = Strings.Split(Item, "x");
                this.Camera.HeightCapture = Conversions.ToInteger(res[1]);
                this.Camera.WidthCapture = Conversions.ToInteger(res[0]);
            }
        }

        private void SetCamera(bool audio = false)
        {
            string[] res;
            string Item = Conversions.ToString(this.cmbResolution.SelectedItem);
            if (!string.IsNullOrEmpty(Item))
            {
                res = Strings.Split(Item, "x");
                this.Camera.HeightCapture = Conversions.ToInteger(res[1]);
                this.Camera.WidthCapture = Conversions.ToInteger(res[0]);
                this.Camera.FacingMode = (Wisej.Web.Ext.Camera.Camera.VideoFacingMode)this.cmbFacing.SelectedIndex;
                this.Camera.Audio = audio;
            }
        }

        private void ManageToolBarControls(bool Enabled)
        {
            this.tbAudio.Enabled = Enabled;
            this.tbFacing.Enabled = Enabled;
            this.tbPhoto.Enabled = Enabled;
            this.tbVideo.Enabled = false;
            this.tbResolution.Enabled = false;
            this.tbMaxRecordTime.Enabled = Enabled;
            this.tbClose.Enabled = Enabled;
        }

        private void tbGetFromCamera_Click(object sender, EventArgs e)
        {
            ManageGetFromCameraClick();
        }

        private void ManageGetFromCameraClick()
        {
            if (this.tbPhoto.Pushed)
            {
                GetImage();
            }

            if (this.tbVideo.Pushed)
            {
                if (mCameraRecording)
                {
                    this.Timer.Stop();
                    this.Timer.Enabled = false;
                    this.Camera.StopRecording();
                    mCameraRecording = false;
                    this.tbGetFromCamera.Text = mStartRecordVideo;
                    this.StatusBar.Text = "Camera is in view mode";
                    this.Camera.Audio = false;
                    this.Camera.Visible = false;
                    // Me.Video.Visible = True

                    ManageToolBarControls(true);
                }
                else
                {
                    ManageToolBarControls(false);
                    this.tbGetFromCamera.Text = mStopRecordVideo;
                    this.StatusBar.Text = "Camera is recording video.";
                    mCameraRecording = true;
                    // Me.Video.Visible = False
                    this.Camera.FacingMode = (Wisej.Web.Ext.Camera.Camera.VideoFacingMode)this.cmbFacing.SelectedIndex;
                    SetCameraResolution();
                    this.Camera.Audio = this.chkAudio.Checked;
                    this.Camera.Visible = true;
                    StarRecordingVideo();
                }
            }
        }

        private void tbPhoto_Click(object sender, EventArgs e)
        {
            ManagePhotoClick();
        }

        private void ManagePhotoClick()
        {
            this.tbPhoto.Pushed = true;
            this.tbVideo.Pushed = false;
            this.tbPhoto.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbVideo.ForeColor = mtbVideoForeColor;
            this.tbGetFromCamera.Text = mTakePhoto;
            // Me.Video.Visible = False
            this.tbAudio.Visible = false;
            this.tbMaxRecordTime.Visible = false;
            this.Camera.FacingMode = (Wisej.Web.Ext.Camera.Camera.VideoFacingMode)this.cmbFacing.SelectedIndex;
            this.Camera.Audio = false;
            SetCameraResolution();
            this.Camera.Visible = true;
            AcquiredObjectType = AcquiredObjectTypes.Image;
        }

        private void tbVideo_Click(object sender, EventArgs e)
        {
            ManageVideoClick();
        }

        private void ManageVideoClick()
        {
            this.Camera.FacingMode = (Wisej.Web.Ext.Camera.Camera.VideoFacingMode)this.cmbFacing.SelectedIndex;
            this.Camera.Audio = this.chkAudio.Checked;
            SetCameraResolution();

            // Me.Video.Visible = False
            this.Camera.Visible = true;
            this.tbAudio.Visible = true;
            this.tbMaxRecordTime.Visible = true;
            this.tbPhoto.Pushed = false;
            this.tbVideo.Pushed = true;
            this.tbPhoto.ForeColor = mtbPhotoForeColor;
            this.tbVideo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbGetFromCamera.Text = mStartRecordVideo;
            AcquiredObjectType = AcquiredObjectTypes.Video;
        }

        private void CameraImagePreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AcquiredObjectType == AcquiredObjectTypes.Video)
            {
                this.Timer.Stop();
                this.Timer.Enabled = false;
                this.Camera.StopRecording();
            }

            if (string.IsNullOrEmpty(RealFileName))
            {
                AcquiredObjectType = AcquiredObjectTypes.Null;
                IsOk = false;
            }

            if (IsOk == false)
            {
                if (!string.IsNullOrEmpty(RealFileName))
                {
                    if (System.IO.File.Exists(RealFileName))
                    {
                        System.IO.File.Delete(RealFileName);
                    }

                    AcquiredObjectType = AcquiredObjectTypes.Null;
                    RealFileName = "";
                    VideoSourceURL = "";
                }
            }

            this.Camera.Dispose();
        }

        private void Camera_Error(object sender, Wisej.Web.Ext.Camera.CameraErrorEventArgs e)
        {
            MessageBox.Show("Error on Camera" + Constants.vbCrLf + e.Message);
        }

        private void Camera_Uploaded(object sender, UploadedEventArgs e)
        {
            RealFileName = "";
            VideoSourceURL = "";
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = Guid.NewGuid().ToString() + ".webm";
            }
            else
            {
                string ext = System.IO.Path.GetExtension(FileName);
                if (string.IsNullOrEmpty(ext))
                {
                    FileName = FileName + ".webm";
                }
                else
                {
                    FileName.Replace(ext, ".webm");
                }
            }

            string path = Application.MapPath(ApplicationTempPath + @"\" + FileName);
            RealFileName = path;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            using (var stream = new System.IO.StreamWriter(path))
            {
                e.Files[0].InputStream.CopyTo(stream.BaseStream);
            }

            ContentType = "video/webm";
            ContentLenght = (int)FileSystem.FileLen(path);
            VideoSourceURL = ApplicationTempPath + @"\" + FileName;
            this.Camera.Visible = false;
            this.chkAudio.Checked = false;
            AcquiredObjectType = AcquiredObjectTypes.Video;
            IsOk = true;
            this.Close();
        }

        private void UpdateRecordingTime()
        {
            var diff = DateTime.Now.Subtract(mStartRecordTime);
            if (diff.TotalSeconds > 0d)
            {
                this.StatusBar.Text = "Recording Time " + string.Format("{0:D2}:{1:D2}:{2:D2}", diff.Hours, diff.Minutes, diff.Seconds);
            }
            else
            {
                this.StatusBar.Text = "00:00:00";
            }

            if (diff.Minutes >= Conversions.ToInteger(this.txt_MaxRecordTime.Text))
            {
                ManageGetFromCameraClick();
            }
        }

        private void chkAudio_CheckedChanged(object sender, EventArgs e)
        {
            this.Camera.Audio = this.chkAudio.Checked;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateRecordingTime();
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            IsOk = false;
            AcquiredObjectType = AcquiredObjectTypes.Null;
            this.Close();
        }
    }
}