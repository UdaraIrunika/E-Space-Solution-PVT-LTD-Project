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

namespace E_Space_Solution
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnColonist_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = true;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = false;
        }

        private void btnDependent_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = true;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = false;
        }

        private void btnPilot_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = true;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = false;
        }

        private void btnAsignpilot_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = true;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = false;
        }

        private void btnEjet_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = true;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = false;
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = true;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = false;
        }

        private void btnHouse_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = true;
            job1.Visible = false;
            assingjob1.Visible = false;
        }

        private void bntJob_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = true;
            assingjob1.Visible = false;
        }

        private void btnJobassign_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = true;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            colonist1.Visible = false;
            dependents1.Visible = false;
            pilot1.Visible = false;
            assignpilot1.Visible = false;
            ejet1.Visible = false;
            trip1.Visible = false;
            house1.Visible = false;
            job1.Visible = false;
            assingjob1.Visible = false;
        }
    }
}
