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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace E_Space_Solution
{
    public partial class Dependents : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Dependents()
        {
            InitializeComponent();
            LoadData();  // Load data when form initializes
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Method to Load Data into DataGridView
        private void LoadData()
        {
            using (SqlConnection connect = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))) ;
            {
                connect.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Dependents", connect);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate required fields before adding
            if (string.IsNullOrWhiteSpace(txtDependentID.Text) || string.IsNullOrWhiteSpace(txtDeFirstname.Text) || string.IsNullOrWhiteSpace(txtColonistID.Text))
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

                // SQL insert query without @Contact
                string insertQuery = @"INSERT INTO Dependents (DependentName, DateOfBirth, Age, RelationshipToColonist, Gender, ColonistID)
                               VALUES (@DependentName, @DOB, @Age, @Relationship, @Gender, @ColonistID)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    // Adding values from TextBoxes and other controls
                    cmd.Parameters.AddWithValue("@DependentName", txtDeFirstname.Text); // Use DependentName instead of FirstName
                    cmd.Parameters.AddWithValue("@DOB", dtpDob.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Age", nudAge.Value);
                    cmd.Parameters.AddWithValue("@Relationship", txtRelationsip.Text);
                    cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ColonistID", txtColonistID.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dependent added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding dependent: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure the dependent ID is provided
            if (string.IsNullOrWhiteSpace(txtDependentID.Text))
            {
                MessageBox.Show("Please enter the Dependent ID to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // SQL update query without @Contact
                string updateQuery = @"UPDATE Dependents 
                               SET DependentName = @DependentName, DateOfBirth = @DOB, 
                                   Age = @Age, RelationshipToColonist = @Relationship, 
                                   Gender = @Gender, ColonistID = @ColonistID
                               WHERE DependentID = @DependentID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@DependentID", txtDependentID.Text);
                    cmd.Parameters.AddWithValue("@DependentName", txtDeFirstname.Text); // Use DependentName instead of FirstName
                    cmd.Parameters.AddWithValue("@DOB", dtpDob.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Age", nudAge.Value);
                    cmd.Parameters.AddWithValue("@Relationship", txtRelationsip.Text);
                    cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ColonistID", txtColonistID.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dependent updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dependent ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating dependent: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data

            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        // Ensure the dependent ID is provided for search
        if (string.IsNullOrWhiteSpace(txtDependentID.Text))
        {
            MessageBox.Show("Please enter a valid Dependent ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }

            // SQL search query without the Contact field
            string searchQuery = @"SELECT DependentID, DependentName, DateOfBirth, Age, RelationshipToColonist, Gender, ColonistID 
                           FROM Dependents WHERE DependentID = @DependentID";

            using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
            {
                cmd.Parameters.AddWithValue("@DependentID", txtDependentID.Text.Trim());

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Populate fields from the database
                    txtDeFirstname.Text = reader["DependentName"].ToString(); // Use DependentName instead of FirstName
                    txtDeMiddlename.Text = reader["MiddleName"]?.ToString(); // Assuming you have a field for middle name
                    dtpDob.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                    nudAge.Value = Convert.ToDecimal(reader["Age"]);
                    txtRelationsip.Text = reader["RelationshipToColonist"].ToString(); // Updated to match the schema
                    cbGender.SelectedItem = reader["Gender"].ToString();
                    txtColonistID.Text = reader["ColonistID"].ToString();

                    MessageBox.Show("Dependent details found and populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Dependent found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error while searching dependent: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            connect.Close();
        }
    }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure the dependent ID is provided for deletion
            if (string.IsNullOrWhiteSpace(txtDependentID.Text))
            {
                MessageBox.Show("Please enter the Dependent ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // SQL delete query
                string deleteQuery = @"DELETE FROM Dependents WHERE DependentID = @DependentID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@DependentID", txtDependentID.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dependent deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dependent ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting dependent: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtColonistID_TextChanged(object sender, EventArgs e)
        {
            
            // SQL query to select the data you want in the ComboBox
            string query = "SELECT ColonistID FROM Colonists"; // Replace with your actual table and column names

            // Create a connection
            using (SqlConnection connect = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))) ;
            {
                try
                {
                    // Open the connection
                    connect.Open();

                    // Create a command
                    SqlCommand cmd = new SqlCommand(query, connect);

                    // Execute the query and get the data reader
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear any existing items in ComboBox
                    txtColonistID.Items.Clear();

                    // Loop through the result set and add items to the ComboBox
                    while (reader.Read())
                    {
                        txtColonistID.Items.Add(reader["ColumnName"].ToString()); // Replace ColumnName with the actual column
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

        private void txtColonistID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            txtDependentID.Text = string.Empty;
            txtDeFirstname.Text = string.Empty;
            txtDeMiddlename.Text = string.Empty;
            txtRelationsip.Text = string.Empty;

            // Reset the combo boxes
            cbGender.SelectedIndex = -1; // Deselect any selected item
            txtColonistID.SelectedIndex = -1;

            // Reset the numeric up-down control
            nudAge.Value = nudAge.Minimum; // Set to minimum value

            // Reset the DateTimePicker
            dtpDob.Value = DateTime.Today; // Set to today's date

            // If you want to clear DataGridView selection (optional)
            dataGridView1.ClearSelection();

            // Reset any other controls as needed
        }
    }
}
