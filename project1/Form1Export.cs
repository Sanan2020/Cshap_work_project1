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
                    itemEx.Sort();
                    String savePath = saveFileDialog1.FileName;
                    foreach (var n in itemEx)
                    {
                    List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                    profile2 profile2 =  ProfileLoad.Where(c => c.Profilename == n.ToString()).FirstOrDefault();
                    lprofile3.Add(profile2);
                    //N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(lprofile3, savePath + ".xml");
                    }
                    N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(lprofile3, savePath);
                    DialogResult res = MessageBox.Show("Export Profile Success", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        //MessageBox.Show("You have clicked Ok Button");
                        //Some task…
                        this.Close();
                    }
                }
                lprofile3.Clear();
            } 
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            write2();
        }
    }
}
