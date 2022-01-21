
namespace BayViewHotel.Popups
{
    partial class PopupCustomerSelector
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridCustomer = new System.Windows.Forms.DataGridView();
            this.CustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddressStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddressPostcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Double click a customer to manage them.";
            // 
            // dataGridCustomer
            // 
            this.dataGridCustomer.AllowUserToAddRows = false;
            this.dataGridCustomer.AllowUserToDeleteRows = false;
            this.dataGridCustomer.AllowUserToResizeRows = false;
            this.dataGridCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerFullName,
            this.CustomerAddressStreet,
            this.CustomerAddressPostcode,
            this.CustomerContactNo,
            this.CustomerEmail});
            this.dataGridCustomer.Location = new System.Drawing.Point(12, 108);
            this.dataGridCustomer.MultiSelect = false;
            this.dataGridCustomer.Name = "dataGridCustomer";
            this.dataGridCustomer.ReadOnly = true;
            this.dataGridCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCustomer.Size = new System.Drawing.Size(881, 547);
            this.dataGridCustomer.TabIndex = 12;
            this.dataGridCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCustomer_CellDoubleClick);
            // 
            // CustomerFullName
            // 
            this.CustomerFullName.HeaderText = "Full Name";
            this.CustomerFullName.Name = "CustomerFullName";
            this.CustomerFullName.ReadOnly = true;
            this.CustomerFullName.Visible = false;
            // 
            // CustomerAddressStreet
            // 
            this.CustomerAddressStreet.HeaderText = "Street Address";
            this.CustomerAddressStreet.Name = "CustomerAddressStreet";
            this.CustomerAddressStreet.ReadOnly = true;
            this.CustomerAddressStreet.Visible = false;
            // 
            // CustomerAddressPostcode
            // 
            this.CustomerAddressPostcode.HeaderText = "Postcode";
            this.CustomerAddressPostcode.Name = "CustomerAddressPostcode";
            this.CustomerAddressPostcode.ReadOnly = true;
            this.CustomerAddressPostcode.Visible = false;
            // 
            // CustomerContactNo
            // 
            this.CustomerContactNo.HeaderText = "Contact Number";
            this.CustomerContactNo.Name = "CustomerContactNo";
            this.CustomerContactNo.ReadOnly = true;
            this.CustomerContactNo.Visible = false;
            // 
            // CustomerEmail
            // 
            this.CustomerEmail.HeaderText = "Email";
            this.CustomerEmail.Name = "CustomerEmail";
            this.CustomerEmail.ReadOnly = true;
            this.CustomerEmail.Visible = false;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackgroundImage = global::BayViewHotel.Properties.Resources.add_customer_icon;
            this.btnAddCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Location = new System.Drawing.Point(853, 31);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(40, 40);
            this.btnAddCustomer.TabIndex = 11;
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search Customer...";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.Location = new System.Drawing.Point(12, 33);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(406, 33);
            this.txtSearchCustomer.TabIndex = 9;
            this.txtSearchCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyUp);
            // 
            // PopupCustomerSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 668);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchCustomer);
            this.MaximizeBox = false;
            this.Name = "PopupCustomerSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select a Customer";
            this.Load += new System.EventHandler(this.PopupCustomerSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddressStreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddressPostcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerEmail;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchCustomer;
    }
}