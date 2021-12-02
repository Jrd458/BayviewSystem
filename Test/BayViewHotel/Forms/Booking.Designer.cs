namespace BayViewHotel.Forms
{
    partial class Booking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewBookings = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.grpBookingSearch = new System.Windows.Forms.GroupBox();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblResultSingle = new System.Windows.Forms.Label();
            this.lblResultDouble = new System.Windows.Forms.Label();
            this.lblResultFamily = new System.Windows.Forms.Label();
            this.btnBookNow = new System.Windows.Forms.Button();
            this.grpBookingSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bookings";
            // 
            // btnViewBookings
            // 
            this.btnViewBookings.BackColor = System.Drawing.Color.Silver;
            this.btnViewBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBookings.Location = new System.Drawing.Point(28, 66);
            this.btnViewBookings.Name = "btnViewBookings";
            this.btnViewBookings.Size = new System.Drawing.Size(132, 36);
            this.btnViewBookings.TabIndex = 2;
            this.btnViewBookings.Text = "View Bookings";
            this.btnViewBookings.UseVisualStyleBackColor = false;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.BackColor = System.Drawing.Color.Silver;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Location = new System.Drawing.Point(187, 66);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(132, 36);
            this.btnCancelBooking.TabIndex = 3;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            // 
            // grpBookingSearch
            // 
            this.grpBookingSearch.Controls.Add(this.groupBox1);
            this.grpBookingSearch.Controls.Add(this.label5);
            this.grpBookingSearch.Controls.Add(this.label6);
            this.grpBookingSearch.Controls.Add(this.timeEnd);
            this.grpBookingSearch.Controls.Add(this.dateEnd);
            this.grpBookingSearch.Controls.Add(this.label4);
            this.grpBookingSearch.Controls.Add(this.label3);
            this.grpBookingSearch.Controls.Add(this.timeStart);
            this.grpBookingSearch.Controls.Add(this.dateStart);
            this.grpBookingSearch.Controls.Add(this.label2);
            this.grpBookingSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookingSearch.Location = new System.Drawing.Point(28, 119);
            this.grpBookingSearch.Name = "grpBookingSearch";
            this.grpBookingSearch.Size = new System.Drawing.Size(879, 280);
            this.grpBookingSearch.TabIndex = 4;
            this.grpBookingSearch.TabStop = false;
            this.grpBookingSearch.Text = "Room Availability Search";
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "";
            this.dateStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStart.Location = new System.Drawing.Point(63, 63);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(173, 29);
            this.dateStart.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Please enter a search range...";
            // 
            // timeStart
            // 
            this.timeStart.CustomFormat = "";
            this.timeStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(268, 63);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(96, 29);
            this.timeStart.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(242, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "at";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Start:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "End:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(242, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "at";
            // 
            // timeEnd
            // 
            this.timeEnd.CustomFormat = "";
            this.timeEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(268, 111);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(96, 29);
            this.timeEnd.TabIndex = 6;
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "";
            this.dateEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEnd.Location = new System.Drawing.Point(63, 111);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(173, 29);
            this.dateEnd.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBookNow);
            this.groupBox1.Controls.Add(this.lblResultFamily);
            this.groupBox1.Controls.Add(this.lblResultDouble);
            this.groupBox1.Controls.Add(this.lblResultSingle);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(462, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 234);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Summary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Single:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Double:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Family:";
            // 
            // lblResultSingle
            // 
            this.lblResultSingle.AutoSize = true;
            this.lblResultSingle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultSingle.Location = new System.Drawing.Point(116, 46);
            this.lblResultSingle.Name = "lblResultSingle";
            this.lblResultSingle.Size = new System.Drawing.Size(241, 21);
            this.lblResultSingle.TabIndex = 3;
            this.lblResultSingle.Text = "0 booked, 0 available for booking";
            // 
            // lblResultDouble
            // 
            this.lblResultDouble.AutoSize = true;
            this.lblResultDouble.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultDouble.Location = new System.Drawing.Point(116, 91);
            this.lblResultDouble.Name = "lblResultDouble";
            this.lblResultDouble.Size = new System.Drawing.Size(241, 21);
            this.lblResultDouble.TabIndex = 4;
            this.lblResultDouble.Text = "0 booked, 0 available for booking";
            // 
            // lblResultFamily
            // 
            this.lblResultFamily.AutoSize = true;
            this.lblResultFamily.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultFamily.Location = new System.Drawing.Point(116, 138);
            this.lblResultFamily.Name = "lblResultFamily";
            this.lblResultFamily.Size = new System.Drawing.Size(241, 21);
            this.lblResultFamily.TabIndex = 5;
            this.lblResultFamily.Text = "0 booked, 0 available for booking";
            // 
            // btnBookNow
            // 
            this.btnBookNow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookNow.Location = new System.Drawing.Point(30, 175);
            this.btnBookNow.Name = "btnBookNow";
            this.btnBookNow.Size = new System.Drawing.Size(343, 43);
            this.btnBookNow.TabIndex = 6;
            this.btnBookNow.Text = "Continue to booking with these dates";
            this.btnBookNow.UseVisualStyleBackColor = true;
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 725);
            this.Controls.Add(this.grpBookingSearch);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnViewBookings);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Booking";
            this.Text = "Booking";
            this.grpBookingSearch.ResumeLayout(false);
            this.grpBookingSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewBookings;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.GroupBox grpBookingSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblResultFamily;
        private System.Windows.Forms.Label lblResultDouble;
        private System.Windows.Forms.Label lblResultSingle;
        private System.Windows.Forms.Button btnBookNow;
    }
}