using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
namespace PictureAlbum
{
    public partial class LoadFromFolder : Form
    {
        DataSet ds;
        MemoryStream ms;
        byte[] photo_array;
        List<Image> li = new List<Image>();
        public LoadFromFolder()
        {
            InitializeComponent();
            LoadFromPC();
        }

        byte[] convPhoto(Image img)
        {
            
                ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                photo_array = new byte[ms.Length]; //init array of bytes
                ms.Position = 0;
                ms.Read(photo_array, 0, photo_array.Length);

            return photo_array;
           
        }
        void LoadFromPC() //from textbox
        {
            DirectoryInfo dir = new DirectoryInfo(@"H:\Pics\");
            if (urlPath.Text.Length > 0)
            dir = new DirectoryInfo(@urlPath.ToString());
            
           
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    this.imageList1.Images.Add(Image.FromFile(file.FullName));
                    li.Add(Image.FromFile(file.FullName));

                }
                catch(Exception e)
                {
                    MessageBox.Show("This is not an image! "+e);
                }
                

               
            }
            listView1.CheckBoxes = true;
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(150, 150);
            this.listView1.LargeImageList = this.imageList1;

            for (int j = 0; j < imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(item);
            }
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LoadFromPC();
            Refresh();
        }

        private void LoadFromFolder_Load(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count>0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                Image img = item.ImageList.Images[item.ImageIndex];
                ShowPhoto f = new ShowPhoto(li[item.ImageIndex]);
                f.Show();
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itemRow in listView1.Items)
            {
                itemRow.Checked = true;
            }
        }

        private void DeselectBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                itemRow.Checked = !true;
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                if(itemRow.Checked)
                    itemRow.Remove();
            }
        }

        void SaveToDB(Image img)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Photos([Pic])" +
            " VALUES(?)";
            cmd.Connection = con;
            con.Open();
            cmd.Parameters.AddWithValue("@Pic", convPhoto(img));

            int result = cmd.ExecuteNonQuery();

            con.Close();
        }
        private void SaveToDB_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                int ImgIndex = itemRow.ImageIndex;
                if (ImgIndex >= 0 && ImgIndex < this.listView1.Items.Count && itemRow.Checked)
                    SaveToDB((Image)itemRow.ImageList.Images[ImgIndex]);
            }
        }
    }
}
