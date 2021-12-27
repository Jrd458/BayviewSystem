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
    public partial class ManageBooking : Form
    {
        string bookingId;

        public ManageBooking(string bookingId)
        {
            InitializeComponent();
            this.bookingId = bookingId;
        }

        private void ManageBooking_Load(object sender, EventArgs e)
        {
            this.Text = "Viewing booking for Ref#" + bookingId;
        }
    }
}
