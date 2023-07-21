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
using Leadtools.Document.Writer;
using System.Reflection.Emit;
using System.Diagnostics;//
using System.Net.NetworkInformation;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.AxHost;

namespace project1
{

    public partial class Form1 : Office2007RibbonForm
    {
        internal static Form2 form2;
        internal static Form1 form1;
        internal static Preview pv;
        internal static Form1Export f1ex;

        public String folderPath;
        RasterCodecs codecs = new RasterCodecs();
        public int value_trackBar1=0;
        public int value_trackBar2=0;
        public int value_trackBar3=0;
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
        public int value_trbGamma = 250;
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
        public int value_trackBar29 = 0;
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
        public bool value_cbbPerProp = true;
        public int value_tbLRV1 = 2;
        public int value_tbLRV2 = 5;
        public int value_tbLRV3 = 200;
        public int value_tbLRV4 = 10;
        public int value_tbLRV5 = 7;
        public bool chckbox_LRV = false;
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
        public class pathLicense
        {
            String license;
            String key;
            public string License   // property
            {
                get { return license; }
                set { license = value; }
            }

            public string Key   // property
            {
                get { return key; }
                set { key = value; }
            }
        }
        void fncSetup() {
            try { 
            flowLayoutPanel1.AutoScroll = true;
           
            comboBox1.Items.Add("--Select--");
            comboBox1.Items.Add("ErosionOmniDirectional");
            comboBox1.Items.Add("ErosionHorizontal");
            comboBox1.Items.Add("ErosionVertical");
            comboBox1.Items.Add("ErosionDiagonal");
            comboBox1.Items.Add("DilationOmniDirectional");
            comboBox1.Items.Add("DilationHorizontal");
            comboBox1.Items.Add("DilationVertical");
            comboBox1.Items.Add("DilationDiagonal");
            comboBox1.SelectedIndex = 0;

            cbBox2re();
            trackBar4.Value = value_trackBar4;
            //l_amount.Text = value_trackBar4.ToString();
            trackBar5.Value = value_trackBar5;
            //l_radius.Text = value_trackBar5.ToString();
            trackBar6.Value = value_trackBar6;
           // l_threshold.Text = value_trackBar6.ToString();

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
            trackBar29.Value = value_trackBar29;
            l_RotateImage.Text = value_trackBar29.ToString();

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
            value_trbGamma = 250;
            trbGamma.Value = value_trbGamma;
            l_gamma.Text = value_trbGamma.ToString();

            /*layout*/
            splitContainer1.Panel1.AutoScroll = true;
            //splitContainer1.Panel1.Width = 200;
            // splitContainer1.Panel1.Dock = DockStyle.Right;
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel1.BackColor = Color.DarkGray;
            splitContainer1.Panel2.BackColor = Color.DarkGray;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            /**/
            flowLayoutPanel1.Visible = true;
            this.progressBarX1.Visible = false;

            btnLineRemove.Enabled = false;
            btnLineRemove.FlatStyle = FlatStyle.Standard;
            btnDotRemove.Enabled = false;
            btnDotRemove.FlatStyle = FlatStyle.Standard;
            btnHolePunchRemove.Enabled = false;
            btnHolePunchRemove.FlatStyle = FlatStyle.Standard;
            btnInvertedText.Enabled = false;
            btnInvertedText.FlatStyle = FlatStyle.Standard;
            btnBorderRemove.Enabled = false;
            btnBorderRemove.FlatStyle = FlatStyle.Standard;
            btnSmooth.Enabled = false;
            btnSmooth.FlatStyle = FlatStyle.Standard;
            btnRakeRemove.Enabled = false;
            btnRakeRemove.FlatStyle = FlatStyle.Standard;
            btnLineRemoveV.Enabled = false;
            btnLineRemoveV.FlatStyle = FlatStyle.Standard;

            cbbPerProp.Items.Add("False");
            cbbPerProp.Items.Add("True");
            cbbPerProp.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void fncLicense() {
            try
            {
                if (System.IO.File.Exists("pathLicense.xml"))//ถ้าเจอไฟล์
                {
                    List<pathLicense> LpfnameLoad = N2N.Data.Serialization.Serialize<List<pathLicense>>.DeserializeFromXmlFile("pathLicense.xml");
                    RasterSupport.SetLicense(LpfnameLoad[0].License, File.ReadAllText(LpfnameLoad[0].Key));
                    /*  RasterSupport.SetLicense(@"", 
                    File.ReadAllText(@""));*/
                    bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
                    if (isLocked)
                    {
                        Console.WriteLine("Document support is locked");
                        Form3 f3 = new Form3();
                        f3.FormClosed += f3_FormClosed;
                        f3.ShowDialog();
                    }
                    else
                    {
                        Console.WriteLine("Document support is unlocked");
                    }
                }
                else
                {
                    Form3 f3 = new Form3();
                    f3.FormClosed += f3_FormClosed;
                    f3.ShowDialog();
                    //MessageBox.Show("not found");   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           fncLicense();
            fncSetup();
        }
        private void f3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar2_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar3_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar4_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar5_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar6_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectCombobox = comboBox1.SelectedIndex;
                Image();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            value_trackBar1 = trackBar1.Value;
            numeric_brightness.Value = value_trackBar1;
           // l_brightness.Text = value_trackBar1.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            value_trackBar2 = trackBar2.Value;
            numeric_contrast.Value = value_trackBar2;
           // l_contrast.Text = value_trackBar2.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            value_trackBar3 = trackBar3.Value;
            numeric_intensity.Value = value_trackBar3;
           // l_intensity.Text = value_trackBar3.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            value_trackBar4 = trackBar4.Value;
            numeric_amount.Value = value_trackBar4;
           // l_amount.Text = value_trackBar4.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            value_trackBar5 = trackBar5.Value;
            numeric_radius.Value = value_trackBar5;
            //l_radius.Text = value_trackBar5.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            value_trackBar6 = trackBar6.Value;
            numeric_threshold.Value = value_trackBar6;
            //l_threshold.Text = value_trackBar6.ToString();
        }

        public void ResetValue()
        {
            try
            {
                value_trackBar1 = 0;
                trackBar1.Value = value_trackBar1;
                //l_brightness.Text = value_trackBar1.ToString();
                value_trackBar2 = 0;
                trackBar2.Value = value_trackBar2;
               // l_contrast.Text = value_trackBar2.ToString();
                value_trackBar3 = 0;
                trackBar3.Value = value_trackBar3;
               // l_intensity.Text = value_trackBar3.ToString();
                numeric_brightness.Value = value_trackBar1;
                numeric_contrast.Value = value_trackBar2;
                numeric_intensity.Value = value_trackBar3;

                value_trackBar4 = 1;
                trackBar4.Value = value_trackBar4;
                //l_amount.Text = value_trackBar4.ToString();
                value_trackBar5 = 1;
                trackBar5.Value = value_trackBar5;
               //l_radius.Text = value_trackBar5.ToString();
                value_trackBar6 = 1;
                trackBar6.Value = value_trackBar6;
                //l_threshold.Text = value_trackBar6.ToString();
                numeric_amount.Value = value_trackBar4;
                numeric_radius.Value = value_trackBar5;
                numeric_threshold.Value = value_trackBar6;

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
                value_trbGamma = 250;
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

                //tb_profile.Text = "";
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

                if (stateBits != true)
                {
                    chckbox21 = false;
                    checkBox21.Checked = chckbox21;
                }
                cbboxUseProfile.SelectedItem = "Default";
                cbbPerProp.SelectedIndex = 0;
                value_cbbPerProp = false;

                value_tbLRV1 = 2;

                value_tbLRV2 = 5;
                value_tbLRV3 = 200;
                value_tbLRV4 = 10;
                value_tbLRV5 = 7;
                chckbox_LRV = false;

                chbox_LRV.Checked = chckbox_LRV;
                tbLRV1.Value = value_tbLRV1;
                l_tbLRV1.Text = value_tbLRV1.ToString();
                tbLRV2.Value = value_tbLRV2;
                l_tbLRV2.Text = value_tbLRV2.ToString();
                tbLRV3.Value = value_tbLRV3;
                l_tbLRV3.Text = value_tbLRV3.ToString();
                tbLRV4.Value = value_tbLRV4;
                l_tbLRV4.Text = value_tbLRV4.ToString();
                tbLRV5.Value = value_tbLRV5;
                l_tbLRV5.Text = value_tbLRV5.ToString();
                Image();

               /* using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }*/
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox1.Checked == true)
            {
                chckbox = true;
                 Image();
            }
            else
            {
                chckbox = false;
                Image();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox2.Checked == true)
            {
                chckbox2 = true;
                Image();
            }
            else
            {
                chckbox2 = false;
                 Image();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        int sum;
        //+ trackBar7.Value + trackBar7.Value;
        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            sum = value_trackBar7 + value_trackBar8 + value_trackBar9;
            if (sum <= 1000)
            {
                value_trackBar7 = trackBar7.Value;
                l_redfactor.Text = value_trackBar7.ToString();
            }
            else {
                MessageBox.Show("เกิน 1,000");
            }
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            sum = value_trackBar7 + value_trackBar8 + value_trackBar9;
            if (sum <= 1000)
            {
                value_trackBar8 = trackBar8.Value;
                l_greenfactor.Text = value_trackBar8.ToString();
            }
            else
            {
                MessageBox.Show("เกิน 1,000");
            }
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            sum = value_trackBar7 + value_trackBar8 + value_trackBar9;
            if (sum <= 1000)
            {
                value_trackBar9 = trackBar9.Value;
                l_bluefactor.Text = value_trackBar9.ToString();
            }
            else {
                MessageBox.Show("เกิน 1,000");
            }
        }
        private void trackBar7_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
            //Image();
        }

        private void trackBar8_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar9_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }
        private bool Expanded = false;
        private void btnConBrigtIntens_Click(object sender, EventArgs e)
        {
            try { 
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Expanded2 = false;
        private void btnUnsharpMask_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded2)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panUnsharpMask.Height = 28;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panUnsharpMask.Height = 237;
            }
            Expanded2 = !Expanded2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Expanded3 = false;
        private void btnGrayScale_Click(object sender, EventArgs e)
        {
            try { 
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox3.Checked == true)
            {
                chckbox3 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox3 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox4.Checked == true)
            {
                chckbox4 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox4 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox5.Checked == true)
            {
                chckbox5 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox5 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox6.Checked == true)
            {
                chckbox6 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox6 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox7.Checked == true)
            {
                chckbox7 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox7 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox8.Checked == true)
            {
                chckbox8 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox8 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox9.Checked == true)
            {
                chckbox9 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox9 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
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
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trbDynBin2_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
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
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trbMinimum_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trbGamma_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox10.Checked == true)
            {
                chckbox10 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox10 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox11.Checked == true)
            {
                chckbox11 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox11 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox12.Checked == true)
            {
                chckbox12 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox12 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox13.Checked == true)
            {
                chckbox13 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox13 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox14.Checked == true)
            {
                chckbox14 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox14 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox15.Checked == true)
            {
                chckbox15 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox15 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox16.Checked == true)
            {
                chckbox16 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox16 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox17.Checked == true)
            {
                chckbox17 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            else
            {
                chckbox17 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded5 = false;
        private void btnDotRemove_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded5)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panDotRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panDotRemove.Height = 301;
            }
            Expanded5 = !Expanded5;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded6 = false;
        private void btnLineRemove_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded6)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panLineRemove.Height = 30;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panLineRemove.Height = 344;
            }
            Expanded6 = !Expanded6;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded7 = false;
        private void btnHolePunchRemove_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded7)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panHolePunchRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panHolePunchRemove.Height = 180;
            }
            Expanded7 = !Expanded7;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded8 = false;
        private void btnInvertedText_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded8)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panInvertedText.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panInvertedText.Height = 293;
            }
            Expanded8 = !Expanded8;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded9 = false;
        private void btnAutoCrop_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded9)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panAutoCrop.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panAutoCrop.Height = 136;
            }
            Expanded9 = !Expanded9;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded10 = false;
        private void btnBorderRemove_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded10)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panBorderRemove.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panBorderRemove.Height = 239;
            }
            Expanded10 = !Expanded10;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded11 = false;
        private void btnSmooth_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded11)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panSmooth.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panSmooth.Height = 129;
            }
            Expanded11 = !Expanded11;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar11_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar12_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar13_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
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
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar15_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar16_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar17_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar22_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
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
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar21_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
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
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar20_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar23_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar24_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar27_Scroll(object sender, EventArgs e)
        {
            value_trackBar27 = trackBar27.Value;
            l_cropThreshold.Text = value_trackBar27.ToString();
        }

        private void trackBar27_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
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
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar26_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar28_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void trackBar31_Scroll(object sender, EventArgs e)
        {
            value_trackBar31 = trackBar31.Value;
            l_length.Text = value_trackBar31.ToString();
        }

        private void trackBar31_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox18.Checked == true)
                {
                    chckbox18 = true;
                    using (ProgressPopup pp = new ProgressPopup(Image))
                    {
                        pp.ShowDialog();
                    }
                }
                else
                {
                    chckbox18 = false;
                    using (ProgressPopup pp = new ProgressPopup(Image))
                    {
                        pp.ShowDialog();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar29_Scroll(object sender, EventArgs e)
        {
            value_trackBar29 = trackBar29.Value;
            l_RotateImage.Text = value_trackBar29.ToString();
        }

        private void trackBar29_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox19.Checked == true)
                {
                    chckbox19 = true;
                    using (ProgressPopup pp = new ProgressPopup(Image))
                    {
                        pp.ShowDialog();
                    }
                }
                else
                {
                    chckbox19 = false;
                    using (ProgressPopup pp = new ProgressPopup(Image))
                    {
                        pp.ShowDialog();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Expanded12;
        private void btnFlipRotate_Click(object sender, EventArgs e)
        {
            try { 
            if (Expanded12)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panFlipRotate.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panFlipRotate.Height = 176;
            }
            Expanded12 = !Expanded12;
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded13;
        private void btnRakeRemove_Click(object sender, EventArgs e)
        {
            try { 
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
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox20.Checked == true)
            {
                chckbox20 = true;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
                //Image();
            }
            else
            {
                chckbox20 = false;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
                //Image();
            }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                value_numUpDown1 = (int)numUpDown1.Value;
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void numUpDown2_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown2 = (int)numUpDown2.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown3_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown3 = (int)numUpDown3.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown4_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown4 = (int)numUpDown4.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown5_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown5 = (int)numUpDown5.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown6_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown6 = (int)numUpDown6.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown7_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown7 = (int)numUpDown7.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown8_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown8 = (int)numUpDown8.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void numUpDown9_ValueChanged(object sender, EventArgs e)
        {
            try { 
            value_numUpDown9 = (int)numUpDown9.Value;
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
       
        private void btnResetConBrigtIntens_Click(object sender, EventArgs e)
        {
            try { 
            value_trackBar1 = 0;
            trackBar1.Value = value_trackBar1;
            numeric_brightness.Value = value_trackBar1;
           // l_brightness.Text = value_trackBar1.ToString();
            value_trackBar2 = 0;
            trackBar2.Value = value_trackBar2;
            numeric_contrast.Value = value_trackBar2;
           // l_contrast.Text = value_trackBar2.ToString();
            value_trackBar3 = 0;
            trackBar3.Value = value_trackBar3;
            numeric_intensity.Value = value_trackBar3;
           // l_intensity.Text = value_trackBar3.ToString();
                Image();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void btnResetUnsharpMask_Click(object sender, EventArgs e)
        {
            try { 
            value_trackBar4 = 1;
            trackBar4.Value = value_trackBar4;
            //l_amount.Text = value_trackBar4.ToString();
            value_trackBar5 = 1;
            trackBar5.Value = value_trackBar5;
           // l_radius.Text = value_trackBar5.ToString();
            value_trackBar6 = 1;
            trackBar6.Value = value_trackBar6;
            //l_threshold.Text = value_trackBar6.ToString();
            numeric_amount.Value = value_trackBar4;
            numeric_radius.Value = value_trackBar5;
            numeric_threshold.Value = value_trackBar6;
            Image();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void btnResetGrayScale_Click(object sender, EventArgs e)
        {
            try { 
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
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetDotRemove_Click(object sender, EventArgs e)
        {
            try { 
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
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetLineRemove_Click(object sender, EventArgs e)
        {
            try { 
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
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetHolePunchRemove_Click(object sender, EventArgs e)
        {
            try { 
            chckbox12 = false;
            checkBox12.Checked = chckbox12;
            value_trackBar18 = 4;
            trackBar18.Value = value_trackBar18;
            l_maximumhole.Text = value_trackBar18.ToString();
            value_trackBar21 = 2;
            trackBar21.Value = value_trackBar21;
            l_minimumhole.Text = value_trackBar21.ToString();
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetInvertedText_Click(object sender, EventArgs e)
        {
            try { 
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
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetAutoCrop_Click(object sender, EventArgs e)
        {
            try { 
            chckbox15 = false;
            checkBox15.Checked = chckbox15;
            value_trackBar27 = 20;
            trackBar27.Value = value_trackBar27;
            l_cropThreshold.Text = value_trackBar27.ToString();
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetBorderRemove_Click(object sender, EventArgs e)
        {
            try { 
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
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetSmooth_Click(object sender, EventArgs e)
        {
            try { 
            chckbox17 = false;
            checkBox17.Checked = chckbox17;
            value_trackBar31 = 2;
            trackBar31.Value = value_trackBar31;
            l_length.Text = value_trackBar31.ToString();
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetFlipRotate_Click(object sender, EventArgs e)
        {
            try { 
            chckbox18 = false;
            checkBox18.Checked = chckbox18;
            value_trackBar29 = 0;
            trackBar29.Value = value_trackBar29;
            l_RotateImage.Text = value_trackBar29.ToString();
            cbbPerProp.SelectedIndex = 0;
            value_cbbPerProp = false;
            Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetRakeRemove_Click(object sender, EventArgs e)
        {
            try { 
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
                using (ProgressPopup pp = new ProgressPopup(Image))
                {
                    pp.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cbBox2re()
        {
            try {
                cbboxUseProfile.Items.Clear();
                cbboxUseProfile.Items.Add("Default");
                if (System.IO.File.Exists("testin.xml"))//ถ้าเจอไฟล์
            {
                cbboxUseProfile.Items.Clear();
                cbboxUseProfile.Items.Add("Default");
                List<profile2> LpfnameLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                for (int i = 0; i < LpfnameLoad.Count; i++)
                {
                    cbboxUseProfile.Items.Add(LpfnameLoad[i].Profilename);
                }
                    
            }
                cbboxUseProfile.SelectedItem = "Default";
            }
            catch (Exception ex){MessageBox.Show(ex.Message);}
        }
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
        public String[] file;

        int pdname=1;
        RasterCodecs _rasterCodecs = new RasterCodecs();
        PictureBox picReview2 = new PictureBox();
        int xRev;
        public void crepic() {
            try
            {
                this.splitContainer1.Panel2.Controls.Clear();
                picReview2.Height = 850; //ความกว้างหน้ากระดาษ
                picReview2.Width = 850;  //ความสูงหน้ากระดาษ
                xRev = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
                if (xRev < 0)
                    xRev = 0;
                var yRev = (splitContainer1.Panel2.Height / 2) - (picReview2.Height / 2);
                if (yRev < 0)
                    yRev = 0;
                picReview2.Location = new Point(xRev, yRev);
                Console.WriteLine(picReview2.Location);
                picReview2.SizeMode = PictureBoxSizeMode.Zoom;
                this.splitContainer1.Panel2.Controls.Add(picReview2);
                picReview2.ImageLocation = null;

               /* this.splitContainer1.Panel2.Controls.Clear();
              //  picReview2.Height = 850; //ความกว้างหน้ากระดาษ
              //  picReview2.Width = 850;  //ความสูงหน้ากระดาษ
                splitContainer1.Panel2.MouseWheel += new MouseEventHandler(picReview2_MouseEnter);
                //pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseEnter);
                picReview2.Left = (splitContainer1.Panel2.Width - picReview2.Width) / 2;
                picReview2.Top = (splitContainer1.Panel2.Height - picReview2.Height) / 2;
                picReview2.SizeMode = PictureBoxSizeMode.Zoom;
                this.splitContainer1.Panel2.Controls.Add(picReview2);*/
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void picReview2_MouseEnter(object sender, MouseEventArgs e)
        {
           
            if (Control.ModifierKeys == Keys.Control)
            {
                picReview2.Focus();
                if (e.Delta > 0)
                {
                    picReview2.Size = new Size((int)(picReview2.Width + 10), (int)(picReview2.Height + 10));
                    picReview2.Left = (splitContainer1.Panel2.Width - picReview2.Width) / 2;
                    picReview2.Top = (splitContainer1.Panel2.Height - picReview2.Height) / 2;
                }
                else if (e.Delta < 0)
                {
                    splitContainer1.Panel1.VerticalScroll.Value = 100;
                    picReview2.Size = new Size((int)(picReview2.Width - 10), (int)(picReview2.Height - 10));
                    picReview2.Left = (splitContainer1.Panel2.Width - picReview2.Width) / 2;
                    picReview2.Top = (splitContainer1.Panel2.Height - picReview2.Height) / 2;
                }
            }
        }
        String bpp;
        
        public async void Image()
        {
            try
            {
                _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
                if (file != null)
                {
                    cbboxUseProfile.Enabled = true;
                    //checkBox21.Enabled = true;
                    btnReset.Enabled = true;
                    btnSave.Enabled = true;
                    btnSavepf.Enabled = true;
                foreach (string img in file)
                {
                    // CodecsPdfOptions & CodecsPdfLoadOptions reference 
                    _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
                    _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
                    _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
                    _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
                    _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
                    RasterImage rasterImage = _rasterCodecs.Load(img, pdname);

                    ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
                    //Increase the brightness by 25 percent  of the possible range. 
                    command.Contrast = value_trackBar2;     //394
                    command.Brightness = value_trackBar1;   //484
                    command.Intensity = value_trackBar3;    //118
                    command.Run(rasterImage);

                    UnsharpMaskCommand command2 = new UnsharpMaskCommand();
                    command2.Amount = value_trackBar4;     //rate 0 - เกิน 1000
                    command2.Radius = value_trackBar5;     //rate 1 - เกิน 1000
                    command2.Threshold = value_trackBar6;  //rate 0 - 255
                    command2.ColorType = UnsharpMaskCommandColorType.Rgb;
                    command2.Run(rasterImage);

                    if (selectCombobox > 0) {
                       int level = selectCombobox - 1;
                       //MessageBox.Show(selectCombobox.ToString());
                       BinaryFilterCommand command3 = new BinaryFilterCommand((BinaryFilterCommandPredefined)level);
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
                        //bool flip;
                    if (chckbox18 == true)
                    {
                        FlipCommand flip = new FlipCommand(value_cbbPerProp);
                        RunCommand(rasterImage, flip);
                    }
                        RotateCommand rotate = new RotateCommand();
                        rotate.Angle = (value_trackBar29 * 100);
                        rotate.FillColor = RasterColor.FromKnownColor(RasterKnownColor.White);
                        rotate.Flags = RotateCommandFlags.Resize;
                        RunCommand(rasterImage, rotate);

                    if (checkBox21.Checked == true)
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

                        rasterImage = null;
                        rasterImage = destImage;

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
                            command13.Run(rasterImage);

                        }
                        if (chckbox_LRV == true) {
                            LineRemoveCommand commandv = new LineRemoveCommand();
                            commandv.LineRemove += new EventHandler<LineRemoveCommandEventArgs>(LineRemoveEvent_S1);
                            commandv.Type = LineRemoveCommandType.Vertical;
                            commandv.Flags = LineRemoveCommandFlags.UseGap;
                            commandv.GapLength = value_tbLRV1;
                            commandv.MaximumLineWidth = value_tbLRV2;
                            commandv.MinimumLineLength = value_tbLRV3;
                            commandv.MaximumWallPercent = value_tbLRV4;
                            commandv.Wall = value_tbLRV5;
                            commandv.Run(rasterImage);
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
                            command13.Run(rasterImage);
                        }

                        if (chckbox12 == true)
                        {
                            HolePunchRemoveCommand command14 = new HolePunchRemoveCommand();
                            command14.HolePunchRemove += new EventHandler<HolePunchRemoveCommandEventArgs>(HolePunchRemoveEvent_S1);
                            command14.Flags = HolePunchRemoveCommandFlags.UseDpi | HolePunchRemoveCommandFlags.UseCount | HolePunchRemoveCommandFlags.UseLocation;
                            command14.Location = HolePunchRemoveCommandLocation.Left;
                            command14.MaximumHoleCount = value_trackBar18;
                            command14.MinimumHoleCount = value_trackBar21;
                            command14.Run(rasterImage);
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
                            command15.Run(rasterImage);
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
                            command18.Run(rasterImage);
                        }

                        if (chckbox17 == true)
                        {
                            SmoothCommand command19 = new SmoothCommand();
                            command19.Smooth += new EventHandler<SmoothCommandEventArgs>(SmoothEventExample_S1);
                            command19.Flags = SmoothCommandFlags.FavorLong;
                            command19.Length = value_trackBar31;
                            command19.Run(rasterImage);
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
                            command20.Run(rasterImage);
                        }
                    }
                    bpp = "Output: "+rasterImage.BitsPerPixel+" Bits";
                    l_stateOutput.Invoke((MethodInvoker)(() => { l_stateOutput.Text = bpp; }));
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                    {
                        picReview2.Image = new Bitmap(destImage1);
                    }
                    rasterImage.Dispose();
                }
                
            }
             }catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
            //Thread.Sleep(10);
            await Task.Delay(1000);
        }
       
        private async void pic2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                 PictureBox pb = (PictureBox)sender;
                 pdname = int.Parse(pb.Name);
                 using (ProgressPopup pp = new ProgressPopup(Image))
                 {
                     pp.ShowDialog();
                 }
                //Image();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        bool stateBits = false;
        private async void btnOpen_Click(object sender, EventArgs e)
        {
            try{
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All File |*.pdf; *.png; *.jpg; *.bmp; *.tif;|PDF File (*.pdf)|*.pdf|Image File (*.png *.jpg *.bmp *.tif)|*.png; *.jpg; *.bmp; *.tif;";
                DialogResult dr = ofd.ShowDialog();
                file = null;
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    splitContainer1.Panel1.Controls.Clear();

                    this.progressBarX1.Visible = true;
                    crepic(); //สร้าง picReview         
                    file = ofd.FileNames;
                    int w2 = 150 / 2;
                    int x2 = (splitContainer1.Panel1.Width / 2) - w2;
                    //int x3 = 40;//ระวหว่าง panel
                    int y2 = 20;//ระวหว่าง panel
                    int maxWidth2 = -1;
                    RasterCodecs _rasterCodecs = new RasterCodecs();
                    //Load documents at 300 DPI for better viewing
                    // _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
                    _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
                    _rasterCodecs.Options.Pdf.Load.GraphicsAlpha = 4;
                    _rasterCodecs.Options.Pdf.Load.DisableCieColors = false;
                    _rasterCodecs.Options.Pdf.Load.DisableCropping = false;
                    _rasterCodecs.Options.Pdf.Load.EnableInterpolate = false;
                    ResetValue();
                    foreach (string img in file)
                    {
                        using (var imageInfo = _rasterCodecs.GetInformation(img, true))
                        { //นับจำนวนเอกสาร
                            pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                        }
                        Console.WriteLine("Page " + pageCount);

                        // Loads all the pages into the viewer
                        for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                        {
                            // Load it as a raster image and add it
                            var rasterImage = _rasterCodecs.Load(img, pageNumber);
                            l_numberPages.Text = $"Page {pageNumber} / {pageCount.ToString()}";
                            l_stateInput.Text = "Input: " + rasterImage.BitsPerPixel.ToString() + " Bits";
                            if (rasterImage.BitsPerPixel == 1)
                            {
                                stateBits = true;
                                chckbox21 = true;
                                checkBox21.Checked = chckbox21;
                                checkBox21.Enabled = false;
                            }
                            else
                            {
                                stateBits = false;
                                chckbox21 = false;
                                checkBox21.Checked = chckbox21;
                                checkBox21.Enabled = true;
                            }

                            this.progressBarX1.MarqueeAnimationSpeed = 20;
                            PictureBox pic2 = new PictureBox();
                            pic2.Height = 140;
                            pic2.Width = 120;
                            pic2.Location = new Point(x2, y2 + splitContainer1.Panel1.AutoScrollPosition.Y); //แก้ปัญหาการวางผิดตำแหน่ง
                            pic2.SizeMode = PictureBoxSizeMode.Zoom;
                            pic2.BorderStyle = BorderStyle.FixedSingle;
                            pic2.Name = pageNumber.ToString();

                            y2 += pic2.Height + 10;
                            maxWidth2 = Math.Max(pic2.Height, maxWidth2);
                            if (x2 > this.ClientSize.Width - 100)
                            {
                                y2 = 20;
                                x2 += maxWidth2 + 100;
                            }

                            //แก้*
                            using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                            {
                                //Console.WriteLine(pageNumber+"check " + destImage1.HorizontalResolution+" "+ destImage1.VerticalResolution);
                                // destImage1.
                                pic2.Image = new Bitmap(destImage1);
                                destImage1.Dispose();
                            }
                            pdname = 1;
                            this.splitContainer1.Panel1.Controls.Add(pic2);
                            //Image();

                            //Console.WriteLine(pic2.Name);
                            pic2.MouseClick += new MouseEventHandler(pic2_MouseClick);

                            Process currentProcess = Process.GetCurrentProcess();
                            long usedMemory = currentProcess.PrivateMemorySize64;
                            Console.WriteLine(usedMemory);

                          //  await Task.Delay(1000);
                            //Thread.Sleep(500);
                            // Clean up 
                            rasterImage.Dispose();
                        }
                        _rasterCodecs.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                this.progressBarX1.Visible = false;
     }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        public String savePath;
        public String fill;
        public String fill2;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RasterCodecs codecs = new RasterCodecs();
                codecs.ThrowExceptionsOnInvalidImages = true;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PDF |*.pdf|JPEG |*.jpg|BMP |*.bmp|GIF |*.gif|PNG |*.png";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK){
                    savePath = saveFileDialog1.FileName;
                    fill  = saveFileDialog1.FileName;
                    string[] array = fill.Split('.');
                    fill = array[1];
                    fill2 = array[0];
                    dialogSaveAS dialogSaveAS = new dialogSaveAS();
                    dialogSaveAS.ShowDialog();
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void checkBox21_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            try { 
                chckbox21 = checkBox21.Checked;
                if (chckbox21 == true)
                {
                btnLineRemove.Enabled = true;
                btnLineRemove.FlatStyle = FlatStyle.Flat;
                btnResetLineRemove.Enabled = true;
                btnDotRemove.Enabled = true;
                btnDotRemove.FlatStyle = FlatStyle.Flat;
                btnResetDotRemove.Enabled = true;
                btnHolePunchRemove.Enabled = true;
                btnHolePunchRemove.FlatStyle = FlatStyle.Flat;
                btnResetHolePunchRemove.Enabled = true;
                btnInvertedText.Enabled = true;
                btnInvertedText.FlatStyle = FlatStyle.Flat;
                btnResetInvertedText.Enabled = true;
                btnBorderRemove.Enabled = true;
                btnBorderRemove.FlatStyle = FlatStyle.Flat;
                btnResetBorderRemove.Enabled = true;
                btnSmooth.Enabled = true;
                btnSmooth.FlatStyle = FlatStyle.Flat;
                btnResetSmooth.Enabled = true;
                btnRakeRemove.Enabled = true;
                btnRakeRemove.FlatStyle = FlatStyle.Flat;
                btnResetRakeRemove.Enabled = true;
                btnLineRemoveV.Enabled = true;
                btnLineRemoveV.FlatStyle = FlatStyle.Flat;
                }
                else {
                    btnLineRemove.Enabled = false;
                    btnLineRemove.FlatStyle = FlatStyle.Standard;
                    btnResetLineRemove.Enabled = false;
                    btnDotRemove.Enabled = false;
                    btnDotRemove.FlatStyle = FlatStyle.Standard;
                    btnResetDotRemove.Enabled = false;
                    btnHolePunchRemove.Enabled = false;
                    btnHolePunchRemove.FlatStyle = FlatStyle.Standard;
                    btnResetHolePunchRemove.Enabled = false;
                    btnInvertedText.Enabled = false;
                    btnInvertedText.FlatStyle = FlatStyle.Standard;
                    btnResetInvertedText.Enabled= false;
                    btnBorderRemove.Enabled = false;
                    btnBorderRemove.FlatStyle = FlatStyle.Standard;
                    btnResetBorderRemove.Enabled =false;
                    btnSmooth.Enabled = false;
                    btnSmooth.FlatStyle = FlatStyle.Standard;
                    btnResetSmooth.Enabled = false;
                    btnRakeRemove.Enabled = false;
                    btnRakeRemove.FlatStyle = FlatStyle.Standard;
                    btnResetRakeRemove.Enabled=false;
                    btnLineRemoveV.Enabled = false;
                    btnLineRemoveV.FlatStyle = FlatStyle.Standard;
                }
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbboxUseProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (file != null) { 
                int numfp = cbboxUseProfile.SelectedIndex;
               
                if (cbboxUseProfile.SelectedItem.ToString() == "Default")
                {
                    ResetValue();
                   // btnRemovepf.Enabled = false;
                }
                else
                {
                    btnRemovepf.Enabled = true;
                    List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                    profile2 profile3 = ProfileLoad.Where(c => c.Profilename == cbboxUseProfile.SelectedItem.ToString()).FirstOrDefault();

                    //ความสว่าง
                    value_trackBar1 = profile3.Brightness;
                    trackBar1.Value = value_trackBar1;
                    //l_brightness.Text = value_trackBar1.ToString();
                    value_trackBar2 = profile3.Contrast;
                    trackBar2.Value = value_trackBar2;
                    //l_contrast.Text = value_trackBar2.ToString();
                    value_trackBar3 = profile3.Intensity;
                    trackBar3.Value = value_trackBar3;
                    //l_intensity.Text = value_trackBar3.ToString();
                    numeric_brightness.Value = value_trackBar1;
                    numeric_contrast.Value = value_trackBar2;
                    numeric_intensity.Value = value_trackBar3;
                        //ความคมชัด
                    value_trackBar4 = profile3.Amount;
                    trackBar4.Value = value_trackBar4;
                   // l_amount.Text = value_trackBar4.ToString();
                    value_trackBar5 = profile3.Radius;
                    trackBar5.Value = value_trackBar5;
                  //  l_radius.Text = value_trackBar5.ToString();
                    value_trackBar6 = profile3.Threshold;
                    trackBar6.Value = value_trackBar6;
                   // l_threshold.Text = value_trackBar6.ToString();
                    numeric_amount.Value = value_trackBar4;
                    numeric_radius.Value = value_trackBar5;
                    numeric_threshold.Value = value_trackBar6;
                    //Gray scale
                    chckbox2 = profile3.UseGrayScale;
                    checkBox2.Checked = chckbox2;
                    value_trackBar7 = profile3.Redfactor;
                    trackBar7.Value = value_trackBar7;
                    l_redfactor.Text = value_trackBar7.ToString();
                    value_trackBar8 = profile3.Greenfactor;
                    trackBar8.Value = value_trackBar8;
                    l_greenfactor.Text = value_trackBar8.ToString();
                    value_trackBar9 = profile3.Bluefactor;
                    trackBar9.Value = value_trackBar9;
                    l_bluefactor.Text = value_trackBar9.ToString();
                    //Document Image Cleanup Functions
                    chckbox7 = profile3.AutoBinarize;
                    checkBox7.Checked = chckbox7;
                    chckbox3 = profile3.Despeckle;
                    checkBox3.Checked = chckbox3;
                    chckbox9 = profile3.DynamicBinary;
                    checkBox9.Checked = chckbox9;
                    value_trbDynBin1 = profile3.Dimension;
                    trbDynBin1.Value = value_trbDynBin1;
                    l_dimension.Text = value_trbDynBin1.ToString();
                    value_trbDynBin2 = profile3.Localcontrast;
                    trbDynBin2.Value = value_trbDynBin2;
                    l_localcontrast.Text = value_trbDynBin2.ToString();
                    selectCombobox = profile3.Binaryfilter;
                    comboBox1.SelectedIndex = selectCombobox;
                    /*if (selectCombobox > 0){
                            comboBox1.SelectedIndex = (selectCombobox-1);
                        }*/
                    //Dot Remove
                    chckbox10 = profile3.Dotremove;
                    checkBox10.Checked = chckbox10;
                    value_trackBar10 = profile3.MaximumdotH;
                    trackBar10.Value = value_trackBar10;
                    l_maximumdotH.Text = value_trackBar10.ToString();
                    value_trackBar11 = profile3.LmaximumdotW;
                    trackBar11.Value = value_trackBar11;
                    l_maximumdotW.Text = value_trackBar11.ToString();
                    value_trackBar12 = profile3.LminimumdotH;
                    trackBar12.Value = value_trackBar12;
                    l_minimumdotH.Text = value_trackBar12.ToString();
                    value_trackBar13 = profile3.MinimumdotW;
                    trackBar13.Value = value_trackBar13;
                    l_minimumdotW.Text = value_trackBar13.ToString();
                    //Line Remove
                    chckbox11 = profile3.LineRemove;
                    checkBox11.Checked = chckbox11;
                    value_trackBar14 = profile3.Gaplength;
                    trackBar14.Value = value_trackBar14;
                    l_gaplength.Text = value_trackBar14.ToString();
                    value_trackBar15 = profile3.MaximumlineW;
                    trackBar15.Value = value_trackBar15;
                    l_maximumlineW.Text = value_trackBar15.ToString();
                    value_trackBar16 = profile3.MinimumlineL;
                    trackBar16.Value = value_trackBar16;
                    l_minimumlineL.Text = value_trackBar16.ToString();
                    value_trackBar17 = profile3.Maximumwall;
                    trackBar17.Value = value_trackBar17;
                    l_maximumwall.Text = value_trackBar17.ToString();
                    value_trackBar22 = profile3.Wall;
                    trackBar22.Value = value_trackBar22;
                    l_wall.Text = value_trackBar22.ToString();

                    chckbox_LRV = profile3.Use_lrv;
                    chbox_LRV.Checked = chckbox_LRV;
                    value_tbLRV1 = profile3.TbLRV1;
                    tbLRV1.Value = value_tbLRV1;
                    l_tbLRV1.Text = value_tbLRV1.ToString();
                    value_tbLRV2 = profile3.TbLRV2;
                    tbLRV2.Value = value_tbLRV2;
                    l_tbLRV2.Text = value_tbLRV2.ToString();
                    value_tbLRV3 = profile3.TbLRV3;
                    tbLRV3.Value = value_tbLRV3;
                    l_tbLRV3.Text = value_tbLRV3.ToString();
                    value_tbLRV4 = profile3.TbLRV4;
                    tbLRV4.Value = value_tbLRV4;
                    l_tbLRV4.Text = value_tbLRV4.ToString();
                    value_tbLRV5 = profile3.TbLRV5;
                    tbLRV5.Value = value_tbLRV5;
                    l_tbLRV5.Text = value_tbLRV5.ToString();
                    //HolePunchRemove
                    chckbox12 = profile3.HolePunchRemove;
                    checkBox12.Checked = chckbox12;
                    value_trackBar18 = profile3.Maximumhole;
                    trackBar18.Value = value_trackBar18;
                    l_maximumhole.Text = value_trackBar18.ToString();
                    value_trackBar21 = profile3.Minimumhole;
                    trackBar21.Value = value_trackBar21;
                    l_minimumhole.Text = value_trackBar21.ToString();
                    //InvertedText
                    chckbox13 = profile3.InvertedText;
                    checkBox13.Checked = chckbox13;
                    value_trackBar19 = profile3.Maximumblack;
                    trackBar19.Value = value_trackBar19;
                    l_maximumblack.Text = value_trackBar19.ToString();
                    value_trackBar20 = profile3.MinimumBlack;
                    trackBar20.Value = value_trackBar20;
                    l_minimumBlack.Text = value_trackBar20.ToString();
                    value_trackBar23 = profile3.MinimuminverH;
                    trackBar23.Value = value_trackBar23;
                    l_minimuminverH.Text = value_trackBar23.ToString();
                    value_trackBar24 = profile3.MinimuminvertW;
                    trackBar24.Value = value_trackBar24;
                    l_minimuminvertW.Text = value_trackBar24.ToString();
                    //Auto Crop
                    chckbox15 = profile3.AutoCrop;
                    checkBox15.Checked = chckbox15;
                    value_trackBar27 = profile3.CropThreshold;
                    trackBar27.Value = value_trackBar27;
                    l_cropThreshold.Text = value_trackBar27.ToString();
                    //Boder Remove
                    chckbox16 = profile3.BorderRemove;
                    checkBox16.Checked = chckbox16;
                    value_trackBar25 = profile3.Percent;
                    trackBar25.Value = value_trackBar25;
                    l_percent.Text = value_trackBar25.ToString();
                    value_trackBar26 = profile3.Variance;
                    trackBar26.Value = value_trackBar26;
                    l_variance.Text = value_trackBar26.ToString();
                    value_trackBar28 = profile3.WhitenoiseL;
                    trackBar28.Value = value_trackBar28;
                    l_whitenoiseL.Text = value_trackBar28.ToString();
                    //Smooth
                    chckbox17 = profile3.Smooth;
                    checkBox17.Checked = chckbox17;
                    value_trackBar31 = profile3.Length;
                    trackBar31.Value = value_trackBar31;
                    l_length.Text = value_trackBar31.ToString();
                    //
                    chckbox = profile3.AutoColorLevel;
                    checkBox1.Checked = chckbox;
                    chckbox4 = profile3.AutoBinary;
                    checkBox4.Checked = chckbox4;
                    //Maximum
                    chckbox5 = profile3.Maximum;
                    checkBox5.Checked = chckbox5;
                    value_trbMaximum = profile3.Lmaximum;
                    trbMaximum.Value = value_trbMaximum;
                    l_maximum.Text = value_trbMaximum.ToString();
                    //Minimum
                    chckbox6 = profile3.Minimum;
                    checkBox6.Checked = chckbox6;
                    value_trbMinimum = profile3.Lminimum;
                    trbMinimum.Value = value_trbMinimum;
                    l_minimum.Text = value_trbMinimum.ToString();
                    //Gamma
                    chckbox8 = profile3.Gamma;
                    checkBox8.Checked = chckbox8;
                    value_trbGamma = profile3.Lgamma;
                    trbGamma.Value = value_trbGamma;
                    l_gamma.Text = value_trbGamma.ToString();

                    chckbox14 = profile3.AutoDeskew;
                    checkBox14.Checked = chckbox14;
                    //Flip Rotate Image
                    chckbox18 = profile3.UseFlipRotateImage;
                    checkBox18.Checked = chckbox18;
                    value_cbbPerProp = profile3.CbbPerProp;
                    if (value_cbbPerProp == false) { cbbPerProp.SelectedIndex = 0; } else { cbbPerProp.SelectedIndex = 1; }
                    value_trackBar29 = profile3.RotateImage;
                    trackBar29.Value = value_trackBar29;
                    l_RotateImage.Text = value_trackBar29.ToString();
                    //RakeRemove
                    chckbox19 = profile3.UseRakeRemove;
                    checkBox19.Checked = chckbox19;
                    value_numUpDown1 = profile3.NumUpDown1;
                    numUpDown1.Value = value_numUpDown1;
                    value_numUpDown2 = profile3.NumUpDown2;
                    numUpDown2.Value = value_numUpDown2;
                    value_numUpDown3 = profile3.NumUpDown3;
                    numUpDown3.Value = value_numUpDown3;
                    value_numUpDown4 = profile3.NumUpDown4;
                    numUpDown4.Value = value_numUpDown4;
                    value_numUpDown5 = profile3.NumUpDown5;
                    numUpDown5.Value = value_numUpDown5;
                    value_numUpDown6 = profile3.NumUpDown6;
                    numUpDown6.Value = value_numUpDown6;
                    value_numUpDown7 = profile3.NumUpDown7;
                    numUpDown7.Value = value_numUpDown7;
                    value_numUpDown8 = profile3.NumUpDown8;
                    numUpDown8.Value = value_numUpDown8;
                    value_numUpDown9 = profile3.NumUpDown9;
                    numUpDown9.Value = value_numUpDown9;
                    chckbox20 = profile3.AutoFilter;
                    checkBox20.Checked = chckbox20;
                    //convetrt to 1 bit
                    chckbox21 = profile3.Convert1bit;
                    checkBox21.Checked = chckbox21;
                         using (ProgressPopup pp = new ProgressPopup(Image))
                         {
                                 pp.ShowDialog();
                         }
                    //Image();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        protected override void OnMouseWheel(MouseEventArgs e)
        {
          /*  if (e.Delta > 0)
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

            }*/
            // l_zoom.Text = "w " + picReview2.Width.ToString() + " h" + picReview2.Height.ToString();
        }

        private void btnExportProfile_Click(object sender, EventArgs e)
        {
            try
            {
                Form1Export form1Export = new Form1Export();
                var result = form1Export.ShowDialog(this);
                form1Export.Dispose();
                form1Export = null;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<profile2> Lprofile3 = new List<profile2>();
        private void btnRemovepf_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbboxUseProfile.SelectedItem.ToString() != "Default")
                {
                    List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                    profile2 profile3 = ProfileLoad.Where(c => c.Profilename == cbboxUseProfile.SelectedItem.ToString()).FirstOrDefault();
                    Console.WriteLine(cbboxUseProfile.SelectedItem.ToString());
                    Lprofile3.Clear();
                    if (profile3 != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Confirm remove profile " + cbboxUseProfile.SelectedItem.ToString(), "Some Title", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            for (int r = 0; r < ProfileLoad.Count; r++)
                            {
                                if (ProfileLoad[r].Profilename != cbboxUseProfile.SelectedItem.ToString())
                                {
                                    Lprofile3.Add(ProfileLoad[r]);
                                }
                            }
                            N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(Lprofile3, "testin.xml");
                            DialogResult res = MessageBox.Show("Remove profile " + cbboxUseProfile.SelectedItem.ToString() + " successful", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (res == DialogResult.OK)
                            {
                                //Some task…
                            }
                            ResetValue();
                            cbBox2re();
                        }
                    }
                }
                else {
                    MessageBox.Show("Please select your profile.");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRMslpf_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            var result = form2.ShowDialog(this);
            //DialogResult result = MessageBox.Show("How are you?", "Hi",MessageBoxButtons.OKCancel);
           /* switch (result)
            {
                case DialogResult.OK:
                {
                        this.Text = "[OK]";
                        break;
                }
                case DialogResult.Cancel:
                {
                        this.Text = "[Cancel]";
                        break;
                }    
            }
            MessageBox.Show(this.Text);*/
        }
        // MessageBox.Show(result.ToString());
    
        void save()
        {
            profile2 profile2 = new profile2();
            profile2.Profilename = cbboxUseProfile.SelectedItem.ToString();
            profile2.Brightness = Form1.form1.value_trackBar1;
            profile2.Contrast = Form1.form1.value_trackBar2;
            profile2.Intensity = Form1.form1.value_trackBar3;
            profile2.Amount = Form1.form1.value_trackBar4;
            profile2.Radius = Form1.form1.value_trackBar5;
            profile2.Threshold = Form1.form1.value_trackBar6;
            profile2.UseGrayScale = Form1.form1.chckbox2;
            profile2.Redfactor = Form1.form1.value_trackBar7;
            profile2.Greenfactor = Form1.form1.value_trackBar8;
            profile2.Bluefactor = Form1.form1.value_trackBar9;
            profile2.AutoBinarize = Form1.form1.chckbox7;
            profile2.Despeckle = Form1.form1.chckbox3;
            profile2.DynamicBinary = Form1.form1.chckbox9;
            profile2.Dimension = Form1.form1.value_trbDynBin1;
            profile2.Localcontrast = Form1.form1.value_trbDynBin2;
            profile2.Binaryfilter = Form1.form1.selectCombobox;
            profile2.Dotremove = Form1.form1.chckbox10;
            profile2.MaximumdotH = Form1.form1.value_trackBar10;
            profile2.LmaximumdotW = Form1.form1.value_trackBar11;
            profile2.LminimumdotH = Form1.form1.value_trackBar12;
            profile2.MinimumdotW = Form1.form1.value_trackBar13;
            profile2.LineRemove = Form1.form1.chckbox11;
            profile2.Gaplength = Form1.form1.value_trackBar14;
            profile2.MaximumlineW = Form1.form1.value_trackBar15;
            profile2.MinimumlineL = Form1.form1.value_trackBar16;
            profile2.Maximumwall = Form1.form1.value_trackBar17;
            profile2.Wall = Form1.form1.value_trackBar22;
            profile2.Use_lrv = Form1.form1.chckbox_LRV;
            profile2.TbLRV1 = Form1.form1.value_tbLRV1;
            profile2.TbLRV2 = Form1.form1.value_tbLRV2;
            profile2.TbLRV3 = Form1.form1.value_tbLRV3;
            profile2.TbLRV4 = Form1.form1.value_tbLRV4;
            profile2.TbLRV5 = Form1.form1.value_tbLRV5;
            profile2.HolePunchRemove = Form1.form1.chckbox12;
            profile2.Maximumhole = Form1.form1.value_trackBar18;
            profile2.Minimumhole = Form1.form1.value_trackBar21;
            profile2.InvertedText = Form1.form1.chckbox13;
            profile2.Maximumblack = Form1.form1.value_trackBar19;
            profile2.MinimuminverH = Form1.form1.value_trackBar23;
            profile2.MinimuminvertW = Form1.form1.value_trackBar24;
            profile2.AutoCrop = Form1.form1.chckbox15;
            profile2.CropThreshold = Form1.form1.value_trackBar27;
            profile2.BorderRemove = Form1.form1.chckbox16;
            profile2.Percent = Form1.form1.value_trackBar25;
            profile2.Variance = Form1.form1.value_trackBar26;
            profile2.WhitenoiseL = Form1.form1.value_trackBar28;
            profile2.Smooth = Form1.form1.chckbox17;
            profile2.Length = Form1.form1.value_trackBar31;
            profile2.AutoColorLevel = Form1.form1.chckbox;
            profile2.AutoBinary = Form1.form1.chckbox4;
            profile2.Maximum = Form1.form1.chckbox5;
            profile2.Lmaximum = Form1.form1.value_trbMaximum;
            profile2.Minimum = Form1.form1.chckbox6;
            profile2.Lminimum = Form1.form1.value_trbMinimum;
            profile2.Gamma = Form1.form1.chckbox8;
            profile2.Lgamma = Form1.form1.value_trbGamma;
            profile2.AutoDeskew = Form1.form1.chckbox14;
            profile2.UseFlipRotateImage = Form1.form1.chckbox18;
            profile2.CbbPerProp = Form1.form1.value_cbbPerProp;
            profile2.RotateImage = Form1.form1.value_trackBar29;
            profile2.UseRakeRemove = Form1.form1.chckbox19;
            profile2.NumUpDown1 = Form1.form1.value_numUpDown1;
            profile2.NumUpDown2 = Form1.form1.value_numUpDown2;
            profile2.NumUpDown3 = Form1.form1.value_numUpDown3;
            profile2.NumUpDown4 = Form1.form1.value_numUpDown4;
            profile2.NumUpDown5 = Form1.form1.value_numUpDown5;
            profile2.NumUpDown6 = Form1.form1.value_numUpDown6;
            profile2.NumUpDown7 = Form1.form1.value_numUpDown7;
            profile2.NumUpDown8 = Form1.form1.value_numUpDown8;
            profile2.NumUpDown9 = Form1.form1.value_numUpDown9;
            profile2.AutoFilter = Form1.form1.chckbox20;
            profile2.Convert1bit = Form1.form1.chckbox21;
            Lprofile2.Add(profile2);

            N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(Lprofile2, "testin.xml");
            DialogResult res = MessageBox.Show("Save profile " + cbboxUseProfile.Text + " success", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show("You have clicked Ok Button");
                //Some task…
            }
        }
        /*
         ถ้าไม่ได้ใช้งานโปรไฟล์อยู่
         -เมื่อกด save หรือ save as ให้ทำการ save as/
         ถ้าใช้งานโปรไฟล์อยู่
         -เมื่อกด save ให้ทำการเซฟทับไฟล์นั้น
         -เมื่อกด save as ให้ทำการ save as/
         */
        private void btnSavepf_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbboxUseProfile.SelectedItem.ToString() != "Default")
                {
                    List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                    profile2 profile3 = ProfileLoad.Where(c => c.Profilename == cbboxUseProfile.SelectedItem.ToString()).FirstOrDefault();
                    Lprofile2.Clear();
                    if (profile3 != null)
                    { //ถ้าเจอ
                        for (int r = 0; r < ProfileLoad.Count; r++)
                        {
                            if (ProfileLoad[r].Profilename != cbboxUseProfile.SelectedItem.ToString())
                            {
                                Lprofile2.Add(ProfileLoad[r]);
                            }
                        }
                        save();
                        //cbboxUseProfile.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                else {
                    dialogSave dialogSave = new dialogSave();
                    dialogSave.ShowDialog();
                    cbBox2re();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSaveASpf_Click(object sender, EventArgs e)
        {
            dialogSave dialogSave = new dialogSave();
            dialogSave.ShowDialog();
        }
        private void btnImportProfile_Click(object sender, EventArgs e)
        {
            try
            {
                dialogImport dialogImport = new dialogImport();
                var dialogIm = dialogImport.ShowDialog();
                //MessageBox.Show(dl.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try { 
                xRev = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
                picReview2.Location = new Point(xRev, 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Expanded15;
        private void btnAutoFunction_Click(object sender, EventArgs e)
        {
            try { 
                if (Expanded15)
                {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panAutoFunction.Height = 29;
                }
                else
                {
                    //  btnExpander.Image = Properties.Resources.expand_arrow; 
                    panAutoFunction.Height = 198;
                }
                Expanded15 = !Expanded15;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnResetAutoFunction_Click(object sender, EventArgs e)
        {
            try
            {
                selectCombobox = 0;
                comboBox1.SelectedIndex = selectCombobox;
                chckbox7 = false;
                checkBox7.Checked = chckbox7;
                chckbox3 = false;
                checkBox3.Checked = chckbox3;
                chckbox = false;
                checkBox1.Checked = chckbox;
                chckbox4 = false;
                checkBox4.Checked = chckbox4;
                chckbox14 = false;
                checkBox14.Checked = chckbox14;
                Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Expanded16;
        private void btnDynamicBinary_Click(object sender, EventArgs e)
        {
            try { 
                if (Expanded16)
                {
                    // btnExpander.Image = Properties.Resources.collapse_arrow;    
                    panDynamicBinary.Height = 29;
                }
                else
                {
                    //  btnExpander.Image = Properties.Resources.expand_arrow; 
                    panDynamicBinary.Height = 206;
                }
                Expanded16 = !Expanded16;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void btnResetDynamicBinary_Click(object sender, EventArgs e)
        {
            try { 
                chckbox9 = false;
                checkBox9.Checked = chckbox9;
                value_trbDynBin1 = 8;
                trbDynBin1.Value = value_trbDynBin1;
                l_dimension.Text = value_trbDynBin1.ToString();
                value_trbDynBin2 = 16;
                trbDynBin2.Value = value_trbDynBin2;
                l_localcontrast.Text = value_trbDynBin2.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded17;
        private void btnGamma_Click(object sender, EventArgs e)
        {
            try { 
                if (Expanded17)
                {
                    // btnExpander.Image = Properties.Resources.collapse_arrow;    
                    panGamma.Height = 29;
                }
                else
                {
                    //  btnExpander.Image = Properties.Resources.expand_arrow; 
                    panGamma.Height = 128;
                }
                Expanded17 = !Expanded17;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void btnResetGamma_Click(object sender, EventArgs e)
        {
            try {
                chckbox8 = false;
                checkBox8.Checked = chckbox8;
                value_trbGamma = 250;
                trbGamma.Value = value_trbGamma;
                l_gamma.Text = value_trbGamma.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Expanded18;
        private void btnMaximum_Click(object sender, EventArgs e)
        {
            try { 
                if (Expanded18)
                {
                    // btnExpander.Image = Properties.Resources.collapse_arrow;    
                    panMaximum.Height = 29;
                }   
                else
                {
                    //  btnExpander.Image = Properties.Resources.expand_arrow; 
                    panMaximum.Height = 136;
                }
                Expanded18 = !Expanded18;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void btnResetMaximum_Click(object sender, EventArgs e)
        {
            try { 
                chckbox5 = false;
                checkBox5.Checked = chckbox5;
                value_trbMaximum = 3;
                trbMaximum.Value = value_trbMaximum;
                l_maximum.Text = value_trbMaximum.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
        private bool Expanded19;
        private void btnMinimum_Click(object sender, EventArgs e)
        {
           if(Expanded19)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;    
                panMinimum.Height = 29;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow; 
                panMinimum.Height = 111;
            }
            Expanded19 = !Expanded19;
        }

        private void btnResetMinimum_Click(object sender, EventArgs e)
        {
            chckbox6 = false;
            checkBox6.Checked = chckbox6;
            value_trbMinimum = 3;
            trbMinimum.Value = value_trbMinimum;
            l_minimum.Text = value_trbMinimum.ToString();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            /* if (picReview2.Width < 1400 || picReview2.Height < 1400)
             {
                 if (picReview2.Top > 5)
                 {
                     picReview2.Top = (int)(picReview2.Top - (picReview2.Height * 0.025));
                 }
                 if (picReview2.Left > 5)
                 {
                     picReview2.Left = (int)(picReview2.Left - (picReview2.Width * 0.025));
                 }
                 picReview2.Height = (int)(picReview2.Height + (picReview2.Height * 0.05));
                 picReview2.Width = (int)(picReview2.Width + (picReview2.Width * 0.05));
             }
             Console.WriteLine(picReview2.Width + " " + picReview2.Height);*/
                picReview2.Size = new Size((int)(picReview2.Width + 50), (int)(picReview2.Height + 50));
                picReview2.Left = (splitContainer1.Panel2.Width - picReview2.Width) / 2;
                picReview2.Top = (splitContainer1.Panel2.Height - picReview2.Height) / 2; 
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
          /*  if (picReview2.Width > 100 || picReview2.Height > 100)
            {
                if (picReview2.Top < 5)
                {
                    picReview2.Top = (int)(picReview2.Top + (picReview2.Height * 0.025));
                }
                picReview2.Left = (int)(picReview2.Left + (picReview2.Width * 0.025));
                picReview2.Height = (int)(picReview2.Height - (picReview2.Height * 0.05));
                picReview2.Width = (int)(picReview2.Width - (picReview2.Width * 0.05));
            }*/
                picReview2.Size = new Size((int)(picReview2.Width - 50), (int)(picReview2.Height - 50));
                picReview2.Left = (splitContainer1.Panel2.Width - picReview2.Width) / 2;
                picReview2.Top = (splitContainer1.Panel2.Height - picReview2.Height) / 2;
        }

        private void btnDefaultZoom_Click(object sender, EventArgs e)
        {
            picReview2.Height = 850; //ความกว้างหน้ากระดาษ
            picReview2.Width = 620;  //ความสูงหน้ากระดาษ
            xRev = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
            picReview2.Location = new Point(xRev, 20);
        }

        private void btnAutoFunction_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btnAutoCrop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/autocropcommand-threshold.html");
            }
        }

        private void btnFlipRotate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/l/imageprocessing-rastercommand.html");
            }
        }

        private void btnConBrigtIntens_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pc/contrastbrightnessintensitycommand.html");
            }
        }

        private void btnUnsharpMask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pe/unsharpmaskcommand.html");
            }
        }

        private void btnGrayScale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/dh/pc/grayscaleextendedcommand.html");
            }
        }

        private void btnDynamicBinary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pc/dynamicbinarycommand.html");
            }
        }

        private void btnGamma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pc/gammacorrectcommand.html");
            }
        }

        private void btnMaximum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/dh/po/maximumcommand.html");
            }
        }

        private void btnMinimum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/dh/po/minimumcommand.html");
            }
        }

        private void btnLineRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/lineremovecommand.html");
            }
        }

        private void btnHolePunchRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/holepunchremovecommand.html");
            }
        }

        private void btnDotRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/image-processing-functions/dot-remove.html");
            }
        }

        private void btnInvertedText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/invertedtextcommand.html");
            }
        }

        private void btnBorderRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/borderremovecommand.html");
            }
        }

        private void btnSmooth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/smoothcommand.html");
            }
        }

        private void btnRakeRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/rakeremovecommand.html");
            }
        }

        private void btnBinFilHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pe/binaryfiltercommand.html");
        }

        private void btnBinarizeHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/autobinarizecommand.html");
        }

        private void btnDespeckleHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/despecklecommand.html");
        }

        private void btnColorlvHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pc/autocolorlevelcommand.html");
        }

        private void btnbinHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pc/autobinarycommand.html");
        }

        private void btnDeskewHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/po/deskewcommand.html");
        }
        
        private void cbbPerProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbPerProp.SelectedIndex == 0) { value_cbbPerProp = false; } else { value_cbbPerProp = true; }
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }
        private bool Expanded14;
        private void btnLineRemoveV_Click(object sender, EventArgs e)
        {
            try
            {
                if (Expanded14)
                {
                    // btnExpander.Image = Properties.Resources.collapse_arrow;    
                    panLRV.Height = 29;
                }
                else
                {
                    //  btnExpander.Image = Properties.Resources.expand_arrow; 
                    panLRV.Height = 347;
                }
                Expanded14 = !Expanded14;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetLineRemoveV_Click(object sender, EventArgs e)
        {
            value_tbLRV1 = 2;

            value_tbLRV2 = 5;
            value_tbLRV3 = 200;
            value_tbLRV4 = 10;
            value_tbLRV5 = 7;
            chckbox_LRV = false;

            chbox_LRV.Checked = chckbox_LRV;
            tbLRV1.Value = value_tbLRV1;
            l_tbLRV1.Text = value_tbLRV1.ToString();
            tbLRV2.Value = value_tbLRV2;
            l_tbLRV2.Text = value_tbLRV2.ToString();
            tbLRV3.Value = value_tbLRV3;
            l_tbLRV3.Text = value_tbLRV3.ToString();
            tbLRV4.Value = value_tbLRV4;
            l_tbLRV4.Text = value_tbLRV4.ToString();
            tbLRV5.Value = value_tbLRV5;
            l_tbLRV5.Text = value_tbLRV5.ToString();
        }

        private void chbox_LRV_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbox_LRV.Checked == true)
                {
                    chckbox_LRV = true;
                    using (ProgressPopup pp = new ProgressPopup(Image))
                    {
                        pp.ShowDialog();
                    }
                }
                else
                {
                    chckbox_LRV = false;
                    using (ProgressPopup pp = new ProgressPopup(Image))
                    {
                        pp.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbLRV1_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void tbLRV1_Scroll(object sender, EventArgs e)
        {
            value_tbLRV1 = tbLRV1.Value;
            l_tbLRV1.Text = value_tbLRV1.ToString();
        }

        private void tbLRV2_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void tbLRV2_Scroll(object sender, EventArgs e)
        {
            value_tbLRV2 = tbLRV2.Value;
            l_tbLRV2.Text = value_tbLRV2.ToString();
        }

        private void tbLRV3_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void tbLRV3_Scroll(object sender, EventArgs e)
        {
            value_tbLRV3 = tbLRV3.Value;
            l_tbLRV3.Text = value_tbLRV3.ToString();
        }

        private void tbLRV4_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void tbLRV4_Scroll(object sender, EventArgs e)
        {
            value_tbLRV4 = tbLRV4.Value;
            l_tbLRV4.Text = value_tbLRV4.ToString();
        }

        private void tbLRV5_MouseCaptureChanged(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(Image))
            {
                pp.ShowDialog();
            }
        }

        private void tbLRV5_Scroll(object sender, EventArgs e)
        {
            value_tbLRV5 = tbLRV5.Value;
            l_tbLRV5.Text = value_tbLRV5.ToString();
        }

        private void numeric_contrast_ValueChanged(object sender, EventArgs e)
        {
            value_trackBar2 = (int)numeric_contrast.Value;
            trackBar2.Value = value_trackBar2;
            //l_contrast.Text = value_trackBar2.ToString();
        }

        private void numeric_brightness_ValueChanged(object sender, EventArgs e)
        {
            value_trackBar1 = (int)numeric_brightness.Value;
            trackBar1.Value = value_trackBar1;
           // l_brightness.Text = value_trackBar1.ToString();
        }

        private void numeric_intensity_ValueChanged(object sender, EventArgs e)
        {
            value_trackBar3 = (int)numeric_intensity.Value;
            trackBar3.Value = value_trackBar3;
           // l_intensity.Text = value_trackBar3.ToString();
        }

        private void numeric_amount_ValueChanged(object sender, EventArgs e)
        {
            value_trackBar4 = (int)numeric_amount.Value;
            trackBar4.Value = value_trackBar4;
        }

        private void numeric_radius_ValueChanged(object sender, EventArgs e)
        {
            value_trackBar5 = (int)numeric_radius.Value;
            trackBar5.Value = value_trackBar5;
        }

        private void numeric_threshold_ValueChanged(object sender, EventArgs e)
        {
            value_trackBar6 = (int)numeric_threshold.Value;
            trackBar6.Value = value_trackBar6;
        }
        private bool state;
        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            if (state)
            {
                panel1.Width = 28;
            }
            else
            {
                panel1.Width = 367;
            }
            state = !state;

            try
            {
                xRev = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
                picReview2.Location = new Point(xRev, 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
