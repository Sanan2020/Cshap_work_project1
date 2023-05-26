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
        public int selectCombobox;
        
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.jpg, *.png)|*.jpg;*.png";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                folderPath = ofile.FileName;
                //MessageBox.Show(folderPath);
                this.picInput.Image = new Bitmap(ofile.FileName);
                Display();
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
           

            comboBox1.Items.Add("Original");
            comboBox1.Items.Add("ErosionOmniDirectional");
            comboBox1.Items.Add("ErosionHorizontal");
            comboBox1.Items.Add("ErosionVertical");
            comboBox1.Items.Add("ErosionDiagonal");
            comboBox1.Items.Add("DilationOmniDirectional");
            comboBox1.Items.Add("DilationHorizontal");
            comboBox1.Items.Add("DilationVertical");
            comboBox1.Items.Add("DilationDiagonal");

            // BinaryFilterConstructorExample_S1();/*test ErosionOmniDirection */
            // BinaryFilterCommandExample(); /* test DilationOmniDirectional */
            //comboBox1.Select();
            /*comboBox1.SelectedIndex = 0;
            string a  = comboBox1.SelectedIndex.ToString();
            MessageBox.Show(a);
            comboBox1.Text = "Ori";*/
        }

        public void fcUnsharpMask() { 
            
        }
        public void fcConBrightsInten()
        {

        }
        public void Display() {
            using (Image destImage1 = RasterImageConverter.ConvertToImage(ChangeCommand(), ConvertToImageOptions.None))
            {
                picOutput.Image = new Bitmap(destImage1);
            }
        }
        public RasterImage ChangeCommand()
        {
            // Load an image 
            codecs.ThrowExceptionsOnInvalidImages = true;
            RasterImage image = codecs.Load(Path.Combine(folderPath));
            // Prepare the command 
            ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
            //Increase the brightness by 25 percent  of the possible range. 
            command.Brightness = value_trackBar1;
            command.Contrast = value_trackBar2;
            command.Intensity = value_trackBar3;
            command.Run(image);

            UnsharpMaskCommand command2 = new UnsharpMaskCommand();
            command2.Amount = value_trackBar4;     //rate 0 - เกิน 1000
            command2.Radius = value_trackBar5;     //rate 1 - เกิน 1000
            command2.Threshold = value_trackBar6;  //rate 0 - 255
            command2.ColorType = UnsharpMaskCommandColorType.Rgb;
            command2.Run(image);

            // Prepare the command 
            //BinaryFilterCommand command = new BinaryFilterCommand(BinaryFilterCommandPredefined.DilationHorizontal);
            if (selectCombobox == 0){}
            else {
                selectCombobox = selectCombobox - 1;
                //MessageBox.Show(selectCombobox.ToString());
                BinaryFilterCommand command3 = new BinaryFilterCommand((BinaryFilterCommandPredefined)selectCombobox);
                //Dilate black objects. 
                command3.Run(image);
            }
            
            /*SharpenCommand command3 = new SharpenCommand();
            //Increase the sharpness by 25 percent  of the possible range. 
            command3.Sharpness = 950;*/

            // command3.Run(image);
            /*   GrayScaleExtendedCommand command3 = new GrayScaleExtendedCommand();
               command3.RedFactor = 500;
               command3.GreenFactor = 250;
               command3.BlueFactor = 250;
               command3.Run(image);*/

            // Prepare the command 
            /*  MinimumCommand command3 = new MinimumCommand();
              //Apply the Minimum filter. 
              command3.Dimension = 3;
              command3.Run(image);*/

            /* AutoColorLevelCommand command3 = new AutoColorLevelCommand();
             // Apply "Auto Leveling" to the image. 
             command3.Run(image);*/

            /* int[] LowerAverage = new int[3];
             int[] Average = new int[3];
             int[] UpperAverage = new int[3];
             LowerAverage[0] = 100;  //for blue, gray or yuv 
             LowerAverage[1] = 120;  //for green 
             LowerAverage[2] = 80;   //for red 
             Average[0] = 210;       //for blue, gray or yuv 
             Average[1] = 210;       //for green 
             Average[2] = 210;       //for red 
             UpperAverage[0] = 255;  //for blue, gray or yuv 
             UpperAverage[1] = 255;  //for green 
             UpperAverage[2] = 255;  //for red  
             LightControlCommand command4 = new LightControlCommand(LowerAverage, Average, UpperAverage, LightControlCommandType.Yuv);
             // change the lightness of the image. 
             command4.Run(image);*/

            /* HighPassCommand command5 = new HighPassCommand();
             command5.Radius = 20;
             command5.Opacity = 100;
             command5.Run(image);*/

            /*  UnsharpMaskCommand command6 = new UnsharpMaskCommand();
              command6.Amount = 1500;     //rate 0 - เกิน 1000
              command6.Radius = 150;     //rate 1 - เกิน 1000
              command6.Threshold = 40;  //rate 0 - 255
              command6.ColorType = UnsharpMaskCommandColorType.Rgb;
              command6.Run(image);*/

            /*MaximumCommand command5 = new MaximumCommand();
            command5.Dimension = 2;
            command5.Run(image);*/

            /*AutoBinaryCommand command7 = new AutoBinaryCommand();
            //Apply Auto Binary Segment. 
             command7.Run(image);*/

            /* DespeckleCommand command5 = new DespeckleCommand();
             //Remove speckles from the image. 
             command5.Run(image);*/

            /*AdaptiveContrastCommand command7 = new AdaptiveContrastCommand();
            command7.Amount = 200;
            command7.Dimension = 9;
            command7.Run(image);*/

            //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\poc\image", "Result000.jpg"), RasterImageFormat.Jpeg, 24);
            // Prepare the command 

            return image;
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
               codecs.Save(ChangeCommand(), Path.Combine(saveFileDialog1.FileName+".pdf"), RasterImageFormat.RasPdf, 24);
               //    myStream.Close();
               // }
            }
        }

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            value_trackBar1 = trackBar1.Value;
            label3.Text = value_trackBar1.ToString();
            Display();
        }

        private void trackBar2_MouseCaptureChanged(object sender, EventArgs e)
        {
            value_trackBar2 = trackBar2.Value;
            label5.Text = value_trackBar2.ToString();
            Display();
        }

        private void trackBar3_MouseCaptureChanged(object sender, EventArgs e)
        {
            value_trackBar3 = trackBar3.Value;
            label8.Text = value_trackBar3.ToString();
            Display();
        }

        private void trackBar4_MouseCaptureChanged(object sender, EventArgs e)
        {
            value_trackBar4 = trackBar4.Value;
            l_amount.Text = value_trackBar4.ToString();
            Display();
        }

        private void trackBar5_MouseCaptureChanged(object sender, EventArgs e)
        {
            value_trackBar5 = trackBar5.Value;
            l_radius.Text = value_trackBar5.ToString();
            Display();
        }

        private void trackBar6_MouseCaptureChanged(object sender, EventArgs e)
        {
            value_trackBar6 = trackBar6.Value;
            l_threshold.Text = value_trackBar6.ToString();
            Display();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          /*  if (trackBar1.Capture)
            {
                //  MessageBox.Show("000");
               
            }
            else {
                MessageBox.Show("111");
            }*/
            
        }


        /*TEST*/
        static class LEAD_VARS
        {
            public const string ImagesDir = @"C:\Users\Administrator\Downloads\poc\image";
        }
        /*test ErosionOmniDirection */
        public void BinaryFilterConstructorExample_S1()
        {
            // Load an image 
            RasterCodecs codecs = new RasterCodecs();
            codecs.ThrowExceptionsOnInvalidImages = true;

            RasterImage image = codecs.Load(Path.Combine(LEAD_VARS.ImagesDir, "download.png"));

            // Prepare the command 
            int[] nMatrix = new int[9];
            nMatrix[0] = 0;
            nMatrix[1] = 0;
            nMatrix[2] = 0;
            nMatrix[3] = 0;
            nMatrix[4] = 0;
            nMatrix[5] = 0;
            nMatrix[6] = 0;
            nMatrix[7] = 0;
            nMatrix[8] = 0;

            BinaryFilterCommand command = new BinaryFilterCommand();
            command.Matrix = nMatrix;
            command.Maximum = true;
            // Dilate black objects. 
            command.Run(image);
            codecs.Save(image, Path.Combine(LEAD_VARS.ImagesDir, "Result.jpg"), RasterImageFormat.Jpeg, 24);

        }
        
        
        /* test DilationOmniDirectional */
      /*  public void BinaryFilterCommandExample()
        {
            // Load an image 
            RasterCodecs codecs = new RasterCodecs();
            codecs.ThrowExceptionsOnInvalidImages = true;

            RasterImage image = codecs.Load(Path.Combine(LEAD_VARS.ImagesDir, "download.png"));
            
            // Prepare the command 
            //BinaryFilterCommand command = new BinaryFilterCommand(BinaryFilterCommandPredefined.DilationHorizontal);
            BinaryFilterCommand command = new BinaryFilterCommand((BinaryFilterCommandPredefined)selectCombobox);
            //Dilate black objects. 
            command.Run(image);
            codecs.Save(image, Path.Combine(LEAD_VARS.ImagesDir, "DilationDiagonal.jpg"), RasterImageFormat.Jpeg, 24);


           
        }*/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0) {
               // 
                
            }
            selectCombobox = comboBox1.SelectedIndex;
            Display();
            // MessageBox.Show(comboBox1.SelectedItem.ToString());
        }
    }
}
