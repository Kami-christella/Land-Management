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
    public partial class PlotMGMT : Form
    {
        public PlotMGMT()
        {
            InitializeComponent();
        }

        private void savePlots_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=Thierry-TSR\\SQLEXPRESS;Initial Catalog=LAND_MGT;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open(); // open connection
                    SqlCommand cmd = new SqlCommand("INSERT INTO Subdivision VALUES(@v_plotNo, @v_landUpi, @v_size)", conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@v_plotNo", plotNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@v_landUpi", landUPI.Text.Trim());
                    cmd.Parameters.AddWithValue("@v_size", sizeBox.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Plot saved");
                    }
                    else
                    {
                        MessageBox.Show("Plot not saved");
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
            ExpenseMGMT expense = new ExpenseMGMT();
            expense.Show();
            this.Hide();
        }
    }
}
