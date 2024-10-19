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
    public partial class Assignpilot : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Assignpilot()
        {
            InitializeComponent();
            LoadAssignmentsData(); // Load data when the UserControl is initialized
        }

        private void LoadAssignmentsData()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string selectQuery = "SELECT AssignmentID, PilotID, JetID, AssignmentDate FROM PilotAssignments";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading assignments data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please fill all required fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string insertQuery = @"INSERT INTO PilotAssignments (PilotID, JetID, AssignmentDate) 
                                   VALUES (@PilotID, @JetID, @AssignmentDate)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@PilotID", txtColonistID.Text);
                    cmd.Parameters.AddWithValue("@JetID", txtJobId.Text);
                    cmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Now.Date); // You can change this to a specific date if needed

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pilot assignment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadAssignmentsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding assignment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColonistID.Text) || string.IsNullOrWhiteSpace(txtJobId.Text))
            {
                MessageBox.Show("Please fill all required fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an assignment to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int assignmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AssignmentID"].Value);

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string updateQuery = @"UPDATE PilotAssignments 
                                   SET PilotID = @PilotID, JetID = @JetID, AssignmentDate = @AssignmentDate 
                                   WHERE AssignmentID = @AssignmentID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);
                    cmd.Parameters.AddWithValue("@PilotID", txtColonistID.Text);
                    cmd.Parameters.AddWithValue("@JetID", txtJobId.Text);
                    cmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Now.Date); // You can change this to a specific date if needed

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pilot assignment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadAssignmentsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating assignment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string pilotId = txtColonistID.Text.Trim();
            string jetId = txtJobId.Text.Trim();

            // Load data based on the search criteria
            LoadAssignmentsData(pilotId, jetId);
        }

        private void LoadAssignmentsData(string pilotId = null, string jetId = null)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // Base SQL query
                string selectQuery = "SELECT AssignmentID, PilotID, JetID, AssignmentDate FROM PilotAssignments";

                // Add conditions based on user input
                bool hasCondition = false; // Flag to track if any condition has been added
                if (!string.IsNullOrWhiteSpace(pilotId) || !string.IsNullOrWhiteSpace(jetId))
                {
                    selectQuery += " WHERE 1=1"; // Start with a true condition for easier appending
                    if (!string.IsNullOrWhiteSpace(pilotId))
                    {
                        selectQuery += " AND PilotID = @PilotID";
                        hasCondition = true;
                    }
                    if (!string.IsNullOrWhiteSpace(jetId))
                    {
                        selectQuery += " AND JetID = @JetID";
                        hasCondition = true;
                    }
                }

                using (SqlCommand cmd = new SqlCommand(selectQuery, connect))
                {
                    // Add parameters if applicable
                    if (!string.IsNullOrWhiteSpace(pilotId))
                    {
                        cmd.Parameters.AddWithValue("@PilotID", pilotId);
                    }
                    if (!string.IsNullOrWhiteSpace(jetId))
                    {
                        cmd.Parameters.AddWithValue("@JetID", jetId);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No assignments found for the provided criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading assignments data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an assignment to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int assignmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AssignmentID"].Value);

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string deleteQuery = @"DELETE FROM PilotAssignments WHERE AssignmentID = @AssignmentID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pilot assignment deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Assignment ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadAssignmentsData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting assignment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
