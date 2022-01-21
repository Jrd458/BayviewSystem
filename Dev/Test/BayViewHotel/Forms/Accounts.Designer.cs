
namespace BayViewHotel.Forms
{
    partial class Accounts
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
            this.dataGridInvoicing = new System.Windows.Forms.DataGridView();
            this.tbljoelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kieranTestDataSet1 = new BayViewHotel.KieranTestDataSet1();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchBookingNumber = new System.Windows.Forms.TextBox();
            this.tbl_joelTableAdapter = new BayViewHotel.KieranTestDataSet1TableAdapters.Tbl_joelTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInvoicing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbljoelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kieranTestDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Invoicing";
            // 
            // dataGridInvoicing
            // 
            this.dataGridInvoicing.AllowUserToAddRows = false;
            this.dataGridInvoicing.AllowUserToDeleteRows = false;
            this.dataGridInvoicing.AllowUserToOrderColumns = true;
            this.dataGridInvoicing.AllowUserToResizeRows = false;
            this.dataGridInvoicing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridInvoicing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInvoicing.Location = new System.Drawing.Point(28, 142);
            this.dataGridInvoicing.MultiSelect = false;
            this.dataGridInvoicing.Name = "dataGridInvoicing";
            this.dataGridInvoicing.ReadOnly = true;
            this.dataGridInvoicing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridInvoicing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridInvoicing.ShowCellErrors = false;
            this.dataGridInvoicing.ShowCellToolTips = false;
            this.dataGridInvoicing.ShowEditingIcon = false;
            this.dataGridInvoicing.Size = new System.Drawing.Size(881, 552);
            this.dataGridInvoicing.TabIndex = 9;
            // 
            // tbljoelBindingSource
            // 
            this.tbljoelBindingSource.DataMember = "Tbl_joel";
            this.tbljoelBindingSource.DataSource = this.kieranTestDataSet1;
            // 
            // kieranTestDataSet1
            // 
            this.kieranTestDataSet1.DataSetName = "KieranTestDataSet1";
            this.kieranTestDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search Invoice Number...";
            // 
            // txtSearchBookingNumber
            // 
            this.txtSearchBookingNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBookingNumber.Location = new System.Drawing.Point(28, 85);
            this.txtSearchBookingNumber.Name = "txtSearchBookingNumber";
            this.txtSearchBookingNumber.Size = new System.Drawing.Size(406, 33);
            this.txtSearchBookingNumber.TabIndex = 7;
            this.txtSearchBookingNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchBookingNumber_KeyUp);
            // 
            // tbl_joelTableAdapter
            // 
            this.tbl_joelTableAdapter.ClearBeforeFill = true;
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 725);
            this.Controls.Add(this.dataGridInvoicing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchBookingNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Accounts";
            this.Text = "Accounts";
            this.Load += new System.EventHandler(this.Accounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInvoicing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbljoelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kieranTestDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridInvoicing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchBookingNumber;
        private KieranTestDataSet1 kieranTestDataSet1;
        private System.Windows.Forms.BindingSource tbljoelBindingSource;
        private KieranTestDataSet1TableAdapters.Tbl_joelTableAdapter tbl_joelTableAdapter;
    }
}