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

namespace DataGenerator
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.ActiveControl = Title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=,443;Initial Catalog=BayViewHotel;Persist Security Info=True;User ID=sa;Password=");

                string query = "INSERT INTO tblStaff (UserName,Title, Password, Role, FirstName, LastName, AddressLine1, AddressLine2, AddressLine3, AddressLine4, Postcode, ContactNo, EmailAddress,DateOfBirth)" +
                    "VALUES (@username, @title, @password, @role, @firstname, @lastname, @addressline1, @addressline2, @addressline3, @addressline4, @postcode, @contactno, @emailaddress,@dob)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@username", FirstName.Text.ToLower() + "." + LastName.Text.ToLower());
                cmd.Parameters.AddWithValue("@title", Title.Text);
                cmd.Parameters.AddWithValue("@role", Role.Text);
                cmd.Parameters.AddWithValue("@firstname", FirstName.Text);
                cmd.Parameters.AddWithValue("@lastname", LastName.Text);
                cmd.Parameters.AddWithValue("@addressline1", Address1.Text);
                cmd.Parameters.AddWithValue("@addressline2", Address2.Text);
                cmd.Parameters.AddWithValue("@addressline3", Address3.Text);
                cmd.Parameters.AddWithValue("@addressline4", Address4.Text);
                cmd.Parameters.AddWithValue("@postcode", Postcode.Text);
                cmd.Parameters.AddWithValue("@contactno", ContactNo.Text);

                byte[] salt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }
                string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: Password.Text,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                Random random = new Random();

                string DateOfBirth = random.Next(1975, 2003) + "-" + random.Next(1, 13) + "-" + random.Next(1, 29);
                cmd.Parameters.AddWithValue("@dob", DateOfBirth);

                //string[] chars = { ".", "_", "__", "" };
                //string[] domains = { "gmail.com", "outlook.com", "live.co.uk", "yahoo.co.uk", "hotmail.co.uk", "protonmail.ch" };
                string EmailAddress = FirstName.Text + "." + LastName.Text + "@" + "bayviewhotel.co.uk";
                cmd.Parameters.AddWithValue("@emailaddress", EmailAddress.ToLower());

                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully inserted");

                    Title.Text = "";
                    FirstName.Text = "";
                    LastName.Text = "";
                    Password.Text = "";
                    Role.Text = "";
                    Address1.Text = "";
                    Address2.Text = "";
                    Address3.Text = "";
                    Address4.Text = "";
                    Postcode.Text = "";
                    ContactNo.Text = "";
                    //EmailAddress.Text = "";

                    this.ActiveControl = Title;

                    //MessageBox.Show(hashedPassword);
                }
                else
                {
                    MessageBox.Show("Failed to insert");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
