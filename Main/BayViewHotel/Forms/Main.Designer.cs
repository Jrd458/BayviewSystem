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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnInfoBox = new System.Windows.Forms.Button();
            this.btnMenuAccounts = new System.Windows.Forms.Button();
            this.btnMenuRooms = new System.Windows.Forms.Button();
            this.btnMenuCustomers = new System.Windows.Forms.Button();
            this.btnMenuBooking = new System.Windows.Forms.Button();
            this.btnMenuHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelViewForm = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnInfoBox);
            this.panel1.Controls.Add(this.btnMenuAccounts);
            this.panel1.Controls.Add(this.btnMenuRooms);
            this.panel1.Controls.Add(this.btnMenuCustomers);
            this.panel1.Controls.Add(this.btnMenuBooking);
            this.panel1.Controls.Add(this.btnMenuHome);
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 764);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = global::BayViewHotel.Properties.Resources.logout_icon1;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(66, 709);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(40, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnInfoBox
            // 
            this.btnInfoBox.BackgroundImage = global::BayViewHotel.Properties.Resources.info_icon;
            this.btnInfoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInfoBox.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnInfoBox.FlatAppearance.BorderSize = 0;
            this.btnInfoBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoBox.Location = new System.Drawing.Point(14, 710);
            this.btnInfoBox.Name = "btnInfoBox";
            this.btnInfoBox.Size = new System.Drawing.Size(40, 40);
            this.btnInfoBox.TabIndex = 0;
            this.btnInfoBox.UseVisualStyleBackColor = true;
            this.btnInfoBox.Click += new System.EventHandler(this.btnInfoBox_Click);
            // 
            // btnMenuAccounts
            // 
            this.btnMenuAccounts.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMenuAccounts.BackgroundImage = global::BayViewHotel.Properties.Resources.btnIconBg_accounts;
            this.btnMenuAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAccounts.FlatAppearance.BorderSize = 0;
            this.btnMenuAccounts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAccounts.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuAccounts.Location = new System.Drawing.Point(0, 469);
            this.btnMenuAccounts.Name = "btnMenuAccounts";
            this.btnMenuAccounts.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnMenuAccounts.Size = new System.Drawing.Size(238, 90);
            this.btnMenuAccounts.TabIndex = 5;
            this.btnMenuAccounts.Text = "accounts";
            this.btnMenuAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuAccounts.UseVisualStyleBackColor = false;
            this.btnMenuAccounts.Click += new System.EventHandler(this.btnMenuAccounts_Click);
            // 
            // btnMenuRooms
            // 
            this.btnMenuRooms.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMenuRooms.BackgroundImage = global::BayViewHotel.Properties.Resources.btnIconBg_rooms;
            this.btnMenuRooms.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuRooms.FlatAppearance.BorderSize = 0;
            this.btnMenuRooms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuRooms.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuRooms.Location = new System.Drawing.Point(0, 379);
            this.btnMenuRooms.Name = "btnMenuRooms";
            this.btnMenuRooms.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnMenuRooms.Size = new System.Drawing.Size(238, 90);
            this.btnMenuRooms.TabIndex = 4;
            this.btnMenuRooms.Text = "rooms";
            this.btnMenuRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuRooms.UseVisualStyleBackColor = false;
            this.btnMenuRooms.Click += new System.EventHandler(this.btnMenuRooms_Click);
            // 
            // btnMenuCustomers
            // 
            this.btnMenuCustomers.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMenuCustomers.BackgroundImage = global::BayViewHotel.Properties.Resources.btnIconBg_customers;
            this.btnMenuCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuCustomers.FlatAppearance.BorderSize = 0;
            this.btnMenuCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCustomers.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuCustomers.Location = new System.Drawing.Point(0, 289);
            this.btnMenuCustomers.Name = "btnMenuCustomers";
            this.btnMenuCustomers.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnMenuCustomers.Size = new System.Drawing.Size(238, 90);
            this.btnMenuCustomers.TabIndex = 3;
            this.btnMenuCustomers.Text = "customers";
            this.btnMenuCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuCustomers.UseVisualStyleBackColor = false;
            this.btnMenuCustomers.Click += new System.EventHandler(this.btnMenuCustomers_Click);
            // 
            // btnMenuBooking
            // 
            this.btnMenuBooking.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMenuBooking.BackgroundImage = global::BayViewHotel.Properties.Resources.btnIconBg_booking;
            this.btnMenuBooking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuBooking.FlatAppearance.BorderSize = 0;
            this.btnMenuBooking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBooking.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuBooking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuBooking.Location = new System.Drawing.Point(0, 199);
            this.btnMenuBooking.Name = "btnMenuBooking";
            this.btnMenuBooking.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnMenuBooking.Size = new System.Drawing.Size(238, 90);
            this.btnMenuBooking.TabIndex = 2;
            this.btnMenuBooking.Text = "booking";
            this.btnMenuBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuBooking.UseVisualStyleBackColor = false;
            this.btnMenuBooking.Click += new System.EventHandler(this.btnMenuBooking_Click);
            // 
            // btnMenuHome
            // 
            this.btnMenuHome.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMenuHome.BackgroundImage = global::BayViewHotel.Properties.Resources.btnIconBg_home;
            this.btnMenuHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuHome.FlatAppearance.BorderSize = 0;
            this.btnMenuHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHome.Location = new System.Drawing.Point(0, 109);
            this.btnMenuHome.Name = "btnMenuHome";
            this.btnMenuHome.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.btnMenuHome.Size = new System.Drawing.Size(238, 90);
            this.btnMenuHome.TabIndex = 1;
            this.btnMenuHome.Text = "home";
            this.btnMenuHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuHome.UseVisualStyleBackColor = false;
            this.btnMenuHome.Click += new System.EventHandler(this.btnMenuHome_Click);
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
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panelViewForm);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bay View Hotel";
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
        private System.Windows.Forms.Button btnInfoBox;
        private System.Windows.Forms.Button btnLogout;
    }
}

