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
            // TODO: This line of code loads data into the 'bayViewHotelDataSet.CustomerBooking' table. You can move, or remove it, as needed.
            this.customerBookingTableAdapter.Fill(this.bayViewHotelDataSet.CustomerBooking);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["BtnClmManageBooking"].Index && e.RowIndex >= 0)
            {
                if (IsCancelledBooking(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Failed to load booking: This booking has been cancelled.", "Error");
                } else
                {
                    PopupManageBooking formManageBooking = new PopupManageBooking(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), "ViewBookings", null);
                    formManageBooking.ShowDialog();
                }
            }
        }

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
                            if (reader["Status"].ToString() == "Cancelled")
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
