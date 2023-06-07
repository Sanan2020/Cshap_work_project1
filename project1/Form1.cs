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
using Leadtools.Ocr;

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
        public int value_trbMaximum = 3;
        public int value_trbMinimum = 3;
        public int value_trbGamma = 310;
        public bool chckbox10 = false;
        public bool chckbox11 = false;
        public bool chckbox12 = false;
        public bool chckbox13 = false;
        public bool chckbox14 = false;
        public bool chckbox15 = false;
        public bool chckbox16 = false;
        public bool chckbox17 = false;
        public int value_trackBar10 = 10;
        public int value_trackBar11 = 10;
        public int value_trackBar12 = 1;
        public int value_trackBar13 = 1;
        public int value_trackBar14 = 2;
        public int value_trackBar15 = 5;
        public int value_trackBar16 = 200;
        public int value_trackBar17 = 10;
        public int value_trackBar22 = 7;
        public int value_trackBar18 = 4;
        public int value_trackBar21 = 2;
        public int value_trackBar19 = 95;
        public int value_trackBar20 = 70;
        public int value_trackBar23 = 500;
        public int value_trackBar24 = 5000;
        public int value_trackBar27 = 20;
        public int value_trackBar25 = 20;
        public int value_trackBar26 = 3;
        public int value_trackBar28 = 9;
        public int value_trackBar31 = 2;
        public Form1()
        {
            InitializeComponent();

        }
       
        private void Browse_Click(object sender, EventArgs e)
        {
            codecs.ThrowExceptionsOnInvalidImages = true;
            
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.bmp,*.tif,*.pdf,*.jpg, *.png)|*.bmp;*.tif;*.pdf;*.jpg;*.png";
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

            trackBar7.Value = value_trackBar7;
            l_redfactor.Text = value_trackBar7.ToString();
            trackBar8.Value = value_trackBar8;
            l_greenfactor.Text = value_trackBar8.ToString();
            trackBar9.Value = value_trackBar9;
            l_bluefactor.Text = value_trackBar9.ToString();

            trackBar10.Value = value_trackBar10;
            l_maximumdotH.Text = value_trackBar10.ToString();
            trackBar11.Value = value_trackBar11;
            l_maximumdotW.Text = value_trackBar11.ToString();
            trackBar12.Value = value_trackBar12;
            l_minimumdotH.Text = value_trackBar12.ToString();
            trackBar13.Value = value_trackBar13;
            l_minimumdotW.Text = value_trackBar13.ToString();

            trackBar14.Value = value_trackBar14;
            l_gaplength.Text = value_trackBar14.ToString();
            trackBar15.Value = value_trackBar15;
            l_maximumlineW.Text = value_trackBar15.ToString();
            trackBar16.Value = value_trackBar16;
            l_minimumlineL.Text = value_trackBar16.ToString();
            trackBar17.Value = value_trackBar17;
            l_maximumwall.Text = value_trackBar17.ToString();
            trackBar22.Value = value_trackBar22;
            l_wall.Text = value_trackBar22.ToString();
            trackBar18.Value = value_trackBar18;
            l_maximumhole.Text = value_trackBar18.ToString();
            trackBar21.Value = value_trackBar21;
            l_minimumhole.Text = value_trackBar21.ToString();

            trackBar19.Value = value_trackBar19;
            l_maximumblack.Text = value_trackBar19.ToString();
            trackBar20.Value = value_trackBar20;
            l_minimumBlack.Text = value_trackBar20.ToString();
            trackBar23.Value = value_trackBar23;
            l_minimuminverH.Text = value_trackBar23.ToString();
            trackBar24.Value = value_trackBar24;
            l_minimuminvertW.Text = value_trackBar24.ToString();
            trackBar27.Value = value_trackBar27;
            l_cropThreshold.Text = value_trackBar27.ToString();
            trackBar25.Value = value_trackBar25;
            l_percent.Text = value_trackBar25.ToString();
            trackBar26.Value = value_trackBar26;
            l_variance.Text = value_trackBar26.ToString();
            trackBar28.Value = value_trackBar28;
            l_whitenoiseL.Text = value_trackBar28.ToString();
            trackBar31.Value = value_trackBar31;
            l_length.Text = value_trackBar31.ToString();
        }

        public void Display() {
            
            using (Image destImage1 = RasterImageConverter.ConvertToImage(ChangeCommand(), ConvertToImageOptions.None))
            {
                picOutput.Image = new Bitmap(destImage1);
                //MessageBox.Show(destImage1.ToString());
            }
        }
        public RasterImage ChangeCommand()
        {

            // Load an image 
            codecs.ThrowExceptionsOnInvalidImages = true;
            RasterImage image = codecs.Load(Path.Combine(folderPath));

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
                command8.Dimension = value_trbMaximum;
                command8.Run(image);
            }

            if (chckbox6 == true)
            {
               MinimumCommand command9 = new MinimumCommand();
                //Apply the Minimum filter. 
              command9.Dimension = value_trbMinimum;
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
                command11.Gamma = value_trbGamma;
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

            if (chckbox11 == true)
            {
                LineRemoveCommand command13 = new LineRemoveCommand();
                command13.LineRemove += new EventHandler<LineRemoveCommandEventArgs>(LineRemoveEvent_S1);
                command13.Type = LineRemoveCommandType.Horizontal;
                command13.Flags = LineRemoveCommandFlags.UseGap;
                command13.GapLength = value_trackBar14;
                command13.MaximumLineWidth = value_trackBar15;
                command13.MinimumLineLength = value_trackBar16;
                command13.MaximumWallPercent = value_trackBar17;
                command13.Wall = value_trackBar22;
                command13.Run(image);
            }

            if (chckbox10 == true)
            {
                DotRemoveCommand command13 = new DotRemoveCommand();
                command13.DotRemove += new EventHandler<DotRemoveCommandEventArgs>(DotRemoveEvent_S1);
                command13.Flags = DotRemoveCommandFlags.UseSize;
                command13.MaximumDotHeight = value_trackBar10;
                command13.MaximumDotWidth = value_trackBar11;
                command13.MinimumDotHeight = value_trackBar12;
                command13.MinimumDotWidth = value_trackBar13;

                command13.Run(image);
            }

            if (chckbox12 == true)
            {
                HolePunchRemoveCommand command14 = new HolePunchRemoveCommand();
                command14.HolePunchRemove += new EventHandler<HolePunchRemoveCommandEventArgs>(HolePunchRemoveEvent_S1);
                command14.Flags = HolePunchRemoveCommandFlags.UseDpi | HolePunchRemoveCommandFlags.UseCount | HolePunchRemoveCommandFlags.UseLocation;
                command14.Location = HolePunchRemoveCommandLocation.Left;
                command14.MaximumHoleCount = value_trackBar18;
                command14.MinimumHoleCount = value_trackBar21;
                command14.Run(image);
            }

            if (chckbox13 == true)
            {
                InvertedTextCommand command15 = new InvertedTextCommand();
                command15.InvertedText += new EventHandler<InvertedTextCommandEventArgs>(InvertedTextEvent_S1);
                command15.Flags = InvertedTextCommandFlags.UseDpi;
                command15.MaximumBlackPercent = value_trackBar19;
                command15.MinimumBlackPercent = value_trackBar20;
                command15.MinimumInvertHeight = value_trackBar23;
                command15.MinimumInvertWidth = value_trackBar24;
                command15.Run(image);
            }

            if (chckbox14 == true)
            {
                DeskewCommand command16 = new DeskewCommand();
                //Deskew the image. 
                command16.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea;
                command16.Run(image);
            }

            if (chckbox15 == true)
            {
                AutoCropCommand command17 = new AutoCropCommand();
                //AutoCrop the image with 20 tolerance. 
                command17.Threshold = value_trackBar27;
                command17.Run(image);
            }

            if (chckbox16 == true)
            {
                BorderRemoveCommand command18 = new BorderRemoveCommand();
                command18.BorderRemove += new EventHandler<BorderRemoveCommandEventArgs>(command_BorderRemove_S1);
                command18.Border = BorderRemoveBorderFlags.All;
                command18.Flags = BorderRemoveCommandFlags.UseVariance;
                command18.Percent = value_trackBar25;
                command18.Variance = value_trackBar26;
                command18.WhiteNoiseLength = value_trackBar28;
                command18.Run(image);
            }

            if (chckbox17 == true)
            {
                SmoothCommand command19 = new SmoothCommand();
                command19.Smooth += new EventHandler<SmoothCommandEventArgs>(SmoothEventExample_S1);
                command19.Flags = SmoothCommandFlags.FavorLong;
                command19.Length = value_trackBar31;
                command19.Run(image);
            }
           
            
            //test 
              // Preprocessing steps
           /* ResizeCommand rcommand = new ResizeCommand();
            rcommand.DestinationImage = image;
            rcommand.Flags = RasterSizeFlags.Bicubic;
            

            DeskewCommand deskewCommand = new DeskewCommand();
            SharpenCommand sharpenCommand = new SharpenCommand();
            //CleanUpCommand cleanUpCommand = new CleanUpCommand();
            AutoBinarizeCommand autoBinarizeCommand = new AutoBinarizeCommand();*/

            //rcommand.Run(image);
           // deskewCommand.Run(image);
           // sharpenCommand.Run(image);
            // cleanUpCommand.Run(image);
           
           // autoBinarizeCommand.Run(image);

            // Perform OCR on the preprocessed image
           /* using (IOcrEngine ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD))
            {
                ocrEngine.Startup(null, null, null, null);
                //ocrEngine.LanguageManager.EnableLanguages(new[] { "tha" }, null, null, null);
                using (IOcrPage ocrPage = ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose))
                {
                    ocrPage.AutoZone(null);
                    ocrPage.Recognize(null);
                    string extractedText = ocrPage.GetText(-1);
                    System.Console.WriteLine("***************Start****************\r\n"+extractedText+ "\r\n***************Start****************");
                }
                ocrEngine.Shutdown();
            }

            // Clean up
            image.Dispose();
            codecs.Dispose();

            System.Console.ReadLine();*/

           //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\poc\image", "Result7.tif"), RasterImageFormat.Tif, 1);
            // Prepare the command 
            if (chckbox3 == true)
            {
                DespeckleCommand command6 = new DespeckleCommand();
                //Remove speckles from the image. 
                command6.Run(image);
            }

           /* RakeRemoveCommand command20 = new RakeRemoveCommand();
            command20.RakeRemove += new EventHandler<RakeRemoveCommandEventArgs>(RakeRemoveEvent_S1);
            command20.MinLength = 50;
            command20.MinWallHeight = 10;
            command20.MaxWidth = 3;
            command20.MaxWallPercent = 25;
            command20.MaxSideteethLength = 60;
            command20.MaxMidteethLength = 50;
            command20.Gaps = 1;
            command20.Variance = 1;
            command20.TeethSpacing = 5;
            command20.AutoFilter = false;

            command20.Run(image);*/

            return image;
        }
        private void RakeRemoveEvent_S1(object sender, RakeRemoveCommandEventArgs e)
        {
            MessageBox.Show("Rake length is " + "( " + e.Length.ToString() + " )");
            e.Status = RemoveStatus.Remove;
        }
        private void DotRemoveEvent_S1(object sender, DotRemoveCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Size   " + e.BoundingRectangle.Width + e.BoundingRectangle.Height + "Bounds"
               + e.BoundingRectangle.Left + "," + e.BoundingRectangle.Top + "," + e.BoundingRectangle.Right + "," + e.BoundingRectangle.Bottom + ","
               + "     WhiteCount" + e.WhiteCount + "    BlackCount" + e.BlackCount, "DotRemove Event");

            //Do not remove the speck if it contains any white pixels 
            if (e.WhiteCount > 0)
            {
                e.Status = RemoveStatus.NoRemove;
            }
            else
            {
                e.Status = RemoveStatus.Remove;
            }
        }
        private void LineRemoveEvent_S1(object sender, LineRemoveCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Row Col " + "( " + e.StartRow.ToString() + ", " + e.StartColumn + " )" +
               "\n Length " + e.Length.ToString());
            e.Status = RemoveStatus.Remove;
        }
        private void HolePunchRemoveEvent_S1(object sender, HolePunchRemoveCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Size " + "( " + e.BoundingRectangle.Left + ", " + e.BoundingRectangle.Top + ") - " + "( " + e.BoundingRectangle.Right + ", " + e.BoundingRectangle.Bottom + ")" +
               "\n Hole Index " + e.HoleIndex.ToString() +
               "\n Holes Total Count " + e.HoleTotalCount.ToString() +
               "\n Black Count " + e.BlackCount.ToString() +
               "\n White Count " + e.WhiteCount.ToString());
            e.Status = RemoveStatus.Remove;
        }
        private void InvertedTextEvent_S1(object sender, InvertedTextCommandEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("Size " + "( " + e.BoundingRectangle.Left + ", " + e.BoundingRectangle.Top + ") - " + "( " + e.BoundingRectangle.Right + ", " + e.BoundingRectangle.Bottom + ")" +
               "\n Black Count " + e.BlackCount.ToString() +
               "\n White Count " + e.WhiteCount.ToString());
            e.Status = RemoveStatus.Remove;
        }
        private void command_BorderRemove_S1(object sender, BorderRemoveCommandEventArgs e)
        {
            string Border;

            switch (e.Border)
            {
                case BorderRemoveBorderFlags.Top:
                    Border = "Top";
                    break;
                case BorderRemoveBorderFlags.Left:
                    Border = "Left";
                    break;
                case BorderRemoveBorderFlags.Right:
                    Border = "Right";
                    break;
                case BorderRemoveBorderFlags.Bottom:
                    Border = "Bottom";
                    break;
                default:
                    Border = "";
                    break;
            }
            System.Diagnostics.Debug.WriteLine("Bounds " + "( " + e.BoundingRectangle.Left + ", " + e.BoundingRectangle.Top + ") - " + "( " + e.BoundingRectangle.Right + ", " + e.BoundingRectangle.Bottom + ")" + "\n Border " + Border.ToString());
            e.Status = RemoveStatus.Remove;
        }
        private void SmoothEventExample_S1(object sender, SmoothCommandEventArgs e)
        {
            string BumpOrNeck;
            string Direction;

            if (e.BumpNick == SmoothCommandBumpNickType.Bump)
                BumpOrNeck = "Bump";
            else
                BumpOrNeck = "Neck";

            if (e.Direction == SmoothCommandDirectionType.Horizontal)
                Direction = "Horizontal";
            else
                Direction = "Vertical";

            System.Diagnostics.Debug.WriteLine("Type " + BumpOrNeck +
               "\n Row Column " + e.StartRow.ToString() + e.StartColumn.ToString() +
               "\n Length " + e.Length +
               "\n Direction " + Direction);

            e.Status = RemoveStatus.Remove;
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
            chckbox5 = false;
            checkBox5.Checked = chckbox5;
            value_trbMaximum = 3;
            trbMaximum.Value = value_trbMaximum;
            l_maximum.Text = value_trbMaximum.ToString();
            chckbox6 = false;
            checkBox6.Checked = chckbox6;
            value_trbMinimum = 3;
            trbMinimum.Value = value_trbMinimum;
            l_minimum.Text = value_trbMinimum.ToString();
            chckbox7 = false;
            checkBox7.Checked = chckbox7;
            chckbox8 = false;
            checkBox8.Checked = chckbox8;
            value_trbGamma = 310;
            trbGamma.Value = value_trbGamma;
            l_gamma.Text = value_trbGamma.ToString();
            chckbox9 = false;
            checkBox9.Checked = chckbox9;
            chckbox10 = false;
            checkBox10.Checked = chckbox10;
            chckbox11 = false;
            checkBox11.Checked = chckbox11;
            chckbox12 = false;
            checkBox12.Checked = chckbox12;
            chckbox13 = false;
            checkBox13.Checked = chckbox13;
            chckbox14 = false;
            checkBox14.Checked = chckbox14;
            chckbox15 = false;
            checkBox15.Checked = chckbox15;
            chckbox16 = false;
            checkBox16.Checked = chckbox16;
            chckbox17 = false;
            checkBox17.Checked = chckbox17;

            value_profilename.Text = "";
            comboBox2.SelectedIndex = 0;

            value_trackBar10 = 10;
            trackBar10.Value = value_trackBar10;
            l_maximumdotH.Text = value_trackBar10.ToString();
            value_trackBar11 = 10;
            trackBar11.Value = value_trackBar11;
            l_maximumdotW.Text = value_trackBar11.ToString();
            value_trackBar12 = 1;
            trackBar12.Value = value_trackBar12;
            l_minimumdotH.Text = value_trackBar12.ToString();
            value_trackBar13 = 1;
            trackBar13.Value = value_trackBar13;
            l_minimumdotW.Text = value_trackBar13.ToString();
            value_trackBar14 = 2;
            trackBar14.Value = value_trackBar14;
            l_gaplength.Text = value_trackBar14.ToString();
            value_trackBar15 = 5;
            trackBar15.Value = value_trackBar15;
            l_maximumlineW.Text = value_trackBar15.ToString();
            value_trackBar16 = 200;
            trackBar16.Value = value_trackBar16;
            l_minimumlineL.Text = value_trackBar16.ToString();
            value_trackBar17 = 10;
            trackBar17.Value = value_trackBar17;
            l_maximumwall.Text = value_trackBar17.ToString();
            value_trackBar22 = 7;
            trackBar22.Value = value_trackBar22;
            l_wall.Text = value_trackBar22.ToString();
            value_trackBar18 = 4;
            trackBar18.Value = value_trackBar18;
            l_maximumhole.Text = value_trackBar18.ToString();
            value_trackBar21 = 2;
            trackBar21.Value = value_trackBar21;
            l_minimumhole.Text = value_trackBar21.ToString();
            value_trackBar19 = 95;
            trackBar19.Value = value_trackBar19;
            l_maximumblack.Text = value_trackBar19.ToString();
            value_trackBar20 = 70;
            trackBar20.Value = value_trackBar20;
            l_minimumBlack.Text = value_trackBar20.ToString();
            value_trackBar23 = 500;
            trackBar23.Value = value_trackBar23;
            l_minimuminverH.Text = value_trackBar23.ToString();
            value_trackBar24 = 5000;
            trackBar24.Value = value_trackBar24;
            l_minimuminvertW.Text = value_trackBar24.ToString();
            value_trackBar27 = 20;
            trackBar27.Value = value_trackBar27;
            l_cropThreshold.Text = value_trackBar27.ToString();
            value_trackBar25 = 20;
            trackBar25.Value = value_trackBar25;
            l_percent.Text = value_trackBar25.ToString();
            value_trackBar26 = 3;
            trackBar26.Value = value_trackBar26;
            l_variance.Text = value_trackBar26.ToString();
            value_trackBar28 = 9;
            trackBar28.Value = value_trackBar28;
            l_whitenoiseL.Text = value_trackBar28.ToString();
            value_trackBar31 = 2;
            trackBar31.Value = value_trackBar31;
            l_length.Text = value_trackBar31.ToString();
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
                streamwri.WriteLine(checkBox5.Text + "=" + chckbox5.ToString());
                streamwri.WriteLine(checkBox6.Text + "=" + chckbox6.ToString());
                streamwri.WriteLine(checkBox7.Text + "=" + chckbox7.ToString());
                streamwri.WriteLine(checkBox8.Text + "=" + chckbox8.ToString());
                streamwri.WriteLine(checkBox9.Text + "=" + chckbox9.ToString());
                streamwri.WriteLine(checkBox10.Text + "=" + chckbox10.ToString());
                streamwri.WriteLine(checkBox11.Text + "=" + chckbox11.ToString());
                streamwri.WriteLine(checkBox12.Text + "=" + chckbox12.ToString());
                streamwri.WriteLine(checkBox13.Text + "=" + chckbox13.ToString());
                streamwri.WriteLine(checkBox14.Text + "=" + chckbox14.ToString());
                streamwri.WriteLine(checkBox15.Text + "=" + chckbox15.ToString());
                streamwri.WriteLine(checkBox16.Text + "=" + chckbox16.ToString());
                streamwri.WriteLine(checkBox17.Text + "=" + chckbox17.ToString());

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
                    chckbox5 = bool.Parse(list[14]);
                    checkBox5.Checked = chckbox5;
                    chckbox6 = bool.Parse(list[15]);
                    checkBox6.Checked = chckbox6;
                    chckbox7 = bool.Parse(list[16]);
                    checkBox7.Checked = chckbox7;
                    chckbox8 = bool.Parse(list[17]);
                    checkBox8.Checked = chckbox8;
                    chckbox9 = bool.Parse(list[18]);
                    checkBox9.Checked = chckbox9;
                    chckbox10 = bool.Parse(list[19]);
                    checkBox10.Checked = chckbox10;
                    chckbox11 = bool.Parse(list[20]);
                    checkBox11.Checked = chckbox11;
                    chckbox12 = bool.Parse(list[21]);
                    checkBox12.Checked = chckbox12;
                    chckbox13 = bool.Parse(list[22]);
                    checkBox13.Checked = chckbox13;
                    chckbox14 = bool.Parse(list[23]);
                    checkBox14.Checked = chckbox14;
                    chckbox15 = bool.Parse(list[24]);
                    checkBox15.Checked = chckbox15;
                    chckbox16 = bool.Parse(list[25]);
                    checkBox16.Checked = chckbox16;
                    chckbox17 = bool.Parse(list[26]);
                    checkBox17.Checked = chckbox17;
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

        private void trbMaximum_Scroll(object sender, EventArgs e)
        {
            value_trbMaximum = trbMaximum.Value;    
            l_maximum.Text = value_trbMaximum.ToString();
        }

        private void trbMinimum_Scroll(object sender, EventArgs e)
        {
            value_trbMinimum = trbMinimum.Value;
            l_minimum.Text = value_trbMinimum.ToString();
        }

        private void trbGamma_Scroll(object sender, EventArgs e)
        {
            value_trbGamma = trbGamma.Value;
            l_gamma.Text = value_trbGamma.ToString();
        }

        private void trbMaximum_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trbMinimum_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trbGamma_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }
        private bool Expanded4 = false;
        private void btnDocImgClupFnct_Click(object sender, EventArgs e)
        {
            if (Expanded4)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panDocImgClupFnct.Height = 28;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panDocImgClupFnct.Height = 240;
            }
            Expanded4 = !Expanded4;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                chckbox10 = true;
                Display();
            }
            else
            {
                chckbox10 = false;
                Display();
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                chckbox11 = true;
                Display();
            }
            else
            {
                chckbox11 = false;
                Display();
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                chckbox12 = true;
                Display();
            }
            else
            {
                chckbox12 = false;
                Display();
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                chckbox13 = true;
                Display();
            }
            else
            {
                chckbox13 = false;
                Display();
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                chckbox14 = true;
                Display();
            }
            else
            {
                chckbox14 = false;
                Display();
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                chckbox15 = true;
                Display();
            }
            else
            {
                chckbox15 = false;
                Display();
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                chckbox16 = true;
                Display();
            }
            else
            {
                chckbox16 = false;
                Display();
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                chckbox17 = true;
                Display();
            }
            else
            {
                chckbox17 = false;
                Display();
            }
        }
        private bool Expanded5 = false;
        private void btnDotRemove_Click(object sender, EventArgs e)
        {
            if (Expanded5)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panDotRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panDotRemove.Height = 267;
            }
            Expanded5 = !Expanded5;
        }
        private bool Expanded6 = false;
        private void btnLineRemove_Click(object sender, EventArgs e)
        {
            if (Expanded6)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panLineRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panLineRemove.Height = 333;
            }
            Expanded6 = !Expanded6;
        }
        private bool Expanded7 = false;
        private void btnHolePunchRemove_Click(object sender, EventArgs e)
        {
            if (Expanded7)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panHolePunchRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panHolePunchRemove.Height = 192;
            }
            Expanded7 = !Expanded7;
        }
        private bool Expanded8 = false;
        private void btnInvertedText_Click(object sender, EventArgs e)
        {
            if (Expanded8)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panInvertedText.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panInvertedText.Height = 309;
            }
            Expanded8 = !Expanded8;
        }
        private bool Expanded9 = false;
        private void btnAutoCrop_Click(object sender, EventArgs e)
        {
            if (Expanded9)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panAutoCrop.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panAutoCrop.Height = 117;
            }
            Expanded9 = !Expanded9;
        }
        private bool Expanded10 = false;
        private void btnBorderRemove_Click(object sender, EventArgs e)
        {
            if (Expanded10)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panBorderRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panBorderRemove.Height = 225;
            }
            Expanded10 = !Expanded10;
        }
        private bool Expanded11 = false;
        private void btnSmooth_Click(object sender, EventArgs e)
        {
            if (Expanded11)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panSmooth.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panSmooth.Height = 114;
            }
            Expanded11 = !Expanded11;
        }

        //dotRemove
        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            value_trackBar10 = trackBar10.Value;
            l_maximumdotH.Text = value_trackBar10.ToString();
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            value_trackBar11 = trackBar11.Value;
            l_maximumdotW.Text = value_trackBar11.ToString();
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            value_trackBar12 = trackBar12.Value;
            l_minimumdotH.Text = value_trackBar12.ToString();
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            value_trackBar13 = trackBar13.Value;
            l_minimumdotW.Text = value_trackBar13.ToString();
        }

        private void trackBar10_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar11_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar12_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar13_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            value_trackBar14 = trackBar14.Value;
            l_gaplength.Text = value_trackBar14.ToString();
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            value_trackBar15 = trackBar15.Value;
            l_maximumlineW.Text = value_trackBar15.ToString();
        }

        private void trackBar16_Scroll(object sender, EventArgs e)
        {
            value_trackBar16 = trackBar16.Value;
            l_minimumlineL.Text = value_trackBar16.ToString();
        }

        private void trackBar17_Scroll(object sender, EventArgs e)
        {
            value_trackBar17 = trackBar17.Value;
            l_maximumwall.Text = value_trackBar17.ToString();
        }

        private void trackBar22_Scroll(object sender, EventArgs e)
        {
            value_trackBar22 = trackBar22.Value;
            l_wall.Text = value_trackBar22.ToString();
        }

        private void trackBar14_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar15_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar16_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar17_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar22_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar18_Scroll(object sender, EventArgs e)
        {
            value_trackBar18 = trackBar18.Value;
            l_maximumhole.Text = value_trackBar18.ToString();
        }

        private void trackBar21_Scroll(object sender, EventArgs e)
        {
            value_trackBar21 = trackBar21.Value;
            l_minimumhole.Text = value_trackBar21.ToString();
        }

        private void trackBar18_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar21_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar19_Scroll(object sender, EventArgs e)
        {
            value_trackBar19 = trackBar19.Value;
            l_maximumblack.Text = value_trackBar19.ToString();
        }

        private void trackBar20_Scroll(object sender, EventArgs e)
        {
            value_trackBar20 = trackBar20.Value;
            l_minimumBlack.Text = value_trackBar20.ToString();
        }

        private void trackBar23_Scroll(object sender, EventArgs e)
        {
            value_trackBar23 = trackBar23.Value;
            l_minimuminverH.Text = value_trackBar23.ToString();
        }

        private void trackBar24_Scroll(object sender, EventArgs e)
        {
            value_trackBar24 = trackBar24.Value;
            l_minimuminvertW.Text = value_trackBar24.ToString();
        }

        private void trackBar19_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar20_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar23_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar24_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar27_Scroll(object sender, EventArgs e)
        {
            value_trackBar27 = trackBar27.Value;
            l_cropThreshold.Text = value_trackBar27.ToString();
        }

        private void trackBar27_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar25_Scroll(object sender, EventArgs e)
        {
            value_trackBar25 = trackBar25.Value;
            l_percent.Text = value_trackBar25.ToString();
        }

        private void trackBar26_Scroll(object sender, EventArgs e)
        {
            value_trackBar26 = trackBar26.Value;
            l_variance.Text = value_trackBar26.ToString();
        }

        private void trackBar28_Scroll(object sender, EventArgs e)
        {
            value_trackBar28 = trackBar28.Value;
            l_whitenoiseL.Text = value_trackBar28.ToString();
        }

        private void trackBar25_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar26_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar28_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void trackBar31_Scroll(object sender, EventArgs e)
        {
            value_trackBar31 = trackBar31.Value;
            l_length.Text = value_trackBar31.ToString();
        }

        private void trackBar31_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
        }
    }
}
