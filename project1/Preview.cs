using System;
using System.Windows.Forms;
using System.Drawing;
using Leadtools.Codecs;
using Leadtools;
using Leadtools.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace project1
{

    public partial class Preview : Form
    {
        private ListView thumbnailListView;
        private ImageList thumbnailImageList;
        private Label imageLabel;
        public Preview()
        {
            RasterSupport.SetLicense("C:\\Users\\Administrator\\Downloads\\New folder (2)\\LEADTOOLS.lic", 
                System.IO.File.ReadAllText("C:\\Users\\Administrator\\Downloads\\New folder (2)\\LEADTOOLS.lic.key"));
            bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
            if (isLocked)
                Console.WriteLine("Document support is locked");
            else
            {
                Console.WriteLine("Document support is unlocked");
            }
            InitializeComponent();
        }
        

        /*[STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Preview());
        }*/
        private void Preview_Load(object sender, EventArgs e) {
          
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            // สร้าง ListView
            thumbnailListView = new ListView();
            thumbnailListView.View = View.SmallIcon;
            thumbnailListView.OwnerDraw = true; // เปิดใช้งาน OwnerDraw
            thumbnailListView.DrawItem += ThumbnailListView_DrawItem;
            thumbnailListView.Dock = DockStyle.Fill;
            thumbnailListView.BackColor = Color.Green;
           

            // สร้าง ImageList เพื่อเก็บภาพย่อ
            thumbnailImageList = new ImageList();
            thumbnailImageList.ImageSize = new Size(120, 140); // ขนาดของภาพย่อ
            thumbnailImageList.ColorDepth = ColorDepth.Depth32Bit;
           


            // กำหนด ImageList ให้กับ ListView
            thumbnailListView.SmallImageList = thumbnailImageList;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File (*.pdf)|*.pdf|Image File (*.png *.jpg *.bmp *.tif)|*.png; *.jpg; *.bmp; *.tif;";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string[] file = ofd.FileNames;
                AddThumbnail(file);
            }
            // เพิ่มภาพย่อลงใน ImageList

            //listView1.Items.Add(@"C:\Users\Administrator\Downloads\in\pdfsegmentation.pdf");

            //AddThumbnail(@"C:\Users\Administrator\Downloads\in\pdfsegmentation.pdf");
            // เพิ่ม ListView เข้าไปใน Form
            // Controls.Add(thumbnailListView);
            // เพิ่มเหตุการณ์ MouseClick หรือ MouseDoubleClick สำหรับการคลิกที่รูปภาพ
            thumbnailListView.MouseClick += ThumbnailListView_MouseClick;
            

            splitContainer1.Panel1.Controls.Add(thumbnailListView);
            
        }

        int pageCount; Image thumbnail;
        private async void AddThumbnail(string[] imagePath)
        {
            RasterCodecs _rasterCodecs = new RasterCodecs();
            foreach (string img in imagePath)
            {
                using (var imageInfo = _rasterCodecs.GetInformation(img, true))
                { //นับจำนวนเอกสาร
                    pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                }
                _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
                _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
                _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
                _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
                _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
                for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                {
                    // RasterImage rasterImage = _rasterCodecs.Load(imagePath);
                    var rasterImage = _rasterCodecs.Load(img, pageNumber);
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                    {
                        // สร้างภาพย่อใหม่
                         thumbnail = destImage1.GetThumbnailImage(120, 140, null, IntPtr.Zero);
                        // เพิ่มภาพย่อลงใน ImageList
                        //thumbnailImageList.Images.Add(thumbnail);
                        // เพิ่มไอเท็มใน ListView โดยกำหนด index ของภาพย่อใน ImageList
                        //thumbnailListView.Items.Add("", thumbnailImageList.Images.Count - 1);

                        
                    }
                    await Task.Delay(1000);

                    Process currentProcess = Process.GetCurrentProcess();
                    long usedMemory = currentProcess.PrivateMemorySize64;
                    Console.WriteLine(usedMemory);
                }
            }
        }

        private void ThumbnailListView_MouseClick(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีการคลิกที่รูปภาพ
            ListViewItem clickedItem = thumbnailListView.GetItemAt(e.X, e.Y);
            if (clickedItem != null)
            {
                // ดึงข้อมูลเกี่ยวกับรูปภาพที่ถูกคลิก
                int imageIndex = clickedItem.ImageIndex;
                string imageName = clickedItem.Text;

                // ประมวลผลหรือดำเนินการที่คุณต้องการเมื่อคลิกที่รูปภาพ
                MessageBox.Show("คุณคลิกที่รูปภาพที่ Index: " + imageIndex + ", ชื่อ: " + imageName);
            }
        }

        private void ThumbnailListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // วาดภาพย่อ
           // Image thumbnail = thumbnailImageList.Images[e.Item.ImageIndex];

            Rectangle imageBounds = new Rectangle(e.Bounds.Location, thumbnail.Size);
            e.Graphics.DrawImage(thumbnail, imageBounds);

            // กำหนดตำแหน่งให้ภาพย่ออยู่ตรงกลาง
            int x = e.Bounds.Left + (e.Bounds.Width - thumbnail.Width) / 2;
            int y = e.Bounds.Top + (e.Bounds.Height - thumbnail.Height) / 2;
            Rectangle centeredBounds = new Rectangle(x, y, thumbnail.Width, thumbnail.Height);

            // วาดภาพย่อที่ตรงกลาง
            e.Graphics.DrawImage(thumbnail, centeredBounds);

        }
    }
}
