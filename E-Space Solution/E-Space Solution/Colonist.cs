using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace E_Space_Solution
{
    public partial class Colonist : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Colonist()
        {
            InitializeComponent();
            LoadData();  // Load data when form initializes
        }

        // Method to load data from the Jobs table into the ComboBox
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Colonist_Load(object sender, EventArgs e)
        {

        }

        // Method to Load Data into DataGridView
        private void LoadData()
        {
            using (SqlConnection connect = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")));
            {
                connect.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Colonists", connect);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                LoadColonistsToDataGrid.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")));
            {
                try
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    string insertQuery = @"INSERT INTO Colonists (FirstName, MiddleName, Surname, DateOfBirth, Qualification, Age, EarthAddress, Gender, ContactNo, CivilStatus, FamilyMembersGoing, MarsColonizationID) 
               VALUES (@FirstName, @MiddleName, @Surname, @DateOfBirth, @Qualification, @Age, @EarthAddress, @Gender, @ContactNo, @CivilStatus, @FamilyMembersGoing, @MarsColonizationID)";


                    using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                    {
                        //Set parameters from the form fields
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddlename.Text);
                        cmd.Parameters.AddWithValue("@Surname", txtSurename.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", txtDob.Value.Date);
                        cmd.Parameters.AddWithValue("@Qualification", txtQlification.Text);
                        cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                        cmd.Parameters.AddWithValue("@EarthAddress", txtEarthaddress.Text);
                        cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString().Substring(0, 1)); // Assumes 'M' or 'F'
                        cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text);
                        cmd.Parameters.AddWithValue("@CivilStatus", cbCvil.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@FamilyMembersGoing", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@MarsColonizationID", GenerateMarsColonizationID());


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Colonist added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadData(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding Colonist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                    LoadData();//Refresh
                }
            }

        }

        private string GenerateMarsColonizationID()
        {
            return Guid.NewGuid().ToString(); // Using GUID for uniqueness
        }

        // Method to load colonists into DataGridView (if needed)
        private void LoadColonists()
        {
            // Implement DataGridView loading logic
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtColonistID.Text))
            {
                MessageBox.Show("Please enter a valid Colonist ID to update.");
                return;
            }

            using (SqlConnection conn = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))) ;
            {
                try
                {
                    connect.Open();

                    // SQL Update command
                    string sql = @"UPDATE Colonists 
               SET FirstName = @FirstName, MiddleName = @MiddleName, Surname = @Surname, 
                   DateOfBirth = @DOB, Age = @Age, ContactNo = @Contact, EarthAddress = @EarthAddress, 
                   Qualification = @Qualification, Gender = @Gender, CivilStatus = @CivilStatus, 
               WHERE ColonistID = @ColonistID";


                    using (SqlCommand cmd = new SqlCommand(sql, connect))
                    {
                        // Set parameters from the form fields
                        cmd.Parameters.AddWithValue("@ColonistID", int.Parse(txtColonistID.Text));
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddlename.Text);
                        cmd.Parameters.AddWithValue("@Surname", txtSurename.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", txtDob.Value.Date);
                        cmd.Parameters.AddWithValue("@Qualification", txtQlification.Text);
                        cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                        cmd.Parameters.AddWithValue("@EarthAddress", txtEarthaddress.Text);
                        cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString().Substring(0, 1)); // Assumes 'M' or 'F'
                        cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text);
                        cmd.Parameters.AddWithValue("@CivilStatus", cbCvil.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@FamilyMembersGoing", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@MarsColonizationID", GenerateMarsColonizationID());

                        // Execute the update command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Colonist updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No colonist found with the given ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        connect.Close();
                        MessageBox.Show("Connection closed successfully.");
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Check if ColonistID or some other unique identifier is provided
            if (string.IsNullOrWhiteSpace(txtColonistID.Text))
            {
                MessageBox.Show("Please enter a valid Colonist ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the connection
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // SQL select query to search by ColonistID
                string searchQuery = @"SELECT * FROM Colonists WHERE ColonistID = @ColonistID";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    // Add the ColonistID parameter from the textbox
                    cmd.Parameters.AddWithValue("@ColonistID", txtColonistID.Text.Trim());

                    // Execute the query and read the data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // If data exists, fill the form fields
                    if (reader.Read())
                    {
                        txtFirstname.Text = reader["FirstName"].ToString();
                        txtMiddlename.Text = reader["MiddleName"].ToString();
                        txtSurename.Text = reader["Surname"].ToString();
                        txtQlification.Text = reader["Qualification"].ToString();
                        txtAge.Text = reader["Age"].ToString();
                        txtEarthaddress.Text = reader["EarthAddress"].ToString();
                        txtContact.Text = reader["ContactNo"].ToString();
                        txtDob.Text = reader["DateOfBirth"].ToString();
                        cbGender.SelectedItem = reader["Gender"].ToString();
                        cbCvil.SelectedItem = reader["CivilStatus"].ToString(); 
                        numericUpDown1.Value = Convert.ToDecimal(reader["FamilyMembersGoing"]);


                        MessageBox.Show("Colonist found and details populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Colonist found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                connect.Close();
            }

            // To display search results in a DataGridView
            string gridQuery = "SELECT * FROM Colonists WHERE ColonistID = @ColonistID";  // Renamed 'searchQuery' to 'gridQuery'

            using (SqlCommand cmd = new SqlCommand(gridQuery, connect))  // Renamed the command to avoid conflict
            {
                cmd.Parameters.AddWithValue("@ColonistID", txtColonistID.Text.Trim());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Bind the result to the DataGridView
                LoadColonistsToDataGrid.DataSource = table;

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No Colonist found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure the Pilot ID is provided for deletion
            if (string.IsNullOrWhiteSpace(txtColonistID.Text))
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
                string deleteQuery = @"DELETE FROM Colonists WHERE ColonistID = @PilotID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@PilotID", txtColonistID.Text.Trim());

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

        private void LoadColonistsToDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Optional");
        }
        private void cbHouseid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clearing all TextBox controls
            txtColonistID.Clear();
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtSurename.Clear();
            txtQlification.Clear();
            txtAge.Clear();
            txtEarthaddress.Clear();
            txtContact.Clear();

            // Reset ComboBox selections
            cbGender.SelectedIndex = -1;  // Unselect gender combo box
            cbCvil.SelectedIndex = -1;    // Unselect civil status combo box

            // Reset DateTimePicker to default value (current date)
            txtDob.Value = DateTime.Now;

            // Reset NumericUpDown to default value (e.g., 0)
            numericUpDown1.Value = 0;
        }

        private void txtColonistID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
