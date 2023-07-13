using DevComponents.DotNetBar;
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
    public partial class dialogImport : Office2007Form
    {
        public dialogImport()
        {
            InitializeComponent();
        }
       
        public List<profile2> lprofileIm = new List<profile2>();
        String path;
        private void btnImport_Click(object sender, EventArgs e)
        {
            try { 
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
                lprofileIm.Clear();
                //lprofileIm2.Clear();
                listBox1.Items.Clear();
                if (System.IO.File.Exists("testin.xml"))//ถ้าเจอไฟล์
                {
                    List<profile2> ProfileLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile("testin.xml");
                    List<profile2> ImportLoad = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile(path);
                    for (int i = 0; i < ProfileLoad.Count; i++)
                    {
                        lprofileIm.Add(ProfileLoad[i]);
                    }

                    for (int r = 0; r < ImportLoad.Count; r++)
                    {
                        profile2 profile3 = ProfileLoad.Where(c => c.Profilename == ImportLoad[r].Profilename).FirstOrDefault();
                        if (profile3 != null)
                        { //ถ้าเจอ
                            DialogResult dialogResult = MessageBox.Show("มีไฟล์ชื่อ " + ImportLoad[r].Profilename + " มีอยู่แล้ว!!! ต้องการทับไฟล์เดิมหรือไม่", "Some Title", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //เก็บข้อมูลใหม่ ลบข้อมูลเก่า
                                Console.WriteLine("ลบข้อมูลเก่า " + profile3.Profilename + " แทนด้วยข้อมูลใหม่ " + ImportLoad[r].Profilename);
                                lprofileIm.Remove(profile3);
                                lprofileIm.Add(ImportLoad[r]);
                                listBox1.Items.Add(ImportLoad[r].Profilename);
                            }
                        }
                        else
                        {
                            Console.WriteLine("เพิ่มข้อมูลใหม่ " + ImportLoad[r].Profilename);
                            lprofileIm.Add(ImportLoad[r]);
                            listBox1.Items.Add(ImportLoad[r].Profilename);
                        }
                    }
                }
                else
                {
                    List<profile2> ImportLoad2 = N2N.Data.Serialization.Serialize<List<profile2>>.DeserializeFromXmlFile(path);
                    for (int r = 0; r < ImportLoad2.Count; r++)
                    {
                        lprofileIm.Add(ImportLoad2[r]);
                        listBox1.Items.Add(ImportLoad2[r].Profilename);
                    }
                }
                N2N.Data.Serialization.Serialize<List<profile2>>.SerializeToXmlFile(lprofileIm, "testin.xml");
                DialogResult res = MessageBox.Show("Import Profile Success", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    //MessageBox.Show("You have clicked Ok Button");
                    //Some task…
                    this.Close();
                }
            }
        }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
}
    }
}
