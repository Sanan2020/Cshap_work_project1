using Leadtools;
using Leadtools.Codecs;
using Leadtools.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Form6 : Form
    {
        
        private ListView thumbnailListView;
        private PictureBox pictureBox;
        private Label imageLabel;
        public Form6()
        {
            RasterSupport.SetLicense("C:\\Users\\wollo\\Downloads\\LEADTOOLSEvaluationLicense1\\LEADTOOLS.lic",
                System.IO.File.ReadAllText("C:\\Users\\wollo\\Downloads\\LEADTOOLSEvaluationLicense1\\LEADTOOLS.lic.key"));
            bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
            if (isLocked)
                Console.WriteLine("Document support is locked");
            else
            {
                Console.WriteLine("Document support is unlocked");
            }
            // InitializeComponent();
            // กำหนดขนาด UserControl
            Size = new Size(400, 300);

            // สร้าง ListView
            thumbnailListView = new ListView();
            thumbnailListView.View = View.LargeIcon;
            thumbnailListView.Dock = DockStyle.Left;
            thumbnailListView.Width = 170;
            thumbnailListView.BackColor = Color.Green;//
            thumbnailListView.SelectedIndexChanged += ThumbnailListView_SelectedIndexChanged;

            // สร้าง PictureBox
            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
           // pictureBox.Dock = DockStyle.Fill;
            pictureBox.Width = 120;
            pictureBox.Height = 140;
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.BackColor = Color.Red;

            // สร้าง Label สำหรับแสดงรายละเอียดของภาพ
            imageLabel = new Label();
            imageLabel.AutoSize = true;
            imageLabel.Dock = DockStyle.Bottom;
            imageLabel.Padding = new Padding(5);
            

            // เพิ่มควบคุมลงใน UserControl
            Controls.Add(thumbnailListView);
            Controls.Add(pictureBox);
            Controls.Add(imageLabel);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File (*.pdf)|*.pdf|Image File (*.png *.jpg *.bmp *.tif)|*.png; *.jpg; *.bmp; *.tif;";
            ofd.Multiselect = true;
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                String[] path = ofd.FileNames;
                LoadImages(path);
            }
             
            
        }
        int pageCount;
        public void LoadImages(string[] imagePaths)
        {
            thumbnailListView.Items.Clear();
            thumbnailListView.LargeImageList = new ImageList();
            thumbnailListView.LargeImageList.ImageSize = new Size(100, 100);

            RasterCodecs _rasterCodecs = new RasterCodecs();
            _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
            _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
            _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
            _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
            _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
            foreach (string imagePath in imagePaths)
            {
                using (var imageInfo = _rasterCodecs.GetInformation(imagePath, true))
                { //นับจำนวนเอกสาร
                    pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                }
                for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                {
                    var rasterImage = _rasterCodecs.Load(imagePath, pageNumber);
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                    {
                        // โหลดภาพต้นฉบับ
                       // Image originalImage = Image.FromFile(imagePath);

                        // สร้างภาพย่อ
                        Image thumbnail = destImage1.GetThumbnailImage(100, 100, null, IntPtr.Zero);

                        // เพิ่มภาพย่อลงใน ImageList
                        thumbnailListView.LargeImageList.Images.Add(thumbnail);

                        // เพิ่มไอเท็มใน ListView
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = thumbnailListView.LargeImageList.Images.Count - 1;
                        item.Text = System.IO.Path.GetFileName(imagePath);
                        item.Tag = imagePath;
                        thumbnailListView.Items.Add(item);
                    }
                }

                  

                
            }
        }

        private void ThumbnailListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (thumbnailListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = thumbnailListView.SelectedItems[0];
                string imagePath = selectedItem.Tag.ToString();

                // โหลดภาพต้นฉบับ
                Image originalImage = Image.FromFile(imagePath);

                // แสดงภาพใน PictureBox
                pictureBox.Image = originalImage;

                // แสดงรายละเอียดของภาพ
                imageLabel.Text = "ชื่อไฟล์: " + selectedItem.Text;
            }
            else
            {
                // ไม่มีภาพที่เลือก ล้างภาพใน PictureBox
                pictureBox.Image = null;

                // ล้างรายละเอียดภาพ
                imageLabel.Text = "";
            }
        }

    }

}

