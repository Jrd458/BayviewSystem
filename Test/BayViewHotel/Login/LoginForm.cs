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
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private string GetSaltForUser(string username)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            con.Open();

            string result = null;

            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 Salt FROM tblStaff WHERE UserName = @username", con);
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
                    result = null;
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

        private bool IsUserExists(string username)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            con.Open();

            bool result = false;

            try
            {
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

        private void Login()
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;
            btnClose.Enabled = false;

            lblError.Visible = false;
            string userName = txtUsername.Text.ToLower();
            string password = txtPassword.Text;

            try
            {
                if (IsUserExists(userName))
                {
                    string userSalt = GetSaltForUser(userName);
                    byte[] salt = Convert.FromBase64String(userSalt);

                    string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
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

                    //MessageBox.Show("USERNAME: " + userName + Environment.NewLine + "SALT: " + Convert.ToBase64String(salt) + Environment.NewLine + "SALT DB: " + userSalt + Environment.NewLine + "HASH: " + hashedPassword);

                    if (count > 0)
                    {
                        LogLogin(userName, true);
                        Main mainForm = new Main();
                        mainForm.Show();
                        this.Hide();
                    } else
                    {
                        LogLogin(userName, false);
                        lblError.Visible = true;
                    }

                    con.Close();
                    enableGui();
                } else
                {
                    LogLogin(userName, false);
                    enableGui();
                    lblError.Visible = true;
                }
            } catch (Exception ex)
            {
                LogLogin(userName, false);
                enableGui();
                MessageBox.Show(ex.Message);
            }
        }

        private void enableGui()
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnLogin.Enabled = true;
            btnClose.Enabled = true;
        }

        private void LogLogin(string username, bool loginSuccess)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO LoginLog (UserName, LoginSuccess) VALUES (@username,@loginsuccess)", con);
                cmd.Parameters.AddWithValue("@username", username);
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
