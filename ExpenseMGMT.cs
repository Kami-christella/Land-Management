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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace MGMT_LAND
{
    public partial class ExpenseMGMT : Form
    {
        public ExpenseMGMT()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveExpenseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=Thierry-TSR\\SQLEXPRESS;Initial Catalog=LAND_MGT;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open(); // open connection
                    SqlCommand cmd = new SqlCommand("INSERT INTO Expenses VALUES(@v_title, @v_landUpi)", conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@v_title", titleBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@v_landUpi", landUPIBOX.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Expense saved");
                    }
                    else
                    {
                        MessageBox.Show("Expense not saved");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void  DisplayExpense()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=Thierry-TSR\\SQLEXPRESS;Initial Catalog=LAND_MGT;Integrated Security=True;TrustServerCertificate=True"))
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT UPI, [Location], title FROM Expenses JOIN Land ON Expenses.LandUPI = land.UPI", conn);
                conn.Open();
                DataSet ds = new DataSet();
                sda.Fill(ds, "Expense");
                dataGridView1.DataSource = ds.Tables["Expense"];

            }
        }

        private void ExpenseMGMT_Load(object sender, EventArgs e)
        {
            DisplayExpense();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
