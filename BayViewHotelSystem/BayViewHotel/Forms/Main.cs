using BayViewHotel.Forms;
using BayViewHotel.Login;
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

namespace BayViewHotel
{
    public partial class Main : Form
    {
        private Form activeForm = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            GenerateStaffGreeting(Properties.Settings.Default.StaffID); // Sets welcome message with custom staff name
            btnMenuHome_Click(null, null); // Loads up 'home' screen into the panel on start up
        }

        // Adding inserted form to the main panel, allows for using only a single main form to display each selected sub form within the panel
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

        // Every time a menu item is clicked it needs to reset to default colouring, for visual front end purposes only
        private void ResetMenuColours()
        {
            btnMenuHome.BackColor = Color.Gainsboro;
            btnMenuBooking.BackColor = Color.WhiteSmoke;
            btnMenuCustomers.BackColor = Color.Gainsboro;
            btnMenuRooms.BackColor = Color.WhiteSmoke;
            btnMenuAccounts.BackColor = Color.Gainsboro;
        }

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            openChildForm(new Home()); // Load form into the main panel
            ResetMenuColours();
            btnMenuHome.BackColor = Color.DarkGray;
        }

        private void btnMenuBooking_Click(object sender, EventArgs e)
        {
            openChildForm(new Booking()); // Load form into the main panel
            ResetMenuColours();
            btnMenuBooking.BackColor = Color.DarkGray;
        }

        private void btnMenuCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new Customers()); // Load form into the main panel
            ResetMenuColours();
            btnMenuCustomers.BackColor = Color.DarkGray;
        }

        private void btnMenuRooms_Click(object sender, EventArgs e)
        {
            openChildForm(new Rooms()); // Load form into the main panel
            ResetMenuColours();
            btnMenuRooms.BackColor = Color.DarkGray;
        }

        private void btnMenuAccounts_Click(object sender, EventArgs e)
        {
            openChildForm(new Accounts()); // Load form into the main panel
            ResetMenuColours();
            btnMenuAccounts.BackColor = Color.DarkGray;
        }

        // Simple about box for the program
        private void btnInfoBox_Click(object sender, EventArgs e)
        {
            PopupAbout aboutPopup = new PopupAbout();
            aboutPopup.ShowDialog();
        }

        // Logout and close main form and open login form
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to logout?", "Signing out", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes) // If yes is selected on the yes/no box
            {
                this.Close();
            }
        }

        // When the main form is shut then send to logout screen
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }

        //Select the title and the last name to generate a greeting message for the label in the main form
        private void GenerateStaffGreeting(int staffId)
        {
            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT Title, LastName FROM tblStaff WHERE StaffID = @staffid", con);
                cmd.Parameters.AddWithValue("@staffid", staffId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblStaffGreeting.Text = "WELCOME BACK, " + reader["Title"].ToString().ToUpper() + " " + reader["LastName"].ToString().ToUpper(); // Set text for label
                    }
                }
                else
                {
                    MessageBox.Show("Error occurred. Please contact your administrator.");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
