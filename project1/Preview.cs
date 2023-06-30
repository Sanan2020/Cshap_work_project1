using Leadtools;
using Leadtools.Codecs;
using Leadtools.Document.Writer;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
using Leadtools.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools.Document.Writer;


namespace project1
{
    public partial class Preview : Form
    {
        private RasterImage destImage;

        public Preview()
        {
            InitializeComponent();
        }

        private async void Preview_Load(object sender, EventArgs e){
            btnSave.Enabled = false;
            //progressBar1.Value = 0;
            panel1.AutoScroll = true;
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Clear();
            int w3 = 550 / 2;
            int x3 = (panel1.Width / 2) - w3;

            //int x3 = 40;//ระวหว่าง panel
            int y3 = 20;//ระวหว่าง panel
            int maxWidth3 = -1;

            for (int i = 1; i <= Form1.form1.pageCount; i++)
            {
                label1.Text = "Page "+i+" / " + Form1.form1.pageCount.ToString();
               // progressBar1.Value += (Form1.form1.pageCount * 100) / 100;
                ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
                //Increase the brightness by 25 percent  of the possible range. 
                command.Brightness = Form1.form1.value_trackBar1;   //484
                command.Contrast = Form1.form1.value_trackBar2;     //394
                command.Intensity = Form1.form1.value_trackBar3;    //118
                command.Run(Form1.form1.imagescol[i - 1]);

                UnsharpMaskCommand command2 = new UnsharpMaskCommand();
                command2.Amount = Form1.form1.value_trackBar4;     //rate 0 - เกิน 1000
                command2.Radius = Form1.form1.value_trackBar5;     //rate 1 - เกิน 1000
                command2.Threshold = Form1.form1.value_trackBar6;  //rate 0 - 255
                command2.ColorType = UnsharpMaskCommandColorType.Rgb;
                command2.Run(Form1.form1.imagescol[i - 1]);

                if (Form1.form1.selectCombobox == 0) { }
                else
                {
                    Form1.form1.selectCombobox = Form1.form1.selectCombobox - 1;
                    //MessageBox.Show(selectCombobox.ToString());
                    BinaryFilterCommand command3 = new BinaryFilterCommand((BinaryFilterCommandPredefined)Form1.form1.selectCombobox);
                    command3.Run(Form1.form1.imagescol[i - 1]);
                }

                if (Form1.form1.chckbox == true)
                {
                    AutoColorLevelCommand command4 = new AutoColorLevelCommand();
                    command4.Run(Form1.form1.imagescol[i - 1]);
                }

                if (Form1.form1.chckbox2 == true)
                {
                    GrayScaleExtendedCommand command5 = new GrayScaleExtendedCommand();
                    command5.RedFactor = Form1.form1.value_trackBar7;
                    command5.GreenFactor = Form1.form1.value_trackBar8;
                    command5.BlueFactor = Form1.form1.value_trackBar9;
                    command5.Run(Form1.form1.imagescol[i - 1]);
                }

                if (Form1.form1.chckbox4 == true)
                {
                    AutoBinaryCommand command7 = new AutoBinaryCommand();
                    //Apply Auto Binary Segment. 
                    command7.Run(Form1.form1.imagescol[i - 1]);
                }

                if (Form1.form1.chckbox5 == true)
                {
                    MaximumCommand command8 = new MaximumCommand();
                    //Apply Maximum filter. 
                    command8.Dimension = Form1.form1.value_trbMaximum;
                    command8.Run(Form1.form1.imagescol[i - 1]);
                }

                if (Form1.form1.chckbox6 == true)
                {
                    MinimumCommand command9 = new MinimumCommand();
                    //Apply the Minimum filter. 
                    command9.Dimension = Form1.form1.value_trbMinimum;
                    command9.Run(Form1.form1.imagescol[i - 1]);
                }

                if (Form1.form1.chckbox7 == true)
                {
                    AutoBinarizeCommand command10 = new AutoBinarizeCommand();
                    command10.Run(Form1.form1.imagescol[i - 1]);
                }

                if (Form1.form1.chckbox8 == true)
                {
                    GammaCorrectCommand command11 = new GammaCorrectCommand();
                    //Set a gamma value of 2.5. 
                    command11.Gamma = Form1.form1.value_trbGamma;
                    command11.Run(Form1.form1.imagescol[i - 1]);
                }
                if (Form1.form1.chckbox9 == true)
                {
                    DynamicBinaryCommand command12 = new DynamicBinaryCommand();
                    command12.Dimension = Form1.form1.value_trbDynBin1;
                    command12.LocalContrast = Form1.form1.value_trbDynBin2;
                    // convert it into a black and white image without changing its bits per pixel. 
                    command12.Run(Form1.form1.imagescol[i - 1]);
                }
                if (Form1.form1.chckbox14 == true)
                {
                    DeskewCommand command16 = new DeskewCommand();
                    //Deskew the image. 
                    command16.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea;
                    command16.Run(Form1.form1.imagescol[i - 1]);
                }
                if (Form1.form1.chckbox15 == true)
                {
                    AutoCropCommand command17 = new AutoCropCommand();
                    //AutoCrop the image with 20 tolerance. 
                    command17.Threshold = Form1.form1.value_trackBar27;
                    command17.Run(Form1.form1.imagescol[i - 1]);
                }
                if (Form1.form1.chckbox3 == true)
                {
                    DespeckleCommand command6 = new DespeckleCommand();
                    //Remove speckles from the image. 
                    command6.Run(Form1.form1.imagescol[i - 1]);
                }
                if (Form1.form1.chckbox18 == true)
                {
                    FlipCommand flip = new FlipCommand(false);
                    RunCommand(Form1.form1.imagescol[i - 1], flip);
                    // rotate the image by 45 degrees 
                    RotateCommand rotate = new RotateCommand();
                    rotate.Angle = (Form1.form1.value_trackBar29 * 100);
                    rotate.FillColor = RasterColor.FromKnownColor(RasterKnownColor.White);
                    rotate.Flags = RotateCommandFlags.Resize;
                    RunCommand(Form1.form1.imagescol[i - 1], rotate);
                }
                if (Form1.form1.chckbox21 == true)
                {
                    RasterImage destImage = new RasterImage(
                    RasterMemoryFlags.Conventional,
                    Form1.form1.imagescol[i - 1].Width,
                    Form1.form1.imagescol[i - 1].Height,
                     1,
                    Form1.form1.imagescol[i - 1].Order,
                    Form1.form1.imagescol[i - 1].ViewPerspective,
                    Form1.form1.imagescol[i - 1].GetPalette(),
                    IntPtr.Zero,
                    0);
                    int bufferSize = RasterBufferConverter.CalculateConvertSize(
                       Form1.form1.imagescol[i - 1].Width,
                       Form1.form1.imagescol[i - 1].BitsPerPixel,
                       destImage.Width,
                       destImage.BitsPerPixel);

                    // Allocate the buffer in unmanaged memory 
                    IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
                    //Assert.IsFalse(buffer == IntPtr.Zero);

                    // Process each row from srcImage to destImage. 
                    Form1.form1.imagescol[i - 1].Access();
                    destImage.Access();
                    for (int ii = 0; ii < Form1.form1.imagescol[i - 1].Height; ii++)
                    {
                        Form1.form1.imagescol[i - 1].GetRow(ii, buffer, Form1.form1.imagescol[i - 1].BytesPerLine);
                        RasterBufferConverter.Convert(
                        buffer,
                           Form1.form1.imagescol[i - 1].Width,
                           Form1.form1.imagescol[i - 1].BitsPerPixel,
                           destImage.BitsPerPixel,
                           Form1.form1.imagescol[i - 1].Order,
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
                    Form1.form1.imagescol[i - 1].Release();
                   
                    // Clean up 
                    Marshal.FreeHGlobal(buffer);
                    /**/
                    Form1.form1.imagescol[i - 1] = null;
                    Form1.form1.imagescol[i - 1] = destImage;
                    /**/
                    if (Form1.form1.chckbox11 == true)
                    {
                        LineRemoveCommand command13 = new LineRemoveCommand();
                        command13.LineRemove += new EventHandler<LineRemoveCommandEventArgs>(LineRemoveEvent_S1);
                        command13.Type = LineRemoveCommandType.Horizontal;
                        //command13.Type = LineRemoveCommandType.Vertical;
                        command13.Flags = LineRemoveCommandFlags.UseGap;
                        command13.GapLength = Form1.form1.value_trackBar14;
                        command13.MaximumLineWidth = Form1.form1.value_trackBar15;
                        command13.MinimumLineLength = Form1.form1.value_trackBar16;
                        command13.MaximumWallPercent = Form1.form1.value_trackBar17;
                        command13.Wall = Form1.form1.value_trackBar22;
                        command13.Run(Form1.form1.imagescol[i - 1]);

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
                    if (Form1.form1.chckbox10 == true)
                    {
                        DotRemoveCommand command13 = new DotRemoveCommand();
                        command13.DotRemove += new EventHandler<DotRemoveCommandEventArgs>(DotRemoveEvent_S1);
                        command13.Flags = DotRemoveCommandFlags.UseSize;
                        command13.MaximumDotHeight = Form1.form1.value_trackBar10;
                        command13.MaximumDotWidth = Form1.form1.value_trackBar11;
                        command13.MinimumDotHeight = Form1.form1.value_trackBar12;
                        command13.MinimumDotWidth = Form1.form1.value_trackBar13;
                        command13.Run(Form1.form1.imagescol[i - 1]);
                    }

                    if (Form1.form1.chckbox12 == true)
                    {
                        HolePunchRemoveCommand command14 = new HolePunchRemoveCommand();
                        command14.HolePunchRemove += new EventHandler<HolePunchRemoveCommandEventArgs>(HolePunchRemoveEvent_S1);
                        command14.Flags = HolePunchRemoveCommandFlags.UseDpi | HolePunchRemoveCommandFlags.UseCount | HolePunchRemoveCommandFlags.UseLocation;
                        command14.Location = HolePunchRemoveCommandLocation.Left;
                        command14.MaximumHoleCount = Form1.form1.value_trackBar18;
                        command14.MinimumHoleCount = Form1.form1.value_trackBar21;
                        command14.Run(Form1.form1.imagescol[i - 1]);
                    }

                    if (Form1.form1.chckbox13 == true)
                    {
                        InvertedTextCommand command15 = new InvertedTextCommand();
                        command15.InvertedText += new EventHandler<InvertedTextCommandEventArgs>(InvertedTextEvent_S1);
                        command15.Flags = InvertedTextCommandFlags.UseDpi;
                        command15.MaximumBlackPercent = Form1.form1.value_trackBar19;
                        command15.MinimumBlackPercent = Form1.form1.value_trackBar20;
                        command15.MinimumInvertHeight = Form1.form1.value_trackBar23;
                        command15.MinimumInvertWidth = Form1.form1.value_trackBar24;
                        command15.Run(Form1.form1.imagescol[i - 1]);
                    }

                    if (Form1.form1.chckbox16 == true)
                    {
                        BorderRemoveCommand command18 = new BorderRemoveCommand();
                        command18.BorderRemove += new EventHandler<BorderRemoveCommandEventArgs>(command_BorderRemove_S1);
                        command18.Border = BorderRemoveBorderFlags.All;
                        command18.Flags = BorderRemoveCommandFlags.UseVariance;
                        command18.Percent = Form1.form1.value_trackBar25;
                        command18.Variance = Form1.form1.value_trackBar26;
                        command18.WhiteNoiseLength = Form1.form1.value_trackBar28;
                        command18.Run(Form1.form1.imagescol[i - 1]);
                    }

                    if (Form1.form1.chckbox17 == true)
                    {
                        SmoothCommand command19 = new SmoothCommand();
                        command19.Smooth += new EventHandler<SmoothCommandEventArgs>(SmoothEventExample_S1);
                        command19.Flags = SmoothCommandFlags.FavorLong;
                        command19.Length = Form1.form1.value_trackBar31;
                        command19.Run(Form1.form1.imagescol[i - 1]);
                    }
                    // Prepare the command 
                    if (Form1.form1.chckbox19 == true)
                    {
                        RakeRemoveCommand command20 = new RakeRemoveCommand();
                        command20.RakeRemove += new EventHandler<RakeRemoveCommandEventArgs>(RakeRemoveEvent_S1);
                        command20.MinLength = Form1.form1.value_numUpDown1;           //ความยาวขั้นต่ำ
                        command20.MinWallHeight = Form1.form1.value_numUpDown2;       //ความสูงของกำแพงขั้นต่ำ
                        command20.MaxWidth = Form1.form1.value_numUpDown3;             //ความกว้างสูงสุด
                        command20.MaxWallPercent = Form1.form1.value_numUpDown4;      //เปอร์เซ็นต์กำแพงสูงสุด
                        command20.MaxSideteethLength = Form1.form1.value_numUpDown5;  //ความยาวฟันข้างสูงสุด
                        command20.MaxMidteethLength = Form1.form1.value_numUpDown6;   //ความยาวฟันกลางสูงสุด
                        command20.Gaps = Form1.form1.value_numUpDown7;                 //ช่องว่าง
                        command20.Variance = Form1.form1.value_numUpDown8;             //ความแปรปรวน
                        command20.TeethSpacing = Form1.form1.value_numUpDown9;         //ระยะห่างระหว่างฟัน
                        command20.AutoFilter = Form1.form1.chckbox20;       //ตัวกรองอัตโนมัติ
                        command20.Run(Form1.form1.imagescol[i - 1]);
                    }
                   
                  /*  using (Image destImage1 = RasterImageConverter.ConvertToImage(destImage, ConvertToImageOptions.None))
                    {
                        picReview2.Image = new Bitmap(destImage1);
                    }*/
                }
                else
                {

                   /* l_stateOutput.Text = "Image " + rasterImage.BitsPerPixel.ToString() + " BitsPerPixel";
                    //picReview2.ImageLocation = null;
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                    {
                        picReview2.Image = new Bitmap(destImage1);
                    }*/
                }
                /**/
                PictureBox pic3 = new PictureBox();
                using (Image destImage1 = RasterImageConverter.ConvertToImage(Form1.form1.imagescol[i - 1], ConvertToImageOptions.None))
                {
                    // piccenter.Image = new Bitmap(destImage1);
                    pic3.Image = new Bitmap(destImage1);
                }
                pic3.Height = 640; //ความสูงหน้ากระดาษ
                pic3.Width = 550;  //ความกว้างหน้ากระดาษ

                pic3.Location = new Point(x3, y3 + panel1.AutoScrollPosition.Y);
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
                this.panel1.Controls.Add(pic3);
                await Task.Delay(2000);
            }
            //progressBar1.Value = 0;
            btnSave.Enabled = true;
        }
        bool cancelAt50;
        void RunCommand(RasterImage image, RasterCommand command){
            // subscribe to the progress event of the command 
            command.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
            // if this is a flip command, we want to stop at 50 percent 
            cancelAt50 = command is FlipCommand;
            // run the command 
            command.Run(image);
            command.Progress -= new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
        }

        void command_Progress(object sender, RasterCommandProgressEventArgs e){
            // show the percentage 
            Console.WriteLine(e.Percent);
            // check if we need to cancel the command at 50% 
            if (e.Percent == 50 && cancelAt50)
                e.Cancel = true;
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RasterCodecs codecs = new RasterCodecs();
                codecs.ThrowExceptionsOnInvalidImages = true;
                // Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "pdf (*.pdf)|*.pdf";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK){
                    String savePath = saveFileDialog1.FileName;
                    var docWriter = new DocumentWriter();
                    // Begin the document 
                    var outputFileName = Path.Combine(saveFileDialog1.FileName,".pdf");
                    docWriter.BeginDocument(saveFileDialog1.FileName, DocumentFormat.Pdf);
                    // Finally, add a third page as an image 
                    var rasterPage = new DocumentWriterRasterPage();
                    // เพิ่มหน้าในเอกสาร PDF
                    foreach (RasterImage image in Form1.form1.imagescol)
                    {
                        using (rasterPage.Image = image)
                        {
                            // Add it 
                            docWriter.AddPage(rasterPage);
                        }
                    }
                    // Finally finish writing the HTML file on disk 
                    docWriter.EndDocument();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static class LEAD_VARS
        {
            public const string ImagesDir = @"C:\Users\Administrator\Downloads\merged";
        }
    }
}
