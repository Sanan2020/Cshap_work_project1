using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project1
{
    public partial class Form5 : Form
    {
       
        public Form5()
        {
            InitializeComponent();
        }
        void SaveData() {
            for (int i = 0; i <= 500; i++) { 
                Thread.Sleep(10);
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            using (ProgressPopup pp = new ProgressPopup(SaveData)) { 
                pp.ShowDialog();
            }
        }
        int x;
        
        PictureBox picReview2 = new PictureBox();
       
        private void Form5_Load(object sender, EventArgs e)
        {


            // x = 100;
            // picReview2.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
         /*   pictureBox1.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
            pictureBox2.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
             pictureBox3.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");*/
            //  picReview2.SizeMode = PictureBoxSizeMode.Zoom;
            //  picReview2.BorderStyle = BorderStyle.FixedSingle;
            // picReview2.Location = new Point(100, 0);
            // flowLayoutPanel1.Controls.Add(picReview2);
            // flowLayoutPanel1.Controls.Add(picReview2);
            // flowLayoutPanel1.Controls.Add(picReview2);
            // this.splitContainer1.Panel2.Controls.Clear();
            // picReview2.Height = 700; //ความกว้างหน้ากระดาษ
            // picReview2.Width = 520;  //ความสูงหน้ากระดาษ
          /*  picReview2.Height = 150; //ความกว้างหน้ากระดาษ
            picReview2.Width = 120;  //ความสูงหน้ากระดาษ
            x = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
            picReview2.Location = new Point(x, 0);
            picReview2.SizeMode = PictureBoxSizeMode.Zoom;
            picReview2.BorderStyle = BorderStyle.FixedSingle;
            picReview2.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
            this.splitContainer1.Panel2.Controls.Add(picReview2);*/


        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            x = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
            picReview2.Location = new Point(x, 0);
            Console.WriteLine(x);
        }
        private bool state;
        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
         /*   if (state)
            {
                tabControl1.Width = 28;
            }
            else
            {
                tabControl1.Width = 300;
            }
            state = !state;*/
        }

        private void Form5_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            var c = this.ActiveControl;
            if (c != null)
                MessageBox.Show(c.Name);
        }

        private void textBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            hlpevent.Handled = true;
            MessageBox.Show("Help request handled and will not bubble up");
        }

        private void toolStrip1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CONTEXTHELP = 0xF180;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_CONTEXTHELP, 0);
        }
        /* private void helpToolStripMenuItem_Click(object sender, EventArgs e)
{
    SendMessage(this.Handle, WM_SYSCOMMAND, SC_CONTEXTHELP, 0);
}*/
        /*
        

ปรับปรุงปุ่มซูมเข้า-ออก ให้เรียบร้อย**
การซูมเข้า-ออก สามารถทำได้โดย กด Ctrl+เลื่อนเมาส์**
ปรับปรุงการเข้าสู่หน้า References ให้เหมาะสม
ลดความละเอียดภาพใน thumbnail และให้สามารถแสดงภาพจำนวนมากได้
ปรับปรุง Form หรือ popup ให้เรียบร้อย

ทำการปรับภาพให้แสดงตามขนาดจริง
วิธีการ Build Application
ทำอย่างไรให้ฟังก์ชัน Gray Scale สามารถใช้ค่า Red+Green+Blue รวมกันโดยไม่เกิน 1,000 ได้ ****top
        */
    }
}
