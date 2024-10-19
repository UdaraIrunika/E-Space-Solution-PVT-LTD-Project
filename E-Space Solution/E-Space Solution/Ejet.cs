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
    public partial class Ejet : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Ejet()
        {
            InitializeComponent();
            LoadData();  // Load data when form initializes
        }

        private void LoadData()
        {
            using (SqlConnection connect = new SqlConnection((@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))) ;
            {
                connect.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM EJets", connect);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // Method to load data into the DataGridView
        private void LoadJetsData()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectQuery = "SELECT JetID, JetCode, PassengerSeats, NuclearEnginePower, MadeYear, Weight, PowerSource, JetType FROM EJets";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading jets data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJetCode.Text) ||
                string.IsNullOrWhiteSpace(nudNumberOfpas.Value.ToString()) ||
                string.IsNullOrWhiteSpace(txtNucEP.Text) ||
                string.IsNullOrWhiteSpace(txtWeight.Text) ||
                string.IsNullOrWhiteSpace(cbPs.Text))
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

                string insertQuery = @"INSERT INTO EJets (JetCode, PassengerSeats, NuclearEnginePower, MadeYear, Weight, PowerSource, JetType) 
                                       VALUES (@JetCode, @PassengerSeats, @NuclearEnginePower, @MadeYear, @Weight, @PowerSource, @JetType)"
                ;

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JetCode", txtJetCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@PassengerSeats", nudNumberOfpas.Value);
                    cmd.Parameters.AddWithValue("@NuclearEnginePower", Convert.ToDecimal(txtNucEP.Text));
                    cmd.Parameters.AddWithValue("@MadeYear", dtpMy.Value.Year);
                    cmd.Parameters.AddWithValue("@Weight", Convert.ToDecimal(txtWeight.Text));
                    cmd.Parameters.AddWithValue("@PowerSource", cbPs.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@JetType", "Nuclear"); // Adjust based on your requirements

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jet added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadJetsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding jet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data after deleting
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure JetCode is provided
            if (string.IsNullOrWhiteSpace(txtJetCode.Text))
            {
                MessageBox.Show("Please enter the Jet Code to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string updateQuery = @"UPDATE EJets 
                                       SET PassengerSeats = @PassengerSeats, NuclearEnginePower = @NuclearEnginePower, 
                                           MadeYear = @MadeYear, Weight = @Weight, PowerSource = @PowerSource, JetType = @JetType 
                                       WHERE JetCode = @JetCode";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JetCode", txtJetCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@PassengerSeats", nudNumberOfpas.Value);
                    cmd.Parameters.AddWithValue("@NuclearEnginePower", Convert.ToDecimal(txtNucEP.Text));
                    cmd.Parameters.AddWithValue("@MadeYear", dtpMy.Value.Year);
                    cmd.Parameters.AddWithValue("@Weight", Convert.ToDecimal(txtWeight.Text));
                    cmd.Parameters.AddWithValue("@PowerSource", cbPs.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@JetType", "Nuclear"); 

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Jet updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Jet not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadJetsData(); // Refresh the DataGridView

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating jet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJetCode.Text))
            {
                MessageBox.Show("Please enter a valid Jet Code to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string searchQuery = @"SELECT * FROM EJets WHERE JetCode = @JetCode";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JetCode", txtJetCode.Text.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        nudNumberOfpas.Value = Convert.ToDecimal(reader["PassengerSeats"]);
                        txtNucEP.Text = reader["NuclearEnginePower"].ToString();
                        dtpMy.Value = new DateTime(Convert.ToInt32(reader["MadeYear"]), 1, 1); // Assuming MadeYear is the year only
                        txtWeight.Text = reader["Weight"].ToString();
                        cbPs.SelectedItem = reader["PowerSource"].ToString();
                        // Set JetType if needed
                        MessageBox.Show("Jet details found and populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No jet found with the provided Jet Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching jet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }



            if (string.IsNullOrWhiteSpace(txtJetCode.Text))
            {
                MessageBox.Show("Please enter a valid Jet ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string searchQuery = @"SELECT * FROM EJets WHERE JetID = @JetID";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JetID", txtJetCode.Text.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtJetCode.Text = reader["JetCode"].ToString();
                        nudNumberOfpas.Value = Convert.ToDecimal(reader["PassengerSeats"]);
                        txtNucEP.Text = reader["NuclearEnginePower"].ToString();
                        dtpMy.Value = new DateTime(Convert.ToInt32(reader["MadeYear"]), 1, 1); // Assuming MadeYear is the year only
                        txtWeight.Text = reader["Weight"].ToString();
                        cbPs.SelectedItem = reader["PowerSource"].ToString();
                        // Set JetType if needed
                        MessageBox.Show("Jet details found and populated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No jet found with the provided Jet Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching jet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJetCode.Text))
            {
                MessageBox.Show("Please enter the Jet Code to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string deleteQuery = @"DELETE FROM EJets WHERE JetCode = @JetCode";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@JetCode", txtJetCode.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Jet deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Jet not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadJetsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting jet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
                LoadData();  // Refresh data after deleting
            }
        }

        private void ManageEJets_Load(object sender, EventArgs e)
        {
            LoadJetsData(); // Load data when the form loads
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cbPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPs.Items.Clear();
            cbPs.Items.Add("Nuclear");
            cbPs.Items.Add("Hydro-Nuc");
            cbPs.Items.Add("Optional");
            cbPs.SelectedIndex = 0; // Optional: Set default selection
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear TextBoxes
            txtJetID.Clear();
            txtJetCode.Clear();
            txtNucEP.Clear();
            txtWeight.Clear();

            // Reset ComboBox
            cbPs.SelectedIndex = -1;  // This will deselect any selected item in the ComboBox

            // Reset DateTimePicker to current date
            dtpMy.Value = DateTime.Now;

            // Reset NumericUpDown
            nudNumberOfpas.Value = nudNumberOfpas.Minimum;  // Sets the value to the minimum value defined

            // Optionally clear DataGridView selection (if needed)
            dataGridView1.ClearSelection();

            // Optionally reset Labels or other UI elements
            label1.Text = "";  // Clear any labels if needed
        }
    }
}
