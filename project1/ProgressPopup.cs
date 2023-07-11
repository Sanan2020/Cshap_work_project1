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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project1
{
    public partial class ProgressPopup : Office2007Form
    {
        private object v;

        public Action Worker { get; set; }
        public ProgressPopup(Action worker)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;
        }

        public ProgressPopup(object v)
        {
            this.v = v;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
