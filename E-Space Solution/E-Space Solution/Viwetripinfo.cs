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

namespace E_Space_Solution
{
    public partial class Viwetripinfo : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Viwetripinfo()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connect = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))) ;
            {
                connect.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Trips", connect);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // Method to Load Data into DataGridView

        private void btnVti_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Optionally, confirm with the user before logging out
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear any user session data here (if applicable)
                // For example: UserSession.CurrentUser = null; 

                // Optionally, close the current form
                this.Hide(); // Hides the current form

                // Show the login form (assuming you have a LoginForm)
                Login loginForm = new Login();
                loginForm.Show();
            }
        }
    }
}
