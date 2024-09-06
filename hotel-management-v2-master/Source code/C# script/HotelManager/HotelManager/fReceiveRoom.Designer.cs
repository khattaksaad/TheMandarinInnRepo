namespace HotelManager
{
    partial class fReceiveRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReceiveRoom));
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnCheckItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckOutDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookedForCustomersUIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txbIDBookRoom = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txbIDCard = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label15 = new System.Windows.Forms.Label();
            this.txbFullName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch4RoomBooking = new Bunifu.Framework.UI.BunifuThinButton2();
            this.cbRoom = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRoomType = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSearchForCustomer = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnClose_ = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnReceiveRoom = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookedForCustomersUIBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 37);
            this.label2.TabIndex = 26;
            this.label2.Text = "Check out";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(7, 44);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(970, 10);
            this.bunifuSeparator1.TabIndex = 29;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox4.Location = new System.Drawing.Point(236, 55);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(741, 545);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "List of booked rooms";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 517);
            this.panel2.TabIndex = 39;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckItem,
            this.customerNameDataGridViewTextBoxColumn,
            this.roomNameDataGridViewTextBoxColumn,
            this.roomTypeNameDataGridViewTextBoxColumn,
            this.CheckInDate,
            this.CheckOutDate1,
            this.BookingDate});
            this.dataGridView1.DataSource = this.bookedForCustomersUIBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(735, 517);
            this.dataGridView1.TabIndex = 49;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnCheckItem
            // 
            this.ColumnCheckItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCheckItem.DataPropertyName = "IsChecked";
            this.ColumnCheckItem.HeaderText = "";
            this.ColumnCheckItem.MinimumWidth = 25;
            this.ColumnCheckItem.Name = "ColumnCheckItem";
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            // 
            // roomNameDataGridViewTextBoxColumn
            // 
            this.roomNameDataGridViewTextBoxColumn.DataPropertyName = "RoomName";
            this.roomNameDataGridViewTextBoxColumn.HeaderText = "Room Name";
            this.roomNameDataGridViewTextBoxColumn.Name = "roomNameDataGridViewTextBoxColumn";
            // 
            // roomTypeNameDataGridViewTextBoxColumn
            // 
            this.roomTypeNameDataGridViewTextBoxColumn.DataPropertyName = "RoomTypeName";
            this.roomTypeNameDataGridViewTextBoxColumn.HeaderText = "Room Type";
            this.roomTypeNameDataGridViewTextBoxColumn.Name = "roomTypeNameDataGridViewTextBoxColumn";
            // 
            // CheckInDate
            // 
            this.CheckInDate.DataPropertyName = "CheckInDate";
            this.CheckInDate.HeaderText = "Check-In";
            this.CheckInDate.Name = "CheckInDate";
            // 
            // CheckOutDate1
            // 
            this.CheckOutDate1.DataPropertyName = "CheckOutDate1";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.CheckOutDate1.DefaultCellStyle = dataGridViewCellStyle1;
            this.CheckOutDate1.HeaderText = "Check Out";
            this.CheckOutDate1.Name = "CheckOutDate1";
            // 
            // BookingDate
            // 
            this.BookingDate.DataPropertyName = "BookingDate";
            this.BookingDate.HeaderText = "Booking Date";
            this.BookingDate.Name = "BookingDate";
            // 
            // bookedForCustomersUIBindingSource
            // 
            this.bookedForCustomersUIBindingSource.DataSource = typeof(HotelManager.fReceiveRoom.BookedForCustomersUI);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Reservation code:";
            // 
            // txbIDBookRoom
            // 
            this.txbIDBookRoom.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbIDBookRoom.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbIDBookRoom.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbIDBookRoom.BorderThickness = 1;
            this.txbIDBookRoom.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txbIDBookRoom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbIDBookRoom.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbIDBookRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbIDBookRoom.isPassword = false;
            this.txbIDBookRoom.Location = new System.Drawing.Point(10, 51);
            this.txbIDBookRoom.Margin = new System.Windows.Forms.Padding(4);
            this.txbIDBookRoom.MaxLength = 32767;
            this.txbIDBookRoom.Name = "txbIDBookRoom";
            this.txbIDBookRoom.Size = new System.Drawing.Size(203, 29);
            this.txbIDBookRoom.TabIndex = 27;
            this.txbIDBookRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbIDBookRoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbIDBookRoom_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txbIDBookRoom);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox3.Location = new System.Drawing.Point(7, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 144);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Res. Code";
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveBorderThickness = 1;
            this.btnSearch.ActiveCornerRadius = 20;
            this.btnSearch.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.ActiveForecolor = System.Drawing.Color.White;
            this.btnSearch.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.ButtonText = "Search";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.IdleBorderThickness = 1;
            this.btnSearch.IdleCornerRadius = 20;
            this.btnSearch.IdleFillColor = System.Drawing.Color.White;
            this.btnSearch.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnSearch.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.Location = new System.Drawing.Point(10, 90);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(203, 40);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txbIDCard
            // 
            this.txbIDCard.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbIDCard.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbIDCard.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbIDCard.BorderThickness = 1;
            this.txbIDCard.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txbIDCard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbIDCard.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbIDCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbIDCard.isPassword = false;
            this.txbIDCard.Location = new System.Drawing.Point(6, 106);
            this.txbIDCard.Margin = new System.Windows.Forms.Padding(4);
            this.txbIDCard.MaxLength = 32767;
            this.txbIDCard.Name = "txbIDCard";
            this.txbIDCard.Size = new System.Drawing.Size(207, 29);
            this.txbIDCard.TabIndex = 50;
            this.txbIDCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.SeaGreen;
            this.label15.Location = new System.Drawing.Point(6, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 20);
            this.label15.TabIndex = 52;
            this.label15.Text = "CNIC:";
            // 
            // txbFullName
            // 
            this.txbFullName.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbFullName.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbFullName.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbFullName.BorderThickness = 1;
            this.txbFullName.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txbFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFullName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbFullName.isPassword = false;
            this.txbFullName.Location = new System.Drawing.Point(6, 49);
            this.txbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txbFullName.MaxLength = 32767;
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Size = new System.Drawing.Size(207, 29);
            this.txbFullName.TabIndex = 49;
            this.txbFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.SeaGreen;
            this.label16.Location = new System.Drawing.Point(6, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 20);
            this.label16.TabIndex = 51;
            this.label16.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch4RoomBooking);
            this.groupBox2.Controls.Add(this.cbRoom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbRoomType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox2.Location = new System.Drawing.Point(7, 414);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 186);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by room";
            // 
            // btnSearch4RoomBooking
            // 
            this.btnSearch4RoomBooking.ActiveBorderThickness = 1;
            this.btnSearch4RoomBooking.ActiveCornerRadius = 20;
            this.btnSearch4RoomBooking.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSearch4RoomBooking.ActiveForecolor = System.Drawing.Color.White;
            this.btnSearch4RoomBooking.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearch4RoomBooking.BackColor = System.Drawing.Color.White;
            this.btnSearch4RoomBooking.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch4RoomBooking.BackgroundImage")));
            this.btnSearch4RoomBooking.ButtonText = "Search";
            this.btnSearch4RoomBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch4RoomBooking.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch4RoomBooking.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSearch4RoomBooking.IdleBorderThickness = 1;
            this.btnSearch4RoomBooking.IdleCornerRadius = 20;
            this.btnSearch4RoomBooking.IdleFillColor = System.Drawing.Color.White;
            this.btnSearch4RoomBooking.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnSearch4RoomBooking.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearch4RoomBooking.Location = new System.Drawing.Point(8, 138);
            this.btnSearch4RoomBooking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch4RoomBooking.Name = "btnSearch4RoomBooking";
            this.btnSearch4RoomBooking.Size = new System.Drawing.Size(205, 40);
            this.btnSearch4RoomBooking.TabIndex = 47;
            this.btnSearch4RoomBooking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch4RoomBooking.Click += new System.EventHandler(this.btnSearch4RoomBooking_Click);
            // 
            // cbRoom
            // 
            this.cbRoom.BackColor = System.Drawing.Color.White;
            this.cbRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.ItemHeight = 23;
            this.cbRoom.Location = new System.Drawing.Point(10, 101);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(203, 29);
            this.cbRoom.Style = MetroFramework.MetroColorStyle.Green;
            this.cbRoom.TabIndex = 54;
            this.cbRoom.UseCustomBackColor = true;
            this.cbRoom.UseCustomForeColor = true;
            this.cbRoom.UseSelectable = true;
            this.cbRoom.UseStyleColors = true;
            this.cbRoom.SelectedIndexChanged += new System.EventHandler(this.cbRoom_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(6, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Room:";
            // 
            // cbRoomType
            // 
            this.cbRoomType.BackColor = System.Drawing.Color.White;
            this.cbRoomType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRoomType.FormattingEnabled = true;
            this.cbRoomType.ItemHeight = 23;
            this.cbRoomType.Location = new System.Drawing.Point(10, 47);
            this.cbRoomType.Name = "cbRoomType";
            this.cbRoomType.Size = new System.Drawing.Size(203, 29);
            this.cbRoomType.Style = MetroFramework.MetroColorStyle.Green;
            this.cbRoomType.TabIndex = 52;
            this.cbRoomType.UseCustomBackColor = true;
            this.cbRoomType.UseCustomForeColor = true;
            this.cbRoomType.UseSelectable = true;
            this.cbRoomType.UseStyleColors = true;
            this.cbRoomType.SelectedIndexChanged += new System.EventHandler(this.cbRoomType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SeaGreen;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Kind of room:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSearchForCustomer);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txbFullName);
            this.groupBox6.Controls.Add(this.txbIDCard);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox6.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox6.Location = new System.Drawing.Point(7, 60);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(223, 198);
            this.groupBox6.TabIndex = 47;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Search for customer";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // btnSearchForCustomer
            // 
            this.btnSearchForCustomer.ActiveBorderThickness = 1;
            this.btnSearchForCustomer.ActiveCornerRadius = 20;
            this.btnSearchForCustomer.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSearchForCustomer.ActiveForecolor = System.Drawing.Color.White;
            this.btnSearchForCustomer.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearchForCustomer.BackColor = System.Drawing.Color.White;
            this.btnSearchForCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchForCustomer.BackgroundImage")));
            this.btnSearchForCustomer.ButtonText = "Search";
            this.btnSearchForCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchForCustomer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchForCustomer.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSearchForCustomer.IdleBorderThickness = 1;
            this.btnSearchForCustomer.IdleCornerRadius = 20;
            this.btnSearchForCustomer.IdleFillColor = System.Drawing.Color.White;
            this.btnSearchForCustomer.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnSearchForCustomer.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearchForCustomer.Location = new System.Drawing.Point(8, 150);
            this.btnSearchForCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearchForCustomer.Name = "btnSearchForCustomer";
            this.btnSearchForCustomer.Size = new System.Drawing.Size(205, 40);
            this.btnSearchForCustomer.TabIndex = 47;
            this.btnSearchForCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearchForCustomer.Click += new System.EventHandler(this.btnSearchForCustomer_Click);
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
            this.btnClose_.Location = new System.Drawing.Point(775, 608);
            this.btnClose_.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose_.Name = "btnClose_";
            this.btnClose_.Size = new System.Drawing.Size(203, 40);
            this.btnClose_.TabIndex = 48;
            this.btnClose_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose_.Click += new System.EventHandler(this.btnClose__Click);
            // 
            // btnReceiveRoom
            // 
            this.btnReceiveRoom.ActiveBorderThickness = 1;
            this.btnReceiveRoom.ActiveCornerRadius = 20;
            this.btnReceiveRoom.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnReceiveRoom.ActiveForecolor = System.Drawing.Color.White;
            this.btnReceiveRoom.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnReceiveRoom.BackColor = System.Drawing.Color.White;
            this.btnReceiveRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReceiveRoom.BackgroundImage")));
            this.btnReceiveRoom.ButtonText = "Check out";
            this.btnReceiveRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceiveRoom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveRoom.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnReceiveRoom.IdleBorderThickness = 1;
            this.btnReceiveRoom.IdleCornerRadius = 20;
            this.btnReceiveRoom.IdleFillColor = System.Drawing.Color.White;
            this.btnReceiveRoom.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnReceiveRoom.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnReceiveRoom.Location = new System.Drawing.Point(564, 608);
            this.btnReceiveRoom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReceiveRoom.Name = "btnReceiveRoom";
            this.btnReceiveRoom.Size = new System.Drawing.Size(203, 40);
            this.btnReceiveRoom.TabIndex = 45;
            this.btnReceiveRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReceiveRoom.Click += new System.EventHandler(this.btnReceiveRoom_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(962, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 27;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fReceiveRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.btnClose_);
            this.Controls.Add(this.btnReceiveRoom);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fReceiveRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fReceiveRoom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fReceiveRoom_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookedForCustomersUIBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuThinButton2 btnReceiveRoom;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbIDBookRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroComboBox cbRoom;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox cbRoomType;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbIDCard;
        private System.Windows.Forms.Label label15;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbFullName;
        private System.Windows.Forms.Label label16;
        private Bunifu.Framework.UI.BunifuThinButton2 btnClose_;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearchForCustomer;
        private System.Windows.Forms.BindingSource bookedForCustomersUIBindingSource;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearch4RoomBooking;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckOutDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingDate;
    }
}