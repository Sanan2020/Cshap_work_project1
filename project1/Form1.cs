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
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;

namespace project1
{
    
    public partial class Form1 : Form
    {
        public String folderPath;
        RasterCodecs codecs = new RasterCodecs();
        public int value_trackBar1;
        public int value_trackBar2;
        public int value_trackBar3;
        public int value_trackBar4 = 1;
        public int value_trackBar5 = 1;
        public int value_trackBar6 = 1;

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

        public void fcUnsharpMask() { 
            
        }
        public void fcConBrightsInten()
        {

        }
        public RasterImage ChangeIntensityCommandExample()
        {
            // Load an image 
            codecs.ThrowExceptionsOnInvalidImages = true;
            RasterImage image = codecs.Load(Path.Combine(folderPath));
            // Prepare the command 
            //ChangeIntensityCommand command = new ChangeIntensityCommand();
            ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
            //Increase the brightness by 25 percent  of the possible range. 
            command.Brightness = 484;
            command.Contrast = 394;
            command.Intensity = 118;
            command.Run(image);

            UnsharpMaskCommand command2 = new UnsharpMaskCommand();
            command2.Amount = 1500;     //rate 0 - เกิน 1000
            command2.Radius = 133;     //rate 1 - เกิน 1000
            command2.Threshold = 33;  //rate 0 - 255
            command2.ColorType = UnsharpMaskCommandColorType.Rgb;
            command2.Run(image);

            /*SharpenCommand command3 = new SharpenCommand();
            //Increase the sharpness by 25 percent  of the possible range. 
            command3.Sharpness = 950;*/

           // command3.Run(image);
            /*GrayScaleExtendedCommand command3 = new GrayScaleExtendedCommand();
            command3.RedFactor = 500;
            command3.GreenFactor = 250;
            command3.BlueFactor = 250;
            command3.Run(image);*/
            /* AutoBinaryCommand command3 = new AutoBinaryCommand();
             //Apply Auto Binary Segment. 
             command3.Run(image);*/


            /*MaximumCommand command4 = new MaximumCommand();
            command4.Dimension = 3;
            command4.Run(image);*/

            // AutoColorLevelCommand command3 = new AutoColorLevelCommand();
            // Apply "Auto Leveling" to the image. 
            //command3.Run(image);

            /*DespeckleCommand command5 = new DespeckleCommand();
            //Remove speckles from the image. 
            command5.Run(image);*/


            /*AdaptiveContrastCommand command3 = new AdaptiveContrastCommand();
            command3.Amount = 200;
            command3.Dimension = 9;
            command3.Run(image);*/

            //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\poc\image", "Result000.jpg"), RasterImageFormat.Jpeg, 24);
            // Prepare the command 
            // BinaryFilterCommand command3 = new BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional);
            //Dilate black objects. 
            // command3.Run(image);

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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            value_trackBar1 = trackBar1.Value;
            label3.Text = value_trackBar1.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            value_trackBar2 = trackBar2.Value;
            label5.Text = value_trackBar2.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            value_trackBar3 = trackBar3.Value;
            label8.Text = value_trackBar3.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            value_trackBar4 = trackBar4.Value;
            l_amount.Text = value_trackBar4.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            value_trackBar5 = trackBar5.Value;
            l_radius.Text = value_trackBar5.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            value_trackBar6 = trackBar6.Value;
            l_threshold.Text = value_trackBar6.ToString();
        }

        /* test DiscreteFourierTransformCommand Class */
        public void DiscreteFourierTransformCommandExample()
        {
            // Load an image 
            RasterCodecs codecs = new RasterCodecs();
            codecs.ThrowExceptionsOnInvalidImages = true;

            RasterImage image2 = codecs.Load(Path.Combine(LEAD_VARS.ImagesDir, "Result000"));

            // Prepare the command 
            FourierTransformInformation FTArray = new FourierTransformInformation(image2);
            LeadRect rcRange = new LeadRect(0, 0, image2.Width - 1, image2.Height - 1);
            DiscreteFourierTransformCommand command = new DiscreteFourierTransformCommand();

            command.FourierTransformInformation = FTArray;
            command.Range = rcRange;
            command.Flags = DiscreteFourierTransformCommandFlags.DiscreteFourierTransform |
               DiscreteFourierTransformCommandFlags.Gray |
               DiscreteFourierTransformCommandFlags.Range |
               DiscreteFourierTransformCommandFlags.InsideX |
               DiscreteFourierTransformCommandFlags.InsideY;
            //Apply DFT. 

            FourierTransformDisplayCommand disCommand = new FourierTransformDisplayCommand();
            disCommand.Flags = FourierTransformDisplayCommandFlags.Log | FourierTransformDisplayCommandFlags.Magnitude;
            disCommand.FourierTransformInformation = command.FourierTransformInformation;
            // plot frequency magnitude 
            disCommand.Run(image2);
            codecs.Save(image2, Path.Combine(@"C:\Users\Administrator\Downloads\poc\image", "Result000.jpg"), RasterImageFormat.Jpeg, 24);
        }

        static class LEAD_VARS
        {
            public const string ImagesDir = @"C:\Users\Administrator\Downloads\poc\image";
        }
    }
}
