namespace BayViewHotel
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenuAccounts = new System.Windows.Forms.Button();
            this.btnMenuHome = new System.Windows.Forms.Button();
            this.btnMenuRooms = new System.Windows.Forms.Button();
            this.btnMenuCustomers = new System.Windows.Forms.Button();
            this.btnMenuBooking = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelViewForm = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenuAccounts);
            this.panel1.Controls.Add(this.btnMenuRooms);
            this.panel1.Controls.Add(this.btnMenuCustomers);
            this.panel1.Controls.Add(this.btnMenuBooking);
            this.panel1.Controls.Add(this.btnMenuHome);
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 800);
            this.panel1.TabIndex = 0;
            // 
            // btnMenuAccounts
            // 
            this.btnMenuAccounts.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMenuAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAccounts.FlatAppearance.BorderSize = 0;
            this.btnMenuAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAccounts.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAccounts.Location = new System.Drawing.Point(0, 469);
            this.btnMenuAccounts.Name = "btnMenuAccounts";
            this.btnMenuAccounts.Size = new System.Drawing.Size(238, 90);
            this.btnMenuAccounts.TabIndex = 5;
            this.btnMenuAccounts.Text = "ACCOUNTS";
            this.btnMenuAccounts.UseVisualStyleBackColor = false;
            // 
            // btnMenuHome
            // 
            this.btnMenuHome.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMenuHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuHome.FlatAppearance.BorderSize = 0;
            this.btnMenuHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHome.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHome.Location = new System.Drawing.Point(0, 109);
            this.btnMenuHome.Name = "btnMenuHome";
            this.btnMenuHome.Size = new System.Drawing.Size(238, 90);
            this.btnMenuHome.TabIndex = 1;
            this.btnMenuHome.Text = "HOME";
            this.btnMenuHome.UseVisualStyleBackColor = false;
            this.btnMenuHome.Click += new System.EventHandler(this.btnMenuHome_Click);
            // 
            // btnMenuRooms
            // 
            this.btnMenuRooms.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMenuRooms.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuRooms.FlatAppearance.BorderSize = 0;
            this.btnMenuRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuRooms.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuRooms.Location = new System.Drawing.Point(0, 379);
            this.btnMenuRooms.Name = "btnMenuRooms";
            this.btnMenuRooms.Size = new System.Drawing.Size(238, 90);
            this.btnMenuRooms.TabIndex = 4;
            this.btnMenuRooms.Text = "ROOMS";
            this.btnMenuRooms.UseVisualStyleBackColor = false;
            // 
            // btnMenuCustomers
            // 
            this.btnMenuCustomers.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMenuCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuCustomers.FlatAppearance.BorderSize = 0;
            this.btnMenuCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCustomers.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCustomers.Location = new System.Drawing.Point(0, 289);
            this.btnMenuCustomers.Name = "btnMenuCustomers";
            this.btnMenuCustomers.Size = new System.Drawing.Size(238, 90);
            this.btnMenuCustomers.TabIndex = 3;
            this.btnMenuCustomers.Text = "CUSTOMERS";
            this.btnMenuCustomers.UseVisualStyleBackColor = false;
            // 
            // btnMenuBooking
            // 
            this.btnMenuBooking.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMenuBooking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuBooking.FlatAppearance.BorderSize = 0;
            this.btnMenuBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuBooking.Location = new System.Drawing.Point(0, 199);
            this.btnMenuBooking.Name = "btnMenuBooking";
            this.btnMenuBooking.Size = new System.Drawing.Size(238, 90);
            this.btnMenuBooking.TabIndex = 2;
            this.btnMenuBooking.Text = "BOOKING";
            this.btnMenuBooking.UseVisualStyleBackColor = false;
            this.btnMenuBooking.Click += new System.EventHandler(this.btnMenuBooking_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = global::BayViewHotel.Properties.Resources.logo;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(238, 109);
            this.panelLogo.TabIndex = 0;
            // 
            // panelViewForm
            // 
            this.panelViewForm.Location = new System.Drawing.Point(237, 0);
            this.panelViewForm.Name = "panelViewForm";
            this.panelViewForm.Size = new System.Drawing.Size(951, 764);
            this.panelViewForm.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panelViewForm);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMenuHome;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnMenuAccounts;
        private System.Windows.Forms.Button btnMenuRooms;
        private System.Windows.Forms.Button btnMenuCustomers;
        private System.Windows.Forms.Button btnMenuBooking;
        private System.Windows.Forms.Panel panelViewForm;
    }
}

