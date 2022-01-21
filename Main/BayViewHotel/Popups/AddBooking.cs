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
    public partial class AddBooking : Form
    {
        public int _selectedCustomerId;
        string _startDate;
        string _endDate;

        int _totalCost = 0;

        public AddBooking(string StartDate, string EndDate, string importedCustomerId)
        {
            InitializeComponent();

            if (importedCustomerId != null) // If they are providing a customer ID already through the customer screen then set that as the selected customer instead, otherwise allow the staff member to select their own customer when creating a new booking
            {
                _selectedCustomerId = Convert.ToInt32(importedCustomerId);

                lblSelectedCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
                lblSelectedCustomer.ForeColor = Color.Black;
                lblSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                SetCustomerSelectionLabel(_selectedCustomerId);
            }

            _startDate = StartDate; // Set date pickers to the provided dates
            _endDate = EndDate;
        }

        private void AddBooking_Load(object sender, EventArgs e)
        {
            if (_startDate == "" || _endDate == "") // If no dates are provided then just set it to todays date and today + 1 day for the check out date
            {
                dateStart.Value = Convert.ToDateTime(DateTime.Now.ToString());
                dateEnd.Value = dateStart.Value.AddDays(1);
            } else // If we're provided a date then set the date pickers to those instead
            {
                dateStart.Value = Convert.ToDateTime(_startDate);
                dateEnd.Value = Convert.ToDateTime(_endDate);
            }

            GrabComboBoxData(); // Update the room availability data (will only show available rooms in the room picker)
        }

        private void chkDisability_CheckedChanged(object sender, EventArgs e)
        {
            lblChooseRoomInfo.Visible = true; // If they make changes they have to re-enter a room to ensure it's still available
            ResetOccupancyCounters(); // Must re-enter adult/child totals just incase they change room types as well
            GrabComboBoxData(); // Update the room availability data again
        }

        private void comboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChooseRoomInfo.Visible = true;
            ResetOccupancyCounters();
            GrabComboBoxData();
        }

        private void comboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChooseRoomInfo.Visible = false;
            lblPersonsError.Visible = false; // User must select a room first before entering guest numbers, once they have selected a room it will remove the error
            ResetOccupancyCounters();
            CalculateTotalCost(); // Recalculate the costs
        }

        // Adult guests selector validation to make sure a room is selected first
        private void numAdults_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboRoomType.Text) || comboRoomType.SelectedIndex == -1 || string.IsNullOrEmpty(comboRoomNo.Text) || comboRoomNo.SelectedIndex == -1)
            {
                ResetOccupancyCounters();

                lblPersonsError.Visible = true;
            } else
            {
                ValidateInputs(); // Check the room type validation
                CalculateTotalCost(); // Recalculate costs
            }
        }

        // Child counter will only enable following at least 1 adult guest entered
        private void numChildren_ValueChanged(object sender, EventArgs e)
        {
            ValidateInputs(); // Check the room type validation
            CalculateTotalCost();
        }

        // If breakfast is added recalculate costs
        private void chkBreakfast_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotalCost();
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
                    }
                    else
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
                    cmd.Parameters.Add(new SqlParameter("@StartDate", Convert.ToDateTime(dateStart.Value.ToString("dd/MM/yyyy")))); // Consider the entered dates in determining availability
                    cmd.Parameters.Add(new SqlParameter("@EndDate", Convert.ToDateTime(dateEnd.Value.ToString("dd/MM/yyyy"))));
                    cmd.Parameters.Add(new SqlParameter("@RoomType", comboRoomType.Text));
                    cmd.Parameters.Add(new SqlParameter("@Disability", chkDisability.Checked));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboRoomNo.Items.Add(reader["RoomNo"]); // Add to room numbers combo box
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
                
            } else
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
        private void lblSelectedCustomer_Click(object sender, EventArgs e)
        {
            PopupCustomerSelector form = new PopupCustomerSelector(this);
            form.ShowDialog();
        }

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
            if (Convert.ToDateTime(dateStart.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                dateStart.Value = DateTime.Now;

            if (Convert.ToDateTime(dateStart.Value.ToString()) >= Convert.ToDateTime(dateEnd.Value.ToString()))
                dateEnd.Value = dateStart.Value.AddDays(1);

            chkDisability_CheckedChanged(null, null); // Short cut to make sure the room number selection must be re completed so that it rechecks that dates were available.

            CalculateTotalCost(); // Recalculate
        }

        // More date picker validation
        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(DateTime.Now.ToString()))
                dateEnd.Value = DateTime.Now.AddDays(1);

            if (Convert.ToDateTime(dateEnd.Value.ToString()) <= Convert.ToDateTime(dateStart.Value.ToString()))
                dateStart.Value = dateEnd.Value.AddDays(-1);

            chkDisability_CheckedChanged(null, null);
            
            CalculateTotalCost();
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
                    // Retrieve all required fields before inserting into tblBooking
                    int roomId = GetRoomID(Convert.ToInt32(comboRoomNo.Text));
                    int customerId = _selectedCustomerId;
                    int staffId = Properties.Settings.Default.StaffID;
                    bool breakfast = chkBreakfast.Checked;
                    int adults = Convert.ToInt32(numAdults.Value);
                    int children = Convert.ToInt32(numChildren.Value);
                    string dateStartString = dateStart.Value.ToString();
                    string dateEndString = dateEnd.Value.ToString();

                    if (roomId != 0 && customerId != 0 && staffId != 0)
                    {
                        try
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand(@"INSERT INTO tblBooking (RoomID, CustomerID, StaffID, Breakfast, NoOfAdult, NoOfChildren, CheckInDate, CheckOutDate, Status) VALUES (@roomid, @customerid, @staffid, @breakfast, @adults, @children, @checkindate, @checkoutdate, @status)", con);

                            cmd.Parameters.AddWithValue("@roomid", roomId);
                            cmd.Parameters.AddWithValue("@customerid", customerId);
                            cmd.Parameters.AddWithValue("@staffid", staffId);
                            cmd.Parameters.AddWithValue("@breakfast", breakfast);
                            cmd.Parameters.AddWithValue("@adults", adults);
                            cmd.Parameters.AddWithValue("@children", children);
                            cmd.Parameters.AddWithValue("@checkindate", Convert.ToDateTime(dateStartString));
                            cmd.Parameters.AddWithValue("@checkoutdate", Convert.ToDateTime(dateEndString));
                            cmd.Parameters.AddWithValue("@status", "Active");

                            cmd.ExecuteScalar();

                            GenerateInvoice(customerId); // Generate a new invoice for the booking with costs etc

                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    } else
                    {
                        MessageBox.Show("Please select a customer before proceeding.", "Error");
                    }
                } catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error");
                }
                
            } else
            {
                MessageBox.Show("You must complete all required fields before proceeding.", "Error");
            }
        }

        // Use the customer ID to generate an invoice for the booking
        private void GenerateInvoice(int customerId)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            int bookingId = GetBookingID(customerId); // Get the booking ID

            if (bookingId != 0) // Ensure there were no errors grabbing the customer ID
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO tblInvoice (BookingID, CustomerID, TotalCost) VALUES (@bookingid, @customerid, @totalcost)", con);

                    cmd.Parameters.AddWithValue("@bookingid", bookingId);
                    cmd.Parameters.AddWithValue("@customerid", customerId);
                    cmd.Parameters.AddWithValue("@totalcost", _totalCost);

                    cmd.ExecuteScalar();

                    con.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("Failed while trying to generate invoice.", "Error");
            }
        }

        // Grab booking ID using customer ID - grabs the latest booking immediately after inserting into tblBooking to get the booking ID provided by SQL server
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
                    } else
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

            return result; // Return booking ID
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
    }
}
