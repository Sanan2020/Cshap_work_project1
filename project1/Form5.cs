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
            pictureBox1.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
            pictureBox2.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
             pictureBox3.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
            //  picReview2.SizeMode = PictureBoxSizeMode.Zoom;
            //  picReview2.BorderStyle = BorderStyle.FixedSingle;
            // picReview2.Location = new Point(100, 0);
            // flowLayoutPanel1.Controls.Add(picReview2);
            // flowLayoutPanel1.Controls.Add(picReview2);
            // flowLayoutPanel1.Controls.Add(picReview2);
            // this.splitContainer1.Panel2.Controls.Clear();
            // picReview2.Height = 700; //ความกว้างหน้ากระดาษ
            // picReview2.Width = 520;  //ความสูงหน้ากระดาษ
            picReview2.Height = 150; //ความกว้างหน้ากระดาษ
            picReview2.Width = 120;  //ความสูงหน้ากระดาษ
            x = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
            picReview2.Location = new Point(x, 0);
            picReview2.SizeMode = PictureBoxSizeMode.Zoom;
            picReview2.BorderStyle = BorderStyle.FixedSingle;
            picReview2.Image = Image.FromFile("C:\\LEADTOOLS22\\Resources\\Images\\clean2.jpg");
            this.splitContainer1.Panel2.Controls.Add(picReview2);


        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            x = (splitContainer1.Panel2.Width / 2) - (picReview2.Width / 2);
            picReview2.Location = new Point(x, 0);
            Console.WriteLine(x);
        }
    }
}
