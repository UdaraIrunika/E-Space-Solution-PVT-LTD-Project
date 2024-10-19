namespace E_Space_Solution
{
    partial class MainFormfcolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormfcolo));
            this.btnLogout = new System.Windows.Forms.Button();
            this.bntColonist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTripw = new System.Windows.Forms.Button();
            this.btnCjob = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tripinfo1 = new E_Space_Solution.tripinfo();
            this.assingjob1 = new E_Space_Solution.Assingjob();
            this.colonist1 = new E_Space_Solution.Colonist();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(61, 672);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // bntColonist
            // 
            this.bntColonist.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntColonist.Location = new System.Drawing.Point(5, 198);
            this.bntColonist.Name = "bntColonist";
            this.bntColonist.Size = new System.Drawing.Size(187, 40);
            this.bntColonist.TabIndex = 2;
            this.bntColonist.Text = "Colonist";
            this.bntColonist.UseVisualStyleBackColor = true;
            this.bntColonist.Click += new System.EventHandler(this.bntColonist_Click);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.tripinfo1);
            this.panel3.Controls.Add(this.assingjob1);
            this.panel3.Controls.Add(this.colonist1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(884, 716);
            this.panel3.TabIndex = 25;
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
            this.panel2.Controls.Add(this.btnTripw);
            this.panel2.Controls.Add(this.btnCjob);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.bntColonist);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 716);
            this.panel2.TabIndex = 24;
            // 
            // btnTripw
            // 
            this.btnTripw.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTripw.Location = new System.Drawing.Point(7, 314);
            this.btnTripw.Name = "btnTripw";
            this.btnTripw.Size = new System.Drawing.Size(187, 40);
            this.btnTripw.TabIndex = 15;
            this.btnTripw.Text = "Viwe Trip Information";
            this.btnTripw.UseVisualStyleBackColor = true;
            this.btnTripw.Click += new System.EventHandler(this.btnTripw_Click);
            // 
            // btnCjob
            // 
            this.btnCjob.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCjob.Location = new System.Drawing.Point(5, 256);
            this.btnCjob.Name = "btnCjob";
            this.btnCjob.Size = new System.Drawing.Size(187, 40);
            this.btnCjob.TabIndex = 14;
            this.btnCjob.Text = "Cheak Job Assign";
            this.btnCjob.UseVisualStyleBackColor = true;
            this.btnCjob.Click += new System.EventHandler(this.btnCjob_Click);
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
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 35);
            this.panel1.TabIndex = 23;
            // 
            // tripinfo1
            // 
            this.tripinfo1.Location = new System.Drawing.Point(-1, 0);
            this.tripinfo1.Name = "tripinfo1";
            this.tripinfo1.Size = new System.Drawing.Size(884, 716);
            this.tripinfo1.TabIndex = 2;
            // 
            // assingjob1
            // 
            this.assingjob1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("assingjob1.BackgroundImage")));
            this.assingjob1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.assingjob1.Location = new System.Drawing.Point(-1, 2);
            this.assingjob1.Name = "assingjob1";
            this.assingjob1.Size = new System.Drawing.Size(884, 713);
            this.assingjob1.TabIndex = 1;
            // 
            // colonist1
            // 
            this.colonist1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colonist1.BackgroundImage")));
            this.colonist1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colonist1.Location = new System.Drawing.Point(0, 1);
            this.colonist1.Name = "colonist1";
            this.colonist1.Size = new System.Drawing.Size(884, 713);
            this.colonist1.TabIndex = 0;
            // 
            // MainFormfcolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 751);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainFormfcolo";
            this.Text = "MainFormfcolo";
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button bntColonist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTripw;
        private System.Windows.Forms.Button btnCjob;
        private Colonist colonist1;
        private tripinfo tripinfo1;
        private Assingjob assingjob1;
    }
}