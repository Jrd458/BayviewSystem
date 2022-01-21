using BayViewHotel.Popups;
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

namespace BayViewHotel.Forms
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            // Default dates to 1 night stay starting with today's date
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now.AddDays(1);

            RetrieveBookingSummary(); // Refresh the booking summery (available rooms and booked rooms)
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            // Validation for dates
            if (Convert.ToDateTime(dateStart.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                dateStart.Value = DateTime.Now;

            if (Convert.ToDateTime(dateStart.Value.ToString()) >= Convert.ToDateTime(dateEnd.Value.ToString()))
                dateEnd.Value = dateStart.Value.AddDays(1);

            RetrieveBookingSummary();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            // Validation for dates
            if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                dateEnd.Value = DateTime.Now.AddDays(1);

            if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(dateStart.Value.ToString()))
                dateStart.Value = dateEnd.Value.AddDays(-1);

            RetrieveBookingSummary();
        }

        // Refresh the booking summery (total available rooms and booked rooms)
        private void RetrieveBookingSummary()
        {
            int singleAvailable = 0;
            int singleUnavailable = 0;

            int doubleAvailable = 0;
            int doubleUnavailable = 0;

            int familyAvailable = 0;
            int familyUnavailable = 0;

            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("RetrieveRoomAvailabilityStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@StartDate", dateStart.Value)); // Date picker start date
                cmd.Parameters.Add(new SqlParameter("@EndDate", dateEnd.Value)); // Date picker end date

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch (reader["RoomType"])
                        {
                            case "Single":
                                if (Convert.ToBoolean(reader["Available"]))
                                {
                                    singleAvailable += 1;
                                }
                                else
                                {
                                    singleUnavailable += 1;
                                }
                                break;
                            case "Double":
                                if (Convert.ToBoolean(reader["Available"]))
                                {
                                    doubleAvailable += 1;
                                }
                                else
                                {
                                    doubleUnavailable += 1;
                                }
                                break;
                            case "Family":
                                if (Convert.ToBoolean(reader["Available"]))
                                {
                                    familyAvailable += 1;
                                }
                                else
                                {
                                    familyUnavailable += 1;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    // Update summary labels with totals
                    lblResultSingle.Text = singleUnavailable + " booked, " + singleAvailable + " available for booking";
                    lblResultDouble.Text = doubleUnavailable + " booked, " + doubleAvailable + " available for booking";
                    lblResultFamily.Text = familyUnavailable + " booked, " + familyAvailable + " available for booking";
                }
                else
                {
                    MessageBox.Show("Sorry, there was an error while retrieving room data.", "Room Availability");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        // Show form to view all bookings where they can be managed and edited
        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            ViewBookings form = new ViewBookings();
            form.ShowDialog();
        }

        // Add booking form with selected dates
        private void btnBookNow_Click(object sender, EventArgs e)
        {
            AddBooking form = new AddBooking(dateStart.Value.ToString("dd/MM/yyyy"), dateEnd.Value.ToString("dd/MM/yyyy"), null);
            form.ShowDialog();
        }
    }
}
