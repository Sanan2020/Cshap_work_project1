using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.ImageProcessing.Color;
//using Leadtools.Controls;
using Leadtools.Drawing;
using System.Runtime.Serialization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
using Leadtools.ImageProcessing;
using Image = System.Drawing.Image;

namespace project1
{
    
    public partial class Form1 : Form
    {
        public String folderPath;
        RasterCodecs codecs = new RasterCodecs();

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.jpg)|*.jpg;";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                folderPath = ofile.FileName;
                //MessageBox.Show(folderPath);
                this.picInput.Image = new Bitmap(ofile.FileName);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RasterSupport.SetLicense(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC",
                File.ReadAllText(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC.KEY"));

            this.picInput.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picInput.BorderStyle = BorderStyle.FixedSingle;
            this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picOutput.BorderStyle = BorderStyle.FixedSingle;
      }


        public RasterImage ChangeIntensityCommandExample()
        {
            // Load an image 
            codecs.ThrowExceptionsOnInvalidImages = true;
            RasterImage image = codecs.Load(Path.Combine(folderPath));
            // Prepare the command 
            ChangeIntensityCommand command = new ChangeIntensityCommand();
            //Increase the brightness by 25 percent  of the possible range. 
            command.Brightness = 400;
            command.Run(image);
            
            return image;
        }

       /* static class LEAD_VARS2
        {
            public const string ImagesDir = @"C:\Users\Administrator\Downloads\poc\image";
        }*/

        private void Result_Click(object sender, EventArgs e)
        {
           // ChangeIntensityCommandExample();
            using (Image destImage1 = RasterImageConverter.ConvertToImage(ChangeIntensityCommandExample(), ConvertToImageOptions.None))
            {
                picOutput.Image = new Bitmap(destImage1);
            }
        }
       
        private void BrowseSave_Click(object sender, EventArgs e)
        {  
           // Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "pdf (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               // if ((myStream = saveFileDialog1.OpenFile()) != null)
               // {
                    // Code to write the stream goes here.
                String savePath = saveFileDialog1.FileName;
                //MessageBox.Show(saveFileDialog1.);
                codecs.Save(ChangeIntensityCommandExample(), Path.Combine(saveFileDialog1.FileName+".pdf"), RasterImageFormat.RasPdf, 24);
                //    myStream.Close();
               // }
            }
        }

       
    }
}
