using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThemalCameraImageRecognition
{
    public partial class MainForm : Form
    {
        private const int PolygonDrawPixelThreshold = 10;   // Minimum pixels required to start polygon drawing
        private const int NewBitmapWidth = 640;             // The width that the new resized bitmap will have
        private const int NewBitmapHeight = 480;            // The height that the new resized bitmap will have

        private Bitmap _initialImage;                       // The image that user initially loads into program
        private Bitmap _currentImage;                       // THe image that is currently in pictureBox
        private Point _latestPoint;                         // Needed for pen drawing
        private readonly List<PointF> _points = new();      // List of points that will define a polygon
        private bool _isReadyToDrawNextPolygon = true;      // Polygon drawing lock
        private bool _arePointsCleared = true;
        
        private struct ColorSumValues
        {
            public float R;
            public float G;
            public float B;
            public float Brightness;
            public int Counter;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadBitmapImage()
        {
            // If the path textbox is empty
            if (textBox1.Text == "")
            {
                return;
            }

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

            Bitmap resizedBitmap = GetResizedBitmap(originalBitmap, NewBitmapWidth, NewBitmapHeight);

            pictureBox.Image = resizedBitmap;
            _currentImage = resizedBitmap;
            _initialImage = resizedBitmap;
            
            // Center the loaded image in the panelImage
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

        // Create and show dialog to select an image
        private bool ShowOpenFileDialog()
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

        // Shows all information about a single pixel (First panel)
        private void ShowPixelInfoLabels()
        {
            panelPixelColor.Show();
            labelPixelColor.Show();
            labelPixels.Show();
            labelPixelIntensity.Show();
            labelIntensityPercent.Show();
            panelBar2.Show();
            panelProgressBar2.Show();
        }

        // Hides all information about a single pixel (First panel)
        private void HidePixelInfoLabels()
        {
            panelPixelColor.Hide();
            labelPixelColor.Hide();
            labelPixels.Hide();
            labelPixelIntensity.Hide();
            labelIntensityPercent.Hide();
            panelBar2.Hide();
            panelProgressBar2.Hide();
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

        // Calculate image's pixel color that cursor is pointing to and update the label values
        private void UpdatePixelInfoLabels(Point localMousePosition)
        {
            // Avoid possible Exception because of wrong parameters, due to negative mouse position or outside of image
            if (localMousePosition.X < 0 || 
                localMousePosition.Y < 0 ||
                localMousePosition.X >= _currentImage.Width || 
                localMousePosition.Y >= _currentImage.Height)
            {
                return;
            }

            // Update cursor's location label info
            labelPixels.Text = $"[{localMousePosition.X}, {localMousePosition.Y}]";

            // Get the color of the pixel that cursor is pointing to
            Color pixelColor = _currentImage.GetPixel(localMousePosition.X, localMousePosition.Y);

            // Update RGB code label  
            labelPixelColor.Text = $"[{pixelColor.R}, {pixelColor.G}, {pixelColor.B}]";

            // Paint the panel to the corresponding RGB color
            panelPixelColor.BackColor = pixelColor;

            // Update intensity label value
            labelPixelIntensity.Text = $"{Math.Round(pixelColor.GetBrightness() * 255)}";

            // Update intensity percentage label value
            labelIntensityPercent.Text = (pixelColor.GetBrightness() * 100).ToString("0.00") + "%";

            // Resize percentage bar to the appropriate width to depict the percentage optically
            panelBar2.Width = (int)(pixelColor.GetBrightness() * panelProgressBar2.Width);
        }
            
        
        
      /*Invoke((MethodInvoker) delegate
            {
                //pictureBoxLoading.Show();
            });*/

      //Task.Run(() => { Invoke((MethodInvoker) delegate { pictureBoxLoading.Show(); }); } );

        private async Task FindPixelsInSelectedRegion()
        {
            panelRegionAverage.Hide();
            pictureBoxLoading.Show();

            // Lock polygon drawing until calculation is finished
            _isReadyToDrawNextPolygon = false;

            ColorSumValues colorSumValues = await Task.Run(GetColorSumInPolygon);

            panelRegionAverage.Show();
            pictureBoxLoading.Hide();
            
            // Set intensity value and intesity percentage labels
            float averageBrightness = CalculateAverage(colorSumValues.Brightness, colorSumValues.Counter);

            // If average brightness could not be calculated
            if ((int)averageBrightness == -1)
            {
                Debug.WriteLine("Brigntess = -1");
                _isReadyToDrawNextPolygon = true;
                return;
            }

            labelRegionIntensity.Text = (averageBrightness * 255).ToString("0");
            labelRegionIntensityPercent.Text = (averageBrightness * 100).ToString("0.00") + "%";

            panelBar1.Width = (int)(averageBrightness * panelProgressBar1.Width);

            // Calculate average RGB color TODO: check if there is a better way to calculate RGB color average
            int averageR = (int)CalculateAverage(colorSumValues.R, colorSumValues.Counter);
            int averageG = (int)CalculateAverage(colorSumValues.G, colorSumValues.Counter);
            int averageB = (int)CalculateAverage(colorSumValues.B, colorSumValues.Counter);
        
            // Update Region average color and panel color
            labelRegionColor.Text = $"[{averageR}, {averageG}, {averageB}]";
            panelRegionColor.BackColor = Color.FromArgb(255, averageR, averageG, averageB);

            // Unlock polygon drawing
            _isReadyToDrawNextPolygon = true;
        }

        private ColorSumValues GetColorSumInPolygon()
        {
            ColorSumValues colorSumValues = new ColorSumValues();
            Bitmap bitmap = new Bitmap(_currentImage);

            colorSumValues.Brightness = 0;
            colorSumValues.R = 0;
            colorSumValues.G = 0;
            colorSumValues.B = 0;
            colorSumValues.Counter = 0;

            // For all pixels in width, height
            for (int i = 0; i < pictureBox.Width; i++)
            {
                for (int j = 0; j < pictureBox.Height; j++)
                {
                    // If current pixel is inside our selected polygon, add it to a sum
                    if (IsPointInPolygon(new PointF(i, j), _points.ToArray()))
                    {
                        colorSumValues.Brightness += bitmap.GetPixel(i, j).GetBrightness();
                        colorSumValues.R += bitmap.GetPixel(i, j).R;
                        colorSumValues.G += bitmap.GetPixel(i, j).G;
                        colorSumValues.B += bitmap.GetPixel(i, j).B;
                        colorSumValues.Counter++;
                    }
                }
            }

            return  colorSumValues;
        }
        
        // Just a simple average calculator
        private static float CalculateAverage(float sum, int counter)
        {
            // If counter equals zero, dont calculate and return a negative float number
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

        // Draw a polygon defined by the points that the cursor has passed over
        private void DrawPolygon(PointF[] points)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            
            // Create pen
            Pen pen = new Pen(Color.White, 2);

            // Create solid brush with a color to fill the polygon
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(100, 50, 50, 50));

            // Draw polygon outline
            graphics.DrawPolygon(pen, points);

            // Draw polygon area
            graphics.FillPolygon(blueBrush, points);

            // Show selected region average info panel
            panelRegionAverage.Show();
        }


//============================================ Events =============================================

        private void btnConvertToGray_Click(object sender, EventArgs e)
        {
            if (_currentImage is null)
            {
                return;
            }
                
            // Toggle convertion buttons
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
            if (ShowOpenFileDialog())
            {
                LoadBitmapImage();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentImage is null || !_isReadyToDrawNextPolygon)
                return;

            if (!(Cursor.Current is null)) 
                Cursor = new Cursor(Cursor.Current.Handle);

            // localMousePosition starts counting [0, 0] from the starting point of pictureBox
            var localMousePosition = pictureBox.PointToClient(Cursor.Position);

            UpdatePixelInfoLabels(localMousePosition);

            ShowPixelInfoLabels();

            if (!_arePointsCleared)
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


        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            HidePixelInfoLabels();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentImage is null || !_isReadyToDrawNextPolygon)
            {
                return;
            }
            
            _arePointsCleared = true;

            // Clear point list to create a new polygon
            _points.Clear();

            // Remember the location where the button was pressed
            _latestPoint = e.Location;

            // Invalidate component to force repaint to clear last graphics
            pictureBox.Invalidate();
        }

        private async void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_arePointsCleared)
            {
                return;
            }

            if (_currentImage is null || _points.Count < PolygonDrawPixelThreshold || !_isReadyToDrawNextPolygon)
            {
                panelRegionAverage.Hide();
                return;
            }

            DrawPolygon(_points.ToArray());
            _arePointsCleared = false;

            await FindPixelsInSelectedRegion();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


//========================================== DLL Imports ===========================================

        // Add Drag Operation to titlebar
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
