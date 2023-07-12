﻿using DevComponents.DotNetBar;
using Leadtools.Drawing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing;
using Leadtools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools.Document.Writer;
using System.IO;
using Leadtools.Codecs;
using static System.Net.Mime.MediaTypeNames;

namespace project1
{
    public partial class dialogSaveAS : Office2007Form
    {
        public dialogSaveAS()
        {
            InitializeComponent();
        }
        int pageCount;
        private async void dialogSaveAS_Load(object sender, EventArgs e)
        {
            try
            {
                var docWriter = new DocumentWriter();
                // Begin the document 
                var outputFileName = Path.Combine(Form1.form1.savePath, ".pdf");
                docWriter.BeginDocument(Form1.form1.savePath, DocumentFormat.Pdf);
                // Finally, add a third page as an image 
                var rasterPage = new DocumentWriterRasterPage();

                RasterCodecs _rasterCodecs = new RasterCodecs();
                _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
                foreach (string img in Form1.form1.file)
                {
                    using (var imageInfo = _rasterCodecs.GetInformation(img, true)) //นับจำนวนเอกสาร
                    {
                        pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                    }
                    for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                    {
                        _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
                        _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
                        _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
                        _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
                        _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
                        var rasterImage = _rasterCodecs.Load(img, pageNumber);

                        label2.Text = $"Page {pageNumber} / {pageCount.ToString()}";
                    // progressBar1.Value += (Form1.form1.pageCount * 100) / 100;
                    ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
                    //Increase the brightness by 25 percent  of the possible range. 
                    command.Brightness = Form1.form1.value_trackBar1;   //484
                    command.Contrast = Form1.form1.value_trackBar2;     //394
                    command.Intensity = Form1.form1.value_trackBar3;    //118
                    command.Run(rasterImage);

                    UnsharpMaskCommand command2 = new UnsharpMaskCommand();
                    command2.Amount = Form1.form1.value_trackBar4;     //rate 0 - เกิน 1000
                    command2.Radius = Form1.form1.value_trackBar5;     //rate 1 - เกิน 1000
                    command2.Threshold = Form1.form1.value_trackBar6;  //rate 0 - 255
                    command2.ColorType = UnsharpMaskCommandColorType.Rgb;
                    command2.Run(rasterImage);

                    if (Form1.form1.selectCombobox > 0) 
                    {
                            Form1.form1.selectCombobox = Form1.form1.selectCombobox - 1;
                            //MessageBox.Show(selectCombobox.ToString());
                            BinaryFilterCommand command3 = new BinaryFilterCommand((BinaryFilterCommandPredefined)Form1.form1.selectCombobox);
                            command3.Run(rasterImage);
                    }
                   /* else
                    {
                        Form1.form1.selectCombobox = Form1.form1.selectCombobox - 1;
                        //MessageBox.Show(selectCombobox.ToString());
                        BinaryFilterCommand command3 = new BinaryFilterCommand((BinaryFilterCommandPredefined)Form1.form1.selectCombobox);
                        command3.Run(rasterImage);
                    }*/

                    if (Form1.form1.chckbox == true)
                    {
                        AutoColorLevelCommand command4 = new AutoColorLevelCommand();
                        command4.Run(rasterImage);
                    }

                    if (Form1.form1.chckbox2)
                    {
                        GrayScaleExtendedCommand command5 = new GrayScaleExtendedCommand();
                        command5.RedFactor = Form1.form1.value_trackBar7;
                        command5.GreenFactor = Form1.form1.value_trackBar8;
                        command5.BlueFactor = Form1.form1.value_trackBar9;
                        command5.Run(rasterImage);
                    }

                    if (Form1.form1.chckbox4 == true)
                    {
                        AutoBinaryCommand command7 = new AutoBinaryCommand();
                        //Apply Auto Binary Segment. 
                        command7.Run(rasterImage);
                    }

                    if (Form1.form1.chckbox5 == true)
                    {
                        MaximumCommand command8 = new MaximumCommand();
                        //Apply Maximum filter. 
                        command8.Dimension = Form1.form1.value_trbMaximum;
                        command8.Run(rasterImage);
                    }

                    if (Form1.form1.chckbox6 == true)
                    {
                        MinimumCommand command9 = new MinimumCommand();
                        //Apply the Minimum filter. 
                        command9.Dimension = Form1.form1.value_trbMinimum;
                        command9.Run(rasterImage);
                    }

                    if (Form1.form1.chckbox7 == true)
                    {
                        AutoBinarizeCommand command10 = new AutoBinarizeCommand();
                        command10.Run(rasterImage);
                    }

                    if (Form1.form1.chckbox8 == true)
                    {
                        GammaCorrectCommand command11 = new GammaCorrectCommand();
                        //Set a gamma value of 2.5. 
                        command11.Gamma = Form1.form1.value_trbGamma;
                        command11.Run(rasterImage);
                    }
                    if (Form1.form1.chckbox9 == true)
                    {
                        DynamicBinaryCommand command12 = new DynamicBinaryCommand();
                        command12.Dimension = Form1.form1.value_trbDynBin1;
                        command12.LocalContrast = Form1.form1.value_trbDynBin2;
                        // convert it into a black and white image without changing its bits per pixel. 
                        command12.Run(rasterImage);
                    }
                    if (Form1.form1.chckbox14 == true)
                    {
                        DeskewCommand command16 = new DeskewCommand();
                        //Deskew the image. 
                        command16.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea;
                        command16.Run(rasterImage);
                    }
                    if (Form1.form1.chckbox15 == true)
                    {
                        AutoCropCommand command17 = new AutoCropCommand();
                        //AutoCrop the image with 20 tolerance. 
                        command17.Threshold = Form1.form1.value_trackBar27;
                        command17.Run(rasterImage);
                    }
                    if (Form1.form1.chckbox3 == true)
                    {
                        DespeckleCommand command6 = new DespeckleCommand();
                        //Remove speckles from the image. 
                        command6.Run(rasterImage);
                    }
                    if (Form1.form1.chckbox18 == true)
                    {
                        FlipCommand flip = new FlipCommand(false);
                        RunCommand(rasterImage, flip);
                        // rotate the image by 45 degrees 
                        RotateCommand rotate = new RotateCommand();
                        rotate.Angle = (Form1.form1.value_trackBar29 * 100);
                        rotate.FillColor = RasterColor.FromKnownColor(RasterKnownColor.White);
                        rotate.Flags = RotateCommandFlags.Resize;
                        RunCommand(rasterImage, rotate);
                    }
                    if (Form1.form1.chckbox21 == true)
                    {
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
                            /**/
                        rasterImage = null;
                        rasterImage = destImage;
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
                            command13.Run(rasterImage);
           

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
                            command13.Run(rasterImage);
                        }

                        if (Form1.form1.chckbox12 == true)
                        {
                            HolePunchRemoveCommand command14 = new HolePunchRemoveCommand();
                            command14.HolePunchRemove += new EventHandler<HolePunchRemoveCommandEventArgs>(HolePunchRemoveEvent_S1);
                            command14.Flags = HolePunchRemoveCommandFlags.UseDpi | HolePunchRemoveCommandFlags.UseCount | HolePunchRemoveCommandFlags.UseLocation;
                            command14.Location = HolePunchRemoveCommandLocation.Left;
                            command14.MaximumHoleCount = Form1.form1.value_trackBar18;
                            command14.MinimumHoleCount = Form1.form1.value_trackBar21;
                            command14.Run(rasterImage);
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
                            command15.Run(rasterImage);
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
                            command18.Run(rasterImage);
                        }

                        if (Form1.form1.chckbox17 == true)
                        {
                            SmoothCommand command19 = new SmoothCommand();
                            command19.Smooth += new EventHandler<SmoothCommandEventArgs>(SmoothEventExample_S1);
                            command19.Flags = SmoothCommandFlags.FavorLong;
                            command19.Length = Form1.form1.value_trackBar31;
                            command19.Run(rasterImage);
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
                            command20.Run(rasterImage);
                        }
                    }

                    await Task.Delay(2000);

                        using (rasterPage.Image = rasterImage)
                    {
                        // Add it 
                        docWriter.AddPage(rasterPage);
                    }
                }
            }
                // Finally finish writing the HTML file on disk 
                docWriter.EndDocument();
                DialogResult res = MessageBox.Show("Save successful", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    //Some task…
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
