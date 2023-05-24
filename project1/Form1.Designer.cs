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
            this.Result = new System.Windows.Forms.Button();
            this.picOutput = new System.Windows.Forms.PictureBox();
            this.BrowseSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(225, 476);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(101, 32);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // picInput
            // 
            this.picInput.Location = new System.Drawing.Point(58, 12);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(451, 451);
            this.picInput.TabIndex = 1;
            this.picInput.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(553, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(757, 470);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(108, 38);
            this.Result.TabIndex = 4;
            this.Result.Text = "Result";
            this.Result.UseVisualStyleBackColor = true;
            this.Result.Click += new System.EventHandler(this.Result_Click);
            // 
            // picOutput
            // 
            this.picOutput.Location = new System.Drawing.Point(617, 12);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(451, 451);
            this.picOutput.TabIndex = 5;
            this.picOutput.TabStop = false;
            // 
            // BrowseSave
            // 
            this.BrowseSave.Location = new System.Drawing.Point(1124, 470);
            this.BrowseSave.Name = "BrowseSave";
            this.BrowseSave.Size = new System.Drawing.Size(115, 38);
            this.BrowseSave.TabIndex = 6;
            this.BrowseSave.Text = "Browse to Save";
            this.BrowseSave.UseVisualStyleBackColor = true;
            this.BrowseSave.Click += new System.EventHandler(this.BrowseSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 520);
            this.Controls.Add(this.BrowseSave);
            this.Controls.Add(this.picOutput);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picInput);
            this.Controls.Add(this.Browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Result;
        private System.Windows.Forms.PictureBox picOutput;
        private System.Windows.Forms.Button BrowseSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

