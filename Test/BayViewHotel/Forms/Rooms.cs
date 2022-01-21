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
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            RetrieveRoomAvailability(); // Generate the room buttons on page load
        }

        private void btnRefreshRooms_Click(object sender, EventArgs e)
        {
            RefreshRooms();
        }

        public void RefreshRooms()
        {
            panelAvailableSingle.Controls.Clear();
            panelAvailableDouble.Controls.Clear();
            panelAvailableFamily.Controls.Clear();

            RetrieveRoomAvailability();
        }

        // Retrieve list of rooms with an 'availability' flag (true/false) so that we can display the results as buttons
        private void RetrieveRoomAvailability()
        {
            // Declare data tables for each room type
            DataTable dtSingle = new DataTable();
            DataTable dtDouble = new DataTable();
            DataTable dtFamily = new DataTable();

            // Button visual settings
            int numberOfColumns = 10;
            int btnHeight = 40;
            int btnWidth = 40;

            // Create lists so we can append all the buttons, we will then convert them to arrays later for our for loops
            List<string> typeSingleList = new List<string>();
            List<string> typeDoubleList = new List<string>();
            List<string> typeFamilyList = new List<string>();

            List<string> disabledRoomsList = new List<string>();
            List<string> unavailableRoomsList = new List<string>();

            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();

                /* SQL SERVER STORED PROCEDURE
                 * 
                 * ALTER PROCEDURE [dbo].[RetrieveRoomAvailabilityStatus]
	                     @StartDate			DATE
	                    ,@EndDate			DATE
                    AS
	                    SELECT
		                     r.RoomID
		                    ,r.RoomNo
		                    ,r.RoomType
		                    ,r.Disability
		                    ,
		                    CASE
			                    WHEN RoomID NOT IN 
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
					                    --(
					                    --	(CheckInDate <= @StartDate AND CheckOutDate >= @EndDate)
					                    --OR 
					                    --	(CheckInDate < @EndDate AND CheckOutDate <= @EndDate)
					                    --OR 
					                    --	(@StartDate <= CheckInDate AND @EndDate >= CheckInDate)
					                    --)
					                    AND
						                    Status = 'Active'
				                    )
				                    THEN
					                    CAST(1 AS BIT)
				                    ELSE
					                    CAST(0 AS BIT)
				                    END AS
					                    Available
	                    FROM tblRoom r
                 */

                SqlCommand cmd = new SqlCommand("RetrieveRoomAvailabilityStatus", con); // Calls from the proc on SQL server
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@StartDate", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@EndDate", DateTime.Now));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch (reader["RoomType"]) // Depending on the room type it adds it to the correct section (single, double, family)
                        {
                            case "Single":
                                typeSingleList.Add(reader["RoomNo"].ToString());
                                break;
                            case "Double":
                                typeDoubleList.Add(reader["RoomNo"].ToString());
                                break;
                            case "Family":
                                typeFamilyList.Add(reader["RoomNo"].ToString());
                                break;
                            default:
                                break;
                        }

                        // If disabled add to that list so we can change button to show as blue
                        if (Convert.ToBoolean(reader["Disability"]) == true)
                        {
                            disabledRoomsList.Add(reader["RoomNo"].ToString());
                        }

                        // If unavailable add to that list so we can change the button to show with a red border (signifying unavailable for today)
                        if (Convert.ToBoolean(reader["Available"]) == false)
                        {
                            unavailableRoomsList.Add(reader["RoomNo"].ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There are no available rooms.", "Room Availability");
                }

                // Convert lists to arrays
                string[] typeSingle = typeSingleList.ToArray();
                string[] typeDouble = typeDoubleList.ToArray();
                string[] typeFamily = typeFamilyList.ToArray();

                string[] disabledRooms = disabledRoomsList.ToArray();
                string[] unavailableRooms = unavailableRoomsList.ToArray();

                // Add to data tables for each type
                for (int i = 0; i < typeSingle.Length; i++)
                {
                    dtSingle.Columns.Add(typeSingle[i], typeof(string));
                }

                for (int i = 0; i < typeDouble.Length; i++)
                {
                    dtDouble.Columns.Add(typeDouble[i], typeof(string));
                }

                for (int i = 0; i < typeFamily.Length; i++)
                {
                    dtFamily.Columns.Add(typeFamily[i], typeof(string));
                }

                // Set visuals for disabled and unavailability buttons
                Color disabilityColor = Color.FromArgb(57, 119, 219);
                Color unavailableColor = Color.FromArgb(247, 97, 87);

                // Repeat through each room to create buttons in a row
                string[] columnNameSingle = dtSingle.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                for (int i = 0; i < columnNameSingle.Length; i++)
                {
                    Button btn = new Button();
                    btn.Text = columnNameSingle[i];
                    int column = i % numberOfColumns;
                    int row = i / numberOfColumns;
                    btn.Left = column * btnHeight;
                    btn.Width = btnWidth;
                    btn.Height = btnHeight;
                    panelAvailableSingle.Controls.Add(btn);

                    // Repeat through rooms to check if they're disabled and update visuals
                    foreach (string x in disabledRooms)
                    {
                        if (x == columnNameSingle[i])
                            btn.BackColor = disabilityColor;
                    }

                    // Repeat through rooms to check if they're unavailable and update visuals
                    foreach (string x in unavailableRooms)
                    {
                        if (x == columnNameSingle[i])
                        {
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderColor = unavailableColor;
                            btn.FlatAppearance.BorderSize = 3;
                        }
                    }

                    btn.Click += new EventHandler(Button_Click); // Add the button click event to new button
                }

                // Repeats the above cycles for each type of room (single, double, family)

                string[] columnNameDouble = dtDouble.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                for (int i = 0; i < columnNameDouble.Length; i++)
                {
                    Button btn = new Button();
                    btn.Text = columnNameDouble[i];
                    int column = i % numberOfColumns;
                    int row = i / numberOfColumns;
                    btn.Left = column * btnHeight;
                    btn.Width = btnWidth;
                    btn.Height = btnHeight;
                    panelAvailableDouble.Controls.Add(btn);

                    foreach (string x in disabledRooms)
                    {
                        if (x == columnNameDouble[i])
                            btn.BackColor = disabilityColor;
                    }

                    foreach (string x in unavailableRooms)
                    {
                        if (x == columnNameDouble[i])
                        {
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderColor = unavailableColor;
                            btn.FlatAppearance.BorderSize = 3;
                        }
                    }

                    btn.Click += new EventHandler(Button_Click);
                }

                string[] columnNameFamily = dtFamily.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                for (int i = 0; i < columnNameFamily.Length; i++)
                {
                    Button btn = new Button();
                    btn.Text = columnNameFamily[i];
                    int column = i % numberOfColumns;
                    int row = i / numberOfColumns;
                    btn.Left = column * btnHeight;
                    btn.Width = btnWidth;
                    btn.Height = btnHeight;
                    panelAvailableFamily.Controls.Add(btn);

                    foreach (string x in disabledRooms)
                    {
                        if (x == columnNameFamily[i])
                            btn.BackColor = disabilityColor;
                    }

                    foreach (string x in unavailableRooms)
                    {
                        if (x == columnNameFamily[i])
                        {
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderColor = unavailableColor;
                            btn.FlatAppearance.BorderSize = 3;
                        }
                    }

                    btn.Click += new EventHandler(Button_Click);
                }

                // Once they have been fully loaded make them visible so it looks more snappy
                panelAvailableSingle.Visible = true;
                panelAvailableDouble.Visible = true;
                panelAvailableFamily.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Room click event, pipes the room number to the Manage Room form so we can view, edit and manage it
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            PopupManageRoom options = new PopupManageRoom(this, btn.Text);
            options.ShowDialog();
        }
    }
}