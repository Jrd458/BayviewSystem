namespace BayViewHotel.Forms
{
    partial class Home
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
            this.kieranTestDataSet = new BayViewHotel.KieranTestDataSet();
            this.tblKieranBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_KieranTableAdapter = new BayViewHotel.KieranTestDataSetTableAdapters.Tbl_KieranTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.kieranTestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKieranBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Our summary";
            // 
            // kieranTestDataSet
            // 
            this.kieranTestDataSet.DataSetName = "KieranTestDataSet";
            this.kieranTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblKieranBindingSource
            // 
            this.tblKieranBindingSource.DataMember = "Tbl_Kieran";
            this.tblKieranBindingSource.DataSource = this.kieranTestDataSet;
            // 
            // tbl_KieranTableAdapter
            // 
            this.tbl_KieranTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            this.reportViewer1.Location = new System.Drawing.Point(28, 70);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.ServerReport.ReportPath = "/TestPieChart";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("http://51.195.252.182/ReportServer", System.UriKind.Absolute);
            this.reportViewer1.ShowContextMenu = false;
            this.reportViewer1.ShowCredentialPrompts = false;
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.ShowToolBar = false;
            this.reportViewer1.Size = new System.Drawing.Size(895, 643);
            this.reportViewer1.TabIndex = 1;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 725);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kieranTestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKieranBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private KieranTestDataSet kieranTestDataSet;
        private System.Windows.Forms.BindingSource tblKieranBindingSource;
        private KieranTestDataSetTableAdapters.Tbl_KieranTableAdapter tbl_KieranTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}