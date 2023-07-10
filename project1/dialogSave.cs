using DevComponents.DotNetBar;
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
        
        public List<profile2> Lprofile2 = new List<profile2>();
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_pfname.Text == "")
                {
                    MessageBox.Show("กรุณาตั้งชื่อ Profile!!");
                }
                else
                {
                    List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                    profile2 profile3 = ProfileLoad.Where(c => c.Profilename == tb_pfname.Text).FirstOrDefault();
                    Lprofile2.Clear();
                    if (profile3 != null)
                    { //ถ้าเจอ
                      //เก็บค่าที่เจอ
                      //MessageBox.Show("f");
                        DialogResult dialogResult = MessageBox.Show("มีไฟล์ชื่อ "+ tb_pfname.Text + " อยู่แล้ว!!! ต้องการทับไฟล์เดิมหรือไม่", "Some Title", MessageBoxButtons.YesNo);
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
                        tb_pfname.Text = "";
                    }
                    else
                    {
                        //บันทึกทันที
                        // Lprofile2.Add(profile2);
                        //MessageBox.Show("n f");
                        for (int r = 0; r < ProfileLoad.Count; r++)
                        {
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
                        
                        N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(Lprofile2, "testin.xml");
                        DialogResult res = MessageBox.Show("Save profile "+ tb_pfname.Text + " success", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            //MessageBox.Show("You have clicked Ok Button");
                            //Some task…
                            this.Close();
                        }
                        tb_pfname.Text = "";
                    }
                    //profile2 profile2 = pfnameLoad.Where(c => c.Profilename == tb_pfname.Text).FirstOrDefault();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
