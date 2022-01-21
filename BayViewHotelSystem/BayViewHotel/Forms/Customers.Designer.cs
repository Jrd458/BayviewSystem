
namespace BayViewHotel.Forms
{
    partial class Customers
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tblCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bayViewHotelDataSet = new BayViewHotel.BayViewHotelDataSet();
            this.tblKieranBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kieranTestDataSet = new BayViewHotel.KieranTestDataSet();
            this.tbl_KieranTableAdapter = new BayViewHotel.KieranTestDataSetTableAdapters.Tbl_KieranTableAdapter();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.tblCustomerTableAdapter = new BayViewHotel.BayViewHotelDataSetTableAdapters.tblCustomerTableAdapter();
            this.dataGridCustomer = new System.Windows.Forms.DataGridView();
            this.CustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddressStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddressPostcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayViewHotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKieranBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kieranTestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customers";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.Location = new System.Drawing.Point(28, 91);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(406, 33);
            this.txtSearchCustomer.TabIndex = 3;
            this.txtSearchCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search Customer...";
            // 
            // tblCustomerBindingSource
            // 
            this.tblCustomerBindingSource.DataMember = "tblCustomer";
            this.tblCustomerBindingSource.DataSource = this.bayViewHotelDataSet;
            // 
            // bayViewHotelDataSet
            // 
            this.bayViewHotelDataSet.DataSetName = "BayViewHotelDataSet";
            this.bayViewHotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblKieranBindingSource
            // 
            this.tblKieranBindingSource.DataMember = "Tbl_Kieran";
            this.tblKieranBindingSource.DataSource = this.kieranTestDataSet;
            // 
            // kieranTestDataSet
            // 
            this.kieranTestDataSet.DataSetName = "KieranTestDataSet";
            this.kieranTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_KieranTableAdapter
            // 
            this.tbl_KieranTableAdapter.ClearBeforeFill = true;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackgroundImage = global::BayViewHotel.Properties.Resources.add_customer_icon;
            this.btnAddCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Location = new System.Drawing.Point(869, 89);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(40, 40);
            this.btnAddCustomer.TabIndex = 6;
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // tblCustomerTableAdapter
            // 
            this.tblCustomerTableAdapter.ClearBeforeFill = true;
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
            this.dataGridCustomer.Location = new System.Drawing.Point(28, 166);
            this.dataGridCustomer.MultiSelect = false;
            this.dataGridCustomer.Name = "dataGridCustomer";
            this.dataGridCustomer.ReadOnly = true;
            this.dataGridCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCustomer.Size = new System.Drawing.Size(881, 547);
            this.dataGridCustomer.TabIndex = 7;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Double click a customer to manage them.";
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 725);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchCustomer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Customers";
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayViewHotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKieranBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kieranTestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Label label2;
        private KieranTestDataSet kieranTestDataSet;
        private System.Windows.Forms.BindingSource tblKieranBindingSource;
        private KieranTestDataSetTableAdapters.Tbl_KieranTableAdapter tbl_KieranTableAdapter;
        private System.Windows.Forms.Button btnAddCustomer;
        private BayViewHotelDataSet bayViewHotelDataSet;
        private System.Windows.Forms.BindingSource tblCustomerBindingSource;
        private BayViewHotelDataSetTableAdapters.tblCustomerTableAdapter tblCustomerTableAdapter;
        private System.Windows.Forms.DataGridView dataGridCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddressStreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddressPostcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerEmail;
        private System.Windows.Forms.Label label3;
    }
}