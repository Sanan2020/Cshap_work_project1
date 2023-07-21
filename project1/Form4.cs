using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Form4 : Office2007Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2.MouseWheel += new MouseEventHandler(pictureBox1_MouseEnter);
            //pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseEnter);
            pictureBox1.Left = (splitContainer1.Panel2.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (splitContainer1.Panel2.Height - pictureBox1.Height) / 2;
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Save AS");
        }
        private void pictureBox1_MouseEnter(object sender, MouseEventArgs e)
        {
                // pictureBox1.Focus();
                 if (Control.ModifierKeys == Keys.Control)
                 {
                     if (e.Delta > 0)
                     {
                         pictureBox1.Size = new Size((int)(pictureBox1.Width + 10), (int)(pictureBox1.Height + 10));
                         pictureBox1.Left = (splitContainer1.Panel2.Width - pictureBox1.Width) / 2;
                         pictureBox1.Top = (splitContainer1.Panel2.Height - pictureBox1.Height) / 2;
                     }
                     else if (e.Delta < 0)
                     {
                         pictureBox1.Size = new Size((int)(pictureBox1.Width - 10), (int)(pictureBox1.Height - 10));
                         pictureBox1.Left = (splitContainer1.Panel2.Width - pictureBox1.Width) / 2;
                         pictureBox1.Top = (splitContainer1.Panel2.Height - pictureBox1.Height) / 2;
                     }
                 }
            }
            private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Wheel");
          
           /* if (Control.ModifierKeys == Keys.Control)
            {
                  if (e.Delta > 0)
            {
                pictureBox1.Width += 10;
                pictureBox1.Height += 10;
            }
            else if (e.Delta < 0)
            {
                pictureBox1.Width -= 10;
                pictureBox1.Height -= 10;
            }
            }*/


           /* if (Control.ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    // ซูมอิน (เพิ่มขนาดภาพ)
                        pictureBox1.Width += (int)(pictureBox1.Width * 0.1);
                        pictureBox1.Height += (int)(pictureBox1.Height * 0.1);
                }
                else if (e.Delta < 0)
                {
                    // ซูมเอาท์ (ลดขนาดภาพ)
                        pictureBox1.Width -= (int)(pictureBox1.Width * 0.1);
                        pictureBox1.Height -= (int)(pictureBox1.Height * 0.1);
                }
            }*/

           
        }

        private void splitContainer1_Panel1_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("Enter");
            Console.WriteLine("Enter");
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //MessageBox.Show("help");
            Console.WriteLine("help");
        }

        private void label2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            /* if (Control.ModifierKeys == Keys.F1)
             {*/
                //MessageBox.Show("Label");
               // Console.WriteLine("label2_MouseHover");
            //}
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                //MessageBox.Show("F1 pressed");
                System.Diagnostics.Process.Start("https://www.leadtools.com/help/sdk/v22/dh/pc/gammacorrectcommand.html");
            }
            Console.WriteLine("label2_MouseHover");
        }

        private void expandablePanel4_MouseHover(object sender, EventArgs e)
        {
           // Console.WriteLine("label2_MouseHover");
        }

        private void expandablePanel4_MouseEnter(object sender, EventArgs e)
        {
            //Console.WriteLine("label2_MouseEnter");
        }

        private void expandablePanel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                Console.WriteLine("MouseMove");
            }
        }
    }
}
