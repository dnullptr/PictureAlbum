using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureAlbum
{
    public partial class ShowPhoto : Form
    {
        public Image Resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);

            return (Image)bmp;
        }
        public ShowPhoto(Image image)
        {
            InitializeComponent();
            
            if (image.Width > pictureBox1.Width && image.Height > pictureBox1.Height)
            {
                pictureBox1.Image = Resize(image, this.Width, this.Height);
            }
            else pictureBox1.Image = image;


        }
    }
}
