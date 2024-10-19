namespace E_Space_Solution
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnJobassign = new System.Windows.Forms.Button();
            this.bntJob = new System.Windows.Forms.Button();
            this.btnHouse = new System.Windows.Forms.Button();
            this.btnTrip = new System.Windows.Forms.Button();
            this.btnEjet = new System.Windows.Forms.Button();
            this.btnAsignpilot = new System.Windows.Forms.Button();
            this.btnPilot = new System.Windows.Forms.Button();
            this.btnDependent = new System.Windows.Forms.Button();
            this.btnColonist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.assingjob1 = new E_Space_Solution.Assingjob();
            this.job1 = new E_Space_Solution.Job();
            this.house1 = new E_Space_Solution.House();
            this.trip1 = new E_Space_Solution.Trip();
            this.ejet1 = new E_Space_Solution.Ejet();
            this.assignpilot1 = new E_Space_Solution.Assignpilot();
            this.pilot1 = new E_Space_Solution.Pilot();
            this.dependents1 = new E_Space_Solution.Dependents();
            this.colonist1 = new E_Space_Solution.Colonist();
            this.dashboard1 = new E_Space_Solution.Dashboard();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 35);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "E-SPACE SOLUTION PVT (LTD).";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(8)))), ((int)(((byte)(97)))));
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnJobassign);
            this.panel2.Controls.Add(this.bntJob);
            this.panel2.Controls.Add(this.btnHouse);
            this.panel2.Controls.Add(this.btnTrip);
            this.panel2.Controls.Add(this.btnEjet);
            this.panel2.Controls.Add(this.btnAsignpilot);
            this.panel2.Controls.Add(this.btnPilot);
            this.panel2.Controls.Add(this.btnDependent);
            this.panel2.Controls.Add(this.btnColonist);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 713);
            this.panel2.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(8, 681);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnJobassign
            // 
            this.btnJobassign.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobassign.Location = new System.Drawing.Point(6, 610);
            this.btnJobassign.Name = "btnJobassign";
            this.btnJobassign.Size = new System.Drawing.Size(187, 40);
            this.btnJobassign.TabIndex = 12;
            this.btnJobassign.Text = "Assign to Job";
            this.btnJobassign.UseVisualStyleBackColor = true;
            this.btnJobassign.Click += new System.EventHandler(this.btnJobassign_Click);
            // 
            // bntJob
            // 
            this.bntJob.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntJob.Location = new System.Drawing.Point(6, 557);
            this.bntJob.Name = "bntJob";
            this.bntJob.Size = new System.Drawing.Size(187, 40);
            this.bntJob.TabIndex = 11;
            this.bntJob.Text = "Job";
            this.bntJob.UseVisualStyleBackColor = true;
            this.bntJob.Click += new System.EventHandler(this.bntJob_Click);
            // 
            // btnHouse
            // 
            this.btnHouse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHouse.Location = new System.Drawing.Point(6, 498);
            this.btnHouse.Name = "btnHouse";
            this.btnHouse.Size = new System.Drawing.Size(187, 40);
            this.btnHouse.TabIndex = 10;
            this.btnHouse.Text = "House";
            this.btnHouse.UseVisualStyleBackColor = true;
            this.btnHouse.Click += new System.EventHandler(this.btnHouse_Click);
            // 
            // btnTrip
            // 
            this.btnTrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrip.Location = new System.Drawing.Point(6, 441);
            this.btnTrip.Name = "btnTrip";
            this.btnTrip.Size = new System.Drawing.Size(187, 40);
            this.btnTrip.TabIndex = 9;
            this.btnTrip.Text = "Trip";
            this.btnTrip.UseVisualStyleBackColor = true;
            this.btnTrip.Click += new System.EventHandler(this.btnTrip_Click);
            // 
            // btnEjet
            // 
            this.btnEjet.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjet.Location = new System.Drawing.Point(6, 386);
            this.btnEjet.Name = "btnEjet";
            this.btnEjet.Size = new System.Drawing.Size(187, 40);
            this.btnEjet.TabIndex = 8;
            this.btnEjet.Text = "Ejet";
            this.btnEjet.UseVisualStyleBackColor = true;
            this.btnEjet.Click += new System.EventHandler(this.btnEjet_Click);
            // 
            // btnAsignpilot
            // 
            this.btnAsignpilot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignpilot.Location = new System.Drawing.Point(6, 330);
            this.btnAsignpilot.Name = "btnAsignpilot";
            this.btnAsignpilot.Size = new System.Drawing.Size(187, 40);
            this.btnAsignpilot.TabIndex = 7;
            this.btnAsignpilot.Text = "Assign Pilot";
            this.btnAsignpilot.UseVisualStyleBackColor = true;
            this.btnAsignpilot.Click += new System.EventHandler(this.btnAsignpilot_Click);
            // 
            // btnPilot
            // 
            this.btnPilot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilot.Location = new System.Drawing.Point(6, 273);
            this.btnPilot.Name = "btnPilot";
            this.btnPilot.Size = new System.Drawing.Size(187, 40);
            this.btnPilot.TabIndex = 6;
            this.btnPilot.Text = "Pilot";
            this.btnPilot.UseVisualStyleBackColor = true;
            this.btnPilot.Click += new System.EventHandler(this.btnPilot_Click);
            // 
            // btnDependent
            // 
            this.btnDependent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDependent.Location = new System.Drawing.Point(6, 217);
            this.btnDependent.Name = "btnDependent";
            this.btnDependent.Size = new System.Drawing.Size(187, 40);
            this.btnDependent.TabIndex = 5;
            this.btnDependent.Text = "Dependent";
            this.btnDependent.UseVisualStyleBackColor = true;
            this.btnDependent.Click += new System.EventHandler(this.btnDependent_Click);
            // 
            // btnColonist
            // 
            this.btnColonist.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColonist.Location = new System.Drawing.Point(6, 162);
            this.btnColonist.Name = "btnColonist";
            this.btnColonist.Size = new System.Drawing.Size(187, 40);
            this.btnColonist.TabIndex = 2;
            this.btnColonist.Text = "Colonist";
            this.btnColonist.UseVisualStyleBackColor = true;
            this.btnColonist.Click += new System.EventHandler(this.btnColonist_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "WELCOME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::E_Space_Solution.Properties.Resources.logo_no_background;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(50, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(884, 713);
            this.panel3.TabIndex = 2;
            // 
            // assingjob1
            // 
            this.assingjob1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("assingjob1.BackgroundImage")));
            this.assingjob1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.assingjob1.Location = new System.Drawing.Point(198, 35);
            this.assingjob1.Name = "assingjob1";
            this.assingjob1.Size = new System.Drawing.Size(884, 713);
            this.assingjob1.TabIndex = 2;
            // 
            // job1
            // 
            this.job1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("job1.BackgroundImage")));
            this.job1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.job1.Location = new System.Drawing.Point(198, 35);
            this.job1.Name = "job1";
            this.job1.Size = new System.Drawing.Size(884, 713);
            this.job1.TabIndex = 3;
            // 
            // house1
            // 
            this.house1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("house1.BackgroundImage")));
            this.house1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.house1.Location = new System.Drawing.Point(198, 32);
            this.house1.Name = "house1";
            this.house1.Size = new System.Drawing.Size(884, 713);
            this.house1.TabIndex = 4;
            // 
            // trip1
            // 
            this.trip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trip1.BackgroundImage")));
            this.trip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trip1.Location = new System.Drawing.Point(198, 35);
            this.trip1.Name = "trip1";
            this.trip1.Size = new System.Drawing.Size(884, 713);
            this.trip1.TabIndex = 5;
            // 
            // ejet1
            // 
            this.ejet1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ejet1.BackgroundImage")));
            this.ejet1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ejet1.Location = new System.Drawing.Point(198, 35);
            this.ejet1.Name = "ejet1";
            this.ejet1.Size = new System.Drawing.Size(884, 713);
            this.ejet1.TabIndex = 6;
            // 
            // assignpilot1
            // 
            this.assignpilot1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("assignpilot1.BackgroundImage")));
            this.assignpilot1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.assignpilot1.Location = new System.Drawing.Point(198, 32);
            this.assignpilot1.Name = "assignpilot1";
            this.assignpilot1.Size = new System.Drawing.Size(884, 713);
            this.assignpilot1.TabIndex = 7;
            // 
            // pilot1
            // 
            this.pilot1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pilot1.BackgroundImage")));
            this.pilot1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pilot1.Location = new System.Drawing.Point(198, 32);
            this.pilot1.Name = "pilot1";
            this.pilot1.Size = new System.Drawing.Size(884, 713);
            this.pilot1.TabIndex = 8;
            // 
            // dependents1
            // 
            this.dependents1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dependents1.BackgroundImage")));
            this.dependents1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dependents1.Location = new System.Drawing.Point(198, 35);
            this.dependents1.Name = "dependents1";
            this.dependents1.Size = new System.Drawing.Size(884, 713);
            this.dependents1.TabIndex = 9;
            // 
            // colonist1
            // 
            this.colonist1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colonist1.BackgroundImage")));
            this.colonist1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colonist1.Location = new System.Drawing.Point(198, 35);
            this.colonist1.Name = "colonist1";
            this.colonist1.Size = new System.Drawing.Size(884, 713);
            this.colonist1.TabIndex = 10;
            // 
            // dashboard1
            // 
            this.dashboard1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dashboard1.Location = new System.Drawing.Point(198, 35);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(884, 713);
            this.dashboard1.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1084, 748);
            this.Controls.Add(this.dashboard1);
            this.Controls.Add(this.colonist1);
            this.Controls.Add(this.dependents1);
            this.Controls.Add(this.pilot1);
            this.Controls.Add(this.assignpilot1);
            this.Controls.Add(this.ejet1);
            this.Controls.Add(this.trip1);
            this.Controls.Add(this.house1);
            this.Controls.Add(this.job1);
            this.Controls.Add(this.assingjob1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColonist;
        private System.Windows.Forms.Button btnJobassign;
        private System.Windows.Forms.Button bntJob;
        private System.Windows.Forms.Button btnHouse;
        private System.Windows.Forms.Button btnTrip;
        private System.Windows.Forms.Button btnEjet;
        private System.Windows.Forms.Button btnAsignpilot;
        private System.Windows.Forms.Button btnPilot;
        private System.Windows.Forms.Button btnDependent;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel3;
        private Assingjob assingjob1;
        private Job job1;
        private House house1;
        private Trip trip1;
        private Ejet ejet1;
        private Assignpilot assignpilot1;
        private Pilot pilot1;
        private Dependents dependents1;
        private Colonist colonist1;
        private Dashboard dashboard1;
    }
}