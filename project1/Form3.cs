using DevComponents.DotNetBar;
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
using static project1.Form3;

namespace project1
{
    public partial class Form3 : Office2007Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public String license;
        public String key;

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
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
        public List<pathLicense> pthLicense = new List<pathLicense>();
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
        private void btnok_Click(object sender, EventArgs e)
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

                    pathLicense pathLicense = new pathLicense();
                    pathLicense.License = textBox1.Text;
                    pathLicense.Key = textBox2.Text;
                    pthLicense.Add(pathLicense);
                    N2N.Data.Serialization.Serialize<List<pathLicense>>.SerializeToXmlFile(pthLicense, "pathLicense.xml");
                    Console.WriteLine("seve part seccess...");

                    //this.Hide();
                    /*  Form1 frm = new Form1();
                      frm.FormClosed += Frm_FormClosed;
                      frm.Show();*/
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(e.Message);
                MessageBox.Show(ex.Message);

            }
        }
        String rf;
        String rfile;
        List<String> list = new List<String>();
        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
        }
    }
}
