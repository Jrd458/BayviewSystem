using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayViewHotel.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsername;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Users can press the enter key as an alternative to pressing the login button
            {
                Login();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Users can press the enter key as an alternative to pressing the login button
            {
                Login();
            }
        }

        // Retrieve the password salt for a specific user, allows for checking their password hash is correct
        private string GetSaltForUser(string username)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            string result = null;

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 Salt FROM tblStaff WHERE UserName = @username", con); // Grab salt for specific user
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetString(0);
                    }
                } else
                {
                    result = null; // If it returns no salt then user doesn't exist, return null
                }
            }
            catch (Exception ex)
            {
                result = null;
                MessageBox.Show(ex.Message);
            }
            
            con.Close();
            
            return result;
        }

        // Check if the user exists, for validation
        private bool IsUserExists(string username)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            bool result = false;

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM tblStaff WHERE UserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                int count = (int)cmd.ExecuteScalar();
                
                if (count > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message);
            }

            con.Close();

            return result;
        }

        // Main login functionality
        private void Login()
        {
            // Reset control visuals
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;
            btnClose.Enabled = false;

            lblError.Visible = false; // Remove any errors that would've occurred from previous attemps
            string userName = txtUsername.Text.ToLower(); // Set username
            string password = txtPassword.Text; // Set password

            try
            {
                if (IsUserExists(userName))
                {
                    string userSalt = GetSaltForUser(userName); // Grab the salt for getting the correct password hash
                    byte[] salt = Convert.FromBase64String(userSalt); // Convert to string

                    string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2( // Uses Pbkdf2 to generate the password hash using the salt and password string to see if the hash matches up with that in the table
                        password: password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));

                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM tblStaff WHERE UserName = @username AND Password = @passwordHash", con);
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@passwordHash", hashedPassword);

                    con.Open();

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0) // If the result of the SQL count is more than 0 then the user exists and the password is correct
                    {
                        LogLogin(userName, true); // Log the login attempt to the table
                        Properties.Settings.Default.StaffID = GetStaffID(userName); // Set the staff ID for keeping track of their actions (bookings, generate greeting message etc)
                        Main mainForm = new Main();
                        mainForm.Show(); // Open main form on success
                        this.Hide(); // Close login on success
                    } else
                    {
                        LogLogin(userName, false); // Log as unsuccessful login
                        lblError.Visible = true; // Show login details were incorrect error
                        this.ActiveControl = txtPassword; // Focus back to password text box
                    }

                    con.Close();
                    enableGui(); // The text boxes/buttons are disabled while the server is connecting to the database, re-enable once this process has ceased
                } else
                {
                    LogLogin(userName, false);
                    enableGui(); // The text boxes/buttons are disabled while the server is connecting to the database, re-enable once this process has ceased for invalid login
                    lblError.Visible = true;
                }
            } catch (Exception ex)
            {
                LogLogin(userName, false);
                enableGui();
                MessageBox.Show(ex.Message);
            }
        }

        // Re-enable textbox/button visuals
        private void enableGui()
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnLogin.Enabled = true;
            btnClose.Enabled = true;
        }

        // Returns the staff ID using their username for setting it to application settings
        private int GetStaffID(string username)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT StaffID FROM tblStaff WHERE UserName = @username", con);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = Convert.ToInt32(reader["StaffID"]);
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

        // When called it will log a new login attempt as either login success true or false with the provided username
        private void LogLogin(string username, bool loginSuccess)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO LoginLog (UserName, LoginSuccess) VALUES (@username,@loginsuccess)", con);
                cmd.Parameters.AddWithValue("@username", username); // Sets as parameters to provide pretty good sanitation for the entered details and avoids sql errors/injection attempts
                cmd.Parameters.AddWithValue("@loginsuccess", loginSuccess);

                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }
    }
}
