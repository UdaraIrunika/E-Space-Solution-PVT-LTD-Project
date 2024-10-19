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
    public partial class House : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public House()
        {
            InitializeComponent();
            LoadHousesData(); // Load data when the form loads
        }

        // Method to load data into the DataGridView
        private void LoadHousesData()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectQuery = "SELECT HouseID, ColonyLotNumber, NumberOfRooms, SquareFeet, IsAssigned FROM Houses";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading houses data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCln.Text) ||
                nudNumberofrooms.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtSquerefeet.Text))
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

                string insertQuery = @"INSERT INTO Houses (ColonyLotNumber, NumberOfRooms, SquareFeet, IsAssigned) 
                                       VALUES (@ColonyLotNumber, @NumberOfRooms, @SquareFeet, @IsAssigned)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@ColonyLotNumber", txtCln.Text.Trim());
                    cmd.Parameters.AddWithValue("@NumberOfRooms", (int)nudNumberofrooms.Value);
                    cmd.Parameters.AddWithValue("@SquareFeet", Convert.ToDecimal(txtSquerefeet.Text.Trim()));
                    cmd.Parameters.AddWithValue("@IsAssigned", checkBox1.Checked);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("House added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadHousesData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding house: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadHousesData();//Refresh
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCln.Text) ||
                nudNumberofrooms.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtSquerefeet.Text))
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

                string updateQuery = @"UPDATE Houses 
                                       SET NumberOfRooms = @NumberOfRooms, SquareFeet = @SquareFeet, IsAssigned = @IsAssigned 
                                       WHERE ColonyLotNumber = @ColonyLotNumber";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@ColonyLotNumber", txtCln.Text.Trim());
                    cmd.Parameters.AddWithValue("@NumberOfRooms", (int)nudNumberofrooms.Value);
                    cmd.Parameters.AddWithValue("@SquareFeet", Convert.ToDecimal(txtSquerefeet.Text.Trim()));
                    cmd.Parameters.AddWithValue("@IsAssigned", checkBox1.Checked);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("House updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No house found with the provided Colony Lot Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadHousesData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating house: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadHousesData();//Refresh
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCln.Text))
            {
                MessageBox.Show("Please enter a valid Colony Lot Number to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string searchQuery = @"SELECT * FROM Houses WHERE ColonyLotNumber = @ColonyLotNumber";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@ColonyLotNumber", txtCln.Text.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        nudNumberofrooms.Value = Convert.ToInt32(reader["NumberOfRooms"]);
                        txtSquerefeet.Text = reader["SquareFeet"].ToString();
                        checkBox1.Checked = Convert.ToBoolean(reader["IsAssigned"]);
                        MessageBox.Show("House details found and populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No house found with the provided Colony Lot Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching house: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCln.Text))
            {
                MessageBox.Show("Please enter the Colony Lot Number to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string deleteQuery = @"DELETE FROM Houses WHERE ColonyLotNumber = @ColonyLotNumber";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@ColonyLotNumber", txtCln.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("House deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No house found with the provided Colony Lot Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadHousesData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting house: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadHousesData();//Refresh
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
