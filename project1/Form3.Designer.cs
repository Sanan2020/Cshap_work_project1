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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnlic = new System.Windows.Forms.Button();
            this.btnkey = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(269, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(55, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(269, 20);
            this.textBox2.TabIndex = 1;
            // 
            // btnlic
            // 
            this.btnlic.Location = new System.Drawing.Point(330, 48);
            this.btnlic.Name = "btnlic";
            this.btnlic.Size = new System.Drawing.Size(47, 20);
            this.btnlic.TabIndex = 2;
            this.btnlic.Text = "...";
            this.btnlic.UseVisualStyleBackColor = true;
            this.btnlic.Click += new System.EventHandler(this.btnlic_Click);
            // 
            // btnkey
            // 
            this.btnkey.Location = new System.Drawing.Point(330, 92);
            this.btnkey.Name = "btnkey";
            this.btnkey.Size = new System.Drawing.Size(47, 20);
            this.btnkey.TabIndex = 3;
            this.btnkey.Text = "...";
            this.btnkey.UseVisualStyleBackColor = true;
            this.btnkey.Click += new System.EventHandler(this.btnkey_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(308, 134);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(69, 24);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 243);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnkey);
            this.Controls.Add(this.btnlic);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Shown += new System.EventHandler(this.Form3_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnlic;
        private System.Windows.Forms.Button btnkey;
        private System.Windows.Forms.Button btnok;
    }
}