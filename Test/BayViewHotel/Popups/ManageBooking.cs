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
    public partial class ManageBooking : Form
    {
        string bookingId;

        public ManageBooking(string bookingId)
        {
            InitializeComponent();
            this.bookingId = bookingId;
        }

        private void ManageBooking_Load(object sender, EventArgs e)
        {
            this.Text = "Viewing booking for Ref#" + bookingId;
            lblBookedUnder.Text = "Booked Under: " + GetCustNameFromBookingId(bookingId);
        }

        private void chkDisability_CheckedChanged(object sender, EventArgs e)
        {
            /*********
             *  JOEL TO DO PROC
             *********/


            //SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            //con.Open();

            //string[] result = { };

            //try
            //{
            //    SqlCommand cmd = new SqlCommand(@"SELECT RoomNo FROM tblRoom WHERE ", con);
            //    cmd.Parameters.AddWithValue("@username", username);

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            result.Append(reader.GetString(0));
            //        }
            //    }
            //    else
            //    {
            //        result = null;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    result = null;
            //    MessageBox.Show(ex.Message);
            //}

            //con.Close();
            lblChooseRoomInfo.Visible = true;
        }

        private string GetCustNameFromBookingId(string bookingId)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            con.Open();

            string result = null;

            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT c.FirstName + ' ' + c.LastName AS 'CustomerName' FROM tblCustomer c INNER JOIN tblBooking b ON b.CustomerID = c.CustomerID WHERE b.BookingID = @bookingid", con);
                cmd.Parameters.AddWithValue("@bookingid", bookingId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetString(0);
                    }
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                result = null;
                MessageBox.Show(ex.Message);
            }

            return result;
        }
    }
}
