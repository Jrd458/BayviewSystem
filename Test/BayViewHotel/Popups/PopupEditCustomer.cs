using BayViewHotel.Forms;
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
    public partial class PopupEditCustomer : Form
    {
        private Customers _master;  // Allows us to call functions/set variables in booking form
        private string _customerId;

        public PopupEditCustomer(Customers master, string customerId)
        {
            InitializeComponent();
            _master = master;
            _customerId = customerId;
        }

        private void PopupEditCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "Viewing customer ID #" + _customerId; // Set form title and label for current customer
            lblEditCustomer.Text = "Manage Customer (ID: " + _customerId + ")";

            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT Title,FirstName,LastName,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Postcode,ContactNo,EmailAddress,DateOfBirth FROM tblCustomer WHERE CustomerID = @customerid", con);
                cmd.Parameters.AddWithValue("@customerid", _customerId);

                SqlDataReader reader = cmd.ExecuteReader(); // Get customer data

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Input customer data from table
                        comboTitle.SelectedIndex = comboTitle.FindStringExact(Convert.ToString(reader["Title"]));
                        txtFirstName.Text = Convert.ToString(reader["FirstName"]);
                        txtLastName.Text = Convert.ToString(reader["LastName"]);
                        txtAddressLine1.Text = Convert.ToString(reader["AddressLine1"]);
                        txtAddressLine2.Text = Convert.ToString(reader["AddressLine2"]);
                        txtAddressLine3.Text = Convert.ToString(reader["AddressLine3"]);
                        txtAddressLine4.Text = Convert.ToString(reader["AddressLine4"]);
                        txtPostcode.Text = Convert.ToString(reader["Postcode"]);
                        txtContactNo.Text = Convert.ToString(reader["ContactNo"]);
                        txtEmail.Text = Convert.ToString(reader["EmailAddress"]);
                        dateDateOfBirth.Value = Convert.ToDateTime(reader["DateOfBirth"]);
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

        // Main save customer function
        private void btnCustomerSubmit_Click(object sender, EventArgs e)
        {
            if (comboTitle.SelectedItem != null && // Validation for details section
                txtFirstName.Text != "" &&
                txtLastName.Text != "" &&
                txtContactNo.Text != "" &&
                txtEmail.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE tblCustomer SET Title = @title, FirstName = @firstname, LastName = @lastname, AddressLine1 = @addressline1, AddressLine2 = @addressline2, AddressLine3 = @addressline3, AddressLine4 = @addressline4, Postcode = @postcode, ContactNo = @contactno, EmailAddress = @emailaddress, DateOfBirth = @dob WHERE CustomerID = @customerid", con);

                    // Grabs inputs and adds to insert parameters
                    cmd.Parameters.AddWithValue("@customerid", _customerId);
                    cmd.Parameters.AddWithValue("@title", comboTitle.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@dob", dateDateOfBirth.Value.Date);
                    cmd.Parameters.AddWithValue("@emailaddress", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@addressline1", txtAddressLine1.Text);
                    cmd.Parameters.AddWithValue("@addressline2", txtAddressLine2.Text);
                    cmd.Parameters.AddWithValue("@addressline3", txtAddressLine3.Text);
                    cmd.Parameters.AddWithValue("@addressline4", txtAddressLine4.Text);
                    cmd.Parameters.AddWithValue("@postcode", txtPostcode.Text);

                    cmd.ExecuteScalar();

                    con.Close();
                    _master.RetrieveCustomerList(); // Refresh the customer list in customer screen before form shuts
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                lblValidationError.Visible = true;
            }
        }

        private void btnCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Delete an account from the system
        private void btnCloseAccount_Click(object sender, EventArgs e)
        {
            // Yes/no popup to confirm deletion
            DialogResult dialogResult = MessageBox.Show("You are about to close this account which will erase all details of this customer from the hotel system." + Environment.NewLine + Environment.NewLine + "Are you sure you want to continue?", "Close Account", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"DELETE FROM tblCustomer WHERE CustomerID = @customerid", con);

                    cmd.Parameters.AddWithValue("@customerid", _customerId);

                    cmd.ExecuteScalar();

                    con.Close();
                    _master.RetrieveCustomerList(); // Refresh the list after deletion
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Create a booking for this specific customer
        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            AddBooking form = new AddBooking("", "", _customerId); // Input current customer ID which is loaded into the booking form
            form.ShowDialog();
        }
    }
}
