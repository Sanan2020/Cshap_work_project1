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

        private void Form5_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile("C:/Users/Administrator/Downloads/in/License_SAMPLE.png");
        }
    }
}
