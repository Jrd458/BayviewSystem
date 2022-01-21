﻿using System;
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
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSearchBookingNumber;
            RetrieveCustomerList();
        }

        private void txtSearchBookingNumber_KeyUp(object sender, KeyEventArgs e)
        {
            RetrieveCustomerList(); // Refresh the list each time a new keystroke is detected for search function
        }

        // Retrieves invoice records from tblInvoice using the search bar in the invoicing screen.
        public void RetrieveCustomerList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM Invoicing WHERE InvoiceID LIKE '%' + @param + '%'", con);
                    cmd.Parameters.Add(new SqlParameter("@param", txtSearchBookingNumber.Text)); // Inserts search box text

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("InvoiceID");
                    dt.Columns.Add("BookingID");
                    dt.Columns.Add("CustomerName");
                    dt.Columns.Add("TotalCost");

                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        row["InvoiceID"] = reader["InvoiceID"];
                        row["BookingID"] = reader["BookingID"];
                        row["CustomerName"] = reader["CustomerName"];
                        row["TotalCost"] = reader["TotalCost"];
                        dt.Rows.Add(row); // Go through each record and add them to data table
                    }

                    // Set to more readable column titles
                    dt.Columns["InvoiceID"].ColumnName = "Invoice Number";
                    dt.Columns["BookingID"].ColumnName = "Booking Reference";
                    dt.Columns["CustomerName"].ColumnName = "Customer Full Name";
                    dt.Columns["TotalCost"].ColumnName = "Final Cost";

                    dataGridInvoicing.DataSource = dt; // Puts columns into data grid view

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
    }
}
