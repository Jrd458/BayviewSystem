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

namespace BayViewHotel.Forms
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            RetrieveCustomerList();
            this.ActiveControl = txtSearchCustomer;
        }

        private void txtSearchCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            RetrieveCustomerList(); // Refresh the list each time a new keystroke is detected for search function
        }

        // Retrieves customer records from tblCustomer using the search bar in the customer screen.
        public void RetrieveCustomerList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    /* SQL SERVER STORED PROCEDURE
                     * 
                     * ALTER PROCEDURE [dbo].[RetrieveCustomerListByName]
	                        @Name VARCHAR(100)
                        AS
	                        SELECT
		                         CustomerID
		                        ,FirstName + ' ' + LastName AS 'CustomerFullName'
		                        ,AddressLine1 AS 'CustomerAddressStreet'
		                        ,Postcode AS 'CustomerAddressPostcode'
		                        ,ContactNo AS 'CustomerContactNo'
		                        ,EmailAddress AS 'CustomerEmail'
	                        FROM
		                        tblCustomer
	                        WHERE
		                        FirstName LIKE '%' + @Name + '%'
	                        OR
		                        LastName LIKE '%' + @Name + '%'
                     * 
                     */

                    SqlCommand cmd = new SqlCommand("RetrieveCustomerListByName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", txtSearchCustomer.Text));

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("CustomerID");
                    dt.Columns.Add("CustomerFullName");
                    dt.Columns.Add("CustomerAddressStreet");
                    dt.Columns.Add("CustomerAddressPostcode");
                    dt.Columns.Add("CustomerContactNo");
                    dt.Columns.Add("CustomerEmail");

                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        row["CustomerID"] = reader["CustomerID"];
                        row["CustomerFullName"] = reader["CustomerFullName"];
                        row["CustomerAddressStreet"] = reader["CustomerAddressStreet"];
                        row["CustomerAddressPostcode"] = reader["CustomerAddressPostcode"];
                        row["CustomerContactNo"] = reader["CustomerContactNo"];
                        row["CustomerEmail"] = reader["CustomerEmail"];
                        dt.Rows.Add(row); // Go through each record and add them to data table
                    }

                    // Set to more readable column titles
                    dt.Columns["CustomerFullName"].ColumnName = "Full Name";
                    dt.Columns["CustomerAddressStreet"].ColumnName = "Street Address";
                    dt.Columns["CustomerAddressPostcode"].ColumnName = "Postcode";
                    dt.Columns["CustomerContactNo"].ColumnName = "Contact Number";
                    dt.Columns["CustomerEmail"].ColumnName = "E-Mail";

                    dataGridCustomer.DataSource = dt; // Puts columns into data grid view
                    dataGridCustomer.Columns["CustomerID"].Visible = false; // Hide irrelevant column but keep it hidden so that we can still grab the customer ID

                    con.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Open add new customer form
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            PopupAddCustomer form = new PopupAddCustomer(this, null);
            form.ShowDialog();
        }

        // Event to detect double click on a customer which opens form to edit/manage them
        private void dataGridCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridCustomer.Rows[e.RowIndex];
            string customerId = Convert.ToString(selectedRow.Cells["CustomerID"].Value);

            PopupEditCustomer editForm = new PopupEditCustomer(this, customerId);
            editForm.ShowDialog();
        }
    }
}
