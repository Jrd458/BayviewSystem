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
            // TODO: This line of code loads data into the 'bayViewHotelDataSet.CustomerBooking' table. You can move, or remove it, as needed.
            this.customerBookingTableAdapter.Fill(this.bayViewHotelDataSet.CustomerBooking);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["BtnClmManageBooking"].Index && e.RowIndex >= 0)
            {
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                ManageBooking formManageBooking = new ManageBooking(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                formManageBooking.ShowDialog();
            }
        }
    }
}
