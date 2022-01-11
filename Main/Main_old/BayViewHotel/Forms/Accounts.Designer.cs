
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
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbljoelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kieranTestDataSet1 = new BayViewHotel.KieranTestDataSet1();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchAccount = new System.Windows.Forms.TextBox();
            this.tbl_joelTableAdapter = new BayViewHotel.KieranTestDataSet1TableAdapters.Tbl_joelTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(114, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Accounts";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.BackgroundImage = global::BayViewHotel.Properties.Resources.add_customer_icon;
            this.btnAddAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAccount.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnAddAccount.FlatAppearance.BorderSize = 0;
            this.btnAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAccount.Location = new System.Drawing.Point(869, 83);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(40, 40);
            this.btnAddAccount.TabIndex = 10;
            this.btnAddAccount.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbljoelBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(28, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(881, 552);
            this.dataGridView1.TabIndex = 9;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
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
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search Staff...";
            // 
            // txtSearchAccount
            // 
            this.txtSearchAccount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAccount.Location = new System.Drawing.Point(28, 85);
            this.txtSearchAccount.Name = "txtSearchAccount";
            this.txtSearchAccount.Size = new System.Drawing.Size(406, 33);
            this.txtSearchAccount.TabIndex = 7;
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
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchAccount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Accounts";
            this.Text = "Accounts";
            this.Load += new System.EventHandler(this.Accounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbljoelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kieranTestDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchAccount;
        private KieranTestDataSet1 kieranTestDataSet1;
        private System.Windows.Forms.BindingSource tbljoelBindingSource;
        private KieranTestDataSet1TableAdapters.Tbl_joelTableAdapter tbl_joelTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}