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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        public String selectCombobox2;
        public int state=0;
        
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

            comboBox1.Items.Add("Default");
            comboBox1.Items.Add("ErosionOmniDirectional");
            comboBox1.Items.Add("ErosionHorizontal");
            comboBox1.Items.Add("ErosionVertical");
            comboBox1.Items.Add("ErosionDiagonal");
            comboBox1.Items.Add("DilationOmniDirectional");
            comboBox1.Items.Add("DilationHorizontal");
            comboBox1.Items.Add("DilationVertical");
            comboBox1.Items.Add("DilationDiagonal");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("Default");
            String rfile;
            StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt");
            while ((rfile = streamread.ReadLine()) != null)
            {
               // textBox1.Text += rfile + "\r\n";
                comboBox2.Items.Add(rfile);
               
            }
            comboBox2.SelectedItem = "Default";

            // BinaryFilterConstructorExample_S1();/*test ErosionOmniDirection */
            // BinaryFilterCommandExample(); /* test DilationOmniDirectional */
           
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

           // if (state==1)
           // {
                ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
                //Increase the brightness by 25 percent  of the possible range. 
                command.Brightness = 484;
                command.Contrast = 394;
                command.Intensity = 118;
                command.Run(image);
               // state = 0;
          //  }
           

            //if (state==2) {
                UnsharpMaskCommand command2 = new UnsharpMaskCommand();
                command2.Amount = value_trackBar4;     //rate 0 - เกิน 1000
                command2.Radius = value_trackBar5;     //rate 1 - เกิน 1000
                command2.Threshold = value_trackBar6;  //rate 0 - 255
                command2.ColorType = UnsharpMaskCommandColorType.Rgb;
                command2.Run(image);
               // state = 0;
           // }
            
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

            /* SharpenCommand command4 = new SharpenCommand();
             //Increase the sharpness by 25 percent  of the possible range. 
             command4.Sharpness = 1200;*/

            /* GrayScaleExtendedCommand command3 = new GrayScaleExtendedCommand();
               command3.RedFactor = 500;
               command3.GreenFactor = 250;
               command3.BlueFactor = 250;
               command3.Run(image);*/

            // Prepare the command 
            /*  MinimumCommand command3 = new MinimumCommand();
              //Apply the Minimum filter. 
              command3.Dimension = 3;
              command3.Run(image);*/
            if (state==1)
            {
                AutoColorLevelCommand command4 = new AutoColorLevelCommand();
                // Apply "Auto Leveling" to the image. 
                command4.Run(image);
               
            }
           
            

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
            Display();
        }

        private void trackBar2_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar3_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar4_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar5_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar6_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (folderPath == null) { }
            else
            {
                selectCombobox = comboBox1.SelectedIndex;
                Display();
                //MessageBox.Show(folderPath);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            value_trackBar1 = trackBar1.Value;
            l_brightness.Text = value_trackBar1.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            value_trackBar2 = trackBar2.Value;
            l_contrast.Text = value_trackBar2.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            value_trackBar3 = trackBar3.Value;
            l_intensity.Text = value_trackBar3.ToString();
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

        private void Reset_Click(object sender, EventArgs e)
        {
            value_trackBar1  = 0;
            trackBar1.Value = value_trackBar1;
            l_brightness.Text = value_trackBar1.ToString();

            value_trackBar2 = 0;
            trackBar2.Value = value_trackBar2;
            l_contrast.Text = value_trackBar2.ToString();

            value_trackBar3 = 0;
            trackBar3.Value = value_trackBar3;
            l_intensity.Text = value_trackBar3.ToString();

            value_trackBar4 = 1;
            trackBar4.Value = value_trackBar4;
            l_amount.Text = value_trackBar4.ToString();

            value_trackBar5 = 1;
            trackBar5.Value = value_trackBar5;
            l_radius.Text = value_trackBar5.ToString();

            value_trackBar6 = 1;
            trackBar6.Value = value_trackBar6;
            l_threshold.Text = value_trackBar6.ToString();

            selectCombobox = 0;
            comboBox1.SelectedIndex = selectCombobox;

            value_profilename.Text = "";
            comboBox2.SelectedIndex = 0;
            state = 0;
            Display();
        }

        private void SaveProfile_Click(object sender, EventArgs e)
        {
            /*if (value_profilename.Text == "") { 
                MessageBox.Show("กรุณาตั้งชื่อ Profile!!"); 
            } else {
                StreamWriter streamwri = new StreamWriter(System.Windows.Forms.Application.StartupPath + "test.txt");
                //streamwri.WriteLine(l_profilename.Name + "," + value_profilename.Text);
                streamwri.WriteLine(l_brightness.Name + "," + value_trackBar1.ToString());
                streamwri.WriteLine(l_contrast.Name + "," + value_trackBar2.ToString());
                streamwri.WriteLine(l_intensity.Name + "," + value_trackBar3.ToString());
                streamwri.WriteLine(l_amount.Name + "," + value_trackBar4.ToString());
                streamwri.WriteLine(l_radius.Name + "," + value_trackBar5.ToString());
                streamwri.WriteLine(l_threshold.Name + "," + value_trackBar6.ToString());

                streamwri.WriteLine(l_binaryfilter.Name + "," + selectCombobox.ToString());

                streamwri.Close();
                l_saveprofile.Text = "Save Success...";
            }*/
            
            String listname = @"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt";
            String pfname = value_profilename.Text;
            if (pfname == "") { 
                MessageBox.Show("กรุณาตั้งชื่อ Profile!!"); 
            }else {
                using (StreamWriter streamwri1 = File.AppendText(listname)) {
                    streamwri1.WriteLine(pfname);
                    streamwri1.Close();
                }
                //l_saveprofile.Text = "Save Success...";
               
                using (StreamWriter streamwri2 = new StreamWriter(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\"+pfname+".txt")) {
                    // StreamWriter streamwri2 = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"C:\Users\Administrator\source\repos\project1\project1\bin\profile\C.txt");
                    streamwri2.WriteLine(value_trackBar1.ToString());
                    streamwri2.WriteLine(value_trackBar2.ToString());
                    streamwri2.WriteLine(value_trackBar3.ToString());
                    streamwri2.WriteLine(value_trackBar4.ToString());
                    streamwri2.WriteLine(value_trackBar5.ToString());
                    streamwri2.WriteLine(value_trackBar6.ToString());
                    streamwri2.WriteLine(selectCombobox.ToString());
                    //streamwri2.WriteLine(state.ToString());

                    streamwri2.Close();
                    l_saveprofile.Text = "Save Success...";
                }  
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectCombobox2 = comboBox2.SelectedItem.ToString();
            if (selectCombobox2 == "Default" && folderPath != null)
            {
                value_trackBar1 = 0;
                trackBar1.Value = value_trackBar1;
                l_brightness.Text = value_trackBar1.ToString();

                value_trackBar2 = 0;
                trackBar2.Value = value_trackBar2;
                l_contrast.Text = value_trackBar2.ToString();

                value_trackBar3 = 0;
                trackBar3.Value = value_trackBar3;
                l_intensity.Text = value_trackBar3.ToString();

                value_trackBar4 = 1;
                trackBar4.Value = value_trackBar4;
                l_amount.Text = value_trackBar4.ToString();

                value_trackBar5 = 1;
                trackBar5.Value = value_trackBar5;
                l_radius.Text = value_trackBar5.ToString();

                value_trackBar6 = 1;
                trackBar6.Value = value_trackBar6;
                l_threshold.Text = value_trackBar6.ToString();

                selectCombobox = 0;
                comboBox1.SelectedIndex = selectCombobox;
                Display();
            }
            else {
                String rfile;
                List<String> list = new List<String>();
                if (selectCombobox2 == "Default") { } else {
                    StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\" + selectCombobox2 + ".txt");
                    while ((rfile = streamread.ReadLine()) != null)
                    {
                       // textBox1.Text += rfile + "\r\n";
                        list.Add(rfile);
                    }
                    value_trackBar1 = int.Parse(list[0]);
                    trackBar1.Value = value_trackBar1;
                    l_brightness.Text = value_trackBar1.ToString();

                    value_trackBar2 = int.Parse(list[1]);
                    trackBar2.Value = value_trackBar2;
                    l_contrast.Text = value_trackBar2.ToString();

                    value_trackBar3 = int.Parse(list[2]);
                    trackBar3.Value = value_trackBar3;
                    l_intensity.Text = value_trackBar3.ToString();

                    value_trackBar4 = int.Parse(list[3]);
                    trackBar4.Value = value_trackBar4;
                    l_amount.Text = value_trackBar4.ToString();

                    value_trackBar5 = int.Parse(list[4]);
                    trackBar5.Value = value_trackBar5;
                    l_radius.Text = value_trackBar5.ToString();

                    value_trackBar6 = int.Parse(list[5]);
                    trackBar6.Value = value_trackBar6;
                    l_threshold.Text = value_trackBar6.ToString();

                    selectCombobox = int.Parse(list[6]);
                    comboBox1.SelectedIndex = (selectCombobox + 1);

                    //state = int.Parse(list[7]);
                    Display();
                    l_saveprofile.Text = "usepf Success...";
                }
                list.Clear();
            }
        }

        private void AutoColorLevel_Click(object sender, EventArgs e)
        {
            
            state = 1;
            Display();
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
    }
}
