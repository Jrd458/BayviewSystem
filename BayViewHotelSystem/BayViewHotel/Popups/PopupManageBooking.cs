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
        PopupManageRoom _master;

        public int _selectedCustomerId;

        string _parentScreen;
        string _bookingId;

        int _totalCost = 0;
        bool fillingData = true;

        public PopupManageBooking(string bookingId, string parentScreen, PopupManageRoom master)
        {
            InitializeComponent();
            _bookingId = bookingId;
            _parentScreen = parentScreen;
            _master = master;
        }

        private void PopupManageBooking_Load(object sender, EventArgs e)
        {
            SetBookingData(Convert.ToInt32(_bookingId)); // Load booking data into inputs using a booking ID
            comboRoomNo.Enabled = false; // Disable the room number selector unless other fields are changed
            fillingData = false; // If set to false then validation techniques won't apply again until it's set to true which is after the data is loaded into the inputs, as when the data was set it would count as a 'value changed' event which causes issues
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
                    FillRoomNoData(); // Temporarily grabs every room number into a list so that we can put the actual room number into the combo box, if the order is changed it will update to only AVAILABLE rooms

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

        // Grab every room number and fill into room number selector
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
                comboRoomNo.Enabled = true; // If data gets changed then clear outdated inputs and tell them to re-select a room/guests
                lblChooseRoomInfo.Visible = true;
                ResetOccupancyCounters();
                GrabComboBoxData();
            }
        }

        private void comboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                comboRoomNo.Enabled = true; // If data gets changed then clear outdated inputs and tell them to re-select a room/guests
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

        // Adult guests selector validation to make sure a room is selected first
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
                    ValidateInputs(); // Check the room type validation
                    CalculateTotalCost(); // Recalculate costs
                }
            }
        }

        // Child counter will only enable following at least 1 adult guest entered
        private void numChildren_ValueChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                ValidateInputs(); // Check the room type validation
                CalculateTotalCost();
            }
        }

        // If breakfast is added recalculate costs
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

        // Main validation for the adult/child counters depending on the room type that is selected to follow max/min guests
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

        // Generate room number list with available rooms
        private void GrabComboBoxData()
        {
            comboRoomNo.Items.Clear();
            comboRoomNo.Text = "";

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    /* SQL SERVER STORED PROCEDURE
                     * 
                     * ALTER PROCEDURE [dbo].[RetrieveAvailableRoomNoList]
	                         @StartDate			DATE
	                        ,@EndDate			DATE
	                        ,@RoomType			VARCHAR(16)
	                        ,@Disability		BIT
                        AS
	                        SELECT
		                        r.RoomNo
	                        FROM
		                        tblRoom r
	                        WHERE
		                        r.RoomID NOT IN 
		                        (
			                        SELECT
				                        RoomID 
			                        FROM 
				                        tblBooking
			                        WHERE
				                        (
					                        @StartDate <= CheckOutDate AND @StartDate >= CheckInDate
				                        OR
					                        CheckInDate <= @EndDate AND CheckInDate >= @StartDate
				                        )
				                        AND
					                        Status = 'Active'
		                        )
		                        AND
			                        r.RoomType = @RoomType
		                        AND
			                        r.Disability = @Disability
                     * 
                     */

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

        // Using SQL server stored procedure to calculate the costs
        private void CalculateTotalCost()
        {
            if ((string.IsNullOrEmpty(comboRoomType.Text) || comboRoomType.SelectedIndex == -1) // Validation check before calculating the costs to ensure all required parameters are filled
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

                        /* SQL SERVER STORED PROCEDURE
                         * 
                         * ALTER PROCEDURE [dbo].[CostCalculation]
	                             @NoAdults			INT
	                            ,@NoChild			INT
	                            ,@RoomType			VarChar(16)
	                            ,@Breakfast			BIT
	                            ,@StartDate			Date
	                            ,@EndDate			Date
                            AS
	                            DECLARE
	                            @NoDays				INT		=  DATEDIFF(day, @StartDate, @EndDate)
	                            SELECT
	                            @NoDays * 
		                            CASE 
			                            WHEN (@RoomType = 'Single') THEN 
				                            CASE 
					                            WHEN(@Breakfast = 1) THEN 75
					                            ELSE 70
					                            END
			                            WHEN (@RoomType = 'Double') THEN
				                            CASE
					                            WHEN(@NoAdults = 1 AND @NoChild = 0 AND  @Breakfast = 1 ) THEN 95
					                            WHEN(@NoAdults = 1 AND @NoChild = 0 AND  @Breakfast = 0 ) THEN 90
					                            WHEN(@NoAdults = 2 And @Breakfast = 1) THEN 120
					                            WHEN(@NoAdults = 2 And @Breakfast = 0) THEN 110
					                            WHEN(@NoAdults = 1 AND @NoChild = 1 And @Breakfast = 1) THEN 120
					                            WHEN(@NoAdults = 1 AND @NoChild = 1 And @Breakfast = 0) THEN 110
					                            END
			                            WHEN (@RoomType = 'Family') THEN
				                            CASE 
					                            WHEN(@Breakfast = 1) THEN 175
					                            ELSE 160
					                            END
			                            END
	                            AS Cost
                         * 
                         */

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
                                    int? cost = reader["Cost"] as int?; // Convert to int, could've been decimal
                                    lblTotalCost.Text = "£" + cost.ToString() + ".00"; // Set to label. Adding pence to the end as doesn't support decimals so is required
                                    _totalCost = Convert.ToInt32(cost); // Set global variable so it can be accessed in other functions
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

        // Open customer selector
        public void SetCustomerSelectionLabel(int customerId)
        {
            lblSelectedCustomer.Text = GetCustNameFromCustomerId(customerId); // Set the label to show customer name once selected
        }

        // Returns full customer name to show in booking form
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

        // Date picker validation, only allows date selections which make sense
        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (!fillingData)
            {
                if (Convert.ToDateTime(dateStart.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                    dateStart.Value = DateTime.Now;

                if (Convert.ToDateTime(dateStart.Value.ToString()) >= Convert.ToDateTime(dateEnd.Value.ToString()))
                    dateEnd.Value = dateStart.Value.AddDays(1);

                chkDisability_CheckedChanged(null, null); // Short cut to make sure the room number selection must be re completed so that it rechecks that dates were available.

                CalculateTotalCost(); // Recalculate
            }    
        }

        // More date picker validation
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

            if ((!string.IsNullOrEmpty(comboRoomType.Text) && comboRoomType.SelectedIndex != -1) // Booking input validation
                && (!string.IsNullOrEmpty(comboRoomNo.Text) || comboRoomNo.SelectedIndex != -1)
                && !(numAdults.Value + numChildren.Value < 1))
            {
                try
                {
                    // Retrieve all required fields before updating to tblBooking
                    int roomId = GetRoomID(Convert.ToInt32(comboRoomNo.Text));
                    int bookingId = Convert.ToInt32(_bookingId);
                    bool breakfast = chkBreakfast.Checked;
                    int adults = Convert.ToInt32(numAdults.Value);
                    int children = Convert.ToInt32(numChildren.Value);
                    string dateStartString = dateStart.Value.ToString();
                    string dateEndString = dateEnd.Value.ToString();

                    if (roomId != 0)
                    {
                        try
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand(@"UPDATE tblBooking SET RoomID = @roomid, Breakfast = @breakfast, NoOfAdult = @adults, NoOfChildren = @children, CheckInDate = @checkindate, CheckOutDate = @checkoutdate WHERE BookingID = @bookingid", con);

                            cmd.Parameters.AddWithValue("@roomid", roomId);
                            cmd.Parameters.AddWithValue("@breakfast", breakfast);
                            cmd.Parameters.AddWithValue("@adults", adults);
                            cmd.Parameters.AddWithValue("@children", children);
                            cmd.Parameters.AddWithValue("@checkindate", Convert.ToDateTime(dateStartString));
                            cmd.Parameters.AddWithValue("@checkoutdate", Convert.ToDateTime(dateEndString));
                            cmd.Parameters.AddWithValue("@bookingid", _bookingId);

                            cmd.ExecuteScalar();

                            UpdateInvoice(bookingId); // Update invoice for the booking with new costs etc

                            con.Close();

                            if (_parentScreen == "ManageRoom")
                            {
                                _master.LoadBookings();
                            }
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

        // Use the customer ID to update the invoice for the booking
        private void UpdateInvoice(int bookingId)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            if (bookingId != 0) // Ensure there were no errors grabbing the customer ID
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

        // Return the invoice ID from the booking in tblBooking
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

        // Grabs the room record ID using the room number that was selected
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

        // Return room number from room ID
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

        // Grab room type from room ID
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

        // When menu item is clicked for canceling booking, prompt with a yes/no option
        private void cancelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bookingId = Convert.ToInt32(_bookingId);

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?" + Environment.NewLine + Environment.NewLine + "This action is irreversible.", "Continue?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) // If yes is selected set booking to 'cancelled' so that it doesn't show as an active order anymore
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
                        
                        if (_parentScreen == "ManageRoom") // If come from the manange booking screen refresh the booking list to show updated status
                        {
                            _master.LoadBookings();
                        }

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

        // Allows user to click button instead of the cancel booking menu item
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            cancelBookingToolStripMenuItem_Click(null, null);
        }
    }
}
