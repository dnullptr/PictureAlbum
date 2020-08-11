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
    public partial class LocationForm : Form
    {
        public string selectedID = "";
        public LocationForm()
        {
            InitializeComponent();
            LoadLocationToGrid();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Location ([LocationTitle]) VALUES(?)";
            cmd.Connection = con;
            con.Open();
            cmd.Parameters.AddWithValue("@LocationTitle", textBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            LoadLocationToGrid();
        }

        public void LoadLocationToGrid()
        {
            string str = "SELECT  * FROM Location";
            OleDbDataAdapter adapter = new OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Location");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Location";

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;


            selectedID = dataGridView1.Rows[selectedIndex].Cells["ID"].Value.ToString();


            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Del")
            {
                cmd.CommandText = "DELETE FROM Location WHERE ID="
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
                textBox1.Text = dataGridView1.Rows[selectedIndex].Cells["LocationTitle"].Value.ToString();
            }
            myCon.Close();
            LoadLocationToGrid();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = @"UPDATE Location  SET LocationTitle = @LocationTitle  WHERE ID="
                                                       + Convert.ToInt32(selectedID) + "";
            cmd.Parameters.AddWithValue("@LocationTitle", textBox1.Text);
            cmd.Connection = myCon;
            myCon.Open();
            int n = cmd.ExecuteNonQuery();
            myCon.Close();
            LoadLocationToGrid();
        }
    }
}
