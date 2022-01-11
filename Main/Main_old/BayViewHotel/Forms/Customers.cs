using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayViewHotel.Forms
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kieranTestDataSet.Tbl_Kieran' table. You can move, or remove it, as needed.
            this.tbl_KieranTableAdapter.Fill(this.kieranTestDataSet.Tbl_Kieran);
            this.ActiveControl = txtSearchCustomer;
        }
    }
}
