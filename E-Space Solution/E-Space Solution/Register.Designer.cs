namespace E_Space_Solution
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Login_show = new System.Windows.Forms.CheckBox();
            this.btn_Register = new System.Windows.Forms.Button();
            this.txtRegPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegusername = new System.Windows.Forms.TextBox();
            this.fh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRegemail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegcpass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Login_show
            // 
            this.Login_show.AutoSize = true;
            this.Login_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login_show.Location = new System.Drawing.Point(295, 393);
            this.Login_show.Name = "Login_show";
            this.Login_show.Size = new System.Drawing.Size(102, 17);
            this.Login_show.TabIndex = 18;
            this.Login_show.Text = "Show Password";
            this.Login_show.UseVisualStyleBackColor = true;
            this.Login_show.CheckedChanged += new System.EventHandler(this.Login_show_CheckedChanged);
            // 
            // btn_Register
            // 
            this.btn_Register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Register.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Register.Location = new System.Drawing.Point(295, 425);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(97, 32);
            this.btn_Register.TabIndex = 17;
            this.btn_Register.Text = "Register";
            this.btn_Register.UseVisualStyleBackColor = false;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // txtRegPassword
            // 
            this.txtRegPassword.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegPassword.Location = new System.Drawing.Point(295, 235);
            this.txtRegPassword.Multiline = true;
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.PasswordChar = '*';
            this.txtRegPassword.Size = new System.Drawing.Size(261, 30);
            this.txtRegPassword.TabIndex = 16;
            this.txtRegPassword.TextChanged += new System.EventHandler(this.txtRegPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Password :";
            // 
            // txtRegusername
            // 
            this.txtRegusername.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegusername.Location = new System.Drawing.Point(295, 102);
            this.txtRegusername.Multiline = true;
            this.txtRegusername.Name = "txtRegusername";
            this.txtRegusername.Size = new System.Drawing.Size(261, 30);
            this.txtRegusername.TabIndex = 14;
            // 
            // fh
            // 
            this.fh.AutoSize = true;
            this.fh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fh.Location = new System.Drawing.Point(295, 77);
            this.fh.Name = "fh";
            this.fh.Size = new System.Drawing.Size(74, 16);
            this.fh.TabIndex = 13;
            this.fh.Text = "Username :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Register Now";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnRegLogin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 467);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::E_Space_Solution.Properties.Resources.logo_no_background;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Location = new System.Drawing.Point(33, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 90);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "E-SPACE SOLUTION PVT (LTD).";
            // 
            // btnRegLogin
            // 
            this.btnRegLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnRegLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegLogin.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegLogin.ForeColor = System.Drawing.Color.White;
            this.btnRegLogin.Location = new System.Drawing.Point(20, 372);
            this.btnRegLogin.Name = "btnRegLogin";
            this.btnRegLogin.Size = new System.Drawing.Size(227, 32);
            this.btnRegLogin.TabIndex = 1;
            this.btnRegLogin.Text = "LOGIN";
            this.btnRegLogin.UseVisualStyleBackColor = false;
            this.btnRegLogin.Click += new System.EventHandler(this.btnRegLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(16, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "If you Already have an account ?";
            // 
            // txtRegemail
            // 
            this.txtRegemail.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegemail.Location = new System.Drawing.Point(298, 168);
            this.txtRegemail.Multiline = true;
            this.txtRegemail.Name = "txtRegemail";
            this.txtRegemail.Size = new System.Drawing.Size(261, 30);
            this.txtRegemail.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "EMAIL :";
            // 
            // txtRegcpass
            // 
            this.txtRegcpass.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegcpass.Location = new System.Drawing.Point(295, 301);
            this.txtRegcpass.Multiline = true;
            this.txtRegcpass.Name = "txtRegcpass";
            this.txtRegcpass.PasswordChar = '*';
            this.txtRegcpass.Size = new System.Drawing.Size(261, 30);
            this.txtRegcpass.TabIndex = 22;
            this.txtRegcpass.TextChanged += new System.EventHandler(this.txtRegcpass_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(295, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Confirm Password :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(295, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Role :";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Data Entry Operator",
            "System Administrator",
            "Colony Superintendent",
            "Pilot"});
            this.cbRole.Location = new System.Drawing.Point(295, 355);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(261, 21);
            this.cbRole.TabIndex = 24;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 467);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRegcpass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRegemail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login_show);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.txtRegPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRegusername);
            this.Controls.Add(this.fh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox Login_show;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegusername;
        private System.Windows.Forms.Label fh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRegemail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegcpass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRole;
    }
}