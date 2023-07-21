namespace project1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnPathLic = new DevComponents.DotNetBar.ButtonX();
            this.btnPathKey = new DevComponents.DotNetBar.ButtonX();
            this.btnPathOk = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(269, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(269, 20);
            this.textBox2.TabIndex = 1;
            // 
            // btnPathLic
            // 
            this.btnPathLic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPathLic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPathLic.Location = new System.Drawing.Point(396, 39);
            this.btnPathLic.Name = "btnPathLic";
            this.btnPathLic.Size = new System.Drawing.Size(45, 20);
            this.btnPathLic.TabIndex = 5;
            this.btnPathLic.Text = "...";
            this.btnPathLic.Click += new System.EventHandler(this.btnPathLic_Click);
            // 
            // btnPathKey
            // 
            this.btnPathKey.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPathKey.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPathKey.Location = new System.Drawing.Point(396, 72);
            this.btnPathKey.Name = "btnPathKey";
            this.btnPathKey.Size = new System.Drawing.Size(45, 20);
            this.btnPathKey.TabIndex = 6;
            this.btnPathKey.Text = "...";
            this.btnPathKey.Click += new System.EventHandler(this.btnPathKey_Click);
            // 
            // btnPathOk
            // 
            this.btnPathOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPathOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPathOk.Location = new System.Drawing.Point(366, 122);
            this.btnPathOk.Name = "btnPathOk";
            this.btnPathOk.Size = new System.Drawing.Size(75, 23);
            this.btnPathOk.TabIndex = 7;
            this.btnPathOk.Text = "OK";
            this.btnPathOk.Click += new System.EventHandler(this.btnPathOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Path license:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Path key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select path file license";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(476, 168);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPathOk);
            this.Controls.Add(this.btnPathKey);
            this.Controls.Add(this.btnPathLic);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog License";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Shown += new System.EventHandler(this.Form3_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private DevComponents.DotNetBar.ButtonX btnPathLic;
        private DevComponents.DotNetBar.ButtonX btnPathKey;
        private DevComponents.DotNetBar.ButtonX btnPathOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}