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
    public partial class Assingjob : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Assingjob()
        {
            InitializeComponent();
            LoadData(); // Load data when the form initializes
        }

        private void LoadData()
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ColonistJobs", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColonistID.Text) || string.IsNullOrWhiteSpace(txtJobId.Text))
            {
                MessageBox.Show("Error: Please enter both Colonist ID and Job ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ColonistJobs (ColonistID, JobID) VALUES (@ColonistID, @JobID)", connect);
                cmd.Parameters.AddWithValue("@ColonistID", int.Parse(txtColonistID.Text));
                cmd.Parameters.AddWithValue("@JobID", int.Parse(txtJobId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success: Job assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data after adding
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColonistID.Text) || string.IsNullOrWhiteSpace(txtJobId.Text))
            {
                MessageBox.Show("Error: Please enter both Colonist ID and Job ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("UPDATE ColonistJobs SET JobID = @JobID WHERE ColonistID = @ColonistID", connect);
                cmd.Parameters.AddWithValue("@ColonistID", int.Parse(txtColonistID.Text));
                cmd.Parameters.AddWithValue("@JobID", int.Parse(txtJobId.Text));
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Success: Job updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error: No record found to update with the given Colonist ID.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data after updating
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColonistID.Text))
            {
                MessageBox.Show("Error: Please enter a Colonist ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ColonistJobs WHERE ColonistID = @ColonistID", connect);
                cmd.Parameters.AddWithValue("@ColonistID", int.Parse(txtColonistID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Error: No records found for the given Colonist ID.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Success: Records found!", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColonistID.Text) || string.IsNullOrWhiteSpace(txtJobId.Text))
            {
                MessageBox.Show("Error: Please enter both Colonist ID and Job ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ColonistJobs WHERE ColonistID = @ColonistID AND JobID = @JobID", connect);
                cmd.Parameters.AddWithValue("@ColonistID", int.Parse(txtColonistID.Text));
                cmd.Parameters.AddWithValue("@JobID", int.Parse(txtJobId.Text));
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Success: Job deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error: No record found to delete with the given Colonist ID and Job ID.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data after deleting
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            // Reset ComboBox selections
            txtJobId.SelectedIndex = -1;  // Unselect gender combo box
            txtColonistID.SelectedIndex = -1;    // Unselect civil status combo box
        }

        private void txtJobId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Connection string to the SQL Server
            string connectionString = @"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // SQL query to get the data from the database table
            string query = "SELECT JobTitle FROM Jobs"; // Replace ColumnName and TableName with actual names

            // Create a connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Execute the command and get a data reader
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear any existing items in the ComboBox
                    txtJobId.Items.Clear();

                    // Loop through the data and add items to the ComboBox
                    while (reader.Read())
                    {
                        txtJobId.Items.Add(reader["ColumnName"].ToString());  // Replace ColumnName with the actual column name
                    }

                    // Close the reader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
