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
            RetrieveRoomAvailability();
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

        private void RetrieveRoomAvailability()
        {
            DataTable dtSingle = new DataTable();
            DataTable dtDouble = new DataTable();
            DataTable dtFamily = new DataTable();

            int numberOfColumns = 10;
            int btnHeight = 40;
            int btnWidth = 40;
            //int btnMargin = 40;

            List<string> typeSingleList = new List<string>();
            List<string> typeDoubleList = new List<string>();
            List<string> typeFamilyList = new List<string>();

            List<string> disabledRoomsList = new List<string>();
            List<string> unavailableRoomsList = new List<string>();

            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("RetrieveAvailableRoomsByDateRange", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StartDate", DateTime.Now)); // testing
                cmd.Parameters.Add(new SqlParameter("@EndDate", DateTime.Now)); // testing

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch (reader["RoomType"])
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

                        if (Convert.ToBoolean(reader["Disability"]) == true)
                        {
                            disabledRoomsList.Add(reader["RoomNo"].ToString());
                        }

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

                string[] typeSingle = typeSingleList.ToArray();
                string[] typeDouble = typeDoubleList.ToArray();
                string[] typeFamily = typeFamilyList.ToArray();

                string[] disabledRooms = disabledRoomsList.ToArray();
                string[] unavailableRooms = unavailableRoomsList.ToArray();

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

                    foreach (string x in disabledRooms)
                    {
                        if (x == columnNameSingle[i])
                            btn.BackColor = System.Drawing.Color.LightBlue;
                    }

                    foreach (string x in unavailableRooms)
                    {
                        if (x == columnNameSingle[i])
                            btn.Enabled = false;
                    }

                    btn.Click += new EventHandler(Button_Click);
                }

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
                            btn.BackColor = System.Drawing.Color.LightBlue;
                    }

                    foreach (string x in unavailableRooms)
                    {
                        if (x == columnNameDouble[i])
                            btn.Enabled = false;
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
                            btn.BackColor = System.Drawing.Color.LightBlue;
                    }

                    foreach (string x in unavailableRooms)
                    {
                        if (x == columnNameFamily[i])
                            btn.Enabled = false;
                    }

                    btn.Click += new EventHandler(Button_Click);
                }

                panelAvailableSingle.Visible = true;
                panelAvailableDouble.Visible = true;
                panelAvailableFamily.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(btn.Text);

            PopupManageRoom options = new PopupManageRoom(this, btn.Text);
            options.ShowDialog();
        }

        //public void ShowPopupManageRoomForm()
        //{
        //    PopupManageRoom form = new PopupManageRoom(this, );
        //    form.ShowDialog();
        //}
    }
}