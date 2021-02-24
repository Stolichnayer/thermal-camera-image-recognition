using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ThemalCameraImageRecognition
{
    public partial class mainForm : Form
    {
        private Bitmap _initialImage;
        private Bitmap _currentImage;

        public mainForm()
        {
            InitializeComponent();
        }

        private void CreateAndShowBitmapImage()
        {
            if (textBox1.Text == "")
                return;

            Bitmap originalBitmap = new Bitmap(textBox1.Text);
            
            //Resize image but keep aspect ratio
            float width = 640;
            float height = 480;
            float scale = Math.Min(width / originalBitmap.Width, height / originalBitmap.Height);
            
            var scaledWidth = (int)(originalBitmap.Width * scale);
            var scaledHeight = (int)(originalBitmap.Height * scale);

            Bitmap resizedBitmap = new Bitmap(originalBitmap, new Size( scaledWidth, scaledHeight));

            pictureBox.Image = resizedBitmap;

            _currentImage = resizedBitmap;
            _initialImage = resizedBitmap;
            
            pictureBox.Location = new Point(panelImage.Width / 2 - pictureBox.Width / 2,
                panelImage.Height / 2 - pictureBox.Height / 2);

            btnConvertToGray.Enabled = true;
        }

        private void CreateAndOpenFileDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog  
            {  
                InitialDirectory = @"C:\",  
                Title = "Browse Image Files",
                CheckFileExists = true,  
                CheckPathExists = true,
                DefaultExt = "jpg",  
                Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF",  
                FilterIndex = 1,  
                RestoreDirectory = true,
                ReadOnlyChecked = true,  
                ShowReadOnly = true  
            };  
  
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  
            {  
                textBox1.Text = openFileDialog1.FileName;
            }  
        }

        private void ShowLabels()
        {
            panelPixelColor.Show();
            labelPixelColor.Show();
            labelPixels.Show();
            labelPixelIntensity.Show();
            labelIntensityPercent.Show();
        }

        private void HideLabels()
        {
            panelPixelColor.Hide();
            labelPixelColor.Hide();
            labelPixels.Hide();
            labelPixelIntensity.Hide();
            labelIntensityPercent.Hide();
        }

        private void btnConvertToGray_Click(object sender, EventArgs e)
        {
            if(_currentImage is null)
                return;

            if (_currentImage != _initialImage)
            {
                _currentImage = _initialImage;
                pictureBox.Image = _currentImage;
                btnConvertToGray.Text = "Convert to grayscale";
            }
            else
            {
                _currentImage = ConvertToGrayscale(_currentImage);
                pictureBox.Image = _currentImage;
                btnConvertToGray.Text = "Restore original";
            }
        }

        private static Bitmap ConvertToGrayscale(Bitmap image)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(image);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image using the grayscale color matrix
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();

            return newBitmap;
        }

        private void UpdatePixelInfo(Point localMousePosition)
        {
            labelPixels.Text = $"[{localMousePosition.X}, {localMousePosition.Y}]";

            Color pixelColor;
            try
            { 
                pixelColor = _currentImage.GetPixel(localMousePosition.X, localMousePosition.Y);
            }
            catch (Exception)
            {
                return;
            }

            labelPixelColor.Text = $"[{pixelColor.R}, {pixelColor.G}, {pixelColor.B}]";
            panelPixelColor.BackColor = pixelColor;

            labelPixelIntensity.Text = $"{Math.Round(pixelColor.GetBrightness() * 255)}";

            labelIntensityPercent.Text = $"{Math.Round(pixelColor.GetBrightness() * 100)}%";
        }

        //Events
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            CreateAndOpenFileDialog();
            CreateAndShowBitmapImage();
        }

        Point latestPoint;
        private List<PointF> points = new List<PointF>();

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            /////////////////////////////////////////////////////////////////////
            if (_currentImage is null)
                return;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                using (Graphics g = pictureBox.CreateGraphics())
                {
                    // Draw next line and...
                    g.DrawLine(Pens.White, latestPoint, e.Location);

                    // ... Remember the location
                    latestPoint = e.Location;

                    points.Add(e.Location);
                }
            }
            /////////////////////////////////////////////////////////////////////

            if (_currentImage is null)
                return;

            if (!(Cursor.Current is null)) 
                Cursor = new Cursor(Cursor.Current.Handle);

            var localMousePosition = pictureBox.PointToClient(Cursor.Position);

            UpdatePixelInfo(localMousePosition);

            ShowLabels();
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            HideLabels();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentImage is null)
                return;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                points.Clear();
                // Remember the location where the button was pressed
                latestPoint = e.Location;
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (points.Count < 10 || _currentImage is null)
            {
                panelRegionAverage.Hide();
                return;
            }
                
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Create pen
                Pen pen = new Pen(Color.White, 2);

                // Create solid brush.
                SolidBrush blueBrush = new SolidBrush(Color.FromArgb(100, 50, 50, 50));

                g.DrawPolygon(pen, points.ToArray());
                g.FillPolygon(blueBrush, points.ToArray());

                FindPixelsInSelectedRegion();
                panelRegionAverage.Show();
            }
        }

        private void FindPixelsInSelectedRegion()
        {
           // List<float> pixelBrightnessList = new();
           float R = 0;
           float G = 0;
           float B = 0;
           float sum = 0.0f;
           int counter = 0;
            for (int i = 0; i < pictureBox.Width; i++)
            {
                for (int j = 0; j < pictureBox.Height; j++)
                {
                    if (IsPointInPolygon( new PointF(i, j), points.ToArray()))
                    {
                        //_currentImage.SetPixel(i, j, Color.Black);
                       // pixelBrightnessList.Add(_currentImage.GetPixel(i, j).GetBrightness());
                       sum += _currentImage.GetPixel(i, j).GetBrightness();

                       R += _currentImage.GetPixel(i, j).R;
                       G += _currentImage.GetPixel(i, j).G;
                       B += _currentImage.GetPixel(i, j).B;

                       counter++;
                    }
                }
            }
            //pictureBox.Image = _currentImage;
            labelRegionIntensity.Text = (CalculateAverage(sum, counter) * 255).ToString("0.0");
            labelRegionIntensityPercent.Text = (CalculateAverage(sum, counter) * 100).ToString("0.00") + "%";

            int averageR = (int)CalculateAverage(R, counter);
            int averageG = (int)CalculateAverage(G, counter);
            int averageB = (int)CalculateAverage(B, counter);
            
            labelRegionColor.Text = $"[{averageR}, {averageG}, {averageB}]";
            panelRegionColor.BackColor = Color.FromArgb(255, averageR, averageG, averageB);
        }

        private float CalculateAverage(float sum, int counter)
        {
            return sum / counter;
        }

        public bool IsPointInPolygon(PointF point, PointF[] polygon)
        {
            int polygonLength = polygon.Length, i = 0;
            bool isInside = false;

            // x, y for tested point.
            float pointX = point.X, pointY = point.Y;

            // start / end point for the current polygon segment.
            float startX, startY, endX, endY;

            PointF endPoint = polygon[polygonLength - 1];           
            endX = endPoint.X; 
            endY = endPoint.Y;

            while (i < polygonLength) 
            {
                startX = endX;           
                startY = endY;
                endPoint = polygon[i++];
                endX = endPoint.X;       
                endY = endPoint.Y;
                //
                isInside ^= ( endY > pointY ^ startY > pointY ) /* ? pointY inside [startY;endY] segment ? */
                            && /* if so, test if it is under the segment */
                            ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY)) ;
            }
            return isInside;
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
           // labelPolygon.Text = IsPointInPolygon(Cursor.Position, points.ToArray()).ToString();
            //labelPolygon.Text = IsPointInPolygon(pictureBox.PointToClient(Cursor.Position), points.ToArray()).ToString();

        }
    }


}
