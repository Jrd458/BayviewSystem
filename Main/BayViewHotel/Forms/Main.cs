using BayViewHotel.Forms;
using BayViewHotel.Login;
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

namespace BayViewHotel
{
    public partial class Main : Form
    {
        private Form activeForm = null;

        public Main()
        {
            InitializeComponent();
        }
        
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

        private void ResetMenuColours()
        {
            btnMenuHome.BackColor = Color.Gainsboro;
            btnMenuBooking.BackColor = Color.WhiteSmoke;
            btnMenuCustomers.BackColor = Color.Gainsboro;
            btnMenuRooms.BackColor = Color.WhiteSmoke;
            btnMenuAccounts.BackColor = Color.Gainsboro;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            btnMenuHome_Click(null, null);
        }

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            openChildForm(new Home());
            ResetMenuColours();
            btnMenuHome.BackColor = Color.DarkGray;
        }

        private void btnMenuBooking_Click(object sender, EventArgs e)
        {
            openChildForm(new Booking());
            ResetMenuColours();
            btnMenuBooking.BackColor = Color.DarkGray;
        }

        private void btnMenuCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new Customers());
            ResetMenuColours();
            btnMenuCustomers.BackColor = Color.DarkGray;
        }

        private void btnMenuRooms_Click(object sender, EventArgs e)
        {
            openChildForm(new Rooms());
            ResetMenuColours();
            btnMenuRooms.BackColor = Color.DarkGray;
        }

        private void btnMenuAccounts_Click(object sender, EventArgs e)
        {
            openChildForm(new Accounts());
            ResetMenuColours();
            btnMenuAccounts.BackColor = Color.DarkGray;
        }

        private void btnInfoBox_Click(object sender, EventArgs e)
        {
            PopupAbout aboutPopup = new PopupAbout();
            aboutPopup.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to logout?", "Signing out", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //LoginForm login = new LoginForm();
                //login.Show();
                this.Close();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
