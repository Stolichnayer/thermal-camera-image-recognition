using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThemalCameraImageRecognition
{
    public partial class mainForm : Form
    {
        private Bitmap _currentImage;
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            CreateAndOpenFileDialog();
            CreateAndShowBitmapImage();
        }

        private void CreateAndShowBitmapImage()
        {
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
                btnProcess.Enabled = true;
            }  
        }
        
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentImage == null)
                return;

            if (!(Cursor.Current is null)) 
                Cursor = new Cursor(Cursor.Current.Handle);

            var localMousePosition = pictureBox.PointToClient(Cursor.Position);

            labelPixels.Text = $"[{localMousePosition.X}, {localMousePosition.Y}]";

            if (localMousePosition.X < 0 || localMousePosition.Y < 0)
                return;

            var pixelColor = _currentImage.GetPixel(localMousePosition.X, localMousePosition.Y);
            labelColor.Text = $"[{pixelColor.R}, {pixelColor.G}, {pixelColor.B}]";
            panelColor.BackColor = pixelColor;

            panelColor.Show();
            labelColor.Show();
            labelPixels.Show();
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            panelColor.Hide();
            labelColor.Hide();
            labelPixels.Hide();
        }

        private void btnConvertToGray_Click(object sender, EventArgs e)
        {
            if(_currentImage == null)
                return;
            _currentImage = ConvertBlackAndWhite(_currentImage);
            pictureBox.Image = _currentImage;
        }

        private Bitmap ConvertBlackAndWhite(Bitmap Image)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(_currentImage);

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
            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(_currentImage, new Rectangle(0, 0, _currentImage.Width, _currentImage.Height),
                0, 0, _currentImage.Width, _currentImage.Height, GraphicsUnit.Pixel, attributes);
            //dispose the Graphics object
            g.Dispose();

            return newBitmap;
        }
    }
}
