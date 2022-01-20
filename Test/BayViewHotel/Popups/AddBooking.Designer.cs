
namespace BayViewHotel.Popups
{
    partial class AddBooking
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
            this.btnBookingCancel = new System.Windows.Forms.Button();
            this.btnBookingSubmit = new System.Windows.Forms.Button();
            this.lblChooseRoomInfo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkDisability = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkBreakfast = new System.Windows.Forms.CheckBox();
            this.comboRoomNo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboRoomType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numChildren = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numAdults = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.lblBookedUnder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedCustomer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBookingCancel
            // 
            this.btnBookingCancel.BackgroundImage = global::BayViewHotel.Properties.Resources.cancel_icon_red_cross1;
            this.btnBookingCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBookingCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookingCancel.FlatAppearance.BorderSize = 0;
            this.btnBookingCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingCancel.Location = new System.Drawing.Point(625, 260);
            this.btnBookingCancel.Name = "btnBookingCancel";
            this.btnBookingCancel.Size = new System.Drawing.Size(40, 40);
            this.btnBookingCancel.TabIndex = 57;
            this.btnBookingCancel.UseVisualStyleBackColor = true;
            this.btnBookingCancel.Click += new System.EventHandler(this.btnBookingCancel_Click);
            // 
            // btnBookingSubmit
            // 
            this.btnBookingSubmit.BackgroundImage = global::BayViewHotel.Properties.Resources.submit_icon_green_tick;
            this.btnBookingSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBookingSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookingSubmit.FlatAppearance.BorderSize = 0;
            this.btnBookingSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingSubmit.Location = new System.Drawing.Point(564, 260);
            this.btnBookingSubmit.Name = "btnBookingSubmit";
            this.btnBookingSubmit.Size = new System.Drawing.Size(40, 40);
            this.btnBookingSubmit.TabIndex = 56;
            this.btnBookingSubmit.UseVisualStyleBackColor = true;
            this.btnBookingSubmit.Click += new System.EventHandler(this.btnBookingSubmit_Click);
            // 
            // lblChooseRoomInfo
            // 
            this.lblChooseRoomInfo.AutoSize = true;
            this.lblChooseRoomInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblChooseRoomInfo.Location = new System.Drawing.Point(341, 146);
            this.lblChooseRoomInfo.Name = "lblChooseRoomInfo";
            this.lblChooseRoomInfo.Size = new System.Drawing.Size(105, 13);
            this.lblChooseRoomInfo.TabIndex = 55;
            this.lblChooseRoomInfo.Text = "Please select a room";
            this.lblChooseRoomInfo.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 54;
            this.label10.Text = "Disability";
            // 
            // chkDisability
            // 
            this.chkDisability.AutoSize = true;
            this.chkDisability.Location = new System.Drawing.Point(28, 187);
            this.chkDisability.Name = "chkDisability";
            this.chkDisability.Size = new System.Drawing.Size(69, 17);
            this.chkDisability.TabIndex = 53;
            this.chkDisability.Text = "Required";
            this.chkDisability.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(184, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 52;
            this.label9.Text = "Breakfast";
            // 
            // chkBreakfast
            // 
            this.chkBreakfast.AutoSize = true;
            this.chkBreakfast.Location = new System.Drawing.Point(188, 273);
            this.chkBreakfast.Name = "chkBreakfast";
            this.chkBreakfast.Size = new System.Drawing.Size(67, 17);
            this.chkBreakfast.TabIndex = 51;
            this.chkBreakfast.Text = "Opted In";
            this.chkBreakfast.UseVisualStyleBackColor = true;
            // 
            // comboRoomNo
            // 
            this.comboRoomNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRoomNo.FormattingEnabled = true;
            this.comboRoomNo.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Family"});
            this.comboRoomNo.Location = new System.Drawing.Point(344, 182);
            this.comboRoomNo.Name = "comboRoomNo";
            this.comboRoomNo.Size = new System.Drawing.Size(69, 25);
            this.comboRoomNo.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(340, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 21);
            this.label8.TabIndex = 49;
            this.label8.Text = "Room Booked";
            // 
            // comboRoomType
            // 
            this.comboRoomType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRoomType.FormattingEnabled = true;
            this.comboRoomType.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Family"});
            this.comboRoomType.Location = new System.Drawing.Point(146, 183);
            this.comboRoomType.Name = "comboRoomType";
            this.comboRoomType.Size = new System.Drawing.Size(135, 25);
            this.comboRoomType.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(142, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 47;
            this.label7.Text = "Room Type";
            // 
            // numChildren
            // 
            this.numChildren.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChildren.Location = new System.Drawing.Point(95, 265);
            this.numChildren.Name = "numChildren";
            this.numChildren.Size = new System.Drawing.Size(41, 25);
            this.numChildren.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Adults / Children";
            // 
            // numAdults
            // 
            this.numAdults.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAdults.Location = new System.Drawing.Point(36, 265);
            this.numAdults.Name = "numAdults";
            this.numAdults.Size = new System.Drawing.Size(41, 25);
            this.numAdults.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(366, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 43;
            this.label5.Text = "Check Out";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(549, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "at";
            // 
            // timeEnd
            // 
            this.timeEnd.CustomFormat = "HH:mm tt";
            this.timeEnd.Enabled = false;
            this.timeEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(575, 96);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(96, 29);
            this.timeEnd.TabIndex = 41;
            this.timeEnd.Value = new System.DateTime(2022, 1, 19, 12, 30, 0, 0);
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "";
            this.dateEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEnd.Location = new System.Drawing.Point(370, 96);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(173, 29);
            this.dateEnd.TabIndex = 40;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 39;
            this.label4.Text = "Check In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "at";
            // 
            // timeStart
            // 
            this.timeStart.CustomFormat = "HH:mm tt";
            this.timeStart.Enabled = false;
            this.timeStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(233, 96);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(96, 29);
            this.timeStart.TabIndex = 37;
            this.timeStart.Value = new System.DateTime(2021, 12, 27, 12, 30, 0, 0);
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "";
            this.dateStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStart.Location = new System.Drawing.Point(28, 96);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(173, 29);
            this.dateStart.TabIndex = 36;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // lblBookedUnder
            // 
            this.lblBookedUnder.AutoSize = true;
            this.lblBookedUnder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookedUnder.Location = new System.Drawing.Point(15, 43);
            this.lblBookedUnder.Name = "lblBookedUnder";
            this.lblBookedUnder.Size = new System.Drawing.Size(99, 17);
            this.lblBookedUnder.TabIndex = 35;
            this.lblBookedUnder.Text = "Booked Under: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 30);
            this.label1.TabIndex = 34;
            this.label1.Text = "Create New Booking";
            // 
            // lblSelectedCustomer
            // 
            this.lblSelectedCustomer.AutoSize = true;
            this.lblSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedCustomer.ForeColor = System.Drawing.Color.Blue;
            this.lblSelectedCustomer.Location = new System.Drawing.Point(111, 43);
            this.lblSelectedCustomer.Name = "lblSelectedCustomer";
            this.lblSelectedCustomer.Size = new System.Drawing.Size(139, 17);
            this.lblSelectedCustomer.TabIndex = 58;
            this.lblSelectedCustomer.Text = "No Customer Selected";
            this.lblSelectedCustomer.Click += new System.EventHandler(this.lblSelectedCustomer_Click);
            // 
            // AddBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 312);
            this.Controls.Add(this.lblSelectedCustomer);
            this.Controls.Add(this.btnBookingCancel);
            this.Controls.Add(this.btnBookingSubmit);
            this.Controls.Add(this.lblChooseRoomInfo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkDisability);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkBreakfast);
            this.Controls.Add(this.comboRoomNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboRoomType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numChildren);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numAdults);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.lblBookedUnder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddBooking";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Booking";
            this.Load += new System.EventHandler(this.AddBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBookingCancel;
        private System.Windows.Forms.Button btnBookingSubmit;
        private System.Windows.Forms.Label lblChooseRoomInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkDisability;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkBreakfast;
        private System.Windows.Forms.ComboBox comboRoomNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboRoomType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numChildren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAdults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label lblBookedUnder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedCustomer;
    }
}