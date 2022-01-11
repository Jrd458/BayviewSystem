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
    public partial class PopupRoomManageOptions : Form
    {
        private Rooms _master;
        private string _roomNo;

        public PopupRoomManageOptions(Rooms master, string roomNo)
        {
            InitializeComponent();
            _master = master;
            _roomNo = roomNo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            //_master.ShowPopupManageRoomForm();
            //PopupManageRoom form = new PopupManageRoom();
            //form.ShowDialog();
            this.Close();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete room " + _roomNo + "?", "Manage Room", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"DELETE FROM tblRoom WHERE RoomNo = @roomno", con);

                    cmd.Parameters.AddWithValue("@roomno", _roomNo);

                    cmd.ExecuteScalar();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                _master.RefreshRooms();
                this.Close();
            }
        }

        private void PopupRoomManageOptions_Load(object sender, EventArgs e)
        {
            this.Text = "Manage Room " + _roomNo;
        }
    }
}
