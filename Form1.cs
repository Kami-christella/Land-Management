using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGMT_LAND
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=Thierry-TSR\\SQLEXPRESS;Initial Catalog=LAND_MGT;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open(); // open connection
                    SqlCommand cmd = new SqlCommand("INSERT INTO LAND VALUES(@v_landUpi, @v_location, @v_size, @v_price, @v_desc)", conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@v_landUpi", upiBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@v_location", locationBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@v_size", sizeBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@v_price", priceBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@v_desc", descriptionBox.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Land saved");
                    } else
                    {
                        MessageBox.Show("Land not saved");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PlotMGMT plot = new PlotMGMT();
            plot.Show();
            this.Hide();
        }
    }
}
