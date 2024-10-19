using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Space_Solution
{
    public partial class MainFormfcolo : Form
    {
        public MainFormfcolo()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Optionally, confirm with the user before logging out
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear any user session data here (if applicable)
                // For example: UserSession.CurrentUser = null; 

                // Optionally, close the current form
                this.Hide(); // Hides the current form

                // Show the login form (assuming you have a LoginForm)
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        private void bntColonist_Click(object sender, EventArgs e)
        {
            colonist1.Visible = true;
            assingjob1.Visible = false;
            tripinfo1.Visible = false;
        }

        private void btnCjob_Click(object sender, EventArgs e)
        {
            colonist1.Visible = false;
            assingjob1.Visible = true;
            tripinfo1.Visible = false;
        }

        private void btnTripw_Click(object sender, EventArgs e)
        {
            colonist1.Visible = false;
            assingjob1.Visible = false;
            tripinfo1.Visible = true;
        }
    }
}
