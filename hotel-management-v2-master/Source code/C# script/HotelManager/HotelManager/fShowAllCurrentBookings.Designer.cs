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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fShowAllCurrentBookings));
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.dataGridViewRoom = new System.Windows.Forms.DataGridView();
            this.roomBooking4ViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose_ = new Bunifu.Framework.UI.BunifuThinButton2();
            this.reservationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCheckInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCheckOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBookRoomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBooking4ViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(5, 43);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(938, 10);
            this.bunifuSeparator1.TabIndex = 64;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SeaGreen;
            this.label6.Location = new System.Drawing.Point(8, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 37);
            this.label6.TabIndex = 63;
            this.label6.Text = "Current bookings";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewRoom.ColumnHeadersHeight = 29;
            this.dataGridViewRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reservationIdDataGridViewTextBoxColumn,
            this.roomDataGridViewTextBoxColumn,
            this.RoomType,
            this.RoomNumber,
            this.customerNameDataGridViewTextBoxColumn,
            this.dateCheckInDataGridViewTextBoxColumn,
            this.dateCheckOutDataGridViewTextBoxColumn,
            this.dateBookRoomDataGridViewTextBoxColumn});
            this.dataGridViewRoom.DataSource = this.roomBooking4ViewBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRoom.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewRoom.GridColor = System.Drawing.Color.White;
            this.dataGridViewRoom.Location = new System.Drawing.Point(5, 61);
            this.dataGridViewRoom.Name = "dataGridViewRoom";
            this.dataGridViewRoom.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRoom.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewRoom.RowHeadersVisible = false;
            this.dataGridViewRoom.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewRoom.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewRoom.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoom.Size = new System.Drawing.Size(940, 364);
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
            // reservationIdDataGridViewTextBoxColumn
            // 
            this.reservationIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reservationIdDataGridViewTextBoxColumn.DataPropertyName = "ReservationId";
            this.reservationIdDataGridViewTextBoxColumn.HeaderText = "Reservation Id";
            this.reservationIdDataGridViewTextBoxColumn.Name = "reservationIdDataGridViewTextBoxColumn";
            this.reservationIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roomDataGridViewTextBoxColumn
            // 
            this.roomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.roomDataGridViewTextBoxColumn.HeaderText = "Room Name";
            this.roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            this.roomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RoomType
            // 
            this.RoomType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoomType.HeaderText = "Room Type";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            // 
            // RoomNumber
            // 
            this.RoomNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoomNumber.HeaderText = "Room No.";
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.ReadOnly = true;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCheckInDataGridViewTextBoxColumn
            // 
            this.dateCheckInDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCheckInDataGridViewTextBoxColumn.DataPropertyName = "DateCheckIn";
            this.dateCheckInDataGridViewTextBoxColumn.HeaderText = "Check in date";
            this.dateCheckInDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.dateCheckInDataGridViewTextBoxColumn.Name = "dateCheckInDataGridViewTextBoxColumn";
            this.dateCheckInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCheckOutDataGridViewTextBoxColumn
            // 
            this.dateCheckOutDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCheckOutDataGridViewTextBoxColumn.DataPropertyName = "DateCheckOut";
            this.dateCheckOutDataGridViewTextBoxColumn.HeaderText = "Check out date";
            this.dateCheckOutDataGridViewTextBoxColumn.Name = "dateCheckOutDataGridViewTextBoxColumn";
            this.dateCheckOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateBookRoomDataGridViewTextBoxColumn
            // 
            this.dateBookRoomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateBookRoomDataGridViewTextBoxColumn.DataPropertyName = "DateBookRoom";
            this.dateBookRoomDataGridViewTextBoxColumn.HeaderText = "Room booked on";
            this.dateBookRoomDataGridViewTextBoxColumn.Name = "dateBookRoomDataGridViewTextBoxColumn";
            this.dateBookRoomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fShowAllCurrentBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 479);
            this.Controls.Add(this.btnClose_);
            this.Controls.Add(this.dataGridViewRoom);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label6);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.DataGridView dataGridViewRoom;
        private System.Windows.Forms.BindingSource roomBooking4ViewBindingSource;
        private Bunifu.Framework.UI.BunifuThinButton2 btnClose_;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheckInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheckOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBookRoomDataGridViewTextBoxColumn;
    }
}