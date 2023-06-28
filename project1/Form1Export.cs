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

        }
    }
}
