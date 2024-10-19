using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace E_Space_Solution
{
    public partial class Register : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-P8R14E4\SQLEXPRESS;Initial Catalog=MarsColonizationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegLogin_Click(object sender, EventArgs e)
        {
            Login sForm = new Login();
            sForm.Show();
            this.Hide();
        }

        private void Login_show_CheckedChanged(object sender, EventArgs e)
        {
            if (Login_show.Checked)
            {
                txtRegPassword.PasswordChar = '*';  
            }
            else
            {
                txtRegPassword.PasswordChar = '\0';
            }
            if (Login_show.Checked)
            {
                txtRegcpass.PasswordChar = '*'; 
            }
            else
            {
                txtRegcpass.PasswordChar = '\0';
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegemail.Text) || 
        string.IsNullOrEmpty(txtRegusername.Text) || 
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
                String checkUsername = "SELECT * FROM Users WHERE Username = @username";
                using (SqlCommand checkUser = new SqlCommand(checkUsername, connect))
                {
                    checkUser.Parameters.AddWithValue("@username", txtRegusername.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count >= 1)
                    {
                        MessageBox.Show(txtRegusername.Text + " already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string insertData = "INSERT INTO Users (Username, PasswordHash, Email ,Role) VALUES(@username, @pass, @email, @Role)";
                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@email", txtRegemail.Text.Trim());
                            cmd.Parameters.AddWithValue("@username", txtRegusername.Text.Trim());
                            cmd.Parameters.AddWithValue("@pass", txtRegPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@Role", cbRole.SelectedItem.ToString());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Switch to the login form
                            Login lForm = new Login();
                            lForm.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close(); 
            }
        }
    }

        }

        private void txtRegPassword_TextChanged(object sender, EventArgs e)
        {
            //txtRegcpass.PasswordChar = '*';
        }

        private void txtRegcpass_TextChanged(object sender, EventArgs e)
        {
            //txtRegcpass.PasswordChar = '*';
        }
    }
}
