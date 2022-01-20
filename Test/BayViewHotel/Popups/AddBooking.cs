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
    public partial class AddBooking : Form
    {
        string _startDate;
        string _endDate;

        public AddBooking(string StartDate, string EndDate)
        {
            InitializeComponent();
            _startDate = StartDate;
            _endDate = EndDate;
        }

        private void AddBooking_Load(object sender, EventArgs e)
        {
            if (_startDate == "" || _endDate == "")
            {
                dateStart.Value = Convert.ToDateTime(DateTime.Now.ToString());
                dateEnd.Value = dateStart.Value.AddDays(1);
            } else
            {
                dateStart.Value = Convert.ToDateTime(_startDate);
                dateEnd.Value = Convert.ToDateTime(_endDate);
            }
        }

        private void lblSelectedCustomer_Click(object sender, EventArgs e)
        {

        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateStart.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                dateStart.Value = DateTime.Now;

            if (Convert.ToDateTime(dateStart.Value.ToString()) >= Convert.ToDateTime(dateEnd.Value.ToString()))
                dateEnd.Value = dateStart.Value.AddDays(1);
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                dateEnd.Value = DateTime.Now.AddDays(1);

            if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(dateStart.Value.ToString()))
                dateStart.Value = dateEnd.Value.AddDays(-1);
        }

        private void btnBookingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBookingSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            int roomId = 0;
            int customerId = 0;
            int staffId = 0;
            bool breakfast = false;
            int adults = 0;
            int children = 0;
            string dateStartString = dateStart.Value.ToString();
            string dateEndString = dateEnd.Value.ToString();
            string status = "";

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO tblBooking (RoomID, CustomerID, StaffID, Breakfast, NoOfAdults, NoOfChildren, CheckInDate, CheckOutDate, Status) VALUES (@roomid, @customerid, @staffid, @breakfast, @adults, @children, @checkindate, @checkoutdate, @status)", con);

                cmd.Parameters.AddWithValue("@roomid", roomId);
                cmd.Parameters.AddWithValue("@customerid", customerId);
                cmd.Parameters.AddWithValue("@staffid", staffId);
                cmd.Parameters.AddWithValue("@breakfast", breakfast);
                cmd.Parameters.AddWithValue("@adults", adults);
                cmd.Parameters.AddWithValue("@children", children);
                cmd.Parameters.AddWithValue("@checkindate", Convert.ToDateTime(dateStartString));
                cmd.Parameters.AddWithValue("@checkoutdate", Convert.ToDateTime(dateEndString));
                cmd.Parameters.AddWithValue("@status", status);

                //cmd.ExecuteScalar();
                MessageBox.Show("For testing purposes only data has not been saved. Closing", "Testing");

                con.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
