using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            // TODO: This line of code loads data into the 'bayViewHotelDataSet.tblBooking' table. You can move, or remove it, as needed.
            this.tblBookingTableAdapter.Fill(this.bayViewHotelDataSet.tblBooking);

        }
    }
}
