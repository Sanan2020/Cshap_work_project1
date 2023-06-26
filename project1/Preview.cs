using Leadtools;
using Leadtools.Codecs;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
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

namespace project1
{
    public partial class Preview : Form
    {
        private RasterImage destImage;

        public Preview()
        {
            InitializeComponent();
        }

        private async void Preview_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            //progressBar1.Value = 0;
            panel1.AutoScroll = true;
            panel1.BackColor = Color.DarkGray;
            //Form1 f1 = new Form1();
            //MessageBox.Show(Form1.form1.value_trackBar1.ToString());
            panel1.Controls.Clear();
            int w3 = 550 / 2;
            int x3 = (panel1.Width / 2) - w3;

            //int x3 = 40;//ระวหว่าง panel
            int y3 = 20;//ระวหว่าง panel
            int maxWidth3 = -1;

            //int munberImagescol = Convert.ToInt32(imagescol);
            //Console.WriteLine("munberImagescol: " + munberImagescol);
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

                 /*if (Form1.form1.chckbox21 == true)
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
                 Form1.form1.imagescol[i - 1] = destImage;
                    // Clean up 
                    Marshal.FreeHGlobal(buffer);
                 }*/
                //Form1.form1.imagescol[i - 1] =;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RasterCodecs codecs = new RasterCodecs();
                codecs.ThrowExceptionsOnInvalidImages = true;
                // Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "pdf (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String savePath = saveFileDialog1.FileName;
                    codecs.Save(Form1.form1.imagescol[0], Path.Combine(saveFileDialog1.FileName + ".pdf"), RasterImageFormat.RasPdf, 24);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
