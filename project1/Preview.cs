using System;
using System.Windows.Forms;
using System.Drawing;
using Leadtools.Codecs;
using Leadtools;
using Leadtools.Drawing;

namespace project1
{

    public partial class Preview : Form
    {
        private ListView thumbnailListView;
        private ImageList thumbnailImageList;
        public Preview()
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();

            InitializeComponent();
            // สร้าง ListView
            thumbnailListView = new ListView();
            thumbnailListView.View = View.LargeIcon;
            thumbnailListView.Dock = DockStyle.Fill;
           
            // สร้าง ImageList เพื่อเก็บภาพย่อ
            thumbnailImageList = new ImageList();
            thumbnailImageList.ImageSize = new Size(100, 100); // ขนาดของภาพย่อ
            thumbnailImageList.ColorDepth = ColorDepth.Depth32Bit;

            // กำหนด ImageList ให้กับ ListView
            thumbnailListView.LargeImageList = thumbnailImageList;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File (*.pdf)|*.pdf|Image File (*.png *.jpg *.bmp *.tif)|*.png; *.jpg; *.bmp; *.tif;";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string[] file = ofd.FileNames;
                AddThumbnail(file);
            }
            // เพิ่มภาพย่อลงใน ImageList
           
            //AddThumbnail(@"C:\Users\Administrator\Downloads\in\pdfsegmentation.pdf");
            // เพิ่ม ListView เข้าไปใน Form
            Controls.Add(thumbnailListView);
        }
        int pageCount;
        //string[] file;
        private void AddThumbnail(string[] imagePath)
        {
            RasterCodecs _rasterCodecs = new RasterCodecs();
            //_rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;

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
                    Image thumbnail = destImage1.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                    // เพิ่มภาพย่อลงใน ImageList
                    thumbnailImageList.Images.Add(thumbnail);
                    thumbnailListView.Items.Add("", thumbnailImageList.Images.Count - 1);
                    }
            }
        }

            // เพิ่มไอเท็มใน ListView โดยกำหนด index ของภาพย่อใน ImageList
            
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
           
        }
        
    }
}
