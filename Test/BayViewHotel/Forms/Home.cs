using BayViewHotel.Classes;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayViewHotel.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kieranTestDataSet.Tbl_Kieran' table. You can move, or remove it, as needed.
            this.tbl_KieranTableAdapter.Fill(this.kieranTestDataSet.Tbl_Kieran);
            //IReportServerCredentials creds = new CustomReportCredentials("Administrator", "Cambrian@1", "");
            NetworkCredential customCred = new NetworkCredential("Administrator", "Cambrian@1", "WIN-41GL1FSD01Q");
            //this.reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = customCred;
            //this.reportViewer1.RefreshReport();
        }
    }
}
