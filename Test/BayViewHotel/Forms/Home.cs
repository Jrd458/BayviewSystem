using BayViewHotel.Classes;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            //this.tbl_KieranTableAdapter.Fill(this.kieranTestDataSet.Tbl_Kieran);
            //IReportServerCredentials creds = new CustomReportCredentials("Administrator", "Cambrian@1", "");
            NetworkCredential customCred = new NetworkCredential("Administrator", "Cambrian@1", "WIN-41GL1FSD01Q");
            //this.reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = customCred;
            //this.reportViewer1.RefreshReport();

            LoadBookingChart();
            LoadRoomTypeDistributionChart();
        }

        private void LoadRoomTypeDistributionChart()
        {
            try
            {
                using (BayViewHotelEntities db = new BayViewHotelEntities())
                {
                    chart2.DataSource = db.RoomTypeDistributions.ToList();
                    chart2.Series["Room Type"].XValueMember = "RoomType";
                    chart2.Series["Room Type"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                    chart2.Series["Room Type"].YValueMembers = "TotalBookings";
                    chart2.Series["Room Type"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                }

                using (BayViewHotelRevenueEntity db = new BayViewHotelRevenueEntity())
                {
                    chart3.DataSource = db.Revenues.ToList();
                    chart3.Series["Revenue"].XValueMember = "BookingDate";
                    chart3.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                    chart3.Series["Revenue"].YValueMembers = "TotalPaid";
                    chart3.Series["Revenue"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }

        private void LoadBookingChart()
        {
            string[] months = { "January", "Februray", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    for (int i = 1; i < 13; i++)
                    {
                        SqlCommand cmd = new SqlCommand("RetrieveYearlyBookingSummary", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Month", i));

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            chart1.Series["Bookings"].Points.AddXY(months[i - 1], reader["TotalBookings"]);
                        }

                        reader.Close();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
