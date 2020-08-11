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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PhotoForm photo = new PhotoForm();
            photo.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            LocationForm location = new LocationForm();
            location.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ImageListViewForm ilv = new ImageListViewForm();
            ilv.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            LoadFromFolder lff = new LoadFromFolder();
            lff.Show();
        }
    }
}
