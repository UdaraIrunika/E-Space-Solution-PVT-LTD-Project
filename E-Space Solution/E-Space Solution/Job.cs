using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Space_Solution
{
    public partial class Job : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Job()
        {
            InitializeComponent();
            LoadJobsData(); // Load data when the form initializes
        }

        private void LoadJobsData()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectQuery = "SELECT JobID, JobTitle FROM Jobs";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading jobs data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobName.Text))
            {
                MessageBox.Show("Please enter a valid Job Title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string insertQuery = "INSERT INTO Jobs (JobTitle) VALUES (@JobTitle)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", txtJobName.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Job added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadJobsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding job: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadJobsData();// Refresh data 
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobID.Text) || string.IsNullOrWhiteSpace(txtJobName.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string updateQuery = "UPDATE Jobs SET JobTitle = @JobTitle WHERE JobID = @JobID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JobID", Convert.ToInt32(txtJobID.Text.Trim()));
                    cmd.Parameters.AddWithValue("@JobTitle", txtJobName.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Job updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No job found with the provided Job ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadJobsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating job: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                connect.Close();
                LoadJobsData();// Refresh data 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobID.Text))
            {
                MessageBox.Show("Please enter a valid Job ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string searchQuery = "SELECT * FROM Jobs WHERE JobID = @JobID";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JobID", Convert.ToInt32(txtJobID.Text.Trim()));

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtJobName.Text = reader["JobTitle"].ToString();
                        MessageBox.Show("Job details found and populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No job found with the provided Job ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching job: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobID.Text))
            {
                MessageBox.Show("Please enter the Job ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string deleteQuery = "DELETE FROM Jobs WHERE JobID = @JobID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JobID", Convert.ToInt32(txtJobID.Text.Trim()));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Job deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No job found with the provided Job ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadJobsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting job: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadJobsData();// Refresh data 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
