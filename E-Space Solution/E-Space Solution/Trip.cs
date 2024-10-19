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
    public partial class Trip : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Trip()
        {
            InitializeComponent();
            LoadTripsData(); // Load JetCodes into the ComboBox when the form loads
        }

        private void LoadTripsData()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectQuery = "SELECT TripID, JetCode, LaunchDate, ReturnDate FROM Trips";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading trips data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbJetCode.Text) ||
                dtpLunch.Value == null ||
                dtpReturn.Value == null)
            {
                MessageBox.Show("Please fill all required fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string insertQuery = @"INSERT INTO Trips (JetCode, LaunchDate, ReturnDate) 
                                       VALUES (@JetCode, @LaunchDate, @ReturnDate)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JetCode", cbJetCode.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LaunchDate", dtpLunch.Value);
                    cmd.Parameters.AddWithValue("@ReturnDate", dtpReturn.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Trip added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadTripsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding trip: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadTripsData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure TripId is provided
            if (string.IsNullOrWhiteSpace(txtTripId.Text) ||
                string.IsNullOrWhiteSpace(cbJetCode.Text))
            {
                MessageBox.Show("Please enter the Trip ID and Jet Code to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string updateQuery = @"UPDATE Trips 
                                       SET JetCode = @JetCode, LaunchDate = @LaunchDate, ReturnDate = @ReturnDate 
                                       WHERE TripID = @TripID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@TripID", Convert.ToInt32(txtTripId.Text.Trim()));
                    cmd.Parameters.AddWithValue("@JetCode", cbJetCode.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LaunchDate", dtpLunch.Value);
                    cmd.Parameters.AddWithValue("@ReturnDate", dtpReturn.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Trip updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Trip not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadTripsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating trip: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadTripsData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTripId.Text))
            {
                MessageBox.Show("Please enter a valid Trip ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string searchQuery = @"SELECT * FROM Trips WHERE TripID = @TripID";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@TripID", Convert.ToInt32(txtTripId.Text.Trim()));

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        cbJetCode.SelectedItem = reader["JetCode"].ToString();
                        dtpLunch.Value = Convert.ToDateTime(reader["LaunchDate"]);
                        dtpReturn.Value = Convert.ToDateTime(reader["ReturnDate"]);
                        MessageBox.Show("Trip details found and populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No trip found with the provided Trip ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching trip: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTripId.Text))
            {
                MessageBox.Show("Please enter the Trip ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string deleteQuery = @"DELETE FROM Trips WHERE TripID = @TripID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@TripID", Convert.ToInt32(txtTripId.Text.Trim()));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Trip deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Trip not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadTripsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting trip: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadTripsData();
            }
        }

        private void ManageTrips_Load(object sender, EventArgs e)
        {
            LoadTripsData(); // Load data when the form loads
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
