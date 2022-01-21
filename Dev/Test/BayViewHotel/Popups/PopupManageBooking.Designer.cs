
namespace BayViewHotel.Popups
{
    partial class PopupManageBooking
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
            this.lblPersonsError = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblCostTitle = new System.Windows.Forms.Label();
            this.lblSelectedCustomer = new System.Windows.Forms.Label();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdults)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPersonsError
            // 
            this.lblPersonsError.AutoSize = true;
            this.lblPersonsError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblPersonsError.Location = new System.Drawing.Point(25, 245);
            this.lblPersonsError.Name = "lblPersonsError";
            this.lblPersonsError.Size = new System.Drawing.Size(139, 13);
            this.lblPersonsError.TabIndex = 89;
            this.lblPersonsError.Text = "You must select a room first.";
            this.lblPersonsError.Visible = false;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.Location = new System.Drawing.Point(24, 350);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(37, 30);
            this.lblTotalCost.TabIndex = 88;
            this.lblTotalCost.Text = "£0";
            // 
            // lblCostTitle
            // 
            this.lblCostTitle.AutoSize = true;
            this.lblCostTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostTitle.Location = new System.Drawing.Point(24, 330);
            this.lblCostTitle.Name = "lblCostTitle";
            this.lblCostTitle.Size = new System.Drawing.Size(77, 21);
            this.lblCostTitle.TabIndex = 87;
            this.lblCostTitle.Text = "Total Cost";
            // 
            // lblSelectedCustomer
            // 
            this.lblSelectedCustomer.AutoSize = true;
            this.lblSelectedCustomer.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblSelectedCustomer.Location = new System.Drawing.Point(111, 60);
            this.lblSelectedCustomer.Name = "lblSelectedCustomer";
            this.lblSelectedCustomer.Size = new System.Drawing.Size(139, 17);
            this.lblSelectedCustomer.TabIndex = 86;
            this.lblSelectedCustomer.Text = "No Customer Selected";
            // 
            // btnBookingCancel
            // 
            this.btnBookingCancel.BackgroundImage = global::BayViewHotel.Properties.Resources.cancel_icon_red_cross1;
            this.btnBookingCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBookingCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookingCancel.FlatAppearance.BorderSize = 0;
            this.btnBookingCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingCancel.Location = new System.Drawing.Point(631, 344);
            this.btnBookingCancel.Name = "btnBookingCancel";
            this.btnBookingCancel.Size = new System.Drawing.Size(40, 40);
            this.btnBookingCancel.TabIndex = 85;
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
            this.btnBookingSubmit.Location = new System.Drawing.Point(570, 344);
            this.btnBookingSubmit.Name = "btnBookingSubmit";
            this.btnBookingSubmit.Size = new System.Drawing.Size(40, 40);
            this.btnBookingSubmit.TabIndex = 84;
            this.btnBookingSubmit.UseVisualStyleBackColor = true;
            this.btnBookingSubmit.Click += new System.EventHandler(this.btnBookingSubmit_Click);
            // 
            // lblChooseRoomInfo
            // 
            this.lblChooseRoomInfo.AutoSize = true;
            this.lblChooseRoomInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblChooseRoomInfo.Location = new System.Drawing.Point(341, 163);
            this.lblChooseRoomInfo.Name = "lblChooseRoomInfo";
            this.lblChooseRoomInfo.Size = new System.Drawing.Size(105, 13);
            this.lblChooseRoomInfo.TabIndex = 83;
            this.lblChooseRoomInfo.Text = "Please select a room";
            this.lblChooseRoomInfo.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 82;
            this.label10.Text = "Disability";
            // 
            // chkDisability
            // 
            this.chkDisability.AutoSize = true;
            this.chkDisability.Location = new System.Drawing.Point(28, 204);
            this.chkDisability.Name = "chkDisability";
            this.chkDisability.Size = new System.Drawing.Size(69, 17);
            this.chkDisability.TabIndex = 81;
            this.chkDisability.Text = "Required";
            this.chkDisability.UseVisualStyleBackColor = true;
            this.chkDisability.CheckedChanged += new System.EventHandler(this.chkDisability_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(184, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 80;
            this.label9.Text = "Breakfast";
            // 
            // chkBreakfast
            // 
            this.chkBreakfast.AutoSize = true;
            this.chkBreakfast.Location = new System.Drawing.Point(188, 290);
            this.chkBreakfast.Name = "chkBreakfast";
            this.chkBreakfast.Size = new System.Drawing.Size(67, 17);
            this.chkBreakfast.TabIndex = 79;
            this.chkBreakfast.Text = "Opted In";
            this.chkBreakfast.UseVisualStyleBackColor = true;
            // 
            // comboRoomNo
            // 
            this.comboRoomNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRoomNo.FormattingEnabled = true;
            this.comboRoomNo.Location = new System.Drawing.Point(344, 199);
            this.comboRoomNo.Name = "comboRoomNo";
            this.comboRoomNo.Size = new System.Drawing.Size(69, 25);
            this.comboRoomNo.TabIndex = 78;
            this.comboRoomNo.SelectedIndexChanged += new System.EventHandler(this.comboRoomNo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(340, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 21);
            this.label8.TabIndex = 77;
            this.label8.Text = "Room";
            // 
            // comboRoomType
            // 
            this.comboRoomType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRoomType.FormattingEnabled = true;
            this.comboRoomType.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Family"});
            this.comboRoomType.Location = new System.Drawing.Point(146, 200);
            this.comboRoomType.Name = "comboRoomType";
            this.comboRoomType.Size = new System.Drawing.Size(135, 25);
            this.comboRoomType.TabIndex = 76;
            this.comboRoomType.SelectedIndexChanged += new System.EventHandler(this.comboRoomType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(142, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 75;
            this.label7.Text = "Room Type";
            // 
            // numChildren
            // 
            this.numChildren.Enabled = false;
            this.numChildren.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChildren.Location = new System.Drawing.Point(95, 282);
            this.numChildren.Name = "numChildren";
            this.numChildren.Size = new System.Drawing.Size(41, 25);
            this.numChildren.TabIndex = 74;
            this.numChildren.ValueChanged += new System.EventHandler(this.numChildren_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 73;
            this.label2.Text = "Adults / Children";
            // 
            // numAdults
            // 
            this.numAdults.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAdults.Location = new System.Drawing.Point(36, 282);
            this.numAdults.Name = "numAdults";
            this.numAdults.Size = new System.Drawing.Size(41, 25);
            this.numAdults.TabIndex = 72;
            this.numAdults.ValueChanged += new System.EventHandler(this.numAdults_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(366, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 71;
            this.label5.Text = "Check Out";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(549, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 21);
            this.label6.TabIndex = 70;
            this.label6.Text = "at";
            // 
            // timeEnd
            // 
            this.timeEnd.CustomFormat = "HH:mm tt";
            this.timeEnd.Enabled = false;
            this.timeEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(575, 113);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(96, 29);
            this.timeEnd.TabIndex = 69;
            this.timeEnd.Value = new System.DateTime(2022, 1, 19, 12, 30, 0, 0);
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "";
            this.dateEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEnd.Location = new System.Drawing.Point(370, 113);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(173, 29);
            this.dateEnd.TabIndex = 68;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 67;
            this.label4.Text = "Check In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 21);
            this.label3.TabIndex = 66;
            this.label3.Text = "at";
            // 
            // timeStart
            // 
            this.timeStart.CustomFormat = "HH:mm tt";
            this.timeStart.Enabled = false;
            this.timeStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(233, 113);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(96, 29);
            this.timeStart.TabIndex = 65;
            this.timeStart.Value = new System.DateTime(2021, 12, 27, 12, 30, 0, 0);
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "";
            this.dateStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStart.Location = new System.Drawing.Point(28, 113);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(173, 29);
            this.dateStart.TabIndex = 64;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // lblBookedUnder
            // 
            this.lblBookedUnder.AutoSize = true;
            this.lblBookedUnder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookedUnder.Location = new System.Drawing.Point(15, 60);
            this.lblBookedUnder.Name = "lblBookedUnder";
            this.lblBookedUnder.Size = new System.Drawing.Size(99, 17);
            this.lblBookedUnder.TabIndex = 63;
            this.lblBookedUnder.Text = "Booked Under: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 30);
            this.label1.TabIndex = 62;
            this.label1.Text = "Edit Booking";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 24);
            this.menuStrip1.TabIndex = 90;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelBookingToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // cancelBookingToolStripMenuItem
            // 
            this.cancelBookingToolStripMenuItem.Name = "cancelBookingToolStripMenuItem";
            this.cancelBookingToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.cancelBookingToolStripMenuItem.Text = "Cancel Booking";
            this.cancelBookingToolStripMenuItem.Click += new System.EventHandler(this.cancelBookingToolStripMenuItem_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelBooking.FlatAppearance.BorderSize = 2;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Font = new System.Drawing.Font("Mukta Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBooking.Location = new System.Drawing.Point(570, 34);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(101, 30);
            this.btnCancelBooking.TabIndex = 91;
            this.btnCancelBooking.Text = "CANCEL BOOKING";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // PopupManageBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 406);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.lblPersonsError);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblCostTitle);
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
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PopupManageBooking";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Booking";
            this.Load += new System.EventHandler(this.PopupManageBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdults)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPersonsError;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblCostTitle;
        private System.Windows.Forms.Label lblSelectedCustomer;
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelBookingToolStripMenuItem;
        private System.Windows.Forms.Button btnCancelBooking;
    }
}