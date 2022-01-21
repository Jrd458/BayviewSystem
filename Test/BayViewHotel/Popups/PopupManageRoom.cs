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
    public partial class PopupManageRoom : Form
    {
        private Rooms _master;
        private string _roomNo;

        public PopupManageRoom(Rooms master, string roomNo)
        {
            InitializeComponent();
            _master = master;
            _roomNo = roomNo;
        }

        private void PopupManageRoom_Load(object sender, EventArgs e)
        {
            this.Text = "Details for Room " + _roomNo;

            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT RoomID,RoomNo,RoomType,Disability FROM tblRoom WHERE RoomNo = @roomno", con);
                cmd.Parameters.AddWithValue("@roomno", _roomNo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtRoomNo.Text = reader["RoomNo"].ToString();
                        comboRoomType.SelectedIndex = comboRoomType.FindStringExact(Convert.ToString(reader["RoomType"]));
                        chkDisability.Checked = Convert.ToBoolean(reader["Disability"]);
                    }
                }
                else
                {
                    MessageBox.Show("Error occurred. Please contact your administrator.");
                    this.Close();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadBookings();
        }

        public void LoadBookings()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("RetrieveBookingsForRoom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RoomNo", _roomNo));

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("BookingID");
                    dt.Columns.Add("CustomerFullName");
                    dt.Columns.Add("CheckInDate");
                    dt.Columns.Add("CheckOutDate");

                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        row["BookingID"] = reader["BookingID"];
                        row["CustomerFullName"] = reader["CustomerFullName"];
                        row["CheckInDate"] = reader["CheckInDate"];
                        row["CheckOutDate"] = reader["CheckOutDate"];
                        dt.Rows.Add(row);
                    }

                    dt.Columns["CustomerFullName"].ColumnName = "Full Name";
                    dt.Columns["CheckInDate"].ColumnName = "Check In";
                    dt.Columns["CheckOutDate"].ColumnName = "Check Out";

                    dataGridActiveBookings.DataSource = dt;
                    dataGridActiveBookings.Columns["BookingID"].Visible = false;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string editedRoomNo = txtRoomNo.Text;
            string roomType = comboRoomType.SelectedItem.ToString();
            bool isDisabledRoom = chkDisability.Checked;

            if (comboRoomType.SelectedItem != null &&
                txtRoomNo.Text != "")
            {
                if (!IsRoomNumberConflict(editedRoomNo))
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        con.Open();

                        SqlCommand cmd = new SqlCommand(@"UPDATE tblRoom SET RoomNo = @roomno, RoomType = @roomtype, Disability = @disability WHERE RoomNo = @initialroomno", con);

                        cmd.Parameters.AddWithValue("@initialroomno", _roomNo);
                        cmd.Parameters.AddWithValue("@roomno", editedRoomNo);
                        cmd.Parameters.AddWithValue("@roomtype", roomType);
                        cmd.Parameters.AddWithValue("@disability", isDisabledRoom);

                        cmd.ExecuteScalar();

                        con.Close();
                        _master.RefreshRooms();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } else
                {
                    MessageBox.Show("A room with this number already exists.", "Error");
                }
            }
            else
            {
                lblValidationError.Visible = true;
            }
        }

        private bool IsRoomNumberConflict(string roomNo)
        {
            bool result = false;

            if (roomNo == _roomNo)
            {
                result = false;
            } else
            {
                try
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM tblRoom WHERE RoomNo = @roomno", con);
                    cmd.Parameters.AddWithValue("@roomno", roomNo);

                    con.Open();

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return result;
        }

        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            AddBooking form = new AddBooking("", "");
            form.ShowDialog();
        }

        private void dataGridActiveBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridActiveBookings.Rows[e.RowIndex];
            string bookingId = Convert.ToString(selectedRow.Cells["BookingID"].Value);

            PopupManageBooking form = new PopupManageBooking(bookingId, "ManageRoom", this);
            form.ShowDialog();
        }
    }
}
