using BayViewHotel.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            ViewBookings form = new ViewBookings();
            form.ShowDialog();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            DateTime datetime = new DateTime(2000, 1, 1, 12, 30, 0);
            timeStart.Value = datetime;
            timeEnd.Value = datetime;
        }
    }
}
