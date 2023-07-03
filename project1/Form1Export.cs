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

namespace project1
{
    public partial class Form1Export : Form
    {
        public Form1Export()
        {
            InitializeComponent();
        }
       /* public List<profile> Lprofile = new List<profile>();
        public class profile {
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
        }*/

        private void Form1Export_Load(object sender, EventArgs e)
        {
           // profile pf = new profile();
           // pf.Name = "sanan";
            //pf.Values = "500";
           // Console.WriteLine(pf.Name.ToString());
           // Console.WriteLine(pf.Values.ToString());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xml (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String savePath = saveFileDialog1.FileName;
                List<profile> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile>>.DeserializeFromXmlFile("Configs.xml");
                N2N.Data.Serialization.Serialize<List<profile>>.SerializeToXmlFile(ProfileLoad, savePath+ ".xml");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.Filter = "xml (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //textBox1.Text = openFileDialog1.FileName;
                foreach (String file in openFileDialog1.FileNames)
                {
                    string text = File.ReadAllText(file);
                    MessageBox.Show(text);
                }
            }
           
        }
    }
}
