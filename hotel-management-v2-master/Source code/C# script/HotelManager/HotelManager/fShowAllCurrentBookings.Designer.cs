namespace HotelManager
{
    partial class fShowAllCurrentBookings
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fShowAllCurrentBookings));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.dataGridViewRoom = new System.Windows.Forms.DataGridView();
            this.roomBooking4ViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose_ = new Bunifu.Framework.UI.BunifuThinButton2();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCurrentBookings = new System.Windows.Forms.TabPage();
            this.tabPageAdvanceBookings = new System.Windows.Forms.TabPage();
            this.dataGridViewAdvanceBookings = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBookRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advanceBookingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reservationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCheckInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCheckOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBookRoomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBooking4ViewBindingSource)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageCurrentBookings.SuspendLayout();
            this.tabPageAdvanceBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdvanceBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advanceBookingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(919, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 57;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewRoom
            // 
            this.dataGridViewRoom.AllowUserToAddRows = false;
            this.dataGridViewRoom.AllowUserToDeleteRows = false;
            this.dataGridViewRoom.AllowUserToResizeRows = false;
            this.dataGridViewRoom.AutoGenerateColumns = false;
            this.dataGridViewRoom.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRoom.ColumnHeadersHeight = 29;
            this.dataGridViewRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reservationIdDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.roomDataGridViewTextBoxColumn,
            this.RoomType,
            this.dateCheckInDataGridViewTextBoxColumn,
            this.dateCheckOutDataGridViewTextBoxColumn,
            this.dateBookRoomDataGridViewTextBoxColumn});
            this.dataGridViewRoom.DataSource = this.roomBooking4ViewBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRoom.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRoom.GridColor = System.Drawing.Color.White;
            this.dataGridViewRoom.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRoom.Name = "dataGridViewRoom";
            this.dataGridViewRoom.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRoom.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRoom.RowHeadersVisible = false;
            this.dataGridViewRoom.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewRoom.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewRoom.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoom.Size = new System.Drawing.Size(919, 371);
            this.dataGridViewRoom.TabIndex = 65;
            this.dataGridViewRoom.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewRoom_CellFormatting);
            // 
            // roomBooking4ViewBindingSource
            // 
            this.roomBooking4ViewBindingSource.DataSource = typeof(HotelManager.fShowAllCurrentBookings.RoomBooking4View);
            // 
            // btnClose_
            // 
            this.btnClose_.ActiveBorderThickness = 1;
            this.btnClose_.ActiveCornerRadius = 20;
            this.btnClose_.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnClose_.ActiveForecolor = System.Drawing.Color.White;
            this.btnClose_.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnClose_.BackColor = System.Drawing.Color.White;
            this.btnClose_.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose_.BackgroundImage")));
            this.btnClose_.ButtonText = "Close";
            this.btnClose_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose_.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose_.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnClose_.IdleBorderThickness = 1;
            this.btnClose_.IdleCornerRadius = 20;
            this.btnClose_.IdleFillColor = System.Drawing.Color.White;
            this.btnClose_.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnClose_.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnClose_.Location = new System.Drawing.Point(742, 433);
            this.btnClose_.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose_.Name = "btnClose_";
            this.btnClose_.Size = new System.Drawing.Size(203, 40);
            this.btnClose_.TabIndex = 66;
            this.btnClose_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose_.Click += new System.EventHandler(this.btnClose__Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCurrentBookings);
            this.tabControl.Controls.Add(this.tabPageAdvanceBookings);
            this.tabControl.Location = new System.Drawing.Point(12, 34);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(933, 403);
            this.tabControl.TabIndex = 67;
            // 
            // tabPageCurrentBookings
            // 
            this.tabPageCurrentBookings.Controls.Add(this.dataGridViewRoom);
            this.tabPageCurrentBookings.Location = new System.Drawing.Point(4, 22);
            this.tabPageCurrentBookings.Name = "tabPageCurrentBookings";
            this.tabPageCurrentBookings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrentBookings.Size = new System.Drawing.Size(925, 377);
            this.tabPageCurrentBookings.TabIndex = 0;
            this.tabPageCurrentBookings.Text = "All Current Bookings";
            this.tabPageCurrentBookings.UseVisualStyleBackColor = true;
            // 
            // tabPageAdvanceBookings
            // 
            this.tabPageAdvanceBookings.Controls.Add(this.dataGridViewAdvanceBookings);
            this.tabPageAdvanceBookings.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdvanceBookings.Name = "tabPageAdvanceBookings";
            this.tabPageAdvanceBookings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanceBookings.Size = new System.Drawing.Size(925, 377);
            this.tabPageAdvanceBookings.TabIndex = 1;
            this.tabPageAdvanceBookings.Text = "Advance Bookings";
            this.tabPageAdvanceBookings.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAdvanceBookings
            // 
            this.dataGridViewAdvanceBookings.AllowUserToAddRows = false;
            this.dataGridViewAdvanceBookings.AllowUserToDeleteRows = false;
            this.dataGridViewAdvanceBookings.AutoGenerateColumns = false;
            this.dataGridViewAdvanceBookings.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAdvanceBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAdvanceBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdvanceBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.roomTypeDataGridViewTextBoxColumn,
            this.DateIn,
            this.DateOut,
            this.DateBookRoom});
            this.dataGridViewAdvanceBookings.DataSource = this.advanceBookingsBindingSource;
            this.dataGridViewAdvanceBookings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAdvanceBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAdvanceBookings.GridColor = System.Drawing.Color.White;
            this.dataGridViewAdvanceBookings.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAdvanceBookings.Name = "dataGridViewAdvanceBookings";
            this.dataGridViewAdvanceBookings.ReadOnly = true;
            this.dataGridViewAdvanceBookings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAdvanceBookings.RowHeadersVisible = false;
            this.dataGridViewAdvanceBookings.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewAdvanceBookings.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewAdvanceBookings.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewAdvanceBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAdvanceBookings.Size = new System.Drawing.Size(919, 371);
            this.dataGridViewAdvanceBookings.TabIndex = 0;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // roomTypeDataGridViewTextBoxColumn
            // 
            this.roomTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.roomTypeDataGridViewTextBoxColumn.DataPropertyName = "RoomType";
            this.roomTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.roomTypeDataGridViewTextBoxColumn.Name = "roomTypeDataGridViewTextBoxColumn";
            this.roomTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DateIn
            // 
            this.DateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateIn.DataPropertyName = "DateIn";
            this.DateIn.HeaderText = "Check-In";
            this.DateIn.Name = "DateIn";
            this.DateIn.ReadOnly = true;
            // 
            // DateOut
            // 
            this.DateOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateOut.DataPropertyName = "DateOut";
            this.DateOut.HeaderText = "Check Out";
            this.DateOut.Name = "DateOut";
            this.DateOut.ReadOnly = true;
            // 
            // DateBookRoom
            // 
            this.DateBookRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateBookRoom.DataPropertyName = "DateBookRoom";
            this.DateBookRoom.HeaderText = "Booked on";
            this.DateBookRoom.Name = "DateBookRoom";
            this.DateBookRoom.ReadOnly = true;
            // 
            // advanceBookingsBindingSource
            // 
            this.advanceBookingsBindingSource.DataSource = typeof(HotelManager.fAdvanceBooking.AdvanceRoomBooking4Grid);
            // 
            // reservationIdDataGridViewTextBoxColumn
            // 
            this.reservationIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reservationIdDataGridViewTextBoxColumn.DataPropertyName = "ReservationId";
            this.reservationIdDataGridViewTextBoxColumn.HeaderText = "Reservation Id";
            this.reservationIdDataGridViewTextBoxColumn.Name = "reservationIdDataGridViewTextBoxColumn";
            this.reservationIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roomDataGridViewTextBoxColumn
            // 
            this.roomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.roomDataGridViewTextBoxColumn.HeaderText = "Room";
            this.roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            this.roomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RoomType
            // 
            this.RoomType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoomType.DataPropertyName = "RoomTypeName";
            this.RoomType.HeaderText = "Room Type";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            // 
            // dateCheckInDataGridViewTextBoxColumn
            // 
            this.dateCheckInDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCheckInDataGridViewTextBoxColumn.DataPropertyName = "DateCheckIn";
            this.dateCheckInDataGridViewTextBoxColumn.HeaderText = "Check-In";
            this.dateCheckInDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.dateCheckInDataGridViewTextBoxColumn.Name = "dateCheckInDataGridViewTextBoxColumn";
            this.dateCheckInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCheckOutDataGridViewTextBoxColumn
            // 
            this.dateCheckOutDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCheckOutDataGridViewTextBoxColumn.DataPropertyName = "DateCheckOut";
            this.dateCheckOutDataGridViewTextBoxColumn.HeaderText = "Check Out";
            this.dateCheckOutDataGridViewTextBoxColumn.Name = "dateCheckOutDataGridViewTextBoxColumn";
            this.dateCheckOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateBookRoomDataGridViewTextBoxColumn
            // 
            this.dateBookRoomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateBookRoomDataGridViewTextBoxColumn.DataPropertyName = "DateBookRoom";
            this.dateBookRoomDataGridViewTextBoxColumn.HeaderText = "Booked on";
            this.dateBookRoomDataGridViewTextBoxColumn.Name = "dateBookRoomDataGridViewTextBoxColumn";
            this.dateBookRoomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fShowAllCurrentBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 479);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnClose_);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "fShowAllCurrentBookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access";
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBooking4ViewBindingSource)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageCurrentBookings.ResumeLayout(false);
            this.tabPageAdvanceBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdvanceBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advanceBookingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.DataGridView dataGridViewRoom;
        private System.Windows.Forms.BindingSource roomBooking4ViewBindingSource;
        private Bunifu.Framework.UI.BunifuThinButton2 btnClose_;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCurrentBookings;
        private System.Windows.Forms.TabPage tabPageAdvanceBookings;
        private System.Windows.Forms.DataGridView dataGridViewAdvanceBookings;
        private System.Windows.Forms.BindingSource advanceBookingsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBookRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheckInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheckOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBookRoomDataGridViewTextBoxColumn;
    }
}