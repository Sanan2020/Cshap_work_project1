using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using N2N.Data.Serialization;
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
using static project1.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace project1
{
    
    public partial class Form2 : Office2007Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.SelectionMode = SelectionMode.MultiSimple;
                listBox1.Items.Clear();
                List<profile2> LpfnameLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                for (int i = 0; i < LpfnameLoad.Count; i++)
                {
                    listBox1.Items.Add(LpfnameLoad[i].Profilename);
                    //item.Add(LpfnameLoad[i].Profilename);
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
           // Form1.form1.cbBox2re();
        }

        private void btnRemovepf2_Click(object sender, EventArgs e)
        {
            try
            {
                List<profile2> ProfileLoad_ = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                DialogResult dialogResult = MessageBox.Show("Confirm remove profiles ", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        var proRemove = ProfileLoad_.Where(c => c.Profilename == listBox1.SelectedItems[i].ToString()).FirstOrDefault();
                        if (proRemove != null)
                            ProfileLoad_.Remove(proRemove);
                    }
                    N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(ProfileLoad_, "testin.xml");
                    DialogResult res = MessageBox.Show("Remove profiles success", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        //MessageBox.Show("You have clicked Ok Button");
                        //Some task…
                        Form1.form1.cbBox2re();
                        this.Close();
                    }
                    listBox1.Items.Clear();
                    List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                    for (int i = 0; i < ProfileLoad.Count; i++)
                    {
                        listBox1.Items.Add(ProfileLoad[i].Profilename);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
