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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

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
        public int value_trackBar7 = 500;
        public int value_trackBar8 = 250;
        public int value_trackBar9 = 250;
        public int selectCombobox;
        public String selectCombobox2;
        public bool chckbox = false;
        public bool chckbox2 = false;
        public bool chckbox3 = false;
        public bool chckbox4 = false;
        public bool chckbox5 = false;
        public bool chckbox6 = false;
        public bool chckbox7 = false;
        public bool chckbox8 = false;
        public bool chckbox9 = false;
        public int value_trbDynBin1 = 8;
        public int value_trbDynBin2 = 16;
        /*public RasterImage Image {
            get {; } 
            private set; 
        }*/
        public class Person
        {
            private RasterImage name;  // field
            public RasterImage Name   // property
            {
                get { return name; }
                set { name = value; }
            }
        }

        //public RasterImage image;
         Person myObj = new Person();
        public Form1()
        {
            InitializeComponent();

        }
       
        private void Browse_Click(object sender, EventArgs e)
        {
            codecs.ThrowExceptionsOnInvalidImages = true;
            
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.tif,*.pdf,*.jpg, *.png)|*.tif;*.pdf;*.jpg;*.png";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                folderPath = ofile.FileName;
                RasterImage image1 = codecs.Load(Path.Combine(folderPath));
                //this.picInput.Image = new Bitmap(ofile.FileName);
                using (Image destImage1 = RasterImageConverter.ConvertToImage(image1, ConvertToImageOptions.None))
                {
                    picInput.Image = new Bitmap(destImage1);
                    //MessageBox.Show(destImage1.ToString());
                }
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


            //groupBox3.Enabled = false;
            trackBar7.Value = value_trackBar7;
            l_redfactor.Text = value_trackBar7.ToString();
            trackBar8.Value = value_trackBar8;
            l_greenfactor.Text = value_trackBar8.ToString();
            trackBar9.Value = value_trackBar9;
            l_bluefactor.Text = value_trackBar9.ToString();
        }

       /* public void fcConBrightsInten()
        {
            ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
            //Increase the brightness by 25 percent  of the possible range. 
            command.Brightness = 484;   //484
            command.Contrast = 394;     //394
            command.Intensity = 118;    //118
            command.Run(myObj.Name);
        }
        public void fcUnsharpMask()
        {
            UnsharpMaskCommand command2 = new UnsharpMaskCommand();
            command2.Amount = 1500;     //rate 0 - เกิน 1000
            command2.Radius = 133;     //rate 1 - เกิน 1000
            command2.Threshold = 33;  //rate 0 - 255
            command2.ColorType = UnsharpMaskCommandColorType.Rgb;
            command2.Run(myObj.Name);
        }*/

        public void Display() {
            
            using (Image destImage1 = RasterImageConverter.ConvertToImage(ChangeCommand(), ConvertToImageOptions.None))
            {
                picOutput.Image = new Bitmap(destImage1);
                //MessageBox.Show(destImage1.ToString());
            }
            //MessageBox.Show(.ToString());
        }
        public RasterImage ChangeCommand()
        {

            // Load an image 
            codecs.ThrowExceptionsOnInvalidImages = true;
            // person.IMG = codecs.Load(Path.Combine(folderPath));
            RasterImage image = codecs.Load(Path.Combine(folderPath));
           // myObj.Name = codecs.Load(Path.Combine(folderPath));
           // MessageBox.Show(myObj.Name.ToString());
            // Prepare the command 

            ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
                //Increase the brightness by 25 percent  of the possible range. 
                command.Brightness = value_trackBar1;   //484
                command.Contrast = value_trackBar2;     //394
                command.Intensity = value_trackBar3;    //118
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
                command3.Run(image);
            }

            if (chckbox == true)
            {
                AutoColorLevelCommand command4 = new AutoColorLevelCommand();
                command4.Run(image);
            }
            
            if(chckbox2 == true) {
                GrayScaleExtendedCommand command5 = new GrayScaleExtendedCommand();
                command5.RedFactor = value_trackBar7;
                command5.GreenFactor = value_trackBar8;
                command5.BlueFactor = value_trackBar9;
                command5.Run(image);
            }

            if (chckbox3 == true) {
                DespeckleCommand command6 = new DespeckleCommand();
                //Remove speckles from the image. 
                command6.Run(image);
            }

            if (chckbox4 == true)
            {
                AutoBinaryCommand command7 = new AutoBinaryCommand();
                //Apply Auto Binary Segment. 
                command7.Run(image);
            }

            if (chckbox5 == true)
            {
                MaximumCommand command8 = new MaximumCommand();
                //Apply Maximum filter. 
                command8.Dimension = 3;
                command8.Run(image);
            }


            if (chckbox6 == true)
            {
               MinimumCommand command9 = new MinimumCommand();
                //Apply the Minimum filter. 
              command9.Dimension = 3;
              command9.Run(image);
            }

            if (chckbox7 == true)
            {
                AutoBinarizeCommand command10 = new AutoBinarizeCommand();
                command10.Run(image);
            }

            if (chckbox8 == true)
            {
                GammaCorrectCommand command11 = new GammaCorrectCommand();
                //Set a gamma value of 2.5. 
                command11.Gamma = 310;
                command11.Run(image);
            }
            if (chckbox9 == true)
            {
                DynamicBinaryCommand command12 = new DynamicBinaryCommand();
                command12.Dimension = value_trbDynBin1;
                command12.LocalContrast = value_trbDynBin2;
                // convert it into a black and white image without changing its bits per pixel. 
                command12.Run(image);
            }
            /*HistogramEqualizeCommand command11 = new HistogramEqualizeCommand();
            //Histogram equalize the image. 
            command11.Type = HistogramqualizeType.Yuv;
            command11.Run(image);*/

            /* HighPassCommand command11 = new HighPassCommand();
             command11.Radius = 20;
             command11.Opacity = 30;
             command11.Run(image);*/

            /* SharpenCommand command11 = new SharpenCommand();
             //Increase the sharpness by 25 percent  of the possible range. 
             command11.Sharpness = 1000;
             command11.Run(image);*/

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
              LightControlCommand command5 = new LightControlCommand(LowerAverage, Average, UpperAverage, LightControlCommandType.Yuv);
              // change the lightness of the image. 
              command5.Run(image);*/



            /* DynamicBinaryCommand command6 = new DynamicBinaryCommand();
             command6.Dimension = 8;
             command6.LocalContrast = 16;
             // convert it into a black and white image without changing its bits per pixel. 
             command6.Run(image);*/

            /*SharpenCommand command6 = new SharpenCommand();
              //Increase the sharpness by 25 percent  of the possible range. 
              command6.Sharpness = 950;
              command6.Run(image);*/

            /* IntensityDetectCommand command6 = new IntensityDetectCommand();
             //Apply the filter. 
             command6.LowThreshold = 128;
             command6.HighThreshold = 255;
             command6.InColor = new RasterColor(255, 255, 255);
             command6.OutColor = new RasterColor(0, 0, 0);
             command6.Channel = IntensityDetectCommandFlags.Master;
             command6.Run(image);*/


            /*AdaptiveContrastCommand command7 = new AdaptiveContrastCommand();
            command7.Amount = 200;
            command7.Dimension = 9;
            command7.Run(image);*/

            //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\poc\image", "Result000.jpg"), RasterImageFormat.Jpeg, 24);
            // Prepare the command 

            // Prepare the command 

            /* GaussianCommand command11 = new GaussianCommand();
             command11.Radius = 5;
             command11.Run(image);*/

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
               //codecs.Save(ChangeCommand(), Path.Combine(saveFileDialog1.FileName + ".jpg"), RasterImageFormat.Jpeg, 24);
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

        public void ResetValue() {
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

            chckbox2 = false;
            checkBox2.Checked = chckbox2;
            value_trackBar7 = 500;
            trackBar7.Value = value_trackBar7;
            l_redfactor.Text = value_trackBar7.ToString();
            value_trackBar8 = 250;
            trackBar8.Value = value_trackBar8;
            l_greenfactor.Text = value_trackBar8.ToString();
            value_trackBar9 = 250;
            trackBar9.Value = value_trackBar9;
            l_bluefactor.Text = value_trackBar9.ToString();

            selectCombobox = 0;
            comboBox1.SelectedIndex = selectCombobox;

            chckbox = false;
            checkBox1.Checked = chckbox;
            chckbox3 = false;
            checkBox3.Checked = chckbox3;
            chckbox4 = false;
            checkBox4.Checked = chckbox4;

            value_profilename.Text = "";
            comboBox2.SelectedIndex = 0;
            Display();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
           ResetValue();
        }
        
        private void SaveProfile_Click(object sender, EventArgs e)
        {
            String pfname = value_profilename.Text; 
            String listname = @"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt";
            if (value_profilename.Text == "") { 
                MessageBox.Show("กรุณาตั้งชื่อ Profile!!"); 
            } else {
                using (StreamWriter streamwri1 = File.AppendText(listname))
                {
                    streamwri1.WriteLine(pfname);
                    streamwri1.Close();
                }

                StreamWriter streamwri = new StreamWriter(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\" + pfname + ".txt");
                //streamwri.WriteLine(l_profilename.Name + "=" + value_profilename.Text);
                streamwri.WriteLine(l_brightness.Name + "=" + value_trackBar1.ToString());
                streamwri.WriteLine(l_contrast.Name + "=" + value_trackBar2.ToString());
                streamwri.WriteLine(l_intensity.Name + "=" + value_trackBar3.ToString());
                streamwri.WriteLine(l_amount.Name + "=" + value_trackBar4.ToString());
                streamwri.WriteLine(l_radius.Name + "=" + value_trackBar5.ToString());
                streamwri.WriteLine(l_threshold.Name + "=" + value_trackBar6.ToString());
                streamwri.WriteLine(checkBox2.Text + "=" + chckbox2.ToString());
                streamwri.WriteLine(l_redfactor.Name + "=" + value_trackBar7.ToString());
                streamwri.WriteLine(l_greenfactor.Name + "=" + value_trackBar8.ToString());
                streamwri.WriteLine(l_bluefactor.Name + "=" + value_trackBar9.ToString());

                streamwri.WriteLine(l_binaryfilter.Name + "=" + selectCombobox.ToString());
                streamwri.WriteLine(l_autocolorlevel.Name+ "=" +chckbox.ToString());            
                streamwri.WriteLine(checkBox3.Text + "=" + chckbox3.ToString());
                streamwri.WriteLine(checkBox4.Text + "=" + chckbox4.ToString());

                streamwri.Close();
                l_saveprofile.Text = "Save Success...";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectCombobox2 = comboBox2.SelectedItem.ToString();
            if (selectCombobox2 == "Default" && folderPath != null)
            { 
                ResetValue();
            }
            else {
                String[] ls;
                String lscol;
                String rf;
                String rfile;
                List<String> list = new List<String>();
                if (selectCombobox2 == "Default") { } else {
                    StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\" + selectCombobox2 + ".txt");
                    while ((rfile = streamread.ReadLine()) != null)
                    {
                        rf = rfile;                         //text = อ่านข้อความทีละบรรทัด
                        ls = rf.Split("=".ToCharArray());   //split ตัดข้อความ ตัดที่ = 
                        lscol = ls[1];                      //เก็บค่าที่ตัดแล้ว เอาค่าที่อยู่หลัง =
                        list.Add(lscol);   
                    }
                    
                    //เซตค่า
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

                    chckbox2 = bool.Parse(list[6]);
                    checkBox2.Checked = chckbox2;
                    value_trackBar7 = int.Parse(list[7]);
                    trackBar7.Value = value_trackBar7;
                    l_redfactor.Text = value_trackBar7.ToString();
                    value_trackBar8 = int.Parse(list[8]);
                    trackBar8.Value = value_trackBar8;
                    l_greenfactor.Text = value_trackBar8.ToString();
                    value_trackBar9 = int.Parse(list[9]);
                    trackBar9.Value = value_trackBar9;
                    l_bluefactor.Text = value_trackBar9.ToString();

                    selectCombobox = int.Parse(list[10]);
                    comboBox1.SelectedIndex = (selectCombobox + 1);

                    chckbox = bool.Parse(list[11]);
                    checkBox1.Checked = chckbox;
                    chckbox3 = bool.Parse(list[12]);
                    checkBox3.Checked = chckbox3;
                    chckbox4 = bool.Parse(list[13]);
                    checkBox4.Checked = chckbox4;
                    Display();
                    l_saveprofile.Text = "usepf Success...";
                }
                list.Clear();
                //เคลียร์ list
                rf = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                chckbox = true;
                Display();
            }
            else { 
                chckbox = false;
                Display();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                chckbox2 = true;
                Display();
            }
            else
            {
                chckbox2 = false;
                Display(); 
            }
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            value_trackBar7 = trackBar7.Value;
            l_redfactor.Text = value_trackBar7.ToString();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            value_trackBar8 = trackBar8.Value;
            l_greenfactor.Text = value_trackBar8.ToString();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            value_trackBar9 = trackBar9.Value;
            l_bluefactor.Text = value_trackBar9.ToString();
        }

        private void trackBar7_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar8_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar9_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }
        private bool Expanded = false;
        private void btnConBrigtIntens_Click(object sender, EventArgs e)
        {
            if (Expanded)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;
                panConBrigtIntens.Height = 32;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow;
                panConBrigtIntens.Height = 230;
            }
            Expanded = !Expanded;
        }
        private bool Expanded2 = false;
        private void btnUnsharpMask_Click(object sender, EventArgs e)
        {
            if (Expanded2)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panUnsharpMask.Height = 32;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panUnsharpMask.Height = 230;
            }
            Expanded2 = !Expanded2;
        }
        private bool Expanded3 = false;
        private void btnGrayScale_Click(object sender, EventArgs e)
        {
            if (Expanded3)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panGrayScale.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panGrayScale.Height = 277;
            }
            Expanded3 = !Expanded3;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                chckbox3 = true;
                Display();
            }
            else
            {
                chckbox3 = false;
                Display();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                chckbox4 = true;
                Display();
            }
            else
            {
                chckbox4 = false;
                Display();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                chckbox5 = true;
                Display();
            }
            else
            {
                chckbox5 = false;
                Display();
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                chckbox6 = true;
                Display();
            }
            else
            {
                chckbox6 = false;
                Display();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                chckbox7 = true;
                Display();
            }
            else
            {
                chckbox7 = false;
                Display();
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                chckbox8 = true;
                Display();
            }
            else
            {
                chckbox8 = false;
                Display();
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                chckbox9 = true;
                Display();
            }
            else
            {
                chckbox9 = false;
                Display();
            }
        }

        private void trbDynBin1_Scroll(object sender, EventArgs e)
        {
            value_trbDynBin1 = trbDynBin1.Value;
            l_redfactor.Text = value_trbDynBin1.ToString();
        }

        private void trbDynBin2_Scroll(object sender, EventArgs e)
        {
            value_trbDynBin2 = trbDynBin2.Value;
            l_redfactor.Text = value_trbDynBin2.ToString();
        }

        private void trbDynBin1_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trbDynBin2_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }
    }
}
