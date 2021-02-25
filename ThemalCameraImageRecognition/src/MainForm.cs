using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ThemalCameraImageRecognition
{
    public partial class MainForm : Form
    {
        private Bitmap _initialImage;                       // The image that user initially loads into program
        private Bitmap _currentImage;                       // THe image that is currently in pictureBox
        private Point _latestPoint;                         // Needed for pen drawing
        private readonly List<PointF> _points = new();      // List of points that will define a polygon
        private const int PolygonDrawPixelThreshold = 10;   // Minimum pixels required to start polygon drawing
        private bool _isReadyToDrawNextPolygon = true;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateAndShowBitmapImage()
        {
            if (textBox1.Text == "")
                return;

            Bitmap originalBitmap;
            // Possible FileNotFoundException if the path doesn't refer to an image
            try
            {
                originalBitmap = new Bitmap(textBox1.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Image was not found. Try again.");
                Debug.WriteLine(e.Message);
                return;
            }

            float width = 640;
            float height = 480;

            Bitmap resizedBitmap = GetResizedBitmap(originalBitmap, width, height);

            pictureBox.Image = resizedBitmap;
            _currentImage = resizedBitmap;
            _initialImage = resizedBitmap;
            
            pictureBox.Location = new Point(panelImage.Width / 2 - pictureBox.Width / 2,
                panelImage.Height / 2 - pictureBox.Height / 2);

            btnConvertToGray.Enabled = true;
        }

        // Resizes bitmap image but keeps aspect ratio
        private Bitmap GetResizedBitmap(Bitmap bitmap, float width, float height)
        {
            float scale = Math.Min(width / bitmap.Width, height / bitmap.Height);
            
            var scaledWidth = (int)(bitmap.Width * scale);
            var scaledHeight = (int)(bitmap.Height * scale);

            Bitmap resizedBitmap = new Bitmap(bitmap, new Size( scaledWidth, scaledHeight));

            return resizedBitmap;
        }

        private bool CreateAndOpenFileDialog()
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
                return true;
            }

            return false;
        }

        private void ShowPixelInfoLabels()
        {
            panelPixelColor.Show();
            labelPixelColor.Show();
            labelPixels.Show();
            labelPixelIntensity.Show();
            labelIntensityPercent.Show();
        }

        private void HidePixelInfoLabels()
        {
            panelPixelColor.Hide();
            labelPixelColor.Hide();
            labelPixels.Hide();
            labelPixelIntensity.Hide();
            labelIntensityPercent.Hide();
        }

        // Converts the image loaded to grayscale
        private static Bitmap ConvertToGrayscale(Bitmap image)
        {
            // Create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(image);

            // Get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            // Create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
                new[]
                {
                    new[] {.3f, .3f, .3f, 0, 0},
                    new[] {.59f, .59f, .59f, 0, 0},
                    new[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            // Create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            // Set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            // Draw the original image on the new image using the grayscale color matrix
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);

            // Dispose the Graphics object
            g.Dispose();

            return newBitmap;
        }

        private void UpdatePixelInfoLabels(Point localMousePosition)
        {
            labelPixels.Text = $"[{localMousePosition.X}, {localMousePosition.Y}]";

            // Get the color of the pixel that cursor is pointing to
            Color pixelColor;
            try
            {
                pixelColor = _currentImage.GetPixel(localMousePosition.X, localMousePosition.Y);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            // Update labels and color panel
            labelPixelColor.Text = $"[{pixelColor.R}, {pixelColor.G}, {pixelColor.B}]";
            panelPixelColor.BackColor = pixelColor;

            labelPixelIntensity.Text = $"{Math.Round(pixelColor.GetBrightness() * 255)}";

            labelIntensityPercent.Text = $"{Math.Round(pixelColor.GetBrightness() * 100)}%";
        }
        
        private void FindPixelsInSelectedRegion()
        {
            panelRegionAverage.Hide();
            pictureBoxLoading.Show();

            //Task.Run(() => { Invoke((MethodInvoker) delegate { pictureBoxLoading.Show(); }); } );

            /*Task.Delay(1000).ContinueWith(t =>
            {
                Invoke((MethodInvoker) delegate
                {
                    pictureBoxLoading.Show();
                });
            });*/

            _isReadyToDrawNextPolygon = false;
            Bitmap bitmap = new Bitmap(_currentImage);
            float R = 0, G = 0, B = 0;
            float brightnessSum = 0.0f;
            int counter = 0;

            // For all pixels in width, height
            for (int i = 0; i < pictureBox.Width; i++)
            {
                for (int j = 0; j < pictureBox.Height; j++)
                {
                    // If current pixel is inside our selected polygon, add it to a sum
                    if (IsPointInPolygon(new PointF(i, j), _points.ToArray()))
                    {
                        //_currentImage.SetPixel(i, j, Color.Black);

                        brightnessSum += bitmap.GetPixel(i, j).GetBrightness();
                        R += bitmap.GetPixel(i, j).R;
                        G += bitmap.GetPixel(i, j).G;
                        B += bitmap.GetPixel(i, j).B;
                        counter++;
                    }
                }
            }
          
            pictureBoxLoading.Hide();
            panelRegionAverage.Show();
            
            // Set intensity value and intesity percentage labels
            float averageBrightness = CalculateAverage(brightnessSum, counter);

            // If average brightness could not be calculated
            if ((int)averageBrightness == -1)
            {
                Debug.WriteLine("Brigntess = -1");
                _isReadyToDrawNextPolygon = true;
                return;
            }

            labelRegionIntensity.Text = (averageBrightness * 255).ToString("0.0");
            labelRegionIntensityPercent.Text = (averageBrightness * 100).ToString("0.00") + "%";

            // Calculate average RGB color TODO: check if there is a better way to calculate RGB color average
            int averageR = (int)CalculateAverage(R, counter);
            int averageG = (int)CalculateAverage(G, counter);
            int averageB = (int)CalculateAverage(B, counter);
        
            // Update Region average color and panel color
            labelRegionColor.Text = $"[{averageR}, {averageG}, {averageB}]";
            panelRegionColor.BackColor = Color.FromArgb(255, averageR, averageG, averageB);

            _isReadyToDrawNextPolygon = true;
        }

        // Just a simple average calculator
        private static float CalculateAverage(float sum, int counter)
        {
            return counter != 0 ? sum / counter : -1.0f;
        }

        // Algorithm that finds if the given point is inside the polygon defined by 2nd parameter's points
        public bool IsPointInPolygon(PointF point, PointF[] polygon)
        {
            int polygonLength = polygon.Length, i = 0;

            if (polygonLength <= 0)
                return false;

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
                
                isInside ^= ( endY > pointY ^ startY > pointY ) // ? pointY inside [startY;endY] segment ? 
                            && // if so, test if it is under the segment 
                            ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY)) ;
            }
            return isInside;
        }

        private void DrawPolygon(PointF[] points)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            
            // Create pen
            Pen pen = new Pen(Color.White, 2);

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(100, 50, 50, 50));

            // Draw polygon outline
            graphics.DrawPolygon(pen, points);

            // Draw polygon area
            graphics.FillPolygon(blueBrush, points);

            // Show selected region average info panel
            panelRegionAverage.Show();
            
        }

        //============================================ Events ============================================


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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (CreateAndOpenFileDialog())
            {
                CreateAndShowBitmapImage();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentImage is null || !_isReadyToDrawNextPolygon)
                return;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Graphics graphics = pictureBox.CreateGraphics();
                
                // Draw next line and...
                graphics.DrawLine(Pens.White, _latestPoint, e.Location);

                // ... Remember the location
                _latestPoint = e.Location;

                _points.Add(e.Location);
            }

            if (!(Cursor.Current is null)) 
                Cursor = new Cursor(Cursor.Current.Handle);

            // localMousePosition starts counting [0, 0] from the starting point of pictureBox
            var localMousePosition = pictureBox.PointToClient(Cursor.Position);

            UpdatePixelInfoLabels(localMousePosition);

            ShowPixelInfoLabels();
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            HidePixelInfoLabels();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentImage is null || !_isReadyToDrawNextPolygon)
                return;

            // Clear point list to create a new polygon
            _points.Clear();

            // Remember the location where the button was pressed
            _latestPoint = e.Location;

            // Invalidate component to force repaint to clear last graphics
            pictureBox.Invalidate();
            
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_points.Count < PolygonDrawPixelThreshold || _currentImage is null)
            {
                panelRegionAverage.Hide();
                return;
            }

            DrawPolygon(_points.ToArray());
            FindPixelsInSelectedRegion();
        }
    }
}
