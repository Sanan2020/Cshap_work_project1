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
using Leadtools.Ocr.LEADEngine;
using System.Runtime.InteropServices;
using Leadtools.Document;
using DevComponents.DotNetBar;
using System.Threading;
using static project1.Form1Export;
using static project1.Form1;
using System.Diagnostics.Contracts;

namespace project1
{

    public partial class Form1 : Form
    {
        internal static Form2 form2;
        internal static Form1 form1;
        internal static Preview pv;

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
        public bool chckbox18 = false;
        public int value_trackBar29 = 45;
        public bool chckbox19 = false;
        public int value_numUpDown1 = 50;
        public int value_numUpDown2 = 10;
        public int value_numUpDown3 = 3;
        public int value_numUpDown4 = 25;
        public int value_numUpDown5 = 60;
        public int value_numUpDown6 = 50;
        public int value_numUpDown7 = 1;
        public int value_numUpDown8 = 1;
        public int value_numUpDown9 = 5;
        public bool chckbox20 = false;
        public bool chckbox21 = false;

        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        bool cancelAt50;
        void RunCommand(RasterImage image, RasterCommand command)
        {
            // subscribe to the progress event of the command 
            command.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
            // if this is a flip command, we want to stop at 50 percent 
            cancelAt50 = command is FlipCommand;
            // run the command 
            command.Run(image);
            command.Progress -= new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
        }

        void command_Progress(object sender, RasterCommandProgressEventArgs e)
        {
            // show the percentage 
            Console.WriteLine(e.Percent);
            // check if we need to cancel the command at 50% 
            if (e.Percent == 50 && cancelAt50)
                e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                /*RasterSupport.SetLicense(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC",
                    File.ReadAllText(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC.KEY"));*/
                bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
                if (isLocked)
                    Console.WriteLine("Document support is locked");
                else
                {
                    Console.WriteLine("Document support is unlocked");
                }

                flowLayoutPanel1.AutoScroll = true;
              
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

                cbboxUseProfile.Items.Add("Default");

                /*if (System.IO.File.Exists(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt"))//ถ้าเจอไฟล์
                {
                    String rfile;
                    StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt");
                    while ((rfile = streamread.ReadLine()) != null)
                    {
                        // textBox1.Text += rfile + "\r\n";
                        comboBox2.Items.Add(rfile);

                    }
                    streamread.Close();
                }
                comboBox2.SelectedItem = "Default";*/
                cbBox2re();
               /* if (System.IO.File.Exists(@"C:\Users\Administrator\source\repos\project1\project1\bin\Debug\*.xml"))
                {*/
                   /* DirectoryInfo di = new DirectoryInfo(@"C:\Users\Administrator\source\repos\project1\project1\bin\Debug");
                    foreach (var fi in di.GetFiles("*.xml"))
                    {
                        //Console.WriteLine(fi.Name);
                        string[] nm = fi.Name.Split('.');
                        Console.WriteLine(nm[0]);
                        cbboxUseProfile.Items.Add(nm[0]);
                    }*/
               // }

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

                trbDynBin1.Value = value_trbDynBin1;
                l_dimension.Text = value_trbDynBin1.ToString();
                trbDynBin2.Value = value_trbDynBin2;
                l_localcontrast.Text = value_trbDynBin2.ToString();
                //RasterCommandExample();
                value_trbMaximum = 3;
                trbMaximum.Value = value_trbMaximum;
                l_maximum.Text = value_trbMaximum.ToString();
                value_trbMinimum = 3;
                trbMinimum.Value = value_trbMinimum;
                l_minimum.Text = value_trbMinimum.ToString();
                value_trbGamma = 310;
                trbGamma.Value = value_trbGamma;
                l_gamma.Text = value_trbGamma.ToString();

                /*layout*/
                splitContainer1.Panel1.AutoScroll = true;
                splitContainer1.Panel2.AutoScroll = true;
                splitContainer1.Panel1.BackColor = Color.DarkGray;
                splitContainer1.Panel2.BackColor = Color.DarkGray;
                splitContainer1.SplitterWidth = 10; //ความกว้างของตัว split ค่าเดิม 4
                splitContainer1.BorderStyle = BorderStyle.FixedSingle;
                /**/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Display()
        {
            try
            {
                using (Image destImage1 = RasterImageConverter.ConvertToImage(ChangeCommand(), ConvertToImageOptions.None))
                {
                    //picOutput.Image = new Bitmap(destImage1);
                    //MessageBox.Show(destImage1.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public RasterImage ChangeCommand()
        {
            // Load an image 
            codecs.ThrowExceptionsOnInvalidImages = true;
            //RasterImage image = codecs.Load(Path.Combine(folderPath));
            RasterImage image = codecs.Load(Path.Combine(folderPath), 24, CodecsLoadByteOrder.Bgr, 1, 1);
            /*try
            {*/
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
            if (selectCombobox == 0) { }
            else
            {
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

            if (chckbox2 == true)
            {
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
            if (chckbox3 == true)
            {
                DespeckleCommand command6 = new DespeckleCommand();
                //Remove speckles from the image. 
                command6.Run(image);
            }
            if (chckbox18 == true)
            {
                FlipCommand flip = new FlipCommand(false);
                RunCommand(image, flip);
                // rotate the image by 45 degrees 
                RotateCommand rotate = new RotateCommand();
                rotate.Angle = (value_trackBar29 * 100);
                rotate.FillColor = RasterColor.FromKnownColor(RasterKnownColor.White);
                rotate.Flags = RotateCommandFlags.Resize;
                RunCommand(image, rotate);
            }
            //if (chckbox21 == true) {
            //MessageBox.Show("jk");
            RasterImage destImage = new RasterImage(
            RasterMemoryFlags.Conventional,
            image.Width,
            image.Height,
            1,
            image.Order,
            image.ViewPerspective,
            image.GetPalette(),
            IntPtr.Zero,
            0);
            int bufferSize = RasterBufferConverter.CalculateConvertSize(
               image.Width,
               image.BitsPerPixel,
               destImage.Width,
               destImage.BitsPerPixel);

            // Allocate the buffer in unmanaged memory 
            IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
            //Assert.IsFalse(buffer == IntPtr.Zero);

            // Process each row from srcImage to destImage. 
            image.Access();
            destImage.Access();
            for (int i = 0; i < image.Height; i++)
            {
                image.GetRow(i, buffer, image.BytesPerLine);
                RasterBufferConverter.Convert(
                   buffer,
                   image.Width,
                   image.BitsPerPixel,
                   destImage.BitsPerPixel,
                   image.Order,
                   destImage.Order,
                   null,
                   null,
                   0,
                   8,
                   0,
                   RasterConvertBufferFlags.None);
                destImage.SetRow(i, buffer, destImage.BytesPerLine);
            }

            destImage.Release();
            image.Release();
            // Clean up 
            Marshal.FreeHGlobal(buffer);

            if (chckbox11 == true)
            {
                LineRemoveCommand command13 = new LineRemoveCommand();
                command13.LineRemove += new EventHandler<LineRemoveCommandEventArgs>(LineRemoveEvent_S1);
                command13.Type = LineRemoveCommandType.Horizontal;
                //command13.Type = LineRemoveCommandType.Vertical;
                command13.Flags = LineRemoveCommandFlags.UseGap;
                command13.GapLength = value_trackBar14;
                command13.MaximumLineWidth = value_trackBar15;
                command13.MinimumLineLength = value_trackBar16;
                command13.MaximumWallPercent = value_trackBar17;
                command13.Wall = value_trackBar22;
                command13.Run(destImage);

                /*LineRemoveCommand commandc = new LineRemoveCommand();
                commandc.LineRemove += new EventHandler<LineRemoveCommandEventArgs>(LineRemoveEvent_S1);
                commandc.Type = LineRemoveCommandType.Vertical;
                //command13.Type = LineRemoveCommandType.Vertical;
                commandc.Flags = LineRemoveCommandFlags.UseGap;
                commandc.GapLength = value_trackBar14;
                commandc.MaximumLineWidth = value_trackBar15;
                commandc.MinimumLineLength = value_trackBar16;
                commandc.MaximumWallPercent = value_trackBar17;
                commandc.Wall = value_trackBar22;
                commandc.Run(destImage);*/
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
                command13.Run(destImage);
            }

            if (chckbox12 == true)
            {
                HolePunchRemoveCommand command14 = new HolePunchRemoveCommand();
                command14.HolePunchRemove += new EventHandler<HolePunchRemoveCommandEventArgs>(HolePunchRemoveEvent_S1);
                command14.Flags = HolePunchRemoveCommandFlags.UseDpi | HolePunchRemoveCommandFlags.UseCount | HolePunchRemoveCommandFlags.UseLocation;
                command14.Location = HolePunchRemoveCommandLocation.Left;
                command14.MaximumHoleCount = value_trackBar18;
                command14.MinimumHoleCount = value_trackBar21;
                command14.Run(destImage);
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
                command15.Run(destImage);
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
                command18.Run(destImage);
            }

            if (chckbox17 == true)
            {
                SmoothCommand command19 = new SmoothCommand();
                command19.Smooth += new EventHandler<SmoothCommandEventArgs>(SmoothEventExample_S1);
                command19.Flags = SmoothCommandFlags.FavorLong;
                command19.Length = value_trackBar31;
                command19.Run(destImage);
            }
            //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\poc\image", "Result7.tif"), RasterImageFormat.Tif, 1);
            // Prepare the command 
            if (chckbox19 == true)
            {
                RakeRemoveCommand command20 = new RakeRemoveCommand();
                command20.RakeRemove += new EventHandler<RakeRemoveCommandEventArgs>(RakeRemoveEvent_S1);
                command20.MinLength = value_numUpDown1;           //ความยาวขั้นต่ำ
                command20.MinWallHeight = value_numUpDown2;       //ความสูงของกำแพงขั้นต่ำ
                command20.MaxWidth = value_numUpDown3;             //ความกว้างสูงสุด
                command20.MaxWallPercent = value_numUpDown4;      //เปอร์เซ็นต์กำแพงสูงสุด
                command20.MaxSideteethLength = value_numUpDown5;  //ความยาวฟันข้างสูงสุด
                command20.MaxMidteethLength = value_numUpDown6;   //ความยาวฟันกลางสูงสุด
                command20.Gaps = value_numUpDown7;                 //ช่องว่าง
                command20.Variance = value_numUpDown8;             //ความแปรปรวน
                command20.TeethSpacing = value_numUpDown9;         //ระยะห่างระหว่างฟัน
                command20.AutoFilter = chckbox20;       //ตัวกรองอัตโนมัติ
                command20.Run(destImage);
            }

            //}
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/
            if (chckbox21 == true)
            {
                l_stateOutput.Text = "Image " + destImage.BitsPerPixel.ToString() + " BitsPerPixel";
                return destImage;
            }
            else
            {
                l_stateOutput.Text = "Image " + image.BitsPerPixel.ToString() + " BitsPerPixel";
                return image;
            }
        }
        private void RakeRemoveEvent_S1(object sender, RakeRemoveCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Rake length is " + "( " + e.Length.ToString() + " )");
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

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
            Image(); 
            ImageChange();
        }

        private void trackBar2_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
            Image();
            ImageChange();
        }

        private void trackBar3_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
            Image();
            ImageChange();
        }

        private void trackBar4_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
            Image();
        }

        private void trackBar5_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display();
            Image();
        }

        private void trackBar6_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (folderPath == null) { }
            else
            {
                selectCombobox = comboBox1.SelectedIndex;
                Display(); Image();
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

        public void ResetValue()
        {
            try
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

                tb_profile.Text = "";
                cbboxUseProfile.SelectedIndex = 0;

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

                value_trbDynBin1 = 8;
                trbDynBin1.Value = value_trbDynBin1;
                l_dimension.Text = value_trbDynBin1.ToString();
                value_trbDynBin2 = 16;
                trbDynBin2.Value = value_trbDynBin2;
                l_localcontrast.Text = value_trbDynBin2.ToString();

                chckbox18 = false;
                checkBox18.Checked = chckbox18;
                value_trackBar29 = 0;
                trackBar29.Value = value_trackBar29;
                l_RotateImage.Text = value_trackBar29.ToString();

                chckbox19 = false;
                checkBox19.Checked = chckbox19;
                value_numUpDown1 = 50;
                numUpDown1.Value = value_numUpDown1;
                value_numUpDown2 = 10;
                numUpDown2.Value = value_numUpDown2;
                value_numUpDown3 = 3;
                numUpDown3.Value = value_numUpDown3;
                value_numUpDown4 = 25;
                numUpDown4.Value = value_numUpDown4;
                value_numUpDown5 = 60;
                numUpDown5.Value = value_numUpDown5;
                value_numUpDown6 = 50;
                numUpDown6.Value = value_numUpDown6;
                value_numUpDown7 = 1;
                numUpDown7.Value = value_numUpDown7;
                value_numUpDown8 = 1;
                numUpDown8.Value = value_numUpDown8;
                value_numUpDown9 = 5;
                numUpDown9.Value = value_numUpDown9;
                chckbox20 = false;
                checkBox20.Checked = chckbox20;

                chckbox21 = false;
                checkBox21.Checked = chckbox21;
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<profile> Lprofile = new List<profile>();
        public List<profile2> Lprofile2 = new List<profile2>();
        public class profile
        {
            String name;
            String values;
            public string Name   // property
            {
                get { return name; }
                set { name = value; }
            }

            public string Values   // property
            {
                get { return values; }
                set { values = value; }
            }
        }

        public class profile2
        {
            String profilename;

            String l_brightness;
            String values_brightness;
            String l_contrast;
            String values_contrast;
            String l_intensity;
            String values_intensity;
            String l_amount;
            String values_amount;
            String l_radius;
            String values_radius;
            String l_threshold;
            String values_threshold;
            String use_GrayScale;
            String values_UseGrayScale;
            String l_redfactor;
            String values_redfactor;
            String l_greenfactor;
            String values_greenfactor;
            String l_bluefactor;
            String values_bluefactor;
            String autoBinarize;
            String values_AutoBinarize;
            String despeckle;
            String values_despeckle;
            String dynamicBinary;
            String values_dynamicBinary;
            String l_dimension;
            String values_dimension;
            String l_localcontrast;
            String values_localcontrast;
            String l_binaryfilter;
            String values_binaryfilter;
            String dotRemove;
            String values_dotremove;
            String l_maximumdotH;
            String values_maximumdotH;
            String l_maximumdotW;
            String values_lmaximumdotW;
            String l_minimumdotH;
            String values_minimumdotH;
            String l_minimumdotW;
            String values_minimumdotW;
            String lineRemove;
            String values_lineRemove;
            String l_gaplength;
            String values_gaplength;
            String l_maximumlineW;
            String values_maximumlineW;
            String l_minimumlineL;
            String values_minimumlineL;
            String l_maximumwall;
            String values_maximumwall;
            String l_wall;
            String values_wall;
            String holePunchRemove;
            String values_holePunchRemove;
            String l_maximumhole;
            String values_maximumhole;
            String l_minimumhole;
            String values_minimumhole;
            String invertedText;
            String values_invertedText;
            String l_maximumblack;
            String values_maximumblack;
            String l_minimumBlack;
            String values_minimumBlack;
            String l_minimuminverH;
            String values_minimuminverH;
            String l_minimuminvertW;
            String values_minimuminvertW;
            String autoCrop;
            String values_autoCrop;
            String l_cropThreshold;
            String values_cropThreshold;
            String borderRemove;
            String values_borderRemove;
            String l_percent;
            String values_percent;
            String l_variance;
            String values_variance;
            String l_whitenoiseL;
            String values_whitenoiseL;
            String smooth;
            String values_smooth;
            String l_length;
            String values_length;
            String autoColorLevel;
            String values_autoColorLevel;
            String autoBinary;
            String values_autoBinary;
            String maximum;
            String values_maximum;
            String l_maximum;
            String values_lmaximum;
            String minimum;
            String values_minimum;
            String l_minimum;
            String values_lminimum;
            String gamma;
            String values_gamma;
            String l_gamma;
            String values_lgamma;
            String autoDeskew;
            String values_autoDeskew;
            String useFlipRotateImage;
            String values_useFlipRotateImage;
            String l_RotateImage;
            String values_RotateImage;
            String useRakeRemove;
            String values_useRakeRemove;
            String l_numUpDown1;
            String values_numUpDown1;
            String l_numUpDown2;
            String values_numUpDown2;
            String l_numUpDown3;
            String values_numUpDown3;
            String l_numUpDown4;
            String values_numUpDown4;
            String l_numUpDown5;
            String values_numUpDown5;
            String l_numUpDown6;
            String values_numUpDown6;
            String l_numUpDown7;
            String values_numUpDown7;
            String l_numUpDown8;
            String values_numUpDown8;
            String l_numUpDown9;
            String values_numUpDown9;
            String autoFilter;
            String values_autoFilter;
            String convert1bit;
            String values_convert1bit;
            public string Profilename   {get { return profilename; }set { profilename = value; }}
            public string L_brightness{get { return l_brightness; }set { l_brightness = value; }}
            public string Values_brightness{get { return values_brightness; }set { values_brightness = value; }}
            public string L_contrast {get { return l_contrast; }set { l_contrast = value; }}
            public string Values_contrast {get { return values_contrast; }set { values_contrast = value; }}
            public string L_intensity { get { return l_intensity; } set { l_intensity = value; } }
            public string Values_intensity { get { return values_intensity; } set { values_intensity = value; } }
            public string L_amount { get { return l_amount; } set { l_amount = value; } }
            public string Values_amount { get { return values_amount; } set { values_amount = value; } }
            public string L_radius { get { return l_radius; } set { l_radius = value; } }
            public string Values_radius { get { return values_radius; } set { values_radius = value; } }
            public string L_threshold { get { return l_threshold; } set { l_threshold = value; } }
            public string Values_threshold { get { return values_threshold; } set { values_threshold = value; } }
            public string Use_GrayScale { get { return use_GrayScale; } set { use_GrayScale = value; } }
            public string Values_UseGrayScale { get { return values_UseGrayScale; } set { values_UseGrayScale = value; } }
            public string L_redfactor { get { return l_redfactor; } set { l_redfactor = value; } }
            public string Values_redfactor { get { return values_redfactor; } set { values_redfactor = value; } }
            public string L_greenfactor { get { return l_greenfactor; } set { l_greenfactor = value; } }
            public string Values_greenfactor { get { return values_greenfactor; } set { values_greenfactor = value; } }
            public string L_bluefactor { get { return l_bluefactor; } set { l_bluefactor = value; } }
            public string Values_bluefactor { get { return values_bluefactor; } set { values_bluefactor = value; } }
            public string AutoBinarize { get { return autoBinarize; } set { autoBinarize = value; } }
            public string Values_AutoBinarize { get { return values_AutoBinarize; } set { values_AutoBinarize = value; } }
            public string Despeckle { get { return despeckle; } set { despeckle = value; } }
            public string Values_despeckle { get { return values_despeckle; } set { values_despeckle = value; } }
            public string DynamicBinary { get { return dynamicBinary; } set { dynamicBinary = value; } }
            public string Values_dynamicBinary { get { return values_dynamicBinary; } set { values_dynamicBinary = value; } }
            public string L_dimension { get { return l_dimension; } set { l_dimension = value; } }
            public string Values_dimension { get { return values_dimension; } set { values_dimension = value; } }
            public string L_localcontrast { get { return l_localcontrast; } set { l_localcontrast = value; } }
            public string Values_localcontrast { get { return values_localcontrast; } set { values_localcontrast = value; } }
            public string L_binaryfilter { get { return l_binaryfilter; } set { l_binaryfilter = value; } }
            public string Values_binaryfilter { get { return values_binaryfilter; } set { values_binaryfilter = value; } }
            public string DotRemove { get { return dotRemove; } set { dotRemove = value; } }
            public string Values_dotremove { get { return values_dotremove; } set { values_dotremove = value; } }
            public string L_maximumdotH { get { return l_maximumdotH; } set { l_maximumdotH = value; } }
            public string Values_maximumdotH { get { return values_maximumdotH; } set { values_maximumdotH = value; } }
            public string L_maximumdotW { get { return l_maximumdotW; } set { l_maximumdotW = value; } }
            public string Values_lmaximumdotW { get { return values_lmaximumdotW; } set { values_lmaximumdotW = value; } }
            public string L_minimumdotH { get { return l_minimumdotH; } set { l_minimumdotH = value; } }
            public string Values_l_minimumdotH { get { return values_minimumdotH; } set { values_minimumdotH = value; } }
            public string L_minimumdotW { get { return l_minimumdotW; } set { l_minimumdotW = value; } }
            public string Values_minimumdotW { get { return values_minimumdotW; } set { values_minimumdotW = value; } }
            public string LineRemove { get { return lineRemove; } set { lineRemove = value; } }
            public string Values_lineRemove { get { return values_lineRemove; } set { values_lineRemove = value; } }
            public string L_gaplength { get { return l_gaplength; } set { l_gaplength = value; } }
            public string Values_gaplength { get { return values_gaplength; } set { values_gaplength = value; } }
            public string L_maximumlineW { get { return l_maximumlineW; } set { l_maximumlineW = value; } }
            public string Values_maximumlineW { get { return values_maximumlineW; } set { values_maximumlineW = value; } }
            public string L_minimumlineL { get { return l_minimumlineL; } set { l_minimumlineL = value; } }
            public string Values_minimumlineL { get { return values_minimumlineL; } set { values_minimumlineL = value; } }
            public string L_maximumwall { get { return l_maximumwall; } set { l_maximumwall = value; } }
            public string Values_maximumwall { get { return values_maximumwall; } set { values_maximumwall = value; } }
            public string L_wall { get { return l_wall; } set { l_wall = value; } }
            public string Values_wall { get { return values_wall; } set { values_wall = value; } }
            public string HolePunchRemove { get { return holePunchRemove; } set { holePunchRemove = value; } }
            public string Values_holePunchRemove { get { return values_holePunchRemove; } set { values_holePunchRemove = value; } }
            public string L_maximumhole { get { return l_maximumhole; } set { l_maximumhole = value; } }
            public string Values_maximumhole { get { return values_maximumhole; } set { values_maximumhole = value; } }
            public string L_minimumhole { get { return l_minimumhole; } set { l_minimumhole = value; } }
            public string Values_minimumhole { get { return values_minimumhole; } set { values_minimumhole = value; } }
            public string InvertedText { get { return invertedText; } set { invertedText = value; } }
            public string Values_invertedText { get { return values_invertedText; } set { values_invertedText = value; } }
            public string L_maximumblack { get { return l_maximumblack; } set { l_maximumblack = value; } }
            public string Values_maximumblack { get { return values_maximumblack; } set { values_maximumblack = value; } }
            public string L_minimumBlack { get { return l_minimumBlack; } set { l_minimumBlack = value; } }
            public string Values_minimumBlack { get { return values_minimumBlack; } set { values_minimumBlack = value; } }
            public string L_minimuminverH { get { return l_minimuminverH; } set { l_minimuminverH = value; } }
            public string Values_minimuminverH { get { return values_minimuminverH; } set { values_minimuminverH = value; } }
            public string L_minimuminvertW { get { return l_minimuminvertW; } set { l_minimuminvertW = value; } }
            public string Values_minimuminvertW { get { return values_minimuminvertW; } set { values_minimuminvertW = value; } }
            public string AutoCrop { get { return autoCrop; } set { autoCrop = value; } }
            public string Values_autoCrop { get { return values_autoCrop; } set { values_autoCrop = value; } }
            public string L_cropThreshold { get { return l_cropThreshold; } set { l_cropThreshold = value; } }
            public string Values_cropThreshold { get { return values_cropThreshold; } set { values_cropThreshold = value; } }
            public string BorderRemove { get { return borderRemove; } set { borderRemove = value; } }
            public string Values_borderRemove { get { return values_borderRemove; } set { values_borderRemove = value; } }
            public string L_percent { get { return l_percent; } set { l_percent = value; } }
            public string Values_percent { get { return values_percent; } set { values_percent = value; } }
            public string L_variance { get { return l_variance; } set { l_variance = value; } }
            public string Values_variance { get { return values_variance; } set { values_variance = value; } }
            public string L_whitenoiseL { get { return l_whitenoiseL; } set { l_whitenoiseL = value; } }
            public string Values_whitenoiseL { get { return values_whitenoiseL; } set { values_whitenoiseL = value; } }
            public string Smooth { get { return smooth; } set { smooth = value; } }
            public string Values_smooth { get { return values_smooth; } set { values_smooth = value; } }
            public string L_length { get { return l_length; } set { l_length = value; } }
            public string Values_length { get { return values_length; } set { values_length = value; } }
            public string AutoColorLevel { get { return autoColorLevel; } set { autoColorLevel = value; } }
            public string Values_autoColorLevel { get { return values_autoColorLevel; } set { values_autoColorLevel = value; } }
            public string AutoBinary { get { return autoBinary; } set { autoBinary = value; } }
            public string Values_autoBinary { get { return values_autoBinary; } set { values_autoBinary = value; } }
            public string Maximum { get { return maximum; } set { maximum = value; } }
            public string Values_maximum { get { return values_maximum; } set { values_maximum = value; } }
            public string L_maximum { get { return l_maximum; } set { l_maximum = value; } }
            public string Values_lmaximum { get { return values_lmaximum; } set { values_lmaximum = value; } }
            public string Minimum { get { return minimum; } set { minimum = value; } }
            public string Values_minimum { get { return values_minimum; } set { values_minimum = value; } }
            public string L_minimum { get { return l_minimum; } set { l_minimum = value; } }
            public string Values_lminimum { get { return values_lminimum; } set { values_lminimum = value; } }
            public string Gamma { get { return gamma; } set { gamma = value; } }
            public string Values_gamma { get { return values_gamma; } set { values_gamma = value; } }
            public string L_gamma { get { return l_gamma; } set { l_gamma = value; } }
            public string Values_lgamma { get { return values_lgamma; } set { values_lgamma = value; } }
            public string AutoDeskew { get { return autoDeskew; } set { autoDeskew = value; } }
            public string Values_autoDeskew { get { return values_autoDeskew; } set { values_autoDeskew = value; } }
            public string UseFlipRotateImage { get { return useFlipRotateImage; } set { useFlipRotateImage = value; } }
            public string Values_useFlipRotateImage { get { return values_useFlipRotateImage; } set { values_useFlipRotateImage = value; } }
            public string L_RotateImage { get { return l_RotateImage; } set { l_RotateImage = value; } }
            public string Values_RotateImage { get { return values_RotateImage; } set { values_RotateImage = value; } }
            public string UseRakeRemove { get { return useRakeRemove; } set { useRakeRemove = value; } }
            public string Values_useRakeRemove { get { return values_useRakeRemove; } set { values_useRakeRemove = value; } }
            public string L_numUpDown1 { get { return l_numUpDown1; } set { l_numUpDown1 = value; } }
            public string Values_numUpDown1 { get { return values_numUpDown1; } set { values_numUpDown1 = value; } }
            public string L_numUpDown2 { get { return l_numUpDown2; } set { l_numUpDown2 = value; } }
            public string Values_numUpDown2 { get { return values_numUpDown2; } set { values_numUpDown2 = value; } }
            public string L_numUpDown3 { get { return l_numUpDown3; } set { l_numUpDown3 = value; } }
            public string Values_numUpDown3 { get { return values_numUpDown3; } set { values_numUpDown3 = value; } }
            public string L_numUpDown4 { get { return l_numUpDown4; } set { l_numUpDown4 = value; } }
            public string Values_numUpDown4 { get { return values_numUpDown4; } set { values_numUpDown4 = value; } }
            public string L_numUpDown5 { get { return l_numUpDown5; } set { l_numUpDown5 = value; } }
            public string Values_numUpDown5 { get { return values_numUpDown5; } set { values_numUpDown5 = value; } }
            public string L_numUpDown6 { get { return l_numUpDown6; } set { l_numUpDown6 = value; } }
            public string Values_numUpDown6 { get { return values_numUpDown6; } set { values_numUpDown6 = value; } }
            public string L_numUpDown7 { get { return l_numUpDown7; } set { l_numUpDown7 = value; } }
            public string Values_numUpDown7 { get { return values_numUpDown7; } set { values_numUpDown7 = value; } }
            public string L_numUpDown8 { get { return l_numUpDown8; } set { l_numUpDown8 = value; } }
            public string Values_numUpDown8 { get { return values_numUpDown8; } set { values_numUpDown8 = value; } }
            public string L_numUpDown9 { get { return l_numUpDown9; } set { l_numUpDown9 = value; } }
            public string Values_numUpDown9 { get { return values_numUpDown9; } set { values_numUpDown9 = value; } }
            public string AutoFilter { get { return autoFilter; } set { autoFilter = value; } }
            public string Values_autoFilter { get { return values_autoFilter; } set { values_autoFilter = value; } }
            public string Convert1bit { get { return convert1bit; } set { convert1bit = value; } }
            public string Values_convert1bit { get { return values_convert1bit; } set { values_convert1bit = value; } }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                chckbox = true;
                Display(); Image();
            }
            else
            {
                chckbox = false;
                Display(); Image();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                chckbox2 = true;
                Display(); Image();
            }
            else
            {
                chckbox2 = false;
                Display(); Image();
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
            Display(); Image();
        }

        private void trackBar8_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar9_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }
        private bool Expanded = false;
        private void btnConBrigtIntens_Click(object sender, EventArgs e)
        {
            if (Expanded)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;
                panConBrigtIntens.Height = 28;
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
                panUnsharpMask.Height = 28;
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
                Display(); Image();
            }
            else
            {
                chckbox3 = false;
                Display(); Image();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                chckbox4 = true;
                Display(); Image();
            }
            else
            {
                chckbox4 = false;
                Display(); Image();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                chckbox5 = true;
                Display(); Image();
            }
            else
            {
                chckbox5 = false;
                Display(); Image();
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                chckbox6 = true;
                Display(); Image();
            }
            else
            {
                chckbox6 = false;
                Display(); Image();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                chckbox7 = true;
                Display(); Image();
            }
            else
            {
                chckbox7 = false;
                Display(); Image();
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                chckbox8 = true;
                Display(); Image();
            }
            else
            {
                chckbox8 = false;
                Display(); Image();
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                chckbox9 = true;
                Display(); Image();
            }
            else
            {
                chckbox9 = false;
                Display(); Image();
            }
        }

        private void trbDynBin1_Scroll(object sender, EventArgs e)
        {
            value_trbDynBin1 = trbDynBin1.Value;
            l_dimension.Text = value_trbDynBin1.ToString();
        }

        private void trbDynBin2_Scroll(object sender, EventArgs e)
        {
            value_trbDynBin2 = trbDynBin2.Value;
            l_localcontrast.Text = value_trbDynBin2.ToString();
        }

        private void trbDynBin1_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trbDynBin2_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
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
            Display(); Image();
        }

        private void trbMinimum_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trbGamma_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
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
                Display(); Image();
            }
            else
            {
                chckbox10 = false;
                Display(); Image();
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                chckbox11 = true;
                Display(); Image();
            }
            else
            {
                chckbox11 = false;
                Display(); Image();
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                chckbox12 = true;
                Display(); Image();
            }
            else
            {
                chckbox12 = false;
                Display(); Image();
            }
        }
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                chckbox13 = true;
                Display(); Image();
            }
            else
            {
                chckbox13 = false;
                Display(); Image();
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                chckbox14 = true;
                Display(); Image();
            }
            else
            {
                chckbox14 = false;
                Display(); Image();
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                chckbox15 = true;
                Display(); Image();
            }
            else
            {
                chckbox15 = false;
                Display(); Image();
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                chckbox16 = true;
                Display(); Image();
            }
            else
            {
                chckbox16 = false;
                Display(); Image();
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                chckbox17 = true;
                Display(); Image();
            }
            else
            {
                chckbox17 = false;
                Display(); Image();
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
                panLineRemove.Height = 30;
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
            Display(); Image();
        }

        private void trackBar11_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar12_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar13_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
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
            Display(); Image();
        }

        private void trackBar15_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar16_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar17_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar22_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
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
            Display(); Image();
        }

        private void trackBar21_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
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
            Display(); Image();
        }

        private void trackBar20_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar23_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar24_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar27_Scroll(object sender, EventArgs e)
        {
            value_trackBar27 = trackBar27.Value;
            l_cropThreshold.Text = value_trackBar27.ToString();
        }

        private void trackBar27_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
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
            Display(); Image();
        }

        private void trackBar26_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar28_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void trackBar31_Scroll(object sender, EventArgs e)
        {
            value_trackBar31 = trackBar31.Value;
            l_length.Text = value_trackBar31.ToString();
        }

        private void trackBar31_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                chckbox18 = true;
                Display(); Image();
            }
            else
            {
                chckbox18 = false;
                Display(); Image();
            }
        }

        private void trackBar29_Scroll(object sender, EventArgs e)
        {
            value_trackBar29 = trackBar29.Value;
            l_RotateImage.Text = value_trackBar29.ToString();
        }

        private void trackBar29_MouseCaptureChanged(object sender, EventArgs e)
        {
            Display(); Image();
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                chckbox19 = true;
                Display(); Image();
            }
            else
            {
                chckbox19 = false;
                Display(); Image();
            }
        }
        private bool Expanded12;
        private void btnFlipRotate_Click(object sender, EventArgs e)
        {
            if (Expanded12)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panFlipRotate.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panFlipRotate.Height = 122;
            }
            Expanded12 = !Expanded12;
        }
        private bool Expanded13;
        private void btnRakeRemove_Click(object sender, EventArgs e)
        {
            if (Expanded13)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panRakeRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panRakeRemove.Height = 347;
            }
            Expanded13 = !Expanded13;
        }
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                chckbox20 = true;
                Display(); Image();
            }
            else
            {
                chckbox20 = false;
                Display(); Image();
            }
        }

        private void numUpDown1_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown1 = (int)numUpDown1.Value;
            Display(); Image();
        }

        private void numUpDown2_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown2 = (int)numUpDown2.Value;
            Display(); Image();
        }

        private void numUpDown3_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown3 = (int)numUpDown3.Value;
            Display(); Image();
        }

        private void numUpDown4_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown4 = (int)numUpDown4.Value;
            Display(); Image();
        }

        private void numUpDown5_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown5 = (int)numUpDown5.Value;
            Display(); Image();
        }

        private void numUpDown6_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown6 = (int)numUpDown6.Value;
            Display(); Image();
        }

        private void numUpDown7_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown7 = (int)numUpDown7.Value;
            Display(); Image();
        }

        private void numUpDown8_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown8 = (int)numUpDown8.Value;
            Display(); Image();
        }

        private void numUpDown9_ValueChanged(object sender, EventArgs e)
        {
            value_numUpDown9 = (int)numUpDown9.Value;
            Display(); Image();
        }

        private void btnResetConBrigtIntens_Click(object sender, EventArgs e)
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
            Display(); Image();
        }

        private void btnResetUnsharpMask_Click(object sender, EventArgs e)
        {
            value_trackBar4 = 1;
            trackBar4.Value = value_trackBar4;
            l_amount.Text = value_trackBar4.ToString();
            value_trackBar5 = 1;
            trackBar5.Value = value_trackBar5;
            l_radius.Text = value_trackBar5.ToString();
            value_trackBar6 = 1;
            trackBar6.Value = value_trackBar6;
            l_threshold.Text = value_trackBar6.ToString();
            Display(); Image();
        }

        private void btnResetGrayScale_Click(object sender, EventArgs e)
        {
            chckbox2 = false;
            checkBox2.Checked = false;
            value_trackBar7 = 500;
            trackBar7.Value = value_trackBar7;
            l_redfactor.Text = value_trackBar7.ToString();
            value_trackBar8 = 250;
            trackBar8.Value = value_trackBar8;
            l_greenfactor.Text = value_trackBar8.ToString();
            value_trackBar9 = 250;
            trackBar9.Value = value_trackBar9;
            l_bluefactor.Text = value_trackBar9.ToString();
            Display(); Image();
        }

        private void btnResetDocImgClupFnct_Click(object sender, EventArgs e)
        {
            chckbox7 = false;
            checkBox7.Checked = chckbox7;
            chckbox3 = false;
            checkBox3.Checked = chckbox3;
            chckbox9 = false;
            checkBox9.Checked = chckbox9;
            value_trbDynBin1 = 8;
            trbDynBin1.Value = value_trbDynBin1;
            l_dimension.Text = value_trbDynBin1.ToString();
            value_trbDynBin2 = 16;
            trbDynBin2.Value = value_trbDynBin2;
            l_localcontrast.Text = value_trbDynBin2.ToString();
            selectCombobox = 0;
            comboBox1.SelectedIndex = selectCombobox;
            chckbox14 = false;
            checkBox14.Checked = chckbox14;
        }

        private void btnResetDotRemove_Click(object sender, EventArgs e)
        {
            chckbox10 = false;
            checkBox10.Checked = chckbox10;
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
            Display(); Image();
        }

        private void btnResetLineRemove_Click(object sender, EventArgs e)
        {
            chckbox11 = false;
            checkBox11.Checked = chckbox11;
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
        }

        private void btnResetHolePunchRemove_Click(object sender, EventArgs e)
        {
            chckbox12 = false;
            checkBox12.Checked = chckbox12;
            value_trackBar18 = 4;
            trackBar18.Value = value_trackBar18;
            l_maximumhole.Text = value_trackBar18.ToString();
            value_trackBar21 = 2;
            trackBar21.Value = value_trackBar21;
            l_minimumhole.Text = value_trackBar21.ToString();
            Display(); Image();
        }

        private void btnResetInvertedText_Click(object sender, EventArgs e)
        {
            chckbox13 = false;
            checkBox13.Checked = chckbox13;
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
            Display(); Image();
        }

        private void btnResetAutoCrop_Click(object sender, EventArgs e)
        {
            chckbox15 = false;
            checkBox15.Checked = chckbox15;
            value_trackBar27 = 20;
            trackBar27.Value = value_trackBar27;
            l_cropThreshold.Text = value_trackBar27.ToString();
            Display(); Image();
        }

        private void btnResetBorderRemove_Click(object sender, EventArgs e)
        {
            chckbox16 = false;
            checkBox16.Checked = chckbox16;
            value_trackBar25 = 20;
            trackBar25.Value = value_trackBar25;
            l_percent.Text = value_trackBar25.ToString();
            value_trackBar26 = 3;
            trackBar26.Value = value_trackBar26;
            l_variance.Text = value_trackBar26.ToString();
            value_trackBar28 = 9;
            trackBar28.Value = value_trackBar28;
            l_whitenoiseL.Text = value_trackBar28.ToString();
            Display(); Image();
        }

        private void btnResetSmooth_Click(object sender, EventArgs e)
        {
            chckbox17 = false;
            checkBox17.Checked = chckbox17;
            value_trackBar31 = 2;
            trackBar31.Value = value_trackBar31;
            l_length.Text = value_trackBar31.ToString();
            Display(); Image();
        }

        private void btnResetFlipRotate_Click(object sender, EventArgs e)
        {
            chckbox18 = false;
            checkBox18.Checked = chckbox18;
            value_trackBar29 = 0;
            trackBar29.Value = value_trackBar29;
            l_RotateImage.Text = value_trackBar29.ToString();
            Display(); Image();
        }

        private void btnResetRakeRemove_Click(object sender, EventArgs e)
        {
            chckbox19 = false;
            checkBox19.Checked = chckbox19;
            value_numUpDown1 = 50;
            numUpDown1.Value = value_numUpDown1;
            value_numUpDown2 = 10;
            numUpDown2.Value = value_numUpDown2;
            value_numUpDown3 = 3;
            numUpDown3.Value = value_numUpDown3;
            value_numUpDown4 = 25;
            numUpDown4.Value = value_numUpDown4;
            value_numUpDown5 = 60;
            numUpDown5.Value = value_numUpDown5;
            value_numUpDown6 = 50;
            numUpDown6.Value = value_numUpDown6;
            value_numUpDown7 = 1;
            numUpDown7.Value = value_numUpDown7;
            value_numUpDown8 = 1;
            numUpDown8.Value = value_numUpDown8;
            value_numUpDown9 = 5;
            numUpDown9.Value = value_numUpDown9;
            chckbox20 = false;
            checkBox20.Checked = chckbox20;
            Display(); Image();
        }
        private bool Expanded14;
        private void btnMaxiMini_Click(object sender, EventArgs e)
        {
            if (Expanded14)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panMaxiMini.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panMaxiMini.Height = 323;
            }
            Expanded14 = !Expanded14;
        }

        private void btnResetMaxiMini_Click(object sender, EventArgs e)
        {
            chckbox = false;
            checkBox1.Checked = chckbox;
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
            chckbox8 = false;
            checkBox8.Checked = chckbox8;
            value_trbGamma = 310;
            trbGamma.Value = value_trbGamma;
            l_gamma.Text = value_trbGamma.ToString();
            Display(); Image();
        }

        public void cbBox2re()
        {
            /*comboBox2.Items.Clear();
            comboBox2.Items.Add("Default");
            String rfile;
            StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt");
            while ((rfile = streamread.ReadLine()) != null)
            {
                // textBox1.Text += rfile + "\r\n";
                comboBox2.Items.Add(rfile);

            }
            streamread.Close();
            comboBox2.SelectedItem = "Default";*/
            /*  if (System.IO.File.Exists(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\*.txt"))//ถ้าเจอไฟล์
              {*/
            cbboxUseProfile.Items.Clear();
            cbboxUseProfile.Items.Add("Default");
            if (System.IO.File.Exists(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt")) { 
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile");
            foreach (var fi in di.GetFiles("*.txt"))
            {
                //Console.WriteLine(fi.Name);
                string[] nm = fi.Name.Split('.');
                Console.WriteLine(nm[0]);
                    cbboxUseProfile.Items.Add(nm[0]);
            }
                cbboxUseProfile.SelectedItem = "Default";
            //}
            }
        }

       /* protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                //pictureBox1.Image = null;
                // ซูมอิน (เพิ่มขนาดภาพ)
                if (picOutput.Width < 4500 || picOutput.Width < 4500)
                { //กำหนดขอบเขตการขยายภาพ
                    picOutput.Width += (int)(picOutput.Width * 0.1);
                    picOutput.Height += (int)(picOutput.Height * 0.1);
                }
            }
            else if (e.Delta < 0)
            {
                //pictureBox1.Image = null;
                // ซูมเอาท์ (ลดขนาดภาพ)
                if (picOutput.Width > 400 || picOutput.Width > 400)
                { //กำหนดขอบเขตการลดภาพ
                    picOutput.Width -= (int)(picOutput.Width * 0.1);
                    picOutput.Height -= (int)(picOutput.Height * 0.1);
                }
            }
            //l_zoom.Text = "w " + pictureBox1.Width.ToString() + " h" + pictureBox1.Height.ToString();
        }*/
        int xPos;
        int yPos;
        bool Dragging;
        private void picOutput_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void picOutput_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging = true;
                xPos = e.X;
                yPos = e.Y;
            }
        }

        private void picOutput_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (Dragging && c != null)
            {
                c.Top = e.Y + c.Top - yPos;
                c.Left = e.X + c.Left - xPos;

                Console.WriteLine("c.Top " + c.Top.ToString());
                Console.WriteLine("c.Left " + c.Left.ToString());
            }
        }

        public List<RasterImage> imagescol = new List<RasterImage>();
        public int pageCount;
        String[] file;
        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            RasterCodecs codecs = new RasterCodecs();
            codecs.ThrowExceptionsOnInvalidImages = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All File |*.*";
            DialogResult dr = ofd.ShowDialog();
            int page = 0;

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                imagescol.Clear();
                crepic(); //สร้าง picReview
                //progressBar1.Value = 0;
                splitContainer1.Panel1.Controls.Clear();
                file = ofd.FileNames;
                /* int x = 20;//ระวหว่าง panel
                 int y = 20;//ระวหว่าง panel
                 int maxWidth = -1;*/
                /**/
                //int w = 170 / 2;
                // int w = 420 / 2;
                //int x3 = (splitContainer1.Panel2.Width / 2) - w;
                int w2 = 160 / 2;
                int x2 = (splitContainer1.Panel1.Width / 2) - w2;
                //int x3 = 40;//ระวหว่าง panel
                int y2 = 20;//ระวหว่าง panel
                int maxWidth2 = -1;
                RasterCodecs _rasterCodecs = new RasterCodecs();
                //Load documents at 300 DPI for better viewing
                _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
                /**/
                // int pageCount;
                foreach (string img in file)
                {
                    /**/
                    using (var imageInfo = _rasterCodecs.GetInformation(img, true)) //นับจำนวนเอกสาร
                    {
                        pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                    }
                    Console.WriteLine("Page " + pageCount);
                    
                    // Loads all the pages into the viewer
                    for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                    {
                        //progressBar1.Value += (pageCount * 100) / 1000;
                        //await Task.Delay(1000);
                        // Load it as a raster image and add it
                        _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
                        _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
                        _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
                        _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
                        _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
                        var rasterImage = _rasterCodecs.Load(img, pageNumber);
                        l_numberPages.Text = "Page " + pageNumber + " / " + pageCount.ToString();
                        l_stateInput.Text = "Image " + rasterImage.BitsPerPixel.ToString() + " BitsPerPixel";
                        //this._imageViewer.Items.AddFromImage(rasterImage, 1);
                        //Label la = new Label();
                        PictureBox pic2 = new PictureBox();
                        pic2.Height = 180;
                        pic2.Width = 160;
                        //selectImage = pageNumber.ToString();
                        //pic2.Location = new Point(x2, y2);
                        pic2.Location = new Point(x2, y2 + splitContainer1.Panel1.AutoScrollPosition.Y); //แก้ปัญหาการวางผิดตำแหน่ง
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic2.BorderStyle = BorderStyle.FixedSingle;
                        pic2.Name = pageNumber.ToString();
                        y2 += pic2.Height + 10;
                        maxWidth2 = Math.Max(pic2.Height, maxWidth2);
                        if (x2 > this.ClientSize.Width - 100)
                        {
                            y2 = 20;
                            x2 += maxWidth2 + 100;
                        }
                        //this.panelImage.Controls.Add(pic2);
                        this.splitContainer1.Panel1.Controls.Add(pic2);

                        using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                        {
                            pic2.Image = new Bitmap(destImage1);
                        }
                        imagescol.Add(rasterImage);

                        /* la.Width = 10;
                         la.Height = 15;
                         la.BackColor = Color.White;
                         la.Location = new Point((splitContainer1.Panel1.Width / 2) - la.Width, y2+splitContainer1.Panel1.AutoScrollPosition.Y);
                         la.Text = pageNumber.ToString();
                         this.splitContainer1.Panel1.Controls.Add(la);*/
                        //Console.WriteLine(pic2.Location.X.ToString() + pic2.Location.Y.ToString());
                        Console.WriteLine(pic2.Name);
                        pic2.MouseClick += new MouseEventHandler(pic2_MouseClick);
                        await Task.Delay(1000);
                    }
                   // progressBar1.Value = 0;
                   // chang();
                    /*using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[0], ConvertToImageOptions.None))
                    {
                        pic2.Image = new Bitmap(destImage1);
                    }*/
                }
            }
            
        }

        public void disp() {
            PictureBox picReview2 = new PictureBox();
            picReview2.Height = 600; //ความกว้างหน้ากระดาษ
            picReview2.Width = 420;  //ความสูงหน้ากระดาษ
            picReview2.Location = new Point((splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2), 20);
            picReview2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.splitContainer1.Panel2.Controls.Add(picReview2);
           /* using (Image destImage1 = RasterImageConverter.ConvertToImage(Image(), ConvertToImageOptions.None))
            {
                picReview2.Image = new Bitmap(destImage1);
            }*/
        }
        int pdname;
        RasterCodecs _rasterCodecs = new RasterCodecs();
        PictureBox picReview2 = new PictureBox();
        //RasterImage rasterImage;
       // RasterImage destImage;
        public void crepic() {
            this.splitContainer1.Panel2.Controls.Clear();
            picReview2.Height = 700; //ความกว้างหน้ากระดาษ
            picReview2.Width = 520;  //ความสูงหน้ากระดาษ
            picReview2.Location = new Point((splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2), 20);
            picReview2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.splitContainer1.Panel2.Controls.Add(picReview2);
            picReview2.ImageLocation = null;
        }
        public void ImageChange() {
            //รับไฟล์ที่กำลังแสดงผลลัพธ์การปรับแต่งในฟังก์ชัน Image();
            //ทำงานเมื่อมีการปรับแต่ง
           // rasterImage = _rasterCodecs.Load(img, pdname);

           /* ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
            //Increase the brightness by 25 percent  of the possible range. 
            command.Brightness = value_trackBar1;   //484
            command.Contrast = value_trackBar2;     //394
            command.Intensity = value_trackBar3;    //118
            command.Run(rasterImage);

            using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
            {
                picReview2.Image = new Bitmap(destImage1);
            }*/
        }
        public async void Image() { //***ส่งดึงไฟล์จากในนี้แล้วไปแสดงผลลัพธ์การปรับแต่ง (ไฟล์จะถูกเลือกในนี้ก่อน)
                                    //ภาพเปลี่ยนเมื่อคลิก

            //l_stateInput.Text = "Image " + rasterImage.BitsPerPixel.ToString() + " BitsPerPixel";
            /* picReview2.Height = 700; //ความกว้างหน้ากระดาษ
             picReview2.Width = 520;  //ความสูงหน้ากระดาษ
             picReview2.Location = new Point((splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2), 20);
             picReview2.SizeMode = PictureBoxSizeMode.StretchImage;
             this.splitContainer1.Panel2.Controls.Add(picReview2);*/
            _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
            foreach (string img in file){
                Console.WriteLine("Page " + pageCount);
                l_numberPages.Text = pageCount.ToString() + " Page";
                // Loads all the pages into the viewer

                // Load it as a raster image and add it
                // CodecsPdfOptions & CodecsPdfLoadOptions reference 
                _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
                _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
                _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
                _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
                _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
                RasterImage rasterImage = _rasterCodecs.Load(img, pdname);

                ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
                //Increase the brightness by 25 percent  of the possible range. 
                command.Brightness = value_trackBar1;   //484
                command.Contrast = value_trackBar2;     //394
                command.Intensity = value_trackBar3;    //118
                command.Run(rasterImage);

                UnsharpMaskCommand command2 = new UnsharpMaskCommand();
                command2.Amount = value_trackBar4;     //rate 0 - เกิน 1000
                command2.Radius = value_trackBar5;     //rate 1 - เกิน 1000
                command2.Threshold = value_trackBar6;  //rate 0 - 255
                command2.ColorType = UnsharpMaskCommandColorType.Rgb;
                command2.Run(rasterImage);

                if (selectCombobox == 0) { }
                else
                {
                    selectCombobox = selectCombobox - 1;
                    //MessageBox.Show(selectCombobox.ToString());
                    BinaryFilterCommand command3 = new BinaryFilterCommand((BinaryFilterCommandPredefined)selectCombobox);
                    command3.Run(rasterImage);
                }

                if (chckbox == true)
                {
                    AutoColorLevelCommand command4 = new AutoColorLevelCommand();
                    command4.Run(rasterImage);
                }

                if (chckbox2 == true)
                {
                    GrayScaleExtendedCommand command5 = new GrayScaleExtendedCommand();
                    command5.RedFactor = value_trackBar7;
                    command5.GreenFactor = value_trackBar8;
                    command5.BlueFactor = value_trackBar9;
                    command5.Run(rasterImage);
                }

                if (chckbox4 == true)
                {
                    AutoBinaryCommand command7 = new AutoBinaryCommand();
                    //Apply Auto Binary Segment. 
                    command7.Run(rasterImage);
                }

                if (chckbox5 == true)
                {
                    MaximumCommand command8 = new MaximumCommand();
                    //Apply Maximum filter. 
                    command8.Dimension = value_trbMaximum;
                    command8.Run(rasterImage);
                }

                if (chckbox6 == true)
                {
                    MinimumCommand command9 = new MinimumCommand();
                    //Apply the Minimum filter. 
                    command9.Dimension = value_trbMinimum;
                    command9.Run(rasterImage);
                }

                if (chckbox7 == true)
                {
                    AutoBinarizeCommand command10 = new AutoBinarizeCommand();
                    command10.Run(rasterImage);
                }

                if (chckbox8 == true)
                {
                    GammaCorrectCommand command11 = new GammaCorrectCommand();
                    //Set a gamma value of 2.5. 
                    command11.Gamma = value_trbGamma;
                    command11.Run(rasterImage);
                }
                if (chckbox9 == true)
                {
                    DynamicBinaryCommand command12 = new DynamicBinaryCommand();
                    command12.Dimension = value_trbDynBin1;
                    command12.LocalContrast = value_trbDynBin2;
                    // convert it into a black and white image without changing its bits per pixel. 
                    command12.Run(rasterImage);
                }
                if (chckbox14 == true)
                {
                    DeskewCommand command16 = new DeskewCommand();
                    //Deskew the image. 
                    command16.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea;
                    command16.Run(rasterImage);
                }
                if (chckbox15 == true)
                {
                    AutoCropCommand command17 = new AutoCropCommand();
                    //AutoCrop the image with 20 tolerance. 
                    command17.Threshold = value_trackBar27;
                    command17.Run(rasterImage);
                }
                if (chckbox3 == true)
                {
                    DespeckleCommand command6 = new DespeckleCommand();
                    //Remove speckles from the image. 
                    command6.Run(rasterImage);
                }
                if (chckbox18 == true)
                {
                    FlipCommand flip = new FlipCommand(false);
                    RunCommand(rasterImage, flip);
                    // rotate the image by 45 degrees 
                    RotateCommand rotate = new RotateCommand();
                    rotate.Angle = (value_trackBar29 * 100);
                    rotate.FillColor = RasterColor.FromKnownColor(RasterKnownColor.White);
                    rotate.Flags = RotateCommandFlags.Resize;
                    RunCommand(rasterImage, rotate);
                }
                if (chckbox21 == true){
                   RasterImage destImage = new RasterImage(
                   RasterMemoryFlags.Conventional,
                   rasterImage.Width,
                   rasterImage.Height,
                    1,
                   rasterImage.Order,
                   rasterImage.ViewPerspective,
                   rasterImage.GetPalette(),
                   IntPtr.Zero,
                   0);
                    int bufferSize = RasterBufferConverter.CalculateConvertSize(
                       rasterImage.Width,
                       rasterImage.BitsPerPixel,
                       destImage.Width,
                       destImage.BitsPerPixel);

                    // Allocate the buffer in unmanaged memory 
                    IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
                    //Assert.IsFalse(buffer == IntPtr.Zero);

                    // Process each row from srcImage to destImage. 
                    rasterImage.Access();
                    destImage.Access();
                    for (int ii = 0; ii < rasterImage.Height; ii++)
                    {
                        rasterImage.GetRow(ii, buffer, rasterImage.BytesPerLine);
                        RasterBufferConverter.Convert(
                        buffer,
                           rasterImage.Width,
                           rasterImage.BitsPerPixel,
                           destImage.BitsPerPixel,
                           rasterImage.Order,
                           destImage.Order,
                           null,
                           null,
                           0,
                           8,
                           0,
                           RasterConvertBufferFlags.None);
                        destImage.SetRow(ii, buffer, destImage.BytesPerLine);
                    }

                    destImage.Release();
                    rasterImage.Release();

                    // Clean up 
                    Marshal.FreeHGlobal(buffer);

                    if (chckbox11 == true)
                    {
                        LineRemoveCommand command13 = new LineRemoveCommand();
                        command13.LineRemove += new EventHandler<LineRemoveCommandEventArgs>(LineRemoveEvent_S1);
                        command13.Type = LineRemoveCommandType.Horizontal;
                        //command13.Type = LineRemoveCommandType.Vertical;
                        command13.Flags = LineRemoveCommandFlags.UseGap;
                        command13.GapLength = value_trackBar14;
                        command13.MaximumLineWidth = value_trackBar15;
                        command13.MinimumLineLength = value_trackBar16;
                        command13.MaximumWallPercent = value_trackBar17;
                        command13.Wall = value_trackBar22;
                        command13.Run(destImage);

                        /*LineRemoveCommand commandc = new LineRemoveCommand();
                        commandc.LineRemove += new EventHandler<LineRemoveCommandEventArgs>(LineRemoveEvent_S1);
                        commandc.Type = LineRemoveCommandType.Vertical;
                        //command13.Type = LineRemoveCommandType.Vertical;
                        commandc.Flags = LineRemoveCommandFlags.UseGap;
                        commandc.GapLength = value_trackBar14;
                        commandc.MaximumLineWidth = value_trackBar15;
                        commandc.MinimumLineLength = value_trackBar16;
                        commandc.MaximumWallPercent = value_trackBar17;
                        commandc.Wall = value_trackBar22;
                        commandc.Run(destImage);*/
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
                        command13.Run(destImage);
                    }

                    if (chckbox12 == true)
                    {
                        HolePunchRemoveCommand command14 = new HolePunchRemoveCommand();
                        command14.HolePunchRemove += new EventHandler<HolePunchRemoveCommandEventArgs>(HolePunchRemoveEvent_S1);
                        command14.Flags = HolePunchRemoveCommandFlags.UseDpi | HolePunchRemoveCommandFlags.UseCount | HolePunchRemoveCommandFlags.UseLocation;
                        command14.Location = HolePunchRemoveCommandLocation.Left;
                        command14.MaximumHoleCount = value_trackBar18;
                        command14.MinimumHoleCount = value_trackBar21;
                        command14.Run(destImage);
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
                        command15.Run(destImage);
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
                        command18.Run(destImage);
                    }

                    if (chckbox17 == true)
                    {
                        SmoothCommand command19 = new SmoothCommand();
                        command19.Smooth += new EventHandler<SmoothCommandEventArgs>(SmoothEventExample_S1);
                        command19.Flags = SmoothCommandFlags.FavorLong;
                        command19.Length = value_trackBar31;
                        command19.Run(destImage);
                    }
                    //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\poc\image", "Result7.tif"), RasterImageFormat.Tif, 1);
                    // Prepare the command 
                    if (chckbox19 == true)
                    {
                        RakeRemoveCommand command20 = new RakeRemoveCommand();
                        command20.RakeRemove += new EventHandler<RakeRemoveCommandEventArgs>(RakeRemoveEvent_S1);
                        command20.MinLength = value_numUpDown1;           //ความยาวขั้นต่ำ
                        command20.MinWallHeight = value_numUpDown2;       //ความสูงของกำแพงขั้นต่ำ
                        command20.MaxWidth = value_numUpDown3;             //ความกว้างสูงสุด
                        command20.MaxWallPercent = value_numUpDown4;      //เปอร์เซ็นต์กำแพงสูงสุด
                        command20.MaxSideteethLength = value_numUpDown5;  //ความยาวฟันข้างสูงสุด
                        command20.MaxMidteethLength = value_numUpDown6;   //ความยาวฟันกลางสูงสุด
                        command20.Gaps = value_numUpDown7;                 //ช่องว่าง
                        command20.Variance = value_numUpDown8;             //ความแปรปรวน
                        command20.TeethSpacing = value_numUpDown9;         //ระยะห่างระหว่างฟัน
                        command20.AutoFilter = chckbox20;       //ตัวกรองอัตโนมัติ
                        command20.Run(destImage);
                    }
                    l_stateOutput.Text = "Image " + destImage.BitsPerPixel.ToString() + " BitsPerPixel";
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(destImage, ConvertToImageOptions.None))
                    {
                        picReview2.Image = new Bitmap(destImage1);
                    }
                }
                else {
                    l_stateOutput.Text = "Image " + rasterImage.BitsPerPixel.ToString() + " BitsPerPixel";
                    //picReview2.ImageLocation = null;
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                    {
                        picReview2.Image = new Bitmap(destImage1);
                    }
                }
            }
           // await Task.Delay(1000);
            picReview2.MouseDown += new MouseEventHandler(picReview2_MouseDown);
            picReview2.MouseUp += new MouseEventHandler(picReview2_MouseUp);
            picReview2.MouseMove += new MouseEventHandler(picReview2_MouseMove);
        }
       
        private async void pic2_MouseClick(object sender, MouseEventArgs e)
        {
            /******/
           /* this.splitContainer1.Panel2.Controls.Clear();
            PictureBox pb = (PictureBox)sender;
            RasterCodecs _rasterCodecs = new RasterCodecs();
            //Load documents at 300 DPI for better viewing
            _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
            foreach (string img in file)
            {
                using (var imageInfo = _rasterCodecs.GetInformation(img, true)) //นับจำนวนเอกสาร
                {
                    pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                }
                Console.WriteLine("Page " + pageCount);
                l_numberPages.Text = pageCount.ToString() + " Page";
                // Loads all the pages into the viewer
                PictureBox picReview2 = new PictureBox();

                // Load it as a raster image and add it
                var rasterImage = _rasterCodecs.Load(img, int.Parse(pb.Name));
                l_stateInput.Text = "Image " + rasterImage.BitsPerPixel.ToString() + " BitsPerPixel";

                picReview2.Height = 600; //ความกว้างหน้ากระดาษ
                picReview2.Width = 420;  //ความสูงหน้ากระดาษ
                picReview2.Location = new Point((splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2), 20);
                picReview2.SizeMode = PictureBoxSizeMode.StretchImage;
                this.splitContainer1.Panel2.Controls.Add(picReview2);
                ContrastBrightnessIntensityCommand command2 = new ContrastBrightnessIntensityCommand();
                //Increase the brightness by 25 percent  of the possible range. 
                command2.Brightness = 484;   //484
                command2.Contrast = 394;     //394
                command2.Intensity = 118;    //118
                command2.Run(rasterImage);
                using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                {
                    picReview2.Image = new Bitmap(destImage1);
                }
            }
            await Task.Delay(500);*/
           PictureBox pb = (PictureBox)sender;
            pdname = int.Parse(pb.Name);
            Image();
           // disp();
        }
        public async void chang(){
            splitContainer1.Panel2.Controls.Clear();
            int w3 = 550 / 2;
            int x3 = (splitContainer1.Panel2.Width / 2) - w3;

            //int x3 = 40;//ระวหว่าง panel
            int y3 = 20;//ระวหว่าง panel
            int maxWidth3 = -1;
            
            //Load documents at 300 DPI for better viewing
            _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
            int pageCount2;
            foreach (string img in file){
                using (var imageInfo = _rasterCodecs.GetInformation(img, true)){
                    pageCount2 = imageInfo.TotalPages; //จำนวนเอกสาร
                }
                Console.WriteLine("Page " + pageCount2);
                l_numberPages.Text = pageCount2.ToString() + " Page";
                // Loads all the pages into the viewer
                for (var pageNumber = 1; pageNumber <= pageCount2; pageNumber++){
                    // Load it as a raster image and add it
                    var rasterImage = _rasterCodecs.Load(img, pageNumber);
                    PictureBox pic3 = new PictureBox();
                    ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
                    //Increase the brightness by 25 percent  of the possible range. 
                    command.Brightness = value_trackBar1;   //484
                    command.Contrast = value_trackBar2;     //394
                    command.Intensity = value_trackBar3;    //118
                    command.Run(rasterImage);
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                    {
                        // piccenter.Image = new Bitmap(destImage1);
                        pic3.Image = new Bitmap(destImage1);
                    }
                    pic3.Height = 640; //ความสูงหน้ากระดาษ
                    pic3.Width = 550;  //ความกว้างหน้ากระดาษ
                    pic3.Location = new Point(x3, y3 + splitContainer1.Panel2.AutoScrollPosition.Y);
                    //pic3.Location = new Point(x3, y3);
                    pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic3.BorderStyle = BorderStyle.FixedSingle;

                    y3 += pic3.Height + 10; //ระยะห่างระหว่างหน้า
                    maxWidth3 = Math.Max(pic3.Height, maxWidth3);
                    if (x3 > this.ClientSize.Width - 100)
                    {
                        y3 = 20;
                        x3 += maxWidth3 + 100;
                    }
                    //this.panelcenter.Controls.Add(pic3);
                    this.splitContainer1.Panel2.Controls.Add(pic3);
                    await Task.Delay(1000);
                }
            }        
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                Preview pv = new Preview();
                pv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            RasterCodecs codecs = new RasterCodecs();
            codecs.ThrowExceptionsOnInvalidImages = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All File |*.*";
            DialogResult dr = ofd.ShowDialog();
            int page = 0;

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                imagescol.Clear();
                crepic(); //สร้าง picReview
                //progressBar1.Value = 0;
                splitContainer1.Panel1.Controls.Clear();
                file = ofd.FileNames;
                /* int x = 20;//ระวหว่าง panel
                 int y = 20;//ระวหว่าง panel
                 int maxWidth = -1;*/
                /**/
                //int w = 170 / 2;
                // int w = 420 / 2;
                //int x3 = (splitContainer1.Panel2.Width / 2) - w;
                int w2 = 150 / 2;
                int x2 = (splitContainer1.Panel1.Width / 2) - w2;
                //int x3 = 40;//ระวหว่าง panel
                int y2 = 20;//ระวหว่าง panel
                int maxWidth2 = -1;
                RasterCodecs _rasterCodecs = new RasterCodecs();
                //Load documents at 300 DPI for better viewing
                _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
                /**/
                // int pageCount;
                foreach (string img in file)
                {
                    /**/
                    using (var imageInfo = _rasterCodecs.GetInformation(img, true)) //นับจำนวนเอกสาร
                    {
                        pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                    }
                    Console.WriteLine("Page " + pageCount);

                    // Loads all the pages into the viewer
                    for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                    {
                        //progressBar1.Value += (pageCount * 100) / 1000;
                        //await Task.Delay(1000);
                        // Load it as a raster image and add it
                        _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
                        _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
                        _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
                        _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
                        _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
                        var rasterImage = _rasterCodecs.Load(img, pageNumber);
                        l_numberPages.Text = "Page " + pageNumber + " / " + pageCount.ToString();
                        l_stateInput.Text = "Image " + rasterImage.BitsPerPixel.ToString() + " BitsPerPixel";
                        //this._imageViewer.Items.AddFromImage(rasterImage, 1);
                        //Label la = new Label();
                        PictureBox pic2 = new PictureBox();
                        pic2.Height = 180;
                        pic2.Width = 160;
                        //selectImage = pageNumber.ToString();
                        //pic2.Location = new Point(x2, y2);
                        pic2.Location = new Point(x2, y2 + splitContainer1.Panel1.AutoScrollPosition.Y); //แก้ปัญหาการวางผิดตำแหน่ง
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic2.BorderStyle = BorderStyle.FixedSingle;
                        pic2.Name = pageNumber.ToString();
                        y2 += pic2.Height + 10;
                        maxWidth2 = Math.Max(pic2.Height, maxWidth2);
                        if (x2 > this.ClientSize.Width - 100)
                        {
                            y2 = 20;
                            x2 += maxWidth2 + 100;
                        }
                        //this.panelImage.Controls.Add(pic2);
                        this.splitContainer1.Panel1.Controls.Add(pic2);

                        using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                        {
                            pic2.Image = new Bitmap(destImage1);
                        }
                        imagescol.Add(rasterImage);

                        /* la.Width = 10;
                         la.Height = 15;
                         la.BackColor = Color.White;
                         la.Location = new Point((splitContainer1.Panel1.Width / 2) - la.Width, y2+splitContainer1.Panel1.AutoScrollPosition.Y);
                         la.Text = pageNumber.ToString();
                         this.splitContainer1.Panel1.Controls.Add(la);*/
                        //Console.WriteLine(pic2.Location.X.ToString() + pic2.Location.Y.ToString());
                        Console.WriteLine(pic2.Name);
                        pic2.MouseClick += new MouseEventHandler(pic2_MouseClick);
                        await Task.Delay(1000);
                    }
                    // progressBar1.Value = 0;
                    // chang();
                    /*using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[0], ConvertToImageOptions.None))
                    {
                        pic2.Image = new Bitmap(destImage1);
                    }*/
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Preview pv = new Preview();
                pv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void checkBox21_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                chckbox21 = true;
                Display(); Image();
            }
            else
            {
                chckbox21 = false;
                Display(); Image();
            }
        }
        String value_tb_profile;
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(tb_profile.GlobalName);
                String pfname = "";
                String listname = @"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt";
                if (tb_profile.Text == "")
                {
                    MessageBox.Show("กรุณาตั้งชื่อ Profile!!");
                }
                else
                {
                    if (System.IO.File.Exists(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\" + pfname + ".txt"))//ถ้าเจอไฟล์
                    {
                        //MessageBox.Show("คุณมีไฟล์ชื่อนี้อยู่แล้ว!!!");
                        DialogResult dialogResult = MessageBox.Show("คุณมีไฟล์ชื่อนี้อยู่แล้ว!!! ต้องการทับไฟล์เดิมไหม", "Some Title", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            save();
                        }
                    }
                    else
                    {
                        save();
                        /* using (StreamWriter streamwri1 = File.AppendText(listname))
                         {
                             streamwri1.WriteLine(pfname);
                             streamwri1.Close();
                         }*/
                    }

                    void save()
                    {/* //ContrastBrightnessIntensity
                         profile prof1 = new profile();
                         prof1.Name = l_brightness.Name;
                         prof1.Values = value_trackBar1.ToString();
                         Lprofile.Add(prof1);

                         profile prof2 = new profile();
                         prof2.Name = l_contrast.Name;
                         prof2.Values = value_trackBar2.ToString();
                         Lprofile.Add(prof2);

                         profile prof3 = new profile();
                         prof3.Name = l_intensity.Name;
                         prof3.Values = value_trackBar3.ToString();
                         Lprofile.Add(prof3);

                         //UnsharpMask
                         profile prof4 = new profile();
                         prof4.Name = l_amount.Name;
                         prof4.Values = value_trackBar4.ToString();
                         Lprofile.Add(prof4);

                         profile prof5 = new profile();
                         prof5.Name = l_radius.Name;
                         prof5.Values = value_trackBar5.ToString();
                         Lprofile.Add(prof5);

                         profile prof6 = new profile();
                         prof6.Name = l_threshold.Name;
                         prof6.Values = value_trackBar6.ToString();
                         Lprofile.Add(prof6);

                         //GrayScale
                         profile prof7 = new profile();
                         prof7.Name = checkBox2.Text;
                         prof7.Values = chckbox2.ToString();
                         Lprofile.Add(prof7);

                         profile prof8 = new profile();
                         prof8.Name = l_redfactor.Name;
                         prof8.Values = value_trackBar7.ToString();
                         Lprofile.Add(prof8);*/

                        /*profile prof9 = new profile();
                        prof9.Name = l_greenfactor.Name;
                        prof9.Values = value_trackBar8.ToString();
                        Lprofile.Add(prof9);

                        profile prof10 = new profile();
                        prof10.Name = l_bluefactor.Name;
                        prof10.Values = value_trackBar9.ToString();
                        Lprofile.Add(prof10);

                        //Document Image Cleanup Functions
                        profile prof11 = new profile();
                        prof11.Name = checkBox7.Text;
                        prof11.Values = chckbox7.ToString();
                        Lprofile.Add(prof11);

                        profile prof12 = new profile();
                        prof12.Name = checkBox3.Text;
                        prof12.Values = chckbox3.ToString();
                        Lprofile.Add(prof12);*/

                        /*profile prof13 = new profile();
                        prof13.Name = checkBox9.Text;
                        prof13.Values = chckbox9.ToString();
                        Lprofile.Add(prof13);

                        profile prof14 = new profile();
                        prof14.Name = l_dimension.Name;
                        prof14.Values = value_trbDynBin1.ToString();
                        Lprofile.Add(prof14);

                        profile prof15 = new profile();
                        prof15.Name = l_localcontrast.Name;
                        prof15.Values = value_trbDynBin2.ToString();
                        Lprofile.Add(prof15);

                        profile prof16 = new profile();
                        prof16.Name = l_binaryfilter.Name;
                        prof16.Values = selectCombobox.ToString();
                        Lprofile.Add(prof16);

                        //Dot Remove
                        profile prof17 = new profile();
                        prof17.Name = checkBox10.Text;
                        prof17.Values = chckbox10.ToString();
                        Lprofile.Add(prof17);

                        profile prof18 = new profile();
                        prof18.Name = l_maximumdotH.Name;
                        prof18.Values = value_trackBar10.ToString();
                        Lprofile.Add(prof18);*/

                        /* profile prof19 = new profile();
                         prof19.Name = l_maximumdotW.Name;
                         prof19.Values = value_trackBar11.ToString();
                         Lprofile.Add(prof19);*/
                        /* profile prof20 = new profile();
                        prof20.Name = l_minimumdotH.Name;
                        prof20.Values = value_trackBar12.ToString();
                        Lprofile.Add(prof20);*/

                        /* profile prof21 = new profile();
                         prof21.Name = l_minimumdotW.Name;
                         prof21.Values = value_trackBar13.ToString();
                         Lprofile.Add(prof21);*/
                        //Line Remove
                        /*profile prof22 = new profile();
                        prof22.Name = checkBox11.Text;
                        prof22.Values = chckbox11.ToString();
                        Lprofile.Add(prof22);*/

                        /*profile prof23 = new profile();
                        prof23.Name = l_gaplength.Name;
                        prof23.Values = value_trackBar14.ToString();
                        Lprofile.Add(prof23);*/

                        /*profile prof24 = new profile();
                        prof24.Name = l_maximumlineW.Name;
                        prof24.Values = value_trackBar15.ToString();
                        Lprofile.Add(prof24);*/

                        /*profile prof25 = new profile();
                        prof25.Name = l_minimumlineL.Name;
                        prof25.Values = value_trackBar16.ToString();
                        Lprofile.Add(prof25);*/
                        /*profile prof26 = new profile();
                        prof26.Name = l_maximumwall.Name;
                        prof26.Values = value_trackBar17.ToString();
                        Lprofile.Add(prof26);*/

                        /* profile prof27 = new profile();
                         prof27.Name = l_wall.Name;
                         prof27.Values = value_trackBar22.ToString();
                         Lprofile.Add(prof27);*/
                        //HolePunchRemove
                        /*profile prof28 = new profile();
                        prof28.Name = checkBox12.Text;
                        prof28.Values = chckbox12.ToString();
                        Lprofile.Add(prof28);*/

                        /*profile prof29 = new profile();
                        prof29.Name = l_maximumhole.Name;
                        prof29.Values = value_trackBar18.ToString();
                        Lprofile.Add(prof29);*/

                        /*profile prof30 = new profile();
                        prof30.Name = l_minimumhole.Name;
                        prof30.Values = value_trackBar21.ToString();
                        Lprofile.Add(prof30);*/
                        //InvertedText
                        /*profile prof31 = new profile();
                        prof31.Name = checkBox13.Text;
                        prof31.Values = chckbox13.ToString();
                        Lprofile.Add(prof31);*/

                        /*profile prof32 = new profile();
                        prof32.Name = l_maximumblack.Name;
                        prof32.Values = value_trackBar19.ToString();
                        Lprofile.Add(prof32);

                        profile prof33 = new profile();
                        prof33.Name = l_minimumBlack.Name;
                        prof33.Values = value_trackBar20.ToString();
                        Lprofile.Add(prof33);*/
                        /*profile prof34 = new profile();
                        prof34.Name = l_minimuminverH.Name;
                        prof34.Values = value_trackBar23.ToString();
                        Lprofile.Add(prof34);*/

                        /*profile prof35 = new profile();
                        prof35.Name = l_minimuminvertW.Name;
                        prof35.Values = value_trackBar24.ToString();
                        Lprofile.Add(prof35);*/
                        //Auto Crop
                        /*profile prof36 = new profile();
                        prof36.Name = checkBox15.Text;
                        prof36.Values = chckbox15.ToString();
                        Lprofile.Add(prof36);*/

                        /*profile prof37 = new profile();
                        prof37.Name = l_cropThreshold.Name;
                        prof37.Values = value_trackBar27.ToString();
                        Lprofile.Add(prof37);*/
                        //Boder Remove
                        /*profile prof38 = new profile();
                        prof38.Name = checkBox16.Text;
                        prof38.Values = chckbox16.ToString();
                        Lprofile.Add(prof38);*/

                        /*profile prof39 = new profile();
                        prof39.Name = l_percent.Name;
                        prof39.Values = value_trackBar25.ToString();
                        Lprofile.Add(prof39);*/

                        /*profile prof40 = new profile();
                        prof40.Name = l_variance.Name;
                        prof40.Values = value_trackBar26.ToString();
                        Lprofile.Add(prof40);*/
                        /*profile prof41 = new profile();
                        prof41.Name = l_whitenoiseL.Name;
                        prof41.Values = value_trackBar28.ToString();
                        Lprofile.Add(prof41);*/

                        //Smooth
                        /* profile prof42 = new profile();
                         prof42.Name = checkBox17.Text;
                         prof42.Values = chckbox17.ToString();
                         Lprofile.Add(prof42);*/

                        /*profile prof43 = new profile();
                        prof43.Name = l_length.Name;
                        prof43.Values = value_trackBar31.ToString();
                        Lprofile.Add(prof43);*/
                        /*profile prof44 = new profile();
                        prof44.Name = checkBox1.Text;
                        prof44.Values = chckbox.ToString();
                        Lprofile.Add(prof44);*/

                        /*profile prof45 = new profile();
                        prof45.Name = checkBox4.Text;
                        prof45.Values = chckbox4.ToString();
                        Lprofile.Add(prof45);*/

                        /*profile prof46 = new profile();
                        prof46.Name = checkBox5.Text;
                        prof46.Values = chckbox5.ToString();
                        Lprofile.Add(prof46);*/
                        /*profile prof47 = new profile();
                        prof47.Name = l_maximum.Name;
                        prof47.Values = value_trbMaximum.ToString();
                        Lprofile.Add(prof47);*/

                        /*profile prof48 = new profile();
                        prof48.Name = checkBox6.Text;
                        prof48.Values = chckbox6.ToString();
                        Lprofile.Add(prof48);*/
                        /*profile prof49 = new profile();
                        prof49.Name = l_minimum.Name;
                        prof49.Values = value_trbMinimum.ToString();
                        Lprofile.Add(prof49);*/

                        /*profile prof50 = new profile();
                        prof50.Name = checkBox8.Text;
                        prof50.Values = chckbox8.ToString();
                        Lprofile.Add(prof50);*/

                        /*profile prof51 = new profile();
                        prof51.Name = l_gamma.Name;
                        prof51.Values = value_trbGamma.ToString();
                        Lprofile.Add(prof51);*/
                        /*profile prof52 = new profile();
                        prof52.Name = checkBox14.Text;
                        prof52.Values = chckbox14.ToString();
                        Lprofile.Add(prof52);*/

                        //Flip Rotate Image
                        /*profile prof53 = new profile();
                        prof53.Name = checkBox18.Text;
                        prof53.Values = chckbox18.ToString();
                        Lprofile.Add(prof53);*/

                        /*profile prof54 = new profile();
                        prof54.Name = l_RotateImage.Name;
                        prof54.Values = value_trackBar29.ToString();
                        Lprofile.Add(prof54);*/
                        //RakeRemove
                        /*profile prof55 = new profile();
                        prof55.Name = checkBox19.Text;
                        prof55.Values = chckbox19.ToString();
                        Lprofile.Add(prof55);*/

                        /*profile prof56 = new profile();
                        prof56.Name = l_numUpDown1.Name;
                        prof56.Values = value_numUpDown1.ToString();
                        Lprofile.Add(prof56);

                        profile prof57 = new profile();
                        prof57.Name = l_numUpDown2.Name;
                        prof57.Values = value_numUpDown2.ToString();
                        Lprofile.Add(prof57);

                        profile prof58 = new profile();
                        prof58.Name = l_numUpDown3.Name;
                        prof58.Values = value_numUpDown3.ToString();
                        Lprofile.Add(prof58);

                        profile prof59 = new profile();
                        prof59.Name = l_numUpDown4.Name;
                        prof59.Values = value_numUpDown4.ToString();
                        Lprofile.Add(prof59);

                        profile prof60 = new profile();
                        prof60.Name = l_numUpDown5.Name;
                        prof60.Values = value_numUpDown5.ToString();
                        Lprofile.Add(prof60);

                        profile prof61 = new profile();
                        prof61.Name = l_numUpDown6.Name;
                        prof61.Values = value_numUpDown6.ToString();
                        Lprofile.Add(prof61);

                        profile prof62 = new profile();
                        prof62.Name = l_numUpDown7.Name;
                        prof62.Values = value_numUpDown7.ToString();
                        Lprofile.Add(prof62);

                        profile prof63 = new profile();
                        prof63.Name = l_numUpDown8.Name;
                        prof63.Values = value_numUpDown8.ToString();
                        Lprofile.Add(prof63);

                        profile prof64 = new profile();
                        prof64.Name = l_numUpDown9.Name;
                        prof64.Values = value_numUpDown9.ToString();
                        Lprofile.Add(prof64);*/
                        profile2 profile2 = new profile2();
                        profile2.Profilename = "BA";

                        profile2.L_brightness = l_brightness.Name;
                        profile2.Values_brightness = value_trackBar1.ToString();
                        profile2.L_contrast = l_contrast.Name;
                        profile2.Values_contrast = value_trackBar2.ToString();
                        profile2.L_intensity = l_intensity.Name;
                        profile2.Values_intensity = value_trackBar3.ToString();
                        profile2.L_amount = l_amount.Name;
                        profile2.Values_amount = value_trackBar4.ToString();
                        profile2.L_radius = l_radius.Name;
                        profile2.Values_radius = value_trackBar5.ToString();
                        profile2.L_threshold = l_threshold.Name;
                        profile2.Values_threshold = value_trackBar6.ToString();
                        profile2.Use_GrayScale = checkBox2.Text;
                        profile2.Values_UseGrayScale = chckbox2.ToString();
                        profile2.L_redfactor = l_redfactor.Name;
                        profile2.Values_redfactor = value_trackBar7.ToString();
                        profile2.L_greenfactor = l_greenfactor.Name;
                        profile2.Values_greenfactor = value_trackBar8.ToString();
                        profile2.L_bluefactor = l_bluefactor.Name;
                        profile2.Values_bluefactor = value_trackBar9.ToString();
                        profile2.AutoBinarize = checkBox7.Text;
                        profile2.Values_autoBinary = checkBox7.ToString();
                        profile2.Despeckle = checkBox3.Text;
                        profile2.Values_despeckle = chckbox3.ToString();
                        profile2.DynamicBinary = checkBox9.Text;
                        profile2.Values_dynamicBinary = chckbox9.ToString();
                        profile2.L_dimension = l_dimension.Name;
                        profile2.Values_dimension = value_trbDynBin1.ToString();
                        profile2.L_localcontrast = l_localcontrast.Name;
                        profile2.Values_localcontrast = value_trbDynBin2.ToString();
                        profile2.L_binaryfilter = l_binaryfilter.Name;
                        profile2.Values_binaryfilter = selectCombobox.ToString();
                        profile2.DotRemove = checkBox10.Text;
                        profile2.Values_dotremove = chckbox10.ToString();
                        profile2.L_maximumdotH = l_maximumdotH.Name;
                        profile2.Values_maximumdotH = value_trackBar10.ToString();
                        profile2.L_maximumdotW = l_maximumdotW.Name;
                        profile2.Values_lmaximumdotW = value_trackBar11.ToString();
                        profile2.L_minimumdotH = l_minimumdotH.Name;
                        profile2.Values_l_minimumdotH = value_trackBar12.ToString();
                        profile2.L_minimumdotW = l_minimumdotW.Name;
                        profile2.Values_minimumdotW = value_trackBar13.ToString();
                        profile2.LineRemove = checkBox11.Text;
                        profile2.Values_lineRemove = chckbox11.ToString();
                        profile2.L_gaplength = l_gaplength.Name;
                        profile2.Values_gaplength = value_trackBar14.ToString();
                        profile2.L_maximumlineW = l_maximumlineW.Name;
                        profile2.Values_maximumlineW = value_trackBar15.ToString();
                        profile2.L_minimumlineL = l_minimumlineL.Name;
                        profile2.Values_minimumlineL= value_trackBar16.ToString();
                        profile2.L_maximumwall = l_maximumwall.Name;
                        profile2.Values_maximumwall = value_trackBar17.ToString();
                        profile2.L_wall = l_wall.Name;
                        profile2.Values_wall = value_trackBar22.ToString();
                        profile2.HolePunchRemove = checkBox12.Text;
                        profile2.Values_holePunchRemove = chckbox12.ToString();
                        profile2.L_maximumhole = l_maximumhole.Name;
                        profile2.Values_maximumhole = value_trackBar18.ToString();
                        profile2.L_minimumhole = l_minimumhole.Name;
                        profile2.Values_minimumhole = value_trackBar21.ToString();
                        profile2.InvertedText = checkBox13.Text;
                        profile2.Values_invertedText = chckbox13.ToString();
                        profile2.L_maximumblack = l_maximumblack.Name;
                        profile2.Values_maximumblack = value_trackBar19.ToString();
                        profile2.L_minimuminverH = l_minimuminverH.Name;
                        profile2.Values_minimuminverH = value_trackBar23.ToString();
                        profile2.L_minimuminvertW = l_minimuminvertW.Name;
                        profile2.Values_minimuminvertW = value_trackBar24.ToString();
                        profile2.AutoCrop = checkBox15.Text;
                        profile2.Values_autoCrop = chckbox15.ToString();
                        profile2.L_cropThreshold = l_cropThreshold.Name;
                        profile2.Values_cropThreshold = value_trackBar27.ToString();
                        profile2.BorderRemove = checkBox16.Text;
                        profile2.Values_borderRemove = chckbox16.ToString();
                        profile2.L_percent = l_percent.Name;
                        profile2.Values_percent = value_trackBar25.ToString();
                        profile2.L_variance = l_variance.Name;
                        profile2.Values_variance = value_trackBar26.ToString();
                        profile2.L_whitenoiseL = l_whitenoiseL.Name;
                        profile2.Values_whitenoiseL = value_trackBar28.ToString();
                        profile2.Smooth = checkBox17.Text;
                        profile2.Values_smooth = chckbox17.ToString();
                        profile2.L_length = l_length.Name;
                        profile2.Values_length = value_trackBar31.ToString();
                        profile2.AutoColorLevel = checkBox1.Text;
                        profile2.Values_autoColorLevel = chckbox.ToString();
                        profile2.AutoBinary = checkBox4.Text;
                        profile2.Values_autoBinary = chckbox4.ToString();
                        profile2.Maximum = checkBox5.Text;
                        profile2.Values_maximum = chckbox5.ToString();
                        profile2.L_maximum = l_maximum.Name;
                        profile2.Values_maximum = value_trbMaximum.ToString();
                        profile2.Minimum = checkBox6.Text;
                        profile2.Values_minimum = chckbox6.ToString();
                        profile2.L_minimum = l_minimum.Name;
                        profile2.Values_minimum = value_trbMinimum.ToString();
                        profile2.Gamma = checkBox8.Text;
                        profile2.Values_gamma = chckbox8.ToString();
                        profile2.L_gamma = l_gamma.Name;
                        profile2.Values_gamma = value_trbGamma.ToString();
                        profile2.AutoDeskew = checkBox14.Text;
                        profile2.Values_autoDeskew = chckbox14.ToString();
                        profile2.UseFlipRotateImage = checkBox18.Text;
                        profile2.Values_useFlipRotateImage = chckbox18.ToString();
                        profile2.L_RotateImage = l_RotateImage.Name;
                        profile2.Values_RotateImage = value_trackBar29.ToString();
                        profile2.UseRakeRemove = checkBox19.Text;
                        profile2.Values_useRakeRemove = chckbox19.ToString();
                        profile2.L_numUpDown1 = l_numUpDown1.Name;
                        profile2.Values_numUpDown1 = value_numUpDown1.ToString();
                        profile2.L_numUpDown2 = l_numUpDown2.Name;
                        profile2.Values_numUpDown2 = value_numUpDown2.ToString();
                        profile2.L_numUpDown3 = l_numUpDown3.Name;
                        profile2.Values_numUpDown3 = value_numUpDown3.ToString();
                        profile2.L_numUpDown4 = l_numUpDown4.Name;
                        profile2.Values_numUpDown4 = value_numUpDown4.ToString();
                        profile2.L_numUpDown5 = l_numUpDown5.Name;
                        profile2.Values_numUpDown5 = value_numUpDown5.ToString();
                        profile2.L_numUpDown6 = l_numUpDown6.Name;
                        profile2.Values_numUpDown6 = value_numUpDown6.ToString();
                        profile2.L_numUpDown7 = l_numUpDown7.Name;
                        profile2.Values_numUpDown7 = value_numUpDown7.ToString();
                        profile2.L_numUpDown8 = l_numUpDown8.Name;
                        profile2.Values_numUpDown8 = value_numUpDown8.ToString();
                        profile2.L_numUpDown9 = l_numUpDown9.Name;
                        profile2.Values_numUpDown9 = value_numUpDown9.ToString();
                        profile2.AutoFilter = l_autofilter.Text;
                        profile2.Values_autoFilter = chckbox20.ToString();
                        profile2.Convert1bit = checkBox21.Text;
                        profile2.Values_convert1bit = chckbox21.ToString();
                        Lprofile2.Add(profile2);
                        /*profile prof65 = new profile();
                        prof65.Name = l_autofilter.Text;
                        prof65.Values = chckbox20.ToString();
                        Lprofile.Add(prof65);*/

                        //convert to 1 bit
                        /*profile prof66 = new profile();
                        prof66.Name = checkBox21.Text;
                        prof66.Values = chckbox21.ToString();
                        Lprofile.Add(prof66);*/

                        l_saveprofile.Text = " Save Success...";
                       // N2N.Data.Serialization.Serialize<List<profile>>.SerializeToXmlFile(Lprofile, tb_profile.Text+ ".xml");
                        int r = Lprofile.Count;
                        for (int i = 0; i < r; i++)
                        {
                            //Console.WriteLine(i + "| " + Lprofile[i].Name + "=" + Lprofile[i].Values);
                        }
                        foreach (var profile3 in Lprofile2)
                        {
                            Console.WriteLine(profile3.Profilename);
                        }
                        
                        tb_profile.Text = "";
                    }
                    cbBox2re();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveProfile_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
           // int x = Remove.Location.X - 200;
          //  int y = Remove.Location.Y;
           // frm2.Location = new Point(x, y);
            frm2.Show();
        }

        private void cbboxUseProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectCombobox2 = cbboxUseProfile.SelectedItem.ToString();
                cbboxUseProfile.Items.Add("Configs");
                if (selectCombobox2 == "Default" && folderPath != null)
                {
                    ResetValue();
                }
                else
                {
                    String[] ls;
                    String lscol;
                    String rf;
                    String rfile;
                    List<String> list = new List<String>();
                    if (selectCombobox2 == "Default") { }
                    else
                    {
                        //StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\" + selectCombobox2 + ".txt");
                       // List<profile> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile>>.DeserializeFromXmlFile("qq.xml");
                        /* while ((rfile = streamread.ReadLine()) != null)
                         {
                             rf = rfile;                         //text = อ่านข้อความทีละบรรทัด
                             ls = rf.Split("=".ToCharArray());   //split ตัดข้อความ ตัดที่ = 
                             lscol = ls[1];                      //เก็บค่าที่ตัดแล้ว เอาค่าที่อยู่หลัง =
                             list.Add(lscol);
                         }*/
                        /*foreach (profile profile in ProfileLoad)
                         {
                             Console.WriteLine("> " + profile.Name);
                             Console.WriteLine("> " + profile.Values);
                         }*/
                       /* foreach (var profile in ProfileLoad)
                         {
                            Console.WriteLine("> " + profile.Profilename);
                        }*/
                        
                        /*Console.WriteLine("> " + ProfileLoad[0].L_brightness);
                        Console.WriteLine("> " + ProfileLoad[0].Values_brightness);*/
                        //เซตค่า
                        //ความสว่าง
                      /*  value_trackBar1 = int.Parse(ProfileLoad[0].Values);
                          trackBar1.Value = value_trackBar1;
                          l_brightness.Text = value_trackBar1.ToString();
                          value_trackBar2 = int.Parse(ProfileLoad[1].Values);
                          trackBar2.Value = value_trackBar2;
                          l_contrast.Text = value_trackBar2.ToString();
                          value_trackBar3 = int.Parse(ProfileLoad[2].Values);
                          trackBar3.Value = value_trackBar3;
                          l_intensity.Text = value_trackBar3.ToString();
                          //ความคมชัด
                          value_trackBar4 = int.Parse(ProfileLoad[3].Values);
                          trackBar4.Value = value_trackBar4;
                          l_amount.Text = value_trackBar4.ToString();
                          value_trackBar5 = int.Parse(ProfileLoad[4].Values);
                          trackBar5.Value = value_trackBar5;
                          l_radius.Text = value_trackBar5.ToString();
                          value_trackBar6 = int.Parse(ProfileLoad[5].Values);
                          trackBar6.Value = value_trackBar6;
                          l_threshold.Text = value_trackBar6.ToString();
                          //Gray scale
                          chckbox2 = bool.Parse(ProfileLoad[6].Values);
                          checkBox2.Checked = chckbox2;
                          value_trackBar7 = int.Parse(ProfileLoad[7].Values);
                          trackBar7.Value = value_trackBar7;
                          l_redfactor.Text = value_trackBar7.ToString();
                          value_trackBar8 = int.Parse(ProfileLoad[8].Values);
                          trackBar8.Value = value_trackBar8;
                          l_greenfactor.Text = value_trackBar8.ToString();
                          value_trackBar9 = int.Parse(ProfileLoad[9].Values);
                          trackBar9.Value = value_trackBar9;
                          l_bluefactor.Text = value_trackBar9.ToString();
                          //Document Image Cleanup Functions
                          chckbox7 = bool.Parse(ProfileLoad[10].Values);
                          checkBox7.Checked = chckbox7;
                          chckbox3 = bool.Parse(ProfileLoad[11].Values);
                          checkBox3.Checked = chckbox3;
                          chckbox9 = bool.Parse(ProfileLoad[12].Values);
                          checkBox9.Checked = chckbox9;
                          value_trbDynBin1 = int.Parse(ProfileLoad[13].Values);
                          trbDynBin1.Value = value_trbDynBin1;
                          l_dimension.Text = value_trbDynBin1.ToString();
                          value_trbDynBin2 = int.Parse(ProfileLoad[14].Values);
                          trbDynBin2.Value = value_trbDynBin2;
                          l_localcontrast.Text = value_trbDynBin2.ToString();
                          selectCombobox = int.Parse(ProfileLoad[15].Values);
                          comboBox1.SelectedIndex = (selectCombobox + 1);
                          //Dot Remove
                          chckbox10 = bool.Parse(ProfileLoad[16].Values);
                          checkBox10.Checked = chckbox10;
                          value_trackBar10 = int.Parse(ProfileLoad[17].Values);
                          trackBar10.Value = value_trackBar10;
                          l_maximumdotH.Text = value_trackBar10.ToString();
                          value_trackBar11 = int.Parse(ProfileLoad[18].Values);
                          trackBar11.Value = value_trackBar11;
                          l_maximumdotW.Text = value_trackBar11.ToString();
                          value_trackBar12 = int.Parse(ProfileLoad[19].Values);
                          trackBar12.Value = value_trackBar12;
                          l_minimumdotH.Text = value_trackBar12.ToString();
                          value_trackBar13 = int.Parse(ProfileLoad[20].Values);
                          trackBar13.Value = value_trackBar13;
                          l_minimumdotW.Text = value_trackBar13.ToString();
                          //Line Remove
                          chckbox11 = bool.Parse(ProfileLoad[21].Values);
                          checkBox11.Checked = chckbox11;
                          value_trackBar14 = int.Parse(ProfileLoad[22].Values);
                          trackBar14.Value = value_trackBar14;
                          l_gaplength.Text = value_trackBar14.ToString();
                          value_trackBar15 = int.Parse(ProfileLoad[23].Values);
                          trackBar15.Value = value_trackBar15;
                          l_maximumlineW.Text = value_trackBar15.ToString();
                          value_trackBar16 = int.Parse(ProfileLoad[24].Values);
                          trackBar16.Value = value_trackBar16;
                          l_minimumlineL.Text = value_trackBar16.ToString();
                          value_trackBar17 = int.Parse(ProfileLoad[25].Values);
                          trackBar17.Value = value_trackBar17;
                          l_maximumwall.Text = value_trackBar17.ToString();
                          value_trackBar22 = int.Parse(ProfileLoad[26].Values);
                          trackBar22.Value = value_trackBar22;
                          l_wall.Text = value_trackBar22.ToString();
                          //HolePunchRemove
                          chckbox12 = bool.Parse(ProfileLoad[27].Values);
                          checkBox12.Checked = chckbox12;
                          value_trackBar18 = int.Parse(ProfileLoad[28].Values);
                          trackBar18.Value = value_trackBar18;
                          l_maximumhole.Text = value_trackBar18.ToString();
                          value_trackBar21 = int.Parse(ProfileLoad[29].Values);
                          trackBar21.Value = value_trackBar21;
                          l_minimumhole.Text = value_trackBar21.ToString();
                          //InvertedText
                          chckbox13 = bool.Parse(ProfileLoad[30].Values);
                          checkBox13.Checked = chckbox13;
                          value_trackBar19 = int.Parse(ProfileLoad[31].Values);
                          trackBar19.Value = value_trackBar19;
                          l_maximumblack.Text = value_trackBar19.ToString();
                          value_trackBar20 = int.Parse(ProfileLoad[32].Values);
                          trackBar20.Value = value_trackBar20;
                          l_minimumBlack.Text = value_trackBar20.ToString();
                          value_trackBar23 = int.Parse(ProfileLoad[33].Values);
                          trackBar23.Value = value_trackBar23;
                          l_minimuminverH.Text = value_trackBar23.ToString();
                          value_trackBar24 = int.Parse(ProfileLoad[34].Values);
                          trackBar24.Value = value_trackBar24;
                          l_minimuminvertW.Text = value_trackBar24.ToString();
                          //Auto Crop
                          chckbox15 = bool.Parse(ProfileLoad[35].Values);
                          checkBox15.Checked = chckbox15;
                          value_trackBar27 = int.Parse(ProfileLoad[36].Values);
                          trackBar27.Value = value_trackBar27;
                          l_cropThreshold.Text = value_trackBar27.ToString();
                          //Boder Remove
                          chckbox16 = bool.Parse(ProfileLoad[37].Values);
                          checkBox16.Checked = chckbox16;
                          value_trackBar25 = int.Parse(ProfileLoad[38].Values);
                          trackBar25.Value = value_trackBar25;
                          l_percent.Text = value_trackBar25.ToString();
                          value_trackBar26 = int.Parse(ProfileLoad[39].Values);
                          trackBar26.Value = value_trackBar26;
                          l_variance.Text = value_trackBar26.ToString();
                          value_trackBar28 = int.Parse(ProfileLoad[40].Values);
                          trackBar28.Value = value_trackBar28;
                          l_whitenoiseL.Text = value_trackBar28.ToString();
                          //Smooth
                          chckbox17 = bool.Parse(ProfileLoad[41].Values);
                          checkBox17.Checked = chckbox17;
                          value_trackBar31 = int.Parse(ProfileLoad[42].Values);
                          trackBar31.Value = value_trackBar31;
                          l_length.Text = value_trackBar31.ToString();
                          //
                          chckbox = bool.Parse(ProfileLoad[43].Values);
                          checkBox1.Checked = chckbox;
                          chckbox4 = bool.Parse(ProfileLoad[44].Values);
                          checkBox4.Checked = chckbox4;
                          //Maximum
                          chckbox5 = bool.Parse(ProfileLoad[45].Values);
                          checkBox5.Checked = chckbox5;
                          value_trbMaximum = int.Parse(ProfileLoad[46].Values);
                          trbMaximum.Value = value_trbMaximum;
                          l_maximum.Text = value_trbMaximum.ToString();
                          //Minimum
                          chckbox6 = bool.Parse(ProfileLoad[47].Values);
                          checkBox6.Checked = chckbox6;
                          value_trbMinimum = int.Parse(ProfileLoad[48].Values);
                          trbMinimum.Value = value_trbMinimum;
                          l_minimum.Text = value_trbMinimum.ToString();
                          //Gamma
                          chckbox8 = bool.Parse(ProfileLoad[49].Values);
                          checkBox8.Checked = chckbox8;
                          value_trbGamma = int.Parse(ProfileLoad[50].Values);
                          trbGamma.Value = value_trbGamma;
                          l_gamma.Text = value_trbGamma.ToString();

                          chckbox14 = bool.Parse(ProfileLoad[51].Values);
                          checkBox14.Checked = chckbox14;
                          //Flip Rotate Image
                          chckbox18 = bool.Parse(ProfileLoad[52].Values);
                          checkBox18.Checked = chckbox18;
                          value_trackBar29 = int.Parse(ProfileLoad[53].Values);
                          trackBar29.Value = value_trackBar29;
                          l_RotateImage.Text = value_trackBar29.ToString();
                          //RakeRemove
                          chckbox19 = bool.Parse(ProfileLoad[54].Values);
                          checkBox19.Checked = chckbox19;
                          value_numUpDown1 = int.Parse(ProfileLoad[55].Values);
                          numUpDown1.Value = value_numUpDown1;
                          value_numUpDown2 = int.Parse(ProfileLoad[56].Values);
                          numUpDown2.Value = value_numUpDown2;
                          value_numUpDown3 = int.Parse(ProfileLoad[57].Values);
                          numUpDown3.Value = value_numUpDown3;
                          value_numUpDown4 = int.Parse(ProfileLoad[58].Values);
                          numUpDown4.Value = value_numUpDown4;
                          value_numUpDown5 = int.Parse(ProfileLoad[59].Values);
                          numUpDown5.Value = value_numUpDown5;
                          value_numUpDown6 = int.Parse(ProfileLoad[60].Values);
                          numUpDown6.Value = value_numUpDown6;
                          value_numUpDown7 = int.Parse(ProfileLoad[61].Values);
                          numUpDown7.Value = value_numUpDown7;
                          value_numUpDown8 = int.Parse(ProfileLoad[62].Values);
                          numUpDown8.Value = value_numUpDown8;
                          value_numUpDown9 = int.Parse(ProfileLoad[63].Values);
                          numUpDown9.Value = value_numUpDown9;
                          chckbox20 = bool.Parse(ProfileLoad[64].Values);
                          checkBox20.Checked = chckbox20;
                          //convetrt to 1 bit
                          chckbox21 = bool.Parse(ProfileLoad[65].Values);
                          checkBox21.Checked = chckbox21;*/
                          //Display();
                        l_saveprofile.Text = "usepf Success...";
                    }
                    list.Clear();
                    //เคลียร์ list
                    rf = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                //pictureBox1.Image = null;
                // ซูมอิน (เพิ่มขนาดภาพ)
                if (picReview2.Width < 4500 || picReview2.Width < 4500)
                { //กำหนดขอบเขตการขยายภาพ
                    picReview2.Width += (int)(picReview2.Width * 0.1);
                    picReview2.Height += (int)(picReview2.Height * 0.1);
                }
            }
            else if (e.Delta < 0)
            {
                //pictureBox1.Image = null;
                // ซูมเอาท์ (ลดขนาดภาพ)
                if (picReview2.Width > 400 || picReview2.Width > 400)
                { //กำหนดขอบเขตการลดภาพ
                    picReview2.Width -= (int)(picReview2.Width * 0.1);
                    picReview2.Height -= (int)(picReview2.Height * 0.1);
                }

            }
            // l_zoom.Text = "w " + picReview2.Width.ToString() + " h" + picReview2.Height.ToString();
        }
        int xPos2;
        int yPos2;
        bool Dragging2;
        //private RasterImage destImage;

        private void picReview2_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging2 = false;
        }
        private void picReview2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging2 = true;
                xPos2 = e.X;
                yPos2 = e.Y;
                // Console.WriteLine("xPos " + xPos);
                // Console.WriteLine("yPos " + yPos);
            }
        }
        private void picReview2_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (Dragging2 && c != null)
            {
                if (c.Top <= 300)
                {
                    c.Top = e.Y + c.Top - yPos2;
                }
                else
                {

                }
                c.Left = e.X + c.Left - xPos2;

                Console.WriteLine("c.Top " + c.Top.ToString());
                Console.WriteLine("c.Left " + c.Left.ToString());
            }
            //l_xy.Text = pictureBox1.Location.ToString();
        }

        private void btnExportProfile_Click(object sender, EventArgs e)
        {
            Form1Export form1Export = new Form1Export();
            form1Export.ShowDialog();
        }
    }
}
