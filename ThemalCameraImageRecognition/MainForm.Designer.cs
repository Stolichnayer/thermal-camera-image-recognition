
namespace ThemalCameraImageRecognition
{
    partial class MainForm
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
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnConvertToGray = new System.Windows.Forms.Button();
            this.labelPixelsDesc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelRegionAverage = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panelRegionColor = new System.Windows.Forms.Panel();
            this.labelRegionIntensityPercent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelRegionColor = new System.Windows.Forms.Label();
            this.labelRegionIntensity = new System.Windows.Forms.Label();
            this.panelSinglePixel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.labelIntensityPercent = new System.Windows.Forms.Label();
            this.labelColorDesc = new System.Windows.Forms.Label();
            this.labelPixels = new System.Windows.Forms.Label();
            this.labelPixelIntensity = new System.Windows.Forms.Label();
            this.labelPixelColor = new System.Windows.Forms.Label();
            this.labelIntensityDesc = new System.Windows.Forms.Label();
            this.panelPixelColor = new System.Windows.Forms.Panel();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelRegionAverage.SuspendLayout();
            this.panelSinglePixel.SuspendLayout();
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
            // panelImage
            // 
            this.panelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.panelImage.Controls.Add(this.pictureBox);
            this.panelImage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelImage.Location = new System.Drawing.Point(0, 64);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(798, 609);
            this.panelImage.TabIndex = 4;
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
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnConvertToGray
            // 
            this.btnConvertToGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.btnConvertToGray.Enabled = false;
            this.btnConvertToGray.FlatAppearance.BorderSize = 0;
            this.btnConvertToGray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertToGray.ForeColor = System.Drawing.Color.White;
            this.btnConvertToGray.Location = new System.Drawing.Point(437, 20);
            this.btnConvertToGray.Name = "btnConvertToGray";
            this.btnConvertToGray.Size = new System.Drawing.Size(112, 22);
            this.btnConvertToGray.TabIndex = 4;
            this.btnConvertToGray.Text = "Convert to grayscale";
            this.btnConvertToGray.UseVisualStyleBackColor = false;
            this.btnConvertToGray.Click += new System.EventHandler(this.btnConvertToGray_Click);
            // 
            // labelPixelsDesc
            // 
            this.labelPixelsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPixelsDesc.AutoSize = true;
            this.labelPixelsDesc.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixelsDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPixelsDesc.Location = new System.Drawing.Point(21, 46);
            this.labelPixelsDesc.Name = "labelPixelsDesc";
            this.labelPixelsDesc.Size = new System.Drawing.Size(79, 21);
            this.labelPixelsDesc.TabIndex = 1;
            this.labelPixelsDesc.Text = "Location:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.btnConvertToGray);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 64);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.panel2.Controls.Add(this.panelRegionAverage);
            this.panel2.Controls.Add(this.panelSinglePixel);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(798, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 609);
            this.panel2.TabIndex = 6;
            // 
            // panelRegionAverage
            // 
            this.panelRegionAverage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.panelRegionAverage.Controls.Add(this.label9);
            this.panelRegionAverage.Controls.Add(this.panelRegionColor);
            this.panelRegionAverage.Controls.Add(this.labelRegionIntensityPercent);
            this.panelRegionAverage.Controls.Add(this.label8);
            this.panelRegionAverage.Controls.Add(this.label4);
            this.panelRegionAverage.Controls.Add(this.labelRegionColor);
            this.panelRegionAverage.Controls.Add(this.labelRegionIntensity);
            this.panelRegionAverage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegionAverage.Location = new System.Drawing.Point(0, 170);
            this.panelRegionAverage.Name = "panelRegionAverage";
            this.panelRegionAverage.Size = new System.Drawing.Size(309, 139);
            this.panelRegionAverage.TabIndex = 11;
            this.panelRegionAverage.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Aquamarine;
            this.label9.Location = new System.Drawing.Point(8, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 21);
            this.label9.TabIndex = 17;
            this.label9.Text = "Region of selection average:";
            // 
            // panelRegionColor
            // 
            this.panelRegionColor.BackColor = System.Drawing.Color.Black;
            this.panelRegionColor.Location = new System.Drawing.Point(110, 58);
            this.panelRegionColor.Name = "panelRegionColor";
            this.panelRegionColor.Size = new System.Drawing.Size(24, 22);
            this.panelRegionColor.TabIndex = 13;
            // 
            // labelRegionIntensityPercent
            // 
            this.labelRegionIntensityPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRegionIntensityPercent.AutoSize = true;
            this.labelRegionIntensityPercent.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegionIntensityPercent.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelRegionIntensityPercent.Location = new System.Drawing.Point(167, 97);
            this.labelRegionIntensityPercent.Name = "labelRegionIntensityPercent";
            this.labelRegionIntensityPercent.Size = new System.Drawing.Size(44, 21);
            this.labelRegionIntensityPercent.TabIndex = 16;
            this.labelRegionIntensityPercent.Text = "BR%";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(20, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "Intensity:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(20, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Color:";
            // 
            // labelRegionColor
            // 
            this.labelRegionColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRegionColor.AutoSize = true;
            this.labelRegionColor.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegionColor.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelRegionColor.Location = new System.Drawing.Point(144, 58);
            this.labelRegionColor.Name = "labelRegionColor";
            this.labelRegionColor.Size = new System.Drawing.Size(42, 21);
            this.labelRegionColor.TabIndex = 12;
            this.labelRegionColor.Text = "RGB";
            // 
            // labelRegionIntensity
            // 
            this.labelRegionIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRegionIntensity.AutoSize = true;
            this.labelRegionIntensity.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegionIntensity.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelRegionIntensity.Location = new System.Drawing.Point(106, 97);
            this.labelRegionIntensity.Name = "labelRegionIntensity";
            this.labelRegionIntensity.Size = new System.Drawing.Size(30, 21);
            this.labelRegionIntensity.TabIndex = 15;
            this.labelRegionIntensity.Text = "BR";
            // 
            // panelSinglePixel
            // 
            this.panelSinglePixel.BackColor = System.Drawing.Color.DimGray;
            this.panelSinglePixel.Controls.Add(this.label10);
            this.panelSinglePixel.Controls.Add(this.labelPixelsDesc);
            this.panelSinglePixel.Controls.Add(this.labelIntensityPercent);
            this.panelSinglePixel.Controls.Add(this.labelColorDesc);
            this.panelSinglePixel.Controls.Add(this.labelPixels);
            this.panelSinglePixel.Controls.Add(this.labelPixelIntensity);
            this.panelSinglePixel.Controls.Add(this.labelPixelColor);
            this.panelSinglePixel.Controls.Add(this.labelIntensityDesc);
            this.panelSinglePixel.Controls.Add(this.panelPixelColor);
            this.panelSinglePixel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSinglePixel.Location = new System.Drawing.Point(0, 0);
            this.panelSinglePixel.Name = "panelSinglePixel";
            this.panelSinglePixel.Size = new System.Drawing.Size(309, 170);
            this.panelSinglePixel.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Aquamarine;
            this.label10.Location = new System.Drawing.Point(8, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "Selected pixel:";
            // 
            // labelIntensityPercent
            // 
            this.labelIntensityPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIntensityPercent.AutoSize = true;
            this.labelIntensityPercent.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntensityPercent.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelIntensityPercent.Location = new System.Drawing.Point(142, 129);
            this.labelIntensityPercent.Name = "labelIntensityPercent";
            this.labelIntensityPercent.Size = new System.Drawing.Size(44, 21);
            this.labelIntensityPercent.TabIndex = 8;
            this.labelIntensityPercent.Text = "BR%";
            this.labelIntensityPercent.Visible = false;
            // 
            // labelColorDesc
            // 
            this.labelColorDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelColorDesc.AutoSize = true;
            this.labelColorDesc.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColorDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelColorDesc.Location = new System.Drawing.Point(21, 89);
            this.labelColorDesc.Name = "labelColorDesc";
            this.labelColorDesc.Size = new System.Drawing.Size(55, 21);
            this.labelColorDesc.TabIndex = 2;
            this.labelColorDesc.Text = "Color:";
            // 
            // labelPixels
            // 
            this.labelPixels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPixels.AutoSize = true;
            this.labelPixels.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixels.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPixels.Location = new System.Drawing.Point(106, 46);
            this.labelPixels.Name = "labelPixels";
            this.labelPixels.Size = new System.Drawing.Size(85, 21);
            this.labelPixels.TabIndex = 3;
            this.labelPixels.Text = "[Location]";
            this.labelPixels.Visible = false;
            // 
            // labelPixelIntensity
            // 
            this.labelPixelIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPixelIntensity.AutoSize = true;
            this.labelPixelIntensity.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixelIntensity.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPixelIntensity.Location = new System.Drawing.Point(106, 129);
            this.labelPixelIntensity.Name = "labelPixelIntensity";
            this.labelPixelIntensity.Size = new System.Drawing.Size(30, 21);
            this.labelPixelIntensity.TabIndex = 7;
            this.labelPixelIntensity.Text = "BR";
            this.labelPixelIntensity.Visible = false;
            // 
            // labelPixelColor
            // 
            this.labelPixelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPixelColor.AutoSize = true;
            this.labelPixelColor.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixelColor.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPixelColor.Location = new System.Drawing.Point(140, 88);
            this.labelPixelColor.Name = "labelPixelColor";
            this.labelPixelColor.Size = new System.Drawing.Size(42, 21);
            this.labelPixelColor.TabIndex = 4;
            this.labelPixelColor.Text = "RGB";
            this.labelPixelColor.Visible = false;
            // 
            // labelIntensityDesc
            // 
            this.labelIntensityDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIntensityDesc.AutoSize = true;
            this.labelIntensityDesc.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntensityDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelIntensityDesc.Location = new System.Drawing.Point(21, 129);
            this.labelIntensityDesc.Name = "labelIntensityDesc";
            this.labelIntensityDesc.Size = new System.Drawing.Size(79, 21);
            this.labelIntensityDesc.TabIndex = 6;
            this.labelIntensityDesc.Text = "Intensity:";
            // 
            // panelPixelColor
            // 
            this.panelPixelColor.BackColor = System.Drawing.Color.Black;
            this.panelPixelColor.Location = new System.Drawing.Point(110, 88);
            this.panelPixelColor.Name = "panelPixelColor";
            this.panelPixelColor.Size = new System.Drawing.Size(24, 22);
            this.panelPixelColor.TabIndex = 5;
            this.panelPixelColor.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 673);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Thermal Camera Image Recognition";
            this.panelImage.ResumeLayout(false);
            this.panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelRegionAverage.ResumeLayout(false);
            this.panelRegionAverage.PerformLayout();
            this.panelSinglePixel.ResumeLayout(false);
            this.panelSinglePixel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelPixelsDesc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelColorDesc;
        private System.Windows.Forms.Label labelPixelColor;
        private System.Windows.Forms.Label labelPixels;
        private System.Windows.Forms.Panel panelPixelColor;
        private System.Windows.Forms.Button btnConvertToGray;
        private System.Windows.Forms.Label labelPixelIntensity;
        private System.Windows.Forms.Label labelIntensityDesc;
        private System.Windows.Forms.Label labelIntensityPercent;
        private System.Windows.Forms.Panel panelRegionAverage;
        private System.Windows.Forms.Panel panelRegionColor;
        private System.Windows.Forms.Label labelRegionIntensityPercent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRegionColor;
        private System.Windows.Forms.Label labelRegionIntensity;
        private System.Windows.Forms.Panel panelSinglePixel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

