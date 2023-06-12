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

namespace project1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public String license;
        public String key;
        public void SetLicenseFileExample()
        {
            try
            {
                /* string MY_LICENSE_FILE = @""+license+"";
                 string MY_DEVELOPER_KEY = ""+key+"";
                 RasterSupport.SetLicense(MY_LICENSE_FILE, MY_DEVELOPER_KEY);*/
                RasterSupport.SetLicense(textBox1.Text, System.IO.File.ReadAllText(textBox2.Text));
                bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
                if (isLocked)
                    Console.WriteLine("Document support is locked");
                else
                {
                    Console.WriteLine("Document support is unlocked");
                    StreamWriter streamwri = new StreamWriter("pathLicense.txt"); //bin/Debug
                    streamwri.WriteLine(textBox1.Text);
                    streamwri.WriteLine(textBox2.Text);
                    streamwri.Close();
                    Console.WriteLine("seve part seccess...");

                    this.Hide();
                    Form1 frm = new Form1();
                    frm.Show();
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);

            }
        }
        private void btnlic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "File (*.LIC)|*.LIC;";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                license = ofile.FileName;
                Console.WriteLine(license);
                textBox1.Text = license;
            }
        }

        private void btnkey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "File (*.KEY)|*.KEY;";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                key = ofile.FileName;
                Console.WriteLine(key);
                textBox2.Text = key;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            SetLicenseFileExample();
        }
        String rf;
        String rfile;
        List<String> list = new List<String>();
        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists("pathLicense.txt"))//ถ้าเจอไฟล์
                {
                    //MessageBox.Show("yes");
                    StreamReader streamread = new StreamReader("pathLicense.txt");//อ่านไฟล์
                    while ((rfile = streamread.ReadLine()) != null)
                    {
                        rf = rfile;                         //text = อ่านข้อความทีละบรรทัด
                        list.Add(rf);
                    }
                    streamread.Close();
                    Console.WriteLine(list.Count());
                    if (list.Count() >= 2)
                    {
                        textBox1.Text = list[0].ToString();
                        textBox2.Text = list[1].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            btnok.PerformClick();
        }
    }
}
