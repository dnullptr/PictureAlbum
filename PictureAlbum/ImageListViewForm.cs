using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace PictureAlbum
{
    public partial class ImageListViewForm : Form
    {
        ListView listView1 = new ListView();
        List<PicClass> lpic = new List<PicClass>();
        public ImageListViewForm()
        {
            InitializeComponent();
            LoadImagesToView();
            CreateMyListView();
            
        }

        
        private void CreateMyListView()
        {
                
                listView1.Bounds = new Rectangle(new Point(10, 10), new Size(600, 400));

                // Set the view to show details.
                listView1.View = View.Details;
                // Allow the user to edit item text.
                listView1.LabelEdit = true;
                // Allow the user to rearrange columns.
                listView1.AllowColumnReorder = true;
                // Display check boxes.
                listView1.CheckBoxes = true;
                // Select the item and subitems when selection is made.
                listView1.FullRowSelect = true;
                listView1.GridLines = true;
                listView1.Sorting = SortOrder.Ascending;
               
                listView1.Columns.Add("Column 1", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

                listView1.View = View.LargeIcon;

                this.imageList1.ImageSize = new Size(200, 200);
                listView1.LargeImageList = this.imageList1;


                for (int j = 0; j < this.imageList1.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    listView1.Items.Add(item);
                }

                listView1.LargeImageList = imageList1;
                this.Controls.Add(listView1);
            
        }

        void DelFromDB(int index,int id)
        {
            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "DELETE FROM Photos [Pic] WHERE ID=" + id;
        }
        void LoadImagesToView()
        {
            string str = "SELECT * FROM Photos";
            OleDbDataAdapter dr = new
            OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();

            dr.Fill(ds, "Photos");




            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Pic"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["Pic"];
                    imageList1.Images.Add(Image.FromStream(new MemoryStream(imageData)));


                }

            }
        }
       

        private void ImageListViewForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Select_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                itemRow.Checked = true;
            }
        }

        private void Deselect_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                itemRow.Checked = !true;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in listView1.Items)
            {
                if (itemRow.Checked)
                    itemRow.Remove();
            }
        }
    }
}
