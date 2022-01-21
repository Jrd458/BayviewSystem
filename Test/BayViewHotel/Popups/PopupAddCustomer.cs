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
    public partial class PopupAddCustomer : Form
    {
        // Allows us to call functions/set variables in booking form
        private Customers _master;
        private PopupCustomerSelector _master2;

        public PopupAddCustomer(Customers master, PopupCustomerSelector master2)
        {
            InitializeComponent();
            _master = master;
            _master2 = master2;
        }

        private void btnCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Main add customer function
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

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO tblCustomer (Title, FirstName, LastName, AddressLine1, AddressLine2, AddressLine3, AddressLine4, Postcode, ContactNo, EmailAddress, DateOfBirth) VALUES 
                                                   (@title,@firstname,@lastname,@addressline1,@addressline2,@addressline3,@addressline4,@postcode,@contactno,@emailaddress,@dob)", con);

                    // Grabs inputs and adds to insert parameters
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

                    if (_master != null) // If it's through the customer's screen then update the customer list before this form shuts
                    {
                        _master.RetrieveCustomerList();
                    } 

                    if (_master2 != null) // If added through the booking customer selector then refresh the list when it shuts
                    {
                        _master2.RetrieveCustomerList();
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } else
            {
                lblValidationError.Visible = true; // Show validation error if validation fails
            }
        }
    }
}
