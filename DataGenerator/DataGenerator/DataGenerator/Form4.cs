using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGenerator
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //txtInput.Text = "";
            txtSalt.Text = "";
            txtHash.Text = "";

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            txtSalt.Text = Convert.ToBase64String(salt);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: txtInput.Text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            txtHash.Text = hashedPassword;

            string newLine = Environment.NewLine;

            txtOutput.Text += txtInput.Text + newLine + "===========" + newLine + txtHash.Text + newLine + newLine + txtSalt.Text + newLine + "===========" + newLine + newLine;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtInput;
        }
    }
}
