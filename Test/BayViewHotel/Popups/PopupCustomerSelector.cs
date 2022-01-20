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

namespace BayViewHotel.Popups
{
    public partial class PopupCustomerSelector : Form
    {
        private AddBooking _master;

        public PopupCustomerSelector(AddBooking master)
        {
            InitializeComponent();
            _master = master;
        }

        private void PopupCustomerSelector_Load(object sender, EventArgs e)
        {
            RetrieveCustomerList();
            this.ActiveControl = txtSearchCustomer;
        }

        private void txtSearchCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            RetrieveCustomerList();
        }

        public void RetrieveCustomerList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

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
                        dt.Rows.Add(row);
                    }

                    dt.Columns["CustomerFullName"].ColumnName = "Full Name";
                    dt.Columns["CustomerAddressStreet"].ColumnName = "Street Address";
                    dt.Columns["CustomerAddressPostcode"].ColumnName = "Postcode";
                    dt.Columns["CustomerContactNo"].ColumnName = "Contact Number";
                    dt.Columns["CustomerEmail"].ColumnName = "E-Mail";

                    dataGridCustomer.DataSource = dt;
                    dataGridCustomer.Columns["CustomerID"].Visible = false;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            PopupAddCustomer form = new PopupAddCustomer(null, this);
            form.ShowDialog();
        }

        private void dataGridCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridCustomer.Rows[e.RowIndex];
            string customerId = Convert.ToString(selectedRow.Cells["CustomerID"].Value);

            _master._selectedCustomerId = Convert.ToInt32(customerId);
            _master.SetCustomerSelectionLabel(Convert.ToInt32(customerId));
            this.Close();
        }
    }
}