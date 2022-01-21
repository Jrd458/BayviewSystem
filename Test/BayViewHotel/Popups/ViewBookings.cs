using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayViewHotel.Popups
{
    public partial class ViewBookings : Form
    {
        public ViewBookings()
        {
            InitializeComponent();
        }

        private void ViewBookings_Load(object sender, EventArgs e)
        {
            /* SQL SERVER VIEW
             * 
             * ALTER VIEW [dbo].[CustomerBooking] AS
	            SELECT
		             b.BookingID AS 'BookingReference'
		            ,b.CustomerID AS 'CustomerNo'
		            ,ISNULL(c.FirstName, 'Deleted Customer') AS FirstName
		            ,ISNULL(c.LastName, 'Deleted Customer') AS LastName
		            ,b.Status
		            ,b.CheckInDate AS 'CheckIn'
		            ,b.CheckOutDate AS 'CheckOut'
		            ,s.FirstName + ' ' + s.LastName AS 'CreatedByStaff'
	            FROM
		            tblBooking b
	            LEFT JOIN
		            tblCustomer c
			            ON b.CustomerID = c.CustomerID
	            LEFT JOIN
		            tblStaff s
			            ON b.StaffID = s.StaffID
             * 
             */

            // Fill the data into the data table using a data set which connects to the 'customerbooking' view in SQL server
            this.customerBookingTableAdapter.Fill(this.bayViewHotelDataSet.CustomerBooking);
        }

        // When the manage button is pressed in the last column
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["BtnClmManageBooking"].Index && e.RowIndex >= 0)
            {
                if (IsCancelledBooking(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())) // Check if it hasn't been cancelled
                {
                    MessageBox.Show("Failed to load booking: This booking has been cancelled.", "Error");
                } else
                {
                    PopupManageBooking formManageBooking = new PopupManageBooking(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), "ViewBookings", null); // Open the manage booking screen for the selected booking
                    formManageBooking.ShowDialog();
                }
            }
        }

        // Check if the booking is cancelled, just returns true/false depending on if the status is equal to active or cancelled
        private bool IsCancelledBooking(string bookingId)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT Status FROM tblBooking WHERE BookingID = @bookingid", con);
                    cmd.Parameters.AddWithValue("@bookingid", bookingId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["Status"].ToString() == "Cancelled") // Check if it's cancelled
                                result = true;
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }
    }
}
