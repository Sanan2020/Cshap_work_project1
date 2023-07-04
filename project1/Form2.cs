using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project1
{
    
    public partial class Form2 : Office2007Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        String[] ls;
        String lscol;
        String rf;
        String rfile;
        List<String> list = new List<String>();
        List<String> itemre = new List<String>();//ที่จะลบ
        List<String> item = new List<String>();
        private void Remove2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    //Console.WriteLine(listBox1.SelectedItems[i]);
                    itemre.Add(listBox1.SelectedItems[i].ToString());
                    //listBox1.Items.Remove(listBox1.SelectedItems[i]);
                    //Console.WriteLine(item[i].ToString());
                }

                if (itemre.Count > 0)
                {
                    //MessageBox.Show("0");
                    DialogResult dialogResult = MessageBox.Show("Your Sure", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (string z in itemre)
                        {
                            Console.WriteLine("itemre " + z);
                            item.Remove(z);
                        }
                        N2N.Data.Serialization.Serialize<List<String>>.SerializeToXmlFile(item, "Lpfname.xml");

                        foreach (string n in itemre)
                        {
                            //Console.WriteLine(n);
                            String path = @"" + n + ".xml";
                            File.Delete(path);
                            listBox1.Items.Remove(itemre);
                            //listBox1.Refresh();
                        }
                    }
                }

                //listBox1.Items.Clear();
                item.Clear();
                listBox1.Items.Clear();
                List<String> LpfnameLoad = N2N.Data.Serialization.Serialize<List<String>>.DeserializeFromXmlFile("Lpfname.xml");
                foreach (String list in LpfnameLoad)
                {
                    listBox1.Items.Add(list);
                    item.Add(list);
                }
                /*String rfile;
                StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\listname.txt");
                while ((rfile = streamread.ReadLine()) != null)
                {
                    listBox1.Items.Add(rfile);
                }
                streamread.Close();*/
                /* DirectoryInfo di = new DirectoryInfo(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile");
                 foreach (var fi in di.GetFiles("*.txt"))
                 {
                     //Console.WriteLine(fi.Name);
                     string[] nm = fi.Name.Split('.');
                     Console.WriteLine(nm[0]);
                     listBox1.Items.Add(nm[0]);
                     item.Add(nm[0]);
                 }*/
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.SelectionMode = SelectionMode.MultiSimple;
                listBox1.Items.Clear();
                List<String> LpfnameLoad = N2N.Data.Serialization.Serialize<List<String>>.DeserializeFromXmlFile("Lpfname.xml");
                foreach (String list in LpfnameLoad)
                {
                    listBox1.Items.Add(list);
                    item.Add(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.form1.cbBox2re();
        }
    }
}
