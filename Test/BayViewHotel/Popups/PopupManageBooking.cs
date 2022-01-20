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
    public partial class PopupManageBooking : Form
    {
        public int _selectedCustomerId;
        string _bookingId;

        int _totalCost = 0;

        bool fillingData = true;

        public PopupManageBooking(string bookingId)
        {
            InitializeComponent();
            _bookingId = bookingId;
        }

        private void PopupManageBooking_Load(object sender, EventArgs e)
        {
            SetBookingData(Convert.ToInt32(_bookingId));
            comboRoomNo.Enabled = false;
            fillingData = false;
            CalculateTotalCost();
        }

        private void SetBookingData(int bookingId)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT * FROM tblBooking WHERE BookingID = @bookingid", con);
                cmd.Parameters.AddWithValue("@bookingid", bookingId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    FillRoomNoData();

                    while (reader.Read())
                    {
                        string roomType = GetRoomType(GetRoomID(GetRoomNo(Convert.ToInt32(reader["RoomID"]))));
                        string roomNo = GetRoomNo(Convert.ToInt32(reader["RoomID"])).ToString();

                        dateStart.Value = Convert.ToDateTime(reader["CheckInDate"]);
                        dateEnd.Value = Convert.ToDateTime(reader["CheckOutDate"]);
                        chkDisability.Checked = Convert.ToBoolean(reader["Breakfast"]);
                        comboRoomType.SelectedIndex = comboRoomType.FindStringExact(roomType);
                        comboRoomNo.SelectedIndex = comboRoomNo.FindStringExact(roomNo);
                        numAdults.Value = Convert.ToInt32(reader["NoOfAdult"]);
                        numChildren.Value = Convert.ToInt32(reader["NoOfChildren"]);
                        chkBreakfast.Checked = Convert.ToBoolean(reader["Breakfast"]);

                        if (numChildren.Value > 0)
                        {
                            numChildren.Enabled = true;
                        }

                        SetCustomerSelectionLabel(Convert.ToInt32(reader["CustomerID"]));
                    }
                }
                else
                {
                    MessageBox.Show("Failed to grab booking data.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void FillRoomNoData()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT RoomNo FROM tblRoom", con);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboRoomNo.Items.Add(reader["RoomNo"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Failed to grab room number data.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void chkDisability_CheckedChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                comboRoomNo.Enabled = true;
                lblChooseRoomInfo.Visible = true;
                ResetOccupancyCounters();
                GrabComboBoxData();
            }
        }

        private void comboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                comboRoomNo.Enabled = true;
                lblChooseRoomInfo.Visible = true;
                ResetOccupancyCounters();
                GrabComboBoxData();
            }
        }

        private void comboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                lblChooseRoomInfo.Visible = false;
                lblPersonsError.Visible = false;
                ResetOccupancyCounters();
                CalculateTotalCost();
            }
        }

        private void numAdults_ValueChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                if (string.IsNullOrEmpty(comboRoomType.Text) || comboRoomType.SelectedIndex == -1 || string.IsNullOrEmpty(comboRoomNo.Text) || comboRoomNo.SelectedIndex == -1)
                {
                    ResetOccupancyCounters();

                    lblPersonsError.Visible = true;
                }
                else
                {
                    ValidateInputs();
                    CalculateTotalCost();
                }
            }
        }

        private void numChildren_ValueChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                ValidateInputs();
                CalculateTotalCost();
            }
        }

        private void chkBreakfast_CheckedChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                CalculateTotalCost();
            }
        }

        private void ResetOccupancyCounters()
        {
            numAdults.Value = 0;
            numChildren.Value = 0;
        }

        private void ValidateInputs()
        {
            if (numAdults.Value < 1)
            {
                numChildren.Value = 0;
                numChildren.Enabled = false;
            }
            else
            {
                if (numChildren.Value > 0 && numAdults.Value < 1)
                {
                    numChildren.Value = 0;
                    numChildren.Enabled = false;
                }
                else
                {
                    numChildren.Enabled = true;
                }
            }

            if (comboRoomType.Text == "Single")
            {
                if (numAdults.Value > 1 || (numAdults.Value == 1 && numChildren.Value > 0))
                {
                    numAdults.Value = 1;
                    numChildren.Value = 0;
                    MessageBox.Show("Single rooms have a maximum occupancy of 1 Adult.", "Error");
                }
            }

            if (comboRoomType.Text == "Double")
            {
                if (numAdults.Value > 2)
                {
                    numAdults.Value = 2;
                    MessageBox.Show("Double rooms have a maximum occupancy of 1 Adult and 1 Child or 2 Adults.", "Error");
                }
                if (numAdults.Value > 1 && numChildren.Value > 0)
                {
                    numAdults.Value = 2;
                    numChildren.Value = 0;
                    MessageBox.Show("Double rooms have a maximum occupancy of 1 Adult and 1 Child or 2 Adults.", "Error");
                }
                if (numAdults.Value == 1 && numChildren.Value > 1)
                {
                    numAdults.Value = 1;
                    numChildren.Value = 1;
                    MessageBox.Show("Double rooms have a maximum occupancy of 1 Adult and 1 Child or 2 Adults.", "Error");
                }
            }

            if (comboRoomType.Text == "Family")
            {
                if (numChildren.Value > 3)
                {
                    numAdults.Value = 1;
                    numChildren.Value = 3;
                    MessageBox.Show("Family rooms have a maximum occupancy of 4 Adults or Children, with at least 1 accompanying Adult.", "Error");
                }
                if (numAdults.Value + numChildren.Value > 4)
                {
                    if (numAdults.Value >= numChildren.Value)
                    {
                        numAdults.Value -= 1;
                    } else
                    {
                        numChildren.Value -= 1;
                    }
                    MessageBox.Show("Family rooms have a maximum occupancy of 4 Adults or Children, with at least 1 accompanying Adult.", "Error");
                }
            }
        }

        private void GrabComboBoxData()
        {
            comboRoomNo.Items.Clear();
            comboRoomNo.Text = "";

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("RetrieveAvailableRoomNoList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StartDate", Convert.ToDateTime(dateStart.Value.ToString("dd/MM/yyyy"))));
                    cmd.Parameters.Add(new SqlParameter("@EndDate", Convert.ToDateTime(dateEnd.Value.ToString("dd/MM/yyyy"))));
                    cmd.Parameters.Add(new SqlParameter("@RoomType", comboRoomType.Text));
                    cmd.Parameters.Add(new SqlParameter("@Disability", chkDisability.Checked));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboRoomNo.Items.Add(reader["RoomNo"]);
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void CalculateTotalCost()
        {
            if ((string.IsNullOrEmpty(comboRoomType.Text) || comboRoomType.SelectedIndex == -1)
                || (string.IsNullOrEmpty(comboRoomNo.Text) || comboRoomNo.SelectedIndex == -1)
                || (numAdults.Value + numChildren.Value < 1))
            {
                lblTotalCost.Text = "£0.00";

            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("CostCalculation", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@NoAdults", numAdults.Value));
                        cmd.Parameters.Add(new SqlParameter("@NoChild", numChildren.Value));
                        cmd.Parameters.Add(new SqlParameter("@RoomType", comboRoomType.Text));
                        cmd.Parameters.Add(new SqlParameter("@Breakfast", chkBreakfast.Checked));
                        cmd.Parameters.Add(new SqlParameter("@StartDate", Convert.ToDateTime(dateStart.Value.ToString("dd/MM/yyyy"))));
                        cmd.Parameters.Add(new SqlParameter("@EndDate", Convert.ToDateTime(dateEnd.Value.ToString("dd/MM/yyyy"))));

                        SqlDataReader reader = cmd.ExecuteReader();

                        int count = 0;

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (count == 0)
                                {
                                    int? cost = reader["Cost"] as int?;
                                    lblTotalCost.Text = "£" + cost.ToString() + ".00";
                                    _totalCost = Convert.ToInt32(cost);
                                }

                                count++;
                            }
                        }

                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public void SetCustomerSelectionLabel(int customerId)
        {
            lblSelectedCustomer.Text = GetCustNameFromCustomerId(customerId);
        }

        private string GetCustNameFromCustomerId(int customerId)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            con.Open();

            string result = null;

            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT FirstName + ' ' + LastName AS 'CustomerName' FROM tblCustomer WHERE CustomerID = @customerid", con);
                cmd.Parameters.AddWithValue("@customerid", customerId);

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

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                if (Convert.ToDateTime(dateStart.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                    dateStart.Value = DateTime.Now;

                if (Convert.ToDateTime(dateStart.Value.ToString()) >= Convert.ToDateTime(dateEnd.Value.ToString()))
                    dateEnd.Value = dateStart.Value.AddDays(1);

                chkDisability_CheckedChanged(null, null);

                CalculateTotalCost();
            }    
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                    dateEnd.Value = DateTime.Now.AddDays(1);

                if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(dateStart.Value.ToString()))
                    dateStart.Value = dateEnd.Value.AddDays(-1);

                chkDisability_CheckedChanged(null, null);

                CalculateTotalCost();
            }
        }

        private void btnBookingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBookingSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            if ((!string.IsNullOrEmpty(comboRoomType.Text) && comboRoomType.SelectedIndex != -1)
                && (!string.IsNullOrEmpty(comboRoomNo.Text) || comboRoomNo.SelectedIndex != -1)
                && !(numAdults.Value + numChildren.Value < 1))
            {
                try
                {
                    int roomId = GetRoomID(Convert.ToInt32(comboRoomNo.Text));
                    //int customerId = _selectedCustomerId;
                    //int staffId = Properties.Settings.Default.StaffID;
                    int bookingId = Convert.ToInt32(_bookingId);
                    bool breakfast = chkBreakfast.Checked;
                    int adults = Convert.ToInt32(numAdults.Value);
                    int children = Convert.ToInt32(numChildren.Value);
                    string dateStartString = dateStart.Value.ToString();
                    string dateEndString = dateEnd.Value.ToString();
                    //string status = "Active";

                    if (roomId != 0)
                    {
                        try
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand(@"UPDATE tblBooking SET RoomID = @roomid, Breakfast = @breakfast, NoOfAdult = @adults, NoOfChildren = @children, CheckInDate = @checkindate, CheckOutDate = @checkoutdate WHERE BookingID = @bookingid", con);

                            cmd.Parameters.AddWithValue("@roomid", roomId);
                            //cmd.Parameters.AddWithValue("@customerid", customerId);
                            //cmd.Parameters.AddWithValue("@staffid", staffId);
                            cmd.Parameters.AddWithValue("@breakfast", breakfast);
                            cmd.Parameters.AddWithValue("@adults", adults);
                            cmd.Parameters.AddWithValue("@children", children);
                            cmd.Parameters.AddWithValue("@checkindate", Convert.ToDateTime(dateStartString));
                            cmd.Parameters.AddWithValue("@checkoutdate", Convert.ToDateTime(dateEndString));
                            cmd.Parameters.AddWithValue("@bookingid", _bookingId);
                            //cmd.Parameters.AddWithValue("@status", "Active");

                            cmd.ExecuteScalar();

                            UpdateInvoice(bookingId);

                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a customer before proceeding.", "Error");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error");
                }

            }
            else
            {
                MessageBox.Show("You must complete all required fields before proceeding.", "Error");
            }
        }

        private void UpdateInvoice(int bookingId)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            if (bookingId != 0)
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE tblInvoice SET TotalCost = @totalcost WHERE InvoiceID = @invoiceid", con);

                    cmd.Parameters.AddWithValue("@totalcost", _totalCost);
                    cmd.Parameters.AddWithValue("@invoiceid", GetInvoiceID(bookingId));

                    cmd.ExecuteScalar();

                    con.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Failed while trying to generate invoice.", "Error");
            }
        }

        private int GetInvoiceID(int bookingId)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT i.InvoiceID FROM tblInvoice i INNER JOIN tblBooking b ON b.BookingID = i.BookingID WHERE i.BookingID = @bookingid", con);
                    cmd.Parameters.AddWithValue("@bookingid", bookingId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = Convert.ToInt32(reader["InvoiceID"]);
                        }
                    }
                    else
                    {
                        result = 0;
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }

        private int GetBookingID(int customerId)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 BookingID FROM tblBooking WHERE CustomerID = @customerid ORDER BY BookingID DESC", con);
                    cmd.Parameters.AddWithValue("@customerid", customerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = Convert.ToInt32(reader["BookingID"]);
                        }
                    }
                    else
                    {
                        result = 0;
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }

        private int GetRoomID(int roomNo)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT RoomID FROM tblRoom WHERE RoomNo = @roomno", con);
                    cmd.Parameters.AddWithValue("@roomno", roomNo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = Convert.ToInt32(reader["RoomID"]);
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }

        private int GetRoomNo(int roomId)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT RoomNo FROM tblRoom WHERE RoomID = @roomid", con);
                    cmd.Parameters.AddWithValue("@roomid", roomId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = Convert.ToInt32(reader["RoomNo"]);
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }

        private string GetRoomType(int roomId)
        {
            string result = "";

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT RoomType FROM tblRoom WHERE RoomID = @roomid", con);
                    cmd.Parameters.AddWithValue("@roomid", roomId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = reader["RoomType"].ToString();
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }

        private void cancelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bookingId = Convert.ToInt32(_bookingId);

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?" + Environment.NewLine + Environment.NewLine + "This action is irreversible.", "Continue?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

                if (bookingId != 0)
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(@"UPDATE tblBooking SET Status = 'Cancelled' WHERE BookingID = @bookingid", con);

                        cmd.Parameters.AddWithValue("@bookingid", bookingId);

                        cmd.ExecuteScalar();

                        con.Close();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Failed while trying to set booking to cancelled.", "Error");
                }
            }
        }
    }
}
