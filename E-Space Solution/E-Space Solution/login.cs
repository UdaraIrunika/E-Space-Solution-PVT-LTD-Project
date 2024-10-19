using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;

namespace E_Space_Solution
{
    public partial class Login : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoginregister_Click(object sender, EventArgs e)
        {
            Register sForm = new Register();
            sForm.Show();
            this.Hide();
        }

        private void Login_show_CheckedChanged(object sender, EventArgs e)
        {
            if (Login_show.Checked)
            {
                txtLogPassword.PasswordChar = '\0';
            }
            else
            {
                txtLogPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogusername.Text) ||
            string.IsNullOrEmpty(txtLogPassword.Text) ||
            cbRole.SelectedItem == null || string.IsNullOrEmpty(cbRole.SelectedItem.ToString()))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        // Query to check user credentials and role
                        string selectData = "SELECT * FROM Users WHERE Username = @username AND PasswordHash = @pass AND Role = @role";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            // Adding parameters for Username, Password, and Role
                            cmd.Parameters.AddWithValue("@username", txtLogusername.Text.Trim());

                            // Hash the input password here if needed (not shown, assuming plain-text for now)
                            cmd.Parameters.AddWithValue("@pass", txtLogPassword.Text.Trim());

                            // Role is a string from the Users table
                            cmd.Parameters.AddWithValue("@role", cbRole.SelectedItem.ToString());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            // Check if any matching user is found
                            if (table.Rows.Count >= 1)
                            {
                                string userRole = cbRole.SelectedItem.ToString();

                                MessageBox.Show("Logged In successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Role-based form navigation
                                if (userRole == "System Administrator")
                                {
                                    MainForm mainForm = new MainForm();
                                    mainForm.Show();
                                }
                                else if (userRole == "Colony Superintendent")
                                {
                                    MainFormfcolo mainFormfcolo = new MainFormfcolo();
                                    mainFormfcolo.Show();
                                }
                                else if (userRole == "Pilot")
                                {
                                    Viwetripinfo viwetripinfo = new Viwetripinfo();
                                    viwetripinfo.Show();
                                }
                                else if (userRole == "Data Entry Operator")
                                {
                                    MainForm mainForm = new MainForm();
                                    mainForm.Show();
                                }

                                this.Hide(); // Hide the current login form
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password/Role", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Connecting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }


        }

    }
}
