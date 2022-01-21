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
            // Load in the chart data
            LoadBookingChart();
            LoadRoomTypeDistributionChart();
            LoadRevenueChart();
        }

        // Bar chart showing total bookings for months of the year
        private void LoadBookingChart()
        {
            string[] months = { "January", "Februray", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    /* SQL SERVER STORED PROCEDURE
                     * 
                     * ALTER PROCEDURE [dbo].[RetrieveYearlyBookingSummary]
	                        @Month		INT
                        AS
	                        SELECT
		                        COUNT(*) AS TotalBookings
	                        FROM
		                        tblBooking b
	                        WHERE
		                        MONTH(b.CheckInDate) = @Month
		                        AND
		                        YEAR(b.CheckInDate) = YEAR(GETDATE())
                     */

                    // Look through each month by retrieving total bookings for every month
                    for (int i = 1; i < 13; i++)
                    {
                        SqlCommand cmd = new SqlCommand("RetrieveYearlyBookingSummary", con); // Call stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Month", i));

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            chart1.Series["Bookings"].Points.AddXY(months[i - 1], reader["TotalBookings"]); // Add points for each month's bookings
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

        // Pie chart for total bookings by room type
        private void LoadRoomTypeDistributionChart()
        {
            /* SQL SERVER VIEW
             * 
             * ALTER VIEW [dbo].[RoomTypeDistribution]
                AS
	                SELECT
		                 r.RoomType
		                ,COUNT(r.RoomType) AS TotalBookings
	                FROM
		                tblBooking b
	                INNER JOIN
		                tblRoom r
		                ON b.RoomID = r.RoomID
	                GROUP BY
		                r.RoomType
             * 
             */

            try
            {
                using (BayViewHotelEntities db = new BayViewHotelEntities())
                {
                    // Uses data entity connected to SQL view table
                    chart2.DataSource = db.RoomTypeDistributions.ToList();
                    chart2.Series["Room Type"].XValueMember = "RoomType";
                    chart2.Series["Room Type"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                    chart2.Series["Room Type"].YValueMembers = "TotalBookings";
                    chart2.Series["Room Type"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        // Line chart for revenue for the month
        private void LoadRevenueChart()
        {
            /* SQL SERVER VIEW
             *  
             * ALTER VIEW [dbo].[Revenue]
                AS
	                SELECT
		                 b.CheckInDate AS BookingDate
		                ,i.TotalCost AS TotalPaid
	                FROM
		                tblBooking b
	                LEFT JOIN
		                tblInvoice i
		                ON b.BookingID = i.BookingID
	                WHERE
		                MONTH(b.CheckInDate) = MONTH(GETDATE())
		                AND
		                YEAR(b.CheckInDate) = YEAR(GETDATE())
             * 
             */
            try
            {
                using (BayViewHotelRevenueEntity db = new BayViewHotelRevenueEntity())
                {
                    // Uses data entity connected to SQL view table
                    chart3.DataSource = db.Revenues.ToList();
                    chart3.Series["Revenue"].XValueMember = "BookingDate";
                    chart3.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                    chart3.Series["Revenue"].YValueMembers = "TotalPaid";
                    chart3.Series["Revenue"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
    }
}
