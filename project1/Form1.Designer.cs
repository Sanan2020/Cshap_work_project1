namespace project1
{
    partial class Form1
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
            this.Browse = new System.Windows.Forms.Button();
            this.picInput = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picOutput = new System.Windows.Forms.PictureBox();
            this.BrowseSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.l_brightness = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.l_contrast = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.l_intensity = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.l_threshold = new System.Windows.Forms.Label();
            this.l_amount = new System.Windows.Forms.Label();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.l_radius = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.l_binaryfilter = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.SaveProfile = new System.Windows.Forms.Button();
            this.l_saveprofile = new System.Windows.Forms.Label();
            this.l_profilename = new System.Windows.Forms.Label();
            this.value_profilename = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(1362, 586);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(76, 32);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // picInput
            // 
            this.picInput.Location = new System.Drawing.Point(860, 32);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(450, 546);
            this.picInput.TabIndex = 1;
            this.picInput.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(856, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output";
            // 
            // picOutput
            // 
            this.picOutput.Location = new System.Drawing.Point(12, 32);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(822, 939);
            this.picOutput.TabIndex = 5;
            this.picOutput.TabStop = false;
            // 
            // BrowseSave
            // 
            this.BrowseSave.Location = new System.Drawing.Point(1667, 586);
            this.BrowseSave.Name = "BrowseSave";
            this.BrowseSave.Size = new System.Drawing.Size(93, 32);
            this.BrowseSave.TabIndex = 6;
            this.BrowseSave.Text = "Browse to Save";
            this.BrowseSave.UseVisualStyleBackColor = true;
            this.BrowseSave.Click += new System.EventHandler(this.BrowseSave_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(34, 26);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(270, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.trackBar1_MouseCaptureChanged);
            // 
            // l_brightness
            // 
            this.l_brightness.AutoSize = true;
            this.l_brightness.Location = new System.Drawing.Point(6, 29);
            this.l_brightness.Name = "l_brightness";
            this.l_brightness.Size = new System.Drawing.Size(13, 13);
            this.l_brightness.TabIndex = 8;
            this.l_brightness.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Brightness";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(34, 87);
            this.trackBar2.Maximum = 1000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(270, 45);
            this.trackBar2.TabIndex = 10;
            this.trackBar2.TickFrequency = 100;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar2.MouseCaptureChanged += new System.EventHandler(this.trackBar2_MouseCaptureChanged);
            // 
            // l_contrast
            // 
            this.l_contrast.AutoSize = true;
            this.l_contrast.Location = new System.Drawing.Point(6, 91);
            this.l_contrast.Name = "l_contrast";
            this.l_contrast.Size = new System.Drawing.Size(13, 13);
            this.l_contrast.TabIndex = 11;
            this.l_contrast.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Contrast";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Intensity";
            // 
            // l_intensity
            // 
            this.l_intensity.AutoSize = true;
            this.l_intensity.Location = new System.Drawing.Point(6, 156);
            this.l_intensity.Name = "l_intensity";
            this.l_intensity.Size = new System.Drawing.Size(13, 13);
            this.l_intensity.TabIndex = 14;
            this.l_intensity.Text = "0";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(34, 151);
            this.trackBar3.Maximum = 1000;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(270, 45);
            this.trackBar3.TabIndex = 13;
            this.trackBar3.TickFrequency = 100;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            this.trackBar3.MouseCaptureChanged += new System.EventHandler(this.trackBar3_MouseCaptureChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.l_intensity);
            this.groupBox1.Controls.Add(this.l_brightness);
            this.groupBox1.Controls.Add(this.trackBar3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.trackBar2);
            this.groupBox1.Controls.Add(this.l_contrast);
            this.groupBox1.Location = new System.Drawing.Point(1316, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 202);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ConBrightsInten";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.trackBar4);
            this.groupBox2.Controls.Add(this.l_threshold);
            this.groupBox2.Controls.Add(this.l_amount);
            this.groupBox2.Controls.Add(this.trackBar5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.trackBar6);
            this.groupBox2.Controls.Add(this.l_radius);
            this.groupBox2.Location = new System.Drawing.Point(1316, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 211);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UnsharpMask";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Radius";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(159, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Threshold";
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(34, 30);
            this.trackBar4.Maximum = 1500;
            this.trackBar4.Minimum = 1;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(270, 45);
            this.trackBar4.TabIndex = 16;
            this.trackBar4.TickFrequency = 100;
            this.trackBar4.Value = 1;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            this.trackBar4.MouseCaptureChanged += new System.EventHandler(this.trackBar4_MouseCaptureChanged);
            // 
            // l_threshold
            // 
            this.l_threshold.AutoSize = true;
            this.l_threshold.Location = new System.Drawing.Point(5, 164);
            this.l_threshold.Name = "l_threshold";
            this.l_threshold.Size = new System.Drawing.Size(13, 13);
            this.l_threshold.TabIndex = 23;
            this.l_threshold.Text = "0";
            // 
            // l_amount
            // 
            this.l_amount.AutoSize = true;
            this.l_amount.Location = new System.Drawing.Point(6, 33);
            this.l_amount.Name = "l_amount";
            this.l_amount.Size = new System.Drawing.Size(13, 13);
            this.l_amount.TabIndex = 17;
            this.l_amount.Text = "0";
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(34, 95);
            this.trackBar5.Maximum = 1000;
            this.trackBar5.Minimum = 1;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(270, 45);
            this.trackBar5.TabIndex = 22;
            this.trackBar5.TickFrequency = 100;
            this.trackBar5.Value = 1;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            this.trackBar5.MouseCaptureChanged += new System.EventHandler(this.trackBar5_MouseCaptureChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(162, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Amount";
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(34, 160);
            this.trackBar6.Maximum = 255;
            this.trackBar6.Minimum = 1;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(270, 45);
            this.trackBar6.TabIndex = 19;
            this.trackBar6.TickFrequency = 20;
            this.trackBar6.Value = 1;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            this.trackBar6.MouseCaptureChanged += new System.EventHandler(this.trackBar6_MouseCaptureChanged);
            // 
            // l_radius
            // 
            this.l_radius.AutoSize = true;
            this.l_radius.Location = new System.Drawing.Point(6, 100);
            this.l_radius.Name = "l_radius";
            this.l_radius.Size = new System.Drawing.Size(13, 13);
            this.l_radius.TabIndex = 20;
            this.l_radius.Text = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1721, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 21);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // l_binaryfilter
            // 
            this.l_binaryfilter.AutoSize = true;
            this.l_binaryfilter.Location = new System.Drawing.Point(1628, 40);
            this.l_binaryfilter.Name = "l_binaryfilter";
            this.l_binaryfilter.Size = new System.Drawing.Size(87, 13);
            this.l_binaryfilter.TabIndex = 19;
            this.l_binaryfilter.Text = "BINARY FILTER";
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(1463, 586);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(74, 32);
            this.Reset.TabIndex = 20;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // SaveProfile
            // 
            this.SaveProfile.Location = new System.Drawing.Point(1559, 586);
            this.SaveProfile.Name = "SaveProfile";
            this.SaveProfile.Size = new System.Drawing.Size(90, 32);
            this.SaveProfile.TabIndex = 21;
            this.SaveProfile.Text = "Save Profile";
            this.SaveProfile.UseVisualStyleBackColor = true;
            this.SaveProfile.Click += new System.EventHandler(this.SaveProfile_Click);
            // 
            // l_saveprofile
            // 
            this.l_saveprofile.AutoSize = true;
            this.l_saveprofile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.l_saveprofile.Location = new System.Drawing.Point(1573, 636);
            this.l_saveprofile.Name = "l_saveprofile";
            this.l_saveprofile.Size = new System.Drawing.Size(0, 15);
            this.l_saveprofile.TabIndex = 22;
            // 
            // l_profilename
            // 
            this.l_profilename.AutoSize = true;
            this.l_profilename.Location = new System.Drawing.Point(1628, 70);
            this.l_profilename.Name = "l_profilename";
            this.l_profilename.Size = new System.Drawing.Size(70, 13);
            this.l_profilename.TabIndex = 23;
            this.l_profilename.Text = "Profile Name:";
            // 
            // value_profilename
            // 
            this.value_profilename.Location = new System.Drawing.Point(1721, 67);
            this.value_profilename.Name = "value_profilename";
            this.value_profilename.Size = new System.Drawing.Size(133, 20);
            this.value_profilename.TabIndex = 24;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1721, 115);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(133, 21);
            this.comboBox2.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1628, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Use Profile";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1445, 471);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 97);
            this.textBox1.TabIndex = 27;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1740, 471);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(131, 97);
            this.textBox2.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1958, 1005);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.value_profilename);
            this.Controls.Add(this.l_profilename);
            this.Controls.Add(this.l_saveprofile);
            this.Controls.Add(this.SaveProfile);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.l_binaryfilter);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BrowseSave);
            this.Controls.Add(this.picOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picInput);
            this.Controls.Add(this.Browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picOutput;
        private System.Windows.Forms.Button BrowseSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label l_brightness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label l_contrast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label l_intensity;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label l_threshold;
        private System.Windows.Forms.Label l_amount;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.Label l_radius;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label l_binaryfilter;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button SaveProfile;
        private System.Windows.Forms.Label l_saveprofile;
        private System.Windows.Forms.Label l_profilename;
        private System.Windows.Forms.TextBox value_profilename;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

