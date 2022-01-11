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
        private Customers _master;

        public PopupAddCustomer(Customers master)
        {
            InitializeComponent();
            _master = master;
        }

        private void btnCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustomerSubmit_Click(object sender, EventArgs e)
        {
            if (comboTitle.SelectedItem != null &&
                txtFirstName.Text != "" &&
                txtLastName.Text != "" &&
                txtContactNo.Text != "" &&
                //dateDateOfBirth.Value != new DateTime(1900, 1, 1) &&
                txtEmail.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO tblCustomer (Title, FirstName, LastName, AddressLine1, AddressLine2, AddressLine3, AddressLine4, Postcode, ContactNo, EmailAddress, DateOfBirth) VALUES 
                                                   (@title,@firstname,@lastname,@addressline1,@addressline2,@addressline3,@addressline4,@postcode,@contactno,@emailaddress,@dob)", con);

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
                    _master.RetrieveCustomerList();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } else
            {
                lblValidationError.Visible = true;
            }
        }
    }
}
