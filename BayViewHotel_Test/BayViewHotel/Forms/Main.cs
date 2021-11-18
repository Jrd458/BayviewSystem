using BayViewHotel.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayViewHotel
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelViewForm.Controls.Add(childForm);
            panelViewForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            btnMenuHome_Click(null, null);
        }

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            openChildForm(new Home());
        }

        private void btnMenuBooking_Click(object sender, EventArgs e)
        {
            openChildForm(new Booking());
        }
    }
}
