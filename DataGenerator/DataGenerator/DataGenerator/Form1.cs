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

namespace DataGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=51.195.252.182,443;Initial Catalog=BayViewHotel;Persist Security Info=True;User ID=sa;Password=Cambrian@1");
            
                string query = "INSERT INTO tblCustomer (Title,FirstName, LastName, AddressLine1, AddressLine2, AddressLine3, AddressLine4, Postcode, ContactNo, EmailAddress,DateOfBirth)" +
                    "VALUES (@title,@firstname, @lastname, @addressline1, @addressline2, @addressline3, @addressline4, @postcode, @contactno, @emailaddress,@dob)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@title", Title.Text);
                cmd.Parameters.AddWithValue("@firstname", FirstName.Text);
                cmd.Parameters.AddWithValue("@lastname", LastName.Text);
                cmd.Parameters.AddWithValue("@addressline1", Address1.Text);
                cmd.Parameters.AddWithValue("@addressline2", Address2.Text);
                cmd.Parameters.AddWithValue("@addressline3", Address3.Text);
                cmd.Parameters.AddWithValue("@addressline4", Address4.Text);
                cmd.Parameters.AddWithValue("@postcode", Postcode.Text);
                cmd.Parameters.AddWithValue("@contactno", ContactNo.Text);

                //cmd.Parameters.AddWithValue("@emailaddress", EmailAddress.Text);
                Random random = new Random();

                string DateOfBirth = random.Next(1965, 2003) + "-" + random.Next(1, 13) + "-" + random.Next(1, 29);
                cmd.Parameters.AddWithValue("@dob", DateOfBirth);

                string[] chars = { ".", "_", "__", ""};
                string[] domains = { "gmail.com", "outlook.com", "live.co.uk", "yahoo.co.uk", "hotmail.co.uk", "protonmail.ch" };
                string EmailAddress = FirstName.Text + chars[random.Next(0, chars.Length)] + LastName.Text + random.Next(0, 99) + "@" + domains[random.Next(0, chars.Length)];
                cmd.Parameters.AddWithValue("@emailaddress", EmailAddress.ToLower());

                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully inserted");

                    Title.Text = "";
                    FirstName.Text = "";
                    LastName.Text = "";
                    Address1.Text = "";
                    Address2.Text = "";
                    Address3.Text = "";
                    Address4.Text = "";
                    Postcode.Text = "";
                    ContactNo.Text = "";
                    //EmailAddress.Text = "";

                    this.ActiveControl = Title;
                } else
                {
                    MessageBox.Show("Failed to insert");
                }

                con.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = Title;
        }
    }
}
