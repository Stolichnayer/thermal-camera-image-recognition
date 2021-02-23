
namespace ThemalCameraImageRecognition
{
    partial class mainForm
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.panelImage = new System.Windows.Forms.Panel();
            this.btnConvertToGray = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelPixelsDesc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelColor = new System.Windows.Forms.Panel();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelPixels = new System.Windows.Forms.Label();
            this.labelColorDesc = new System.Windows.Forms.Label();
            this.labelIntensity = new System.Windows.Forms.Label();
            this.labelIntensityDesc = new System.Windows.Forms.Label();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(333, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(98, 22);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image";
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.btnProcess.Enabled = false;
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(437, 20);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 22);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            // 
            // panelImage
            // 
            this.panelImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.panelImage.Controls.Add(this.pictureBox);
            this.panelImage.Location = new System.Drawing.Point(0, 59);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(798, 614);
            this.panelImage.TabIndex = 4;
            // 
            // btnConvertToGray
            // 
            this.btnConvertToGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.btnConvertToGray.Enabled = false;
            this.btnConvertToGray.FlatAppearance.BorderSize = 0;
            this.btnConvertToGray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertToGray.ForeColor = System.Drawing.Color.White;
            this.btnConvertToGray.Location = new System.Drawing.Point(19, 134);
            this.btnConvertToGray.Name = "btnConvertToGray";
            this.btnConvertToGray.Size = new System.Drawing.Size(112, 22);
            this.btnConvertToGray.TabIndex = 4;
            this.btnConvertToGray.Text = "Convert to grayscale";
            this.btnConvertToGray.UseVisualStyleBackColor = false;
            this.btnConvertToGray.Click += new System.EventHandler(this.btnConvertToGray_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(50, 57);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(700, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // labelPixelsDesc
            // 
            this.labelPixelsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPixelsDesc.AutoSize = true;
            this.labelPixelsDesc.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixelsDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPixelsDesc.Location = new System.Drawing.Point(15, 14);
            this.labelPixelsDesc.Name = "labelPixelsDesc";
            this.labelPixelsDesc.Size = new System.Drawing.Size(79, 21);
            this.labelPixelsDesc.TabIndex = 1;
            this.labelPixelsDesc.Text = "Location:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.btnProcess);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 59);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.panel2.Controls.Add(this.btnConvertToGray);
            this.panel2.Controls.Add(this.labelIntensity);
            this.panel2.Controls.Add(this.labelIntensityDesc);
            this.panel2.Controls.Add(this.panelColor);
            this.panel2.Controls.Add(this.labelColor);
            this.panel2.Controls.Add(this.labelPixels);
            this.panel2.Controls.Add(this.labelColorDesc);
            this.panel2.Controls.Add(this.labelPixelsDesc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(798, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 614);
            this.panel2.TabIndex = 6;
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Black;
            this.panelColor.Location = new System.Drawing.Point(104, 55);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(24, 22);
            this.panelColor.TabIndex = 5;
            this.panelColor.Visible = false;
            // 
            // labelColor
            // 
            this.labelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelColor.Location = new System.Drawing.Point(134, 56);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(70, 21);
            this.labelColor.TabIndex = 4;
            this.labelColor.Text = "[R, G, B]";
            this.labelColor.Visible = false;
            // 
            // labelPixels
            // 
            this.labelPixels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPixels.AutoSize = true;
            this.labelPixels.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixels.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPixels.Location = new System.Drawing.Point(100, 14);
            this.labelPixels.Name = "labelPixels";
            this.labelPixels.Size = new System.Drawing.Size(85, 21);
            this.labelPixels.TabIndex = 3;
            this.labelPixels.Text = "[Location]";
            this.labelPixels.Visible = false;
            // 
            // labelColorDesc
            // 
            this.labelColorDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelColorDesc.AutoSize = true;
            this.labelColorDesc.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColorDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelColorDesc.Location = new System.Drawing.Point(15, 57);
            this.labelColorDesc.Name = "labelColorDesc";
            this.labelColorDesc.Size = new System.Drawing.Size(55, 21);
            this.labelColorDesc.TabIndex = 2;
            this.labelColorDesc.Text = "Color:";
            // 
            // labelIntensity
            // 
            this.labelIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIntensity.AutoSize = true;
            this.labelIntensity.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntensity.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelIntensity.Location = new System.Drawing.Point(100, 97);
            this.labelIntensity.Name = "labelIntensity";
            this.labelIntensity.Size = new System.Drawing.Size(70, 21);
            this.labelIntensity.TabIndex = 7;
            this.labelIntensity.Text = "[R, G, B]";
            this.labelIntensity.Visible = false;
            // 
            // labelIntensityDesc
            // 
            this.labelIntensityDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIntensityDesc.AutoSize = true;
            this.labelIntensityDesc.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntensityDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelIntensityDesc.Location = new System.Drawing.Point(15, 97);
            this.labelIntensityDesc.Name = "labelIntensityDesc";
            this.labelIntensityDesc.Size = new System.Drawing.Size(79, 21);
            this.labelIntensityDesc.TabIndex = 6;
            this.labelIntensityDesc.Text = "Intensity:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 673);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "Thermal Camera Image Recognition";
            this.panelImage.ResumeLayout(false);
            this.panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelPixelsDesc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelColorDesc;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelPixels;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Button btnConvertToGray;
        private System.Windows.Forms.Label labelIntensity;
        private System.Windows.Forms.Label labelIntensityDesc;
    }
}

