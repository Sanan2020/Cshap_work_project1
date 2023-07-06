﻿using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class dialogSave : Office2007Form
    {
        public dialogSave()
        {
            InitializeComponent();
        }
        public class profile2
        {
            String profilename;
            int brightness;
            int contrast;
            int intensity;
            int amount;
            int radius;
            int threshold;
            bool useGrayScale;
            int redfactor;
            int greenfactor;
            int bluefactor;
            bool autoBinarize;
            bool despeckle;
            bool dynamicBinary;
            int dimension;
            int localcontrast;
            int binaryfilter;
            bool dotremove;
            int maximumdotH;
            int lmaximumdotW;
            int minimumdotH;
            int minimumdotW;
            bool lineRemove;
            int gaplength;
            int maximumlineW;
            int minimumlineL;
            int maximumwall;
            int wall;
            bool holePunchRemove;
            int maximumhole;
            int minimumhole;
            bool invertedText;
            int maximumblack;
            int minimumBlack;
            int minimuminverH;
            int minimuminvertW;
            bool autoCrop;
            int cropThreshold;
            bool borderRemove;
            int percent;
            int variance;
            int whitenoiseL;
            bool smooth;
            int length;
            bool autoColorLevel;
            bool autoBinary;
            bool maximum;
            int lmaximum;
            bool minimum;
            int lminimum;
            bool gamma;
            int lgamma;
            bool autoDeskew;
            bool useFlipRotateImage;
            int rotateImage;
            bool useRakeRemove;
            int numUpDown1;
            int numUpDown2;
            int numUpDown3;
            int numUpDown4;
            int numUpDown5;
            int numUpDown6;
            int numUpDown7;
            int numUpDown8;
            int numUpDown9;
            bool autoFilter;
            bool convert1bit;
            public string Profilename { get { return profilename; } set { profilename = value; } }
            public int Brightness { get { return brightness; } set { brightness = value; } }
            public int Contrast { get { return contrast; } set { contrast = value; } }
            public int Intensity { get { return intensity; } set { intensity = value; } }
            public int Amount { get { return amount; } set { amount = value; } }
            public int Radius { get { return radius; } set { radius = value; } }
            public int Threshold { get { return threshold; } set { threshold = value; } }
            public bool UseGrayScale { get { return useGrayScale; } set { useGrayScale = value; } }
            public int Redfactor { get { return redfactor; } set { redfactor = value; } }
            public int Greenfactor { get { return greenfactor; } set { greenfactor = value; } }
            public int Bluefactor { get { return bluefactor; } set { bluefactor = value; } }
            public bool AutoBinarize { get { return autoBinarize; } set { autoBinarize = value; } }
            public bool Despeckle { get { return despeckle; } set { despeckle = value; } }
            public bool DynamicBinary { get { return dynamicBinary; } set { dynamicBinary = value; } }
            public int Dimension { get { return dimension; } set { dimension = value; } }
            public int Localcontrast { get { return localcontrast; } set { localcontrast = value; } }
            public int Binaryfilter { get { return binaryfilter; } set { binaryfilter = value; } }
            public bool Dotremove { get { return dotremove; } set { dotremove = value; } }
            public int MaximumdotH { get { return maximumdotH; } set { maximumdotH = value; } }
            public int LmaximumdotW { get { return lmaximumdotW; } set { lmaximumdotW = value; } }
            public int LminimumdotH { get { return minimumdotH; } set { minimumdotH = value; } }
            public int MinimumdotW { get { return minimumdotW; } set { minimumdotW = value; } }
            public bool LineRemove { get { return lineRemove; } set { lineRemove = value; } }
            public int Gaplength { get { return gaplength; } set { gaplength = value; } }
            public int MaximumlineW { get { return maximumlineW; } set { maximumlineW = value; } }
            public int MinimumlineL { get { return minimumlineL; } set { minimumlineL = value; } }
            public int Maximumwall { get { return maximumwall; } set { maximumwall = value; } }
            public int Wall { get { return wall; } set { wall = value; } }
            public bool HolePunchRemove { get { return holePunchRemove; } set { holePunchRemove = value; } }
            public int Maximumhole { get { return maximumhole; } set { maximumhole = value; } }
            public int Minimumhole { get { return minimumhole; } set { minimumhole = value; } }
            public bool InvertedText { get { return invertedText; } set { invertedText = value; } }
            public int Maximumblack { get { return maximumblack; } set { maximumblack = value; } }
            public int MinimumBlack { get { return minimumBlack; } set { minimumBlack = value; } }
            public int MinimuminverH { get { return minimuminverH; } set { minimuminverH = value; } }
            public int MinimuminvertW { get { return minimuminvertW; } set { minimuminvertW = value; } }
            public bool AutoCrop { get { return autoCrop; } set { autoCrop = value; } }
            public int CropThreshold { get { return cropThreshold; } set { cropThreshold = value; } }
            public bool BorderRemove { get { return borderRemove; } set { borderRemove = value; } }
            public int Percent { get { return percent; } set { percent = value; } }
            public int Variance { get { return variance; } set { variance = value; } }
            public int WhitenoiseL { get { return whitenoiseL; } set { whitenoiseL = value; } }
            public bool Smooth { get { return smooth; } set { smooth = value; } }
            public int Length { get { return length; } set { length = value; } }
            public bool AutoColorLevel { get { return autoColorLevel; } set { autoColorLevel = value; } }
            public bool AutoBinary { get { return autoBinary; } set { autoBinary = value; } }
            public bool Maximum { get { return maximum; } set { maximum = value; } }
            public int Lmaximum { get { return lmaximum; } set { lmaximum = value; } }
            public bool Minimum { get { return minimum; } set { minimum = value; } }
            public int Lminimum { get { return lminimum; } set { lminimum = value; } }
            public bool Gamma { get { return gamma; } set { gamma = value; } }
            public int Lgamma { get { return lgamma; } set { lgamma = value; } }
            public bool AutoDeskew { get { return autoDeskew; } set { autoDeskew = value; } }
            public bool UseFlipRotateImage { get { return useFlipRotateImage; } set { useFlipRotateImage = value; } }
            public int RotateImage { get { return rotateImage; } set { rotateImage = value; } }
            public bool UseRakeRemove { get { return useRakeRemove; } set { useRakeRemove = value; } }
            public int NumUpDown1 { get { return numUpDown1; } set { numUpDown1 = value; } }
            public int NumUpDown2 { get { return numUpDown2; } set { numUpDown2 = value; } }
            public int NumUpDown3 { get { return numUpDown3; } set { numUpDown3 = value; } }
            public int NumUpDown4 { get { return numUpDown4; } set { numUpDown4 = value; } }
            public int NumUpDown5 { get { return numUpDown5; } set { numUpDown5 = value; } }
            public int NumUpDown6 { get { return numUpDown6; } set { numUpDown6 = value; } }
            public int NumUpDown7 { get { return numUpDown7; } set { numUpDown7 = value; } }
            public int NumUpDown8 { get { return numUpDown8; } set { numUpDown8 = value; } }
            public int NumUpDown9 { get { return numUpDown9; } set { numUpDown9 = value; } }
            public bool AutoFilter { get { return autoFilter; } set { autoFilter = value; } }
            public bool Convert1bit { get { return convert1bit; } set { convert1bit = value; } }
        }
        public List<profile2> Lprofile2 = new List<profile2>();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tb_pfname.Text == "")
            {
                MessageBox.Show("กรุณาตั้งชื่อ Profile!!");
            }
            else {
                List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                profile2 profile3 = ProfileLoad.Where(c => c.Profilename == tb_pfname.Text).FirstOrDefault();
                Lprofile2.Clear();
                    if (profile3 != null)
                    { //ถ้าเจอ
                      //เก็บค่าที่เจอ
                        //MessageBox.Show("f");
                        DialogResult dialogResult = MessageBox.Show("มีไฟล์ชื่อนี้อยู่แล้ว!!! ต้องการทับไฟล์เดิมหรือไม่", "Some Title", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                        for (int r = 0; r < ProfileLoad.Count; r++)
                        {
                            if (ProfileLoad[r].Profilename != tb_pfname.Text)
                            {
                                Lprofile2.Add(ProfileLoad[r]);
                            }
                        }
                        save();
                        }
                       
                    }else{
                        //บันทึกทันที
                        // Lprofile2.Add(profile2);
                        //MessageBox.Show("n f");
                        for (int r = 0; r < ProfileLoad.Count; r++){
                            Lprofile2.Add(ProfileLoad[r]);
                        }
                        save();
                    }
               // }
               void save()
                {
                    profile2 profile2 = new profile2();
                    profile2.Profilename = tb_pfname.Text;
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
                    //  Lprofile2.Remove(profile2[]);
                    //LpfnameLoad2.Add(profile2);
                    //  l_saveprofile.Text = " Save Success...";
                    N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(Lprofile2, "testin.xml");
                    tb_pfname.Text = "";
                }
                

                
                //profile2 profile2 = pfnameLoad.Where(c => c.Profilename == tb_pfname.Text).FirstOrDefault();
            }
        }
    }
}
