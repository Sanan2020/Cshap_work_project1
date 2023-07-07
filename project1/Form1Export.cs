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
using static project1.dialogSave;
using DevComponents.DotNetBar;

namespace project1
{
    public partial class Form1Export : Office2007Form
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
        List<String> listIm = new List<String>();
        private void btnImport_Click(object sender, EventArgs e)
        {
            lprofileIm.Clear();
            //listBox2.SelectionMode = SelectionMode.MultiSimple;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.Filter = "xml (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                
                List<profile2> ImportLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile(path);
                listBox2.Items.Add(ImportLoad);
                List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                for (int r = 0; r < ImportLoad.Count; r++)
                {
                    profile2 profile3 = ProfileLoad.Where(c => c.Profilename == ImportLoad[r].Profilename).FirstOrDefault();

                    if (profile3 != null)
                    { //ถ้าเจอ
                      //เก็บค่าที่เจอ
                       // MessageBox.Show("f");
                        DialogResult dialogResult = MessageBox.Show("มีไฟล์ชื่อ "+ ImportLoad[r].Profilename + " มีอยู่แล้ว!!! ต้องการทับไฟล์เดิมหรือไม่", "Some Title", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            lprofileIm.Add(ImportLoad[r]);
                        }
                        //lprofileIm.Add(ProfileLoad[r]);
                        //lprofileIm.Add(ProfileLoad[r]);
                        //save();
                    }
                    else//
                    {
                        lprofileIm.Add(ProfileLoad[r]);
                        lprofileIm.Add(ImportLoad[r]);
                    }
                }
                    N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(lprofileIm, "testin.xml");
                    Form1.form1.cbBox2re();
            }
        }

        public List<profile2> Lprofile2 = new List<profile2>();
      
    }
}
