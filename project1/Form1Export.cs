using Leadtools.Document.Writer;
using Leadtools;
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
using static project1.Form1;
using System.Xml;
using Leadtools.Document.Unstructured.Highlevel;
using static project1.Form1Export;

namespace project1
{
    public partial class Form1Export : Form
    {
        public Form1Export()
        {
            InitializeComponent();
        }
        private void Form1Export_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.Items.Clear();
            List<profile2> LpfnameLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
            for (int i = 0; i < LpfnameLoad.Count; i++)
            {
                listBox1.Items.Add(LpfnameLoad[i].Profilename);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            write2();
        }
        public class profile2
        {
            String profilename;
            int values_brightness;
            int values_contrast;
            int values_intensity;
            int values_amount;
            int values_radius;
            int values_threshold;
            bool values_UseGrayScale;
            int values_redfactor;
            int values_greenfactor;
            int values_bluefactor;
            bool values_AutoBinarize;
            bool values_despeckle;
            bool values_dynamicBinary;
            int values_dimension;
            int values_localcontrast;
            int values_binaryfilter;
            bool values_dotremove;
            int values_maximumdotH;
            int values_lmaximumdotW;
            int values_minimumdotH;
            int values_minimumdotW;
            bool values_lineRemove;
            int values_gaplength;
            int values_maximumlineW;
            int values_minimumlineL;
            int values_maximumwall;
            int values_wall;
            bool values_holePunchRemove;
            int values_maximumhole;
            int values_minimumhole;
            bool values_invertedText;
            int values_maximumblack;
            int values_minimumBlack;
            int values_minimuminverH;
            int values_minimuminvertW;
            bool values_autoCrop;
            int values_cropThreshold;
            bool values_borderRemove;
            int values_percent;
            int values_variance;
            int values_whitenoiseL;
            bool values_smooth;
            int values_length;
            bool values_autoColorLevel;
            bool values_autoBinary;
            bool values_maximum;
            int values_lmaximum;
            bool values_minimum;
            int values_lminimum;
            bool values_gamma;
            int values_lgamma;
            bool values_autoDeskew;
            bool values_useFlipRotateImage;
            int values_RotateImage;
            bool values_useRakeRemove;
            int values_numUpDown1;
            int values_numUpDown2;
            int values_numUpDown3;
            int values_numUpDown4;
            int values_numUpDown5;
            int values_numUpDown6;
            int values_numUpDown7;
            int values_numUpDown8;
            int values_numUpDown9;
            bool values_autoFilter;
            bool values_convert1bit;
            public string Profilename { get { return profilename; } set { profilename = value; } }
            public int Values_brightness { get { return values_brightness; } set { values_brightness = value; } }
            public int Values_contrast { get { return values_contrast; } set { values_contrast = value; } }
            public int Values_intensity { get { return values_intensity; } set { values_intensity = value; } }
            public int Values_amount { get { return values_amount; } set { values_amount = value; } }
            public int Values_radius { get { return values_radius; } set { values_radius = value; } }
            public int Values_threshold { get { return values_threshold; } set { values_threshold = value; } }
            public bool Values_UseGrayScale { get { return values_UseGrayScale; } set { values_UseGrayScale = value; } }
            public int Values_redfactor { get { return values_redfactor; } set { values_redfactor = value; } }
            public int Values_greenfactor { get { return values_greenfactor; } set { values_greenfactor = value; } }
            public int Values_bluefactor { get { return values_bluefactor; } set { values_bluefactor = value; } }
            public bool Values_AutoBinarize { get { return values_AutoBinarize; } set { values_AutoBinarize = value; } }
            public bool Values_despeckle { get { return values_despeckle; } set { values_despeckle = value; } }
            public bool Values_dynamicBinary { get { return values_dynamicBinary; } set { values_dynamicBinary = value; } }
            public int Values_dimension { get { return values_dimension; } set { values_dimension = value; } }
            public int Values_localcontrast { get { return values_localcontrast; } set { values_localcontrast = value; } }
            public int Values_binaryfilter { get { return values_binaryfilter; } set { values_binaryfilter = value; } }
            public bool Values_dotremove { get { return values_dotremove; } set { values_dotremove = value; } }
            public int Values_maximumdotH { get { return values_maximumdotH; } set { values_maximumdotH = value; } }
            public int Values_lmaximumdotW { get { return values_lmaximumdotW; } set { values_lmaximumdotW = value; } }
            public int Values_lminimumdotH { get { return values_minimumdotH; } set { values_minimumdotH = value; } }
            public int Values_minimumdotW { get { return values_minimumdotW; } set { values_minimumdotW = value; } }
            public bool Values_lineRemove { get { return values_lineRemove; } set { values_lineRemove = value; } }
            public int Values_gaplength { get { return values_gaplength; } set { values_gaplength = value; } }
            public int Values_maximumlineW { get { return values_maximumlineW; } set { values_maximumlineW = value; } }
            public int Values_minimumlineL { get { return values_minimumlineL; } set { values_minimumlineL = value; } }
            public int Values_maximumwall { get { return values_maximumwall; } set { values_maximumwall = value; } }
            public int Values_wall { get { return values_wall; } set { values_wall = value; } }
            public bool Values_holePunchRemove { get { return values_holePunchRemove; } set { values_holePunchRemove = value; } }
            public int Values_maximumhole { get { return values_maximumhole; } set { values_maximumhole = value; } }
            public int Values_minimumhole { get { return values_minimumhole; } set { values_minimumhole = value; } }
            public bool Values_invertedText { get { return values_invertedText; } set { values_invertedText = value; } }
            public int Values_maximumblack { get { return values_maximumblack; } set { values_maximumblack = value; } }
            public int Values_minimumBlack { get { return values_minimumBlack; } set { values_minimumBlack = value; } }
            public int Values_minimuminverH { get { return values_minimuminverH; } set { values_minimuminverH = value; } }
            public int Values_minimuminvertW { get { return values_minimuminvertW; } set { values_minimuminvertW = value; } }
            public bool Values_autoCrop { get { return values_autoCrop; } set { values_autoCrop = value; } }
            public int Values_cropThreshold { get { return values_cropThreshold; } set { values_cropThreshold = value; } }
            public bool Values_borderRemove { get { return values_borderRemove; } set { values_borderRemove = value; } }
            public int Values_percent { get { return values_percent; } set { values_percent = value; } }
            public int Values_variance { get { return values_variance; } set { values_variance = value; } }
            public int Values_whitenoiseL { get { return values_whitenoiseL; } set { values_whitenoiseL = value; } }
            public bool Values_smooth { get { return values_smooth; } set { values_smooth = value; } }
            public int Values_length { get { return values_length; } set { values_length = value; } }
            public bool Values_autoColorLevel { get { return values_autoColorLevel; } set { values_autoColorLevel = value; } }
            public bool Values_autoBinary { get { return values_autoBinary; } set { values_autoBinary = value; } }
            public bool Values_maximum { get { return values_maximum; } set { values_maximum = value; } }
            public int Values_lmaximum { get { return values_lmaximum; } set { values_lmaximum = value; } }
            public bool Values_minimum { get { return values_minimum; } set { values_minimum = value; } }
            public int Values_lminimum { get { return values_lminimum; } set { values_lminimum = value; } }
            public bool Values_gamma { get { return values_gamma; } set { values_gamma = value; } }
            public int Values_lgamma { get { return values_lgamma; } set { values_lgamma = value; } }
            public bool Values_autoDeskew { get { return values_autoDeskew; } set { values_autoDeskew = value; } }
            public bool Values_useFlipRotateImage { get { return values_useFlipRotateImage; } set { values_useFlipRotateImage = value; } }
            public int Values_RotateImage { get { return values_RotateImage; } set { values_RotateImage = value; } }
            public bool Values_useRakeRemove { get { return values_useRakeRemove; } set { values_useRakeRemove = value; } }
            public int Values_numUpDown1 { get { return values_numUpDown1; } set { values_numUpDown1 = value; } }
            public int Values_numUpDown2 { get { return values_numUpDown2; } set { values_numUpDown2 = value; } }
            public int Values_numUpDown3 { get { return values_numUpDown3; } set { values_numUpDown3 = value; } }
            public int Values_numUpDown4 { get { return values_numUpDown4; } set { values_numUpDown4 = value; } }
            public int Values_numUpDown5 { get { return values_numUpDown5; } set { values_numUpDown5 = value; } }
            public int Values_numUpDown6 { get { return values_numUpDown6; } set { values_numUpDown6 = value; } }
            public int Values_numUpDown7 { get { return values_numUpDown7; } set { values_numUpDown7 = value; } }
            public int Values_numUpDown8 { get { return values_numUpDown8; } set { values_numUpDown8 = value; } }
            public int Values_numUpDown9 { get { return values_numUpDown9; } set { values_numUpDown9 = value; } }
            public bool Values_autoFilter { get { return values_autoFilter; } set { values_autoFilter = value; } }
            public bool Values_convert1bit { get { return values_convert1bit; } set { values_convert1bit = value; } }
        }
        public List<profile2> lprofile3 = new List<profile2>();
      //  List<int> itemEx = new List<int>();
        List<String> itemEx = new List<String>();
        void write2() {
            itemEx.Clear(); 
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                //Console.WriteLine(listBox1.SelectedItems[i]);
               // itemEx.Add(listBox1.SelectedIndex);
                itemEx.Add(listBox1.SelectedItems[i].ToString());
                //listBox1.Items.Remove(listBox1.SelectedItems[i]);
                Console.WriteLine(listBox1.SelectedItems);
            }
         
            if (itemEx.Count > 0)
            {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "xml (*.xml)|*.xml";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        String savePath = saveFileDialog1.FileName;
                        foreach (var n in itemEx)
                        {
                            List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                            profile2 profile2 =  ProfileLoad.Where(c => c.Profilename == n.ToString()).FirstOrDefault();
                            lprofile3.Add(profile2);
                            N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(lprofile3, savePath + ".xml");
                    }
                }
                lprofile3.Clear();
            } 
        }
        List<String> name = new List<String>();
        String path;
        public List<profile2> lprofileIm = new List<profile2>();
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.Filter = "xml (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile(path);
                for (int i = 0; i < ProfileLoad.Count; i++)
                {
                    listBox2.Items.Add(ProfileLoad[i].Profilename);
                }
                /* Console.WriteLine(ProfileLoad[0].Profilename);
                 Console.WriteLine(ProfileLoad[1].Profilename);
                 listBox2.Items.Add(ProfileLoad[0].Profilename);
                 listBox2.Items.Add(ProfileLoad[1].Profilename);*/
                /**/
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile(path);
            List<profile2> LpfnameLoad2 = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
            for (int i = 0; i < LpfnameLoad2.Count; i++)
            {
                lprofileIm.Add(LpfnameLoad2[i]);
            }
            itemEx.Clear();
            for (int i = listBox2.SelectedItems.Count - 1; i >= 0; i--)
            {
                //Console.WriteLine(listBox1.SelectedItems[i]);
                // itemEx.Add(listBox1.SelectedIndex);
                itemEx.Add(listBox2.SelectedItems[i].ToString());
                //listBox1.Items.Remove(listBox1.SelectedItems[i]);
                Console.WriteLine(listBox2.SelectedItems);
            }

            if (itemEx.Count > 0)
            {
                foreach (var n in itemEx)
                {
                    profile2 profile2 = ProfileLoad.Where(c => c.Profilename == n.ToString()).FirstOrDefault();
                    lprofileIm.Add(profile2);
                    N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(lprofileIm, "testin.xml");
                }
                lprofileIm.Clear();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
         /*  foreach (var n in itemEx)
                    {*/
            List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
            profile2 profile2 = ProfileLoad.Where(c => c.Profilename == "test2").FirstOrDefault();
                Console.WriteLine(profile2.Profilename);
           // }
        }
    }
}
