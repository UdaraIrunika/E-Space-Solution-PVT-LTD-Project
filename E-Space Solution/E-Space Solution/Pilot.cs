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
    public partial class Pilot : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Pilot()
        {
            InitializeComponent();
            LoadData();  // Load data when form initializes
        }

        private void LoadData()
        {
            using (SqlConnection connect = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))) ;
            {
                connect.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Pilots", connect);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtDeFirstname.Text) || string.IsNullOrWhiteSpace(txtDeMiddlename.Text) ||
                string.IsNullOrWhiteSpace(txtRank.Text) || string.IsNullOrWhiteSpace(cbSpacehoures.Text))
            {
                MessageBox.Show("Please fill all required fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate if SpaceHours is a valid integer
            if (!int.TryParse(cbSpacehoures.Text, out int spaceHours))
            {
                MessageBox.Show("Please enter a valid number for Space Hours", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // SQL insert query without PilotID (let the database auto-generate the ID)
                string insertQuery = @"INSERT INTO Pilots (FirstName, LastName, SpaceHours, Qualifications, Rank)
                           VALUES (@FirstName, @LastName, @SpaceHours, @Qualifications, @Rank)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtDeFirstname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtDeMiddlename.Text);
                    cmd.Parameters.AddWithValue("@SpaceHours", spaceHours);  // Now it's an integer
                    cmd.Parameters.AddWithValue("@Qualifications", txtQlification.Text);
                    cmd.Parameters.AddWithValue("@Rank", txtRank.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pilot added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding pilot: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure the Pilot ID is provided
            if (string.IsNullOrWhiteSpace(txtDependentID.Text))
            {
                MessageBox.Show("Please enter the Pilot ID to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // SQL update query
                string updateQuery = @"UPDATE Pilots 
                               SET FirstName = @FirstName, LastName = @LastName, SpaceHours = @SpaceHours, 
                                   Qualifications = @Qualifications, Rank = @Rank
                               WHERE PilotID = @PilotID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@PilotID", txtDependentID.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtDeFirstname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtDeMiddlename.Text);
                    cmd.Parameters.AddWithValue("@SpaceHours", Convert.ToInt32(cbSpacehoures.Text));
                    cmd.Parameters.AddWithValue("@Qualifications", txtQlification.Text);
                    cmd.Parameters.AddWithValue("@Rank", txtRank.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pilot updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Pilot ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating pilot: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Ensure the Pilot ID is provided for search
            if (string.IsNullOrWhiteSpace(txtDependentID.Text))
            {
                MessageBox.Show("Please enter a valid Pilot ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // SQL search query
                string searchQuery = @"SELECT * FROM Pilots WHERE PilotID = @PilotID";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@PilotID", txtDependentID.Text.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDeFirstname.Text = reader["FirstName"].ToString();
                        txtDeMiddlename.Text = reader["LastName"].ToString();
                        cbSpacehoures.Text = reader["SpaceHours"].ToString();
                        txtQlification.Text = reader["Qualifications"].ToString();
                        txtRank.Text = reader["Rank"].ToString();

                        MessageBox.Show("Pilot details found and populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Pilot found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching pilot: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure the Pilot ID is provided for deletion
            if (string.IsNullOrWhiteSpace(txtDependentID.Text))
            {
                MessageBox.Show("Please enter a valid Pilot ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // SQL delete query
                string deleteQuery = @"DELETE FROM Pilots WHERE PilotID = @PilotID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@PilotID", txtDependentID.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pilot deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Pilot ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting pilot: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Clear TextBoxes
            txtDeMiddlename.Clear();
            txtDeFirstname.Clear();
            txtDependentID.Clear();
            txtRank.Clear();
            txtQlification.Clear();

            // Reset DateTimePicker to the current date
            dateTimePicker1.Value = DateTime.Now;

            // Reset NumericUpDown (cbSpacehoures)
            cbSpacehoures.Value = cbSpacehoures.Minimum; // Set to the minimum value defined for the NumericUpDown

            // Optionally clear any selection in the DataGridView
            dataGridView1.ClearSelection();

            // Optionally reset labels or other UI elements if needed
           
           
            
        }
    }
}
