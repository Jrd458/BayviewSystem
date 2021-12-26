
namespace BayViewHotel.Popups
{
    partial class ViewBookings
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblBookingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bayViewHotelDataSet = new BayViewHotel.BayViewHotelDataSet();
            this.tblBookingTableAdapter = new BayViewHotel.BayViewHotelDataSetTableAdapters.tblBookingTableAdapter();
            this.tblCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblCustomerTableAdapter = new BayViewHotel.BayViewHotelDataSetTableAdapters.tblCustomerTableAdapter();
            this.tblStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblStaffTableAdapter = new BayViewHotel.BayViewHotelDataSetTableAdapters.tblStaffTableAdapter();
            this.tblBookingBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bayViewHotelDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerBookingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerBookingTableAdapter = new BayViewHotel.BayViewHotelDataSetTableAdapters.CustomerBookingTableAdapter();
            this.bookingReferenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByStaffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnClmManageBooking = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBookingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayViewHotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBookingBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayViewHotelDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBookingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookingReferenceDataGridViewTextBoxColumn,
            this.customerNoDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.checkInDataGridViewTextBoxColumn,
            this.checkOutDataGridViewTextBoxColumn,
            this.createdByStaffDataGridViewTextBoxColumn,
            this.BtnClmManageBooking});
            this.dataGridView1.DataSource = this.customerBookingBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(913, 621);
            this.dataGridView1.TabIndex = 0;
            // 
            // tblBookingBindingSource
            // 
            this.tblBookingBindingSource.DataMember = "tblBooking";
            this.tblBookingBindingSource.DataSource = this.bayViewHotelDataSet;
            // 
            // bayViewHotelDataSet
            // 
            this.bayViewHotelDataSet.DataSetName = "BayViewHotelDataSet";
            this.bayViewHotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblBookingTableAdapter
            // 
            this.tblBookingTableAdapter.ClearBeforeFill = true;
            // 
            // tblCustomerBindingSource
            // 
            this.tblCustomerBindingSource.DataMember = "tblCustomer";
            this.tblCustomerBindingSource.DataSource = this.bayViewHotelDataSet;
            // 
            // tblCustomerTableAdapter
            // 
            this.tblCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // tblStaffBindingSource
            // 
            this.tblStaffBindingSource.DataMember = "tblStaff";
            this.tblStaffBindingSource.DataSource = this.bayViewHotelDataSet;
            // 
            // tblStaffTableAdapter
            // 
            this.tblStaffTableAdapter.ClearBeforeFill = true;
            // 
            // tblBookingBindingSource1
            // 
            this.tblBookingBindingSource1.DataMember = "tblBooking";
            this.tblBookingBindingSource1.DataSource = this.bayViewHotelDataSet;
            // 
            // bayViewHotelDataSetBindingSource
            // 
            this.bayViewHotelDataSetBindingSource.DataSource = this.bayViewHotelDataSet;
            this.bayViewHotelDataSetBindingSource.Position = 0;
            // 
            // customerBookingBindingSource
            // 
            this.customerBookingBindingSource.DataMember = "CustomerBooking";
            this.customerBookingBindingSource.DataSource = this.bayViewHotelDataSetBindingSource;
            // 
            // customerBookingTableAdapter
            // 
            this.customerBookingTableAdapter.ClearBeforeFill = true;
            // 
            // bookingReferenceDataGridViewTextBoxColumn
            // 
            this.bookingReferenceDataGridViewTextBoxColumn.DataPropertyName = "BookingReference";
            this.bookingReferenceDataGridViewTextBoxColumn.HeaderText = "Booking Reference";
            this.bookingReferenceDataGridViewTextBoxColumn.Name = "bookingReferenceDataGridViewTextBoxColumn";
            this.bookingReferenceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerNoDataGridViewTextBoxColumn
            // 
            this.customerNoDataGridViewTextBoxColumn.DataPropertyName = "CustomerNo";
            this.customerNoDataGridViewTextBoxColumn.HeaderText = "Customer No.";
            this.customerNoDataGridViewTextBoxColumn.Name = "customerNoDataGridViewTextBoxColumn";
            this.customerNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "Customer First Name";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Customer Last Name";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkInDataGridViewTextBoxColumn
            // 
            this.checkInDataGridViewTextBoxColumn.DataPropertyName = "CheckIn";
            this.checkInDataGridViewTextBoxColumn.HeaderText = "Check In";
            this.checkInDataGridViewTextBoxColumn.Name = "checkInDataGridViewTextBoxColumn";
            this.checkInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkOutDataGridViewTextBoxColumn
            // 
            this.checkOutDataGridViewTextBoxColumn.DataPropertyName = "CheckOut";
            this.checkOutDataGridViewTextBoxColumn.HeaderText = "Check Out";
            this.checkOutDataGridViewTextBoxColumn.Name = "checkOutDataGridViewTextBoxColumn";
            this.checkOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByStaffDataGridViewTextBoxColumn
            // 
            this.createdByStaffDataGridViewTextBoxColumn.DataPropertyName = "CreatedByStaff";
            this.createdByStaffDataGridViewTextBoxColumn.HeaderText = "Created By Staff";
            this.createdByStaffDataGridViewTextBoxColumn.Name = "createdByStaffDataGridViewTextBoxColumn";
            this.createdByStaffDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BtnClmManageBooking
            // 
            this.BtnClmManageBooking.HeaderText = "Manage Booking";
            this.BtnClmManageBooking.Name = "BtnClmManageBooking";
            this.BtnClmManageBooking.ReadOnly = true;
            this.BtnClmManageBooking.Text = "Manage";
            this.BtnClmManageBooking.UseColumnTextForButtonValue = true;
            // 
            // ViewBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 621);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewBookings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Bookings";
            this.Load += new System.EventHandler(this.ViewBookings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBookingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayViewHotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStaffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBookingBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayViewHotelDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBookingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private BayViewHotelDataSet bayViewHotelDataSet;
        private System.Windows.Forms.BindingSource tblBookingBindingSource;
        private BayViewHotelDataSetTableAdapters.tblBookingTableAdapter tblBookingTableAdapter;
        private System.Windows.Forms.BindingSource tblCustomerBindingSource;
        private BayViewHotelDataSetTableAdapters.tblCustomerTableAdapter tblCustomerTableAdapter;
        private System.Windows.Forms.BindingSource tblStaffBindingSource;
        private BayViewHotelDataSetTableAdapters.tblStaffTableAdapter tblStaffTableAdapter;
        private System.Windows.Forms.BindingSource tblBookingBindingSource1;
        private System.Windows.Forms.BindingSource bayViewHotelDataSetBindingSource;
        private System.Windows.Forms.BindingSource customerBookingBindingSource;
        private BayViewHotelDataSetTableAdapters.CustomerBookingTableAdapter customerBookingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingReferenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByStaffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn BtnClmManageBooking;
    }
}