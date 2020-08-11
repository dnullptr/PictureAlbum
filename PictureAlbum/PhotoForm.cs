using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace PictureAlbum
{
    public partial class PhotoForm : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adapter;
        DataSet ds;
        MemoryStream ms;
        byte[] photo_array;
        Image SourceImage;
        int selectedIndex=0;
        string selectedID;
        int idFromCell;
        string selIdFromCell;
        public PhotoForm()
        {
            InitializeComponent();
        }
        public Image Resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);

            return (Image)bmp;
        }
        
        void LoadGrid()
        {
            string str = "SELECT * FROM Photos";
            OleDbDataAdapter dr = new OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();
            dr.Fill(ds, "Photos");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Photos";
            dataGridView1.Columns[4].Width = 200;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                
                if(dataGridView1.Rows[i].Cells[6].Value.ToString()=="System.Byte[]") //if this cell value is byte arr , enlarge it
                    dataGridView1.Rows[i].Height = 200;}
        }
        void LoadCategory()
        {
            string str = "SELECT  * FROM Category";
            adapter = new OleDbDataAdapter(str, con);
            ds = new DataSet();
            adapter.Fill(ds, "Category");
            categoryCmb.DataSource = ds.Tables["Category"];
            categoryCmb.DisplayMember = "CatTitle";
            categoryCmb.ValueMember = "ID";
        }

        void LoadLocation()
        {
            string str = "SELECT  * FROM Location";
            adapter = new OleDbDataAdapter(str, con);
            ds = new DataSet();
            adapter.Fill(ds, "Location");
            locationCmb.DataSource = ds.Tables["Location"];
            locationCmb.DisplayMember = "LocationTitle";
            locationCmb.ValueMember = "ID";
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(dlg.FileName);
                SourceImage = img;
                img = Resize(img, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = img;// Image.FromFile(openFileDialog1.FileName);
            }
        }

        byte[] convPhoto()
        {
            if(pictureBox1.Image != null && SourceImage != null)
            {
                ms = new MemoryStream();
                SourceImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                photo_array = new byte[ms.Length]; //init array of bytes
                ms.Position = 0;
                ms.Read(photo_array, 0, photo_array.Length);
            }
            return photo_array;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Photos([Title],[CatId],[LocID],[Pic])" +
            " VALUES(?,?,?,?)";
            cmd.Connection = con;
            con.Open();
            cmd.Parameters.AddWithValue("@Title", descText.Text);
            cmd.Parameters.AddWithValue("@CatId", categoryCmb.SelectedIndex);
            cmd.Parameters.AddWithValue("@LocID", locationCmb.SelectedIndex);
            cmd.Parameters.AddWithValue("@Pic", convPhoto());

            int result=cmd.ExecuteNonQuery();

            con.Close();

            if (result > 0)
                MessageBox.Show("Inserted Successfully!");
            else MessageBox.Show("Insert Failed!");
            LoadCategory();
            LoadLocation();
            LoadGrid();


        }

        private void PhotoForm_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(Properties.Settings.Default.Con); //init from VS settings
            LoadCategory();
            LoadLocation();
            LoadGrid();
        }

        public void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            string selectedID = dataGridView1.Rows[selectedIndex].Cells["ID"].Value.ToString();
            //MessageBox.Show(selectedID);

            selIdFromCell= dataGridView1.Rows[selectedIndex].Cells["ID"].Value.ToString();

            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Del")
            {
                cmd.CommandText = "DELETE FROM Photos WHERE ID="
                                                             + Convert.ToInt32(selectedID) + "";
                cmd.Connection = myCon;
                myCon.Open();
                int n = cmd.ExecuteNonQuery();
                myCon.Close();
                if (n > 0)
                {
                    MessageBox.Show("record in row :" + selectedIndex.ToString() + " is Deleted");

                }
                else
                    MessageBox.Show("DELETE failed");

            }


            if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
            {
                selectedID = dataGridView1.Rows[e.ColumnIndex].Cells["ID"].Value.ToString();
                descText.Text = dataGridView1.Rows[selectedIndex].Cells["Title"].Value.ToString();
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name=="Pic")
            {
                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value); //must use casting to field type.
                //pictureBox2.Image = Resize(SourceImage, pictureBox2.Width, pictureBox2.Height);
                ShowPhoto f = new ShowPhoto(Image.FromStream(ms));
                f.Show();
            }
            myCon.Close();
            LoadGrid();
        }

        public void Updatebtn_Click(object sender, EventArgs e)
        {
            
            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = @"UPDATE Photos SET Title = @Title  WHERE ID="
                                                       + Convert.ToInt32(selIdFromCell) + "";
            MessageBox.Show(selIdFromCell);
            cmd.Parameters.AddWithValue("@Title", descText.Text);
            cmd.Connection = myCon;
            myCon.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
                MessageBox.Show("Updated " + n + " Rows!");
            else MessageBox.Show(" Failed! No Changes Made.");
            myCon.Close();
            LoadGrid();
        }
    }
    }

