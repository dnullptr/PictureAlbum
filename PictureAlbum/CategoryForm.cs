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

namespace PictureAlbum
{
    public partial class CategoryForm : Form
    {
        public string selectedID = "";
        public CategoryForm()
        {
            InitializeComponent();
            LoadCategoryToGrid();
        }

    public void LoadCategoryToGrid()
        {
            string str = "SELECT  * FROM Category";
            OleDbDataAdapter adapter = new OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Category");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Category";
            
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Category ([CatTitle]) VALUES(?)";
            cmd.Connection = con;
            con.Open();
            cmd.Parameters.AddWithValue("@CatTitle", textBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            LoadCategoryToGrid();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;


            selectedID = dataGridView1.Rows[selectedIndex].Cells["ID"].Value.ToString();


            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            if (dataGridView1.Columns[e.ColumnIndex].Name== "Del")
            {
                cmd.CommandText = "DELETE FROM Category WHERE ID="
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
                textBox1.Text = dataGridView1.Rows[selectedIndex].Cells["CatTitle"].Value.ToString();
            }
            myCon.Close();
            LoadCategoryToGrid();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = @"UPDATE Category  SET CatTitle = @CatTitle  WHERE ID="
                                                       + Convert.ToInt32(selectedID) + "";
            cmd.Parameters.AddWithValue("@CatTitle", textBox1.Text);
            cmd.Connection = myCon;
            myCon.Open();
            int n = cmd.ExecuteNonQuery();
            myCon.Close();
            LoadCategoryToGrid();


        }
    }
}
