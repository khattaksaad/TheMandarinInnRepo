namespace HotelManager
{
    partial class fManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fManagement));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelRight = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.metroTileCustomerManagement = new MetroFramework.Controls.MetroTile();
            this.metroTileBillManagement = new MetroFramework.Controls.MetroTile();
            this.metroTilePayment = new MetroFramework.Controls.MetroTile();
            this.titleReports = new MetroFramework.Controls.MetroTile();
            this.titleManageRoom = new MetroFramework.Controls.MetroTile();
            this.metroTileServiceManagement = new MetroFramework.Controls.MetroTile();
            this.metroTileManageProfile = new MetroFramework.Controls.MetroTile();
            this.titleRoomService = new MetroFramework.Controls.MetroTile();
            this.titleRecieveRoom = new MetroFramework.Controls.MetroTile();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.titleBookRoom = new MetroFramework.Controls.MetroTile();
            this.metroTileAdvanceBooking = new MetroFramework.Controls.MetroTile();
            this.metroTileShowAllBookedRooms = new MetroFramework.Controls.MetroTile();
            this.panelLeft = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bbtnUploadDB = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNavigationPanel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAccountProfile = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLogOut = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHelp = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnIntroduce = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelRight;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.bunifuSeparator1);
            this.panelRight.Controls.Add(this.metroTileCustomerManagement);
            this.panelRight.Controls.Add(this.metroTileBillManagement);
            this.panelRight.Controls.Add(this.metroTilePayment);
            this.panelRight.Controls.Add(this.titleReports);
            this.panelRight.Controls.Add(this.titleManageRoom);
            this.panelRight.Controls.Add(this.metroTileServiceManagement);
            this.panelRight.Controls.Add(this.metroTileManageProfile);
            this.panelRight.Controls.Add(this.titleRoomService);
            this.panelRight.Controls.Add(this.titleRecieveRoom);
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.titleBookRoom);
            this.panelRight.Controls.Add(this.metroTileAdvanceBooking);
            this.panelRight.Controls.Add(this.metroTileShowAllBookedRooms);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(171, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(942, 576);
            this.panelRight.TabIndex = 1;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(14, 42);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(886, 19);
            this.bunifuSeparator1.TabIndex = 54;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // metroTileCustomerManagement
            // 
            this.metroTileCustomerManagement.ActiveControl = null;
            this.metroTileCustomerManagement.BackColor = System.Drawing.Color.SeaGreen;
            this.metroTileCustomerManagement.ForeColor = System.Drawing.Color.White;
            this.metroTileCustomerManagement.Location = new System.Drawing.Point(623, 74);
            this.metroTileCustomerManagement.Name = "metroTile17";
            this.metroTileCustomerManagement.Size = new System.Drawing.Size(276, 135);
            this.metroTileCustomerManagement.TabIndex = 47;
            this.metroTileCustomerManagement.Text = "Manage Customers";
            this.metroTileCustomerManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileCustomerManagement.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileCustomerManagement.TileImage")));
            this.metroTileCustomerManagement.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileCustomerManagement.UseCustomBackColor = true;
            this.metroTileCustomerManagement.UseCustomForeColor = true;
            this.metroTileCustomerManagement.UseSelectable = true;
            this.metroTileCustomerManagement.UseStyleColors = true;
            this.metroTileCustomerManagement.UseTileImage = true;
            this.metroTileCustomerManagement.UseVisualStyleBackColor = false;
            this.metroTileCustomerManagement.Click += new System.EventHandler(this.metroTile17_Click);
            // 
            // metroTileBillManagement
            // 
            this.metroTileBillManagement.ActiveControl = null;
            this.metroTileBillManagement.BackColor = System.Drawing.Color.SeaGreen;
            this.metroTileBillManagement.ForeColor = System.Drawing.Color.White;
            this.metroTileBillManagement.Location = new System.Drawing.Point(475, 404);
            this.metroTileBillManagement.Name = "metroTile16";
            this.metroTileBillManagement.Size = new System.Drawing.Size(135, 135);
            this.metroTileBillManagement.TabIndex = 44;
            this.metroTileBillManagement.Text = "Manage Billing";
            this.metroTileBillManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileBillManagement.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileBillManagement.TileImage")));
            this.metroTileBillManagement.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileBillManagement.UseCustomBackColor = true;
            this.metroTileBillManagement.UseCustomForeColor = true;
            this.metroTileBillManagement.UseSelectable = true;
            this.metroTileBillManagement.UseStyleColors = true;
            this.metroTileBillManagement.UseTileImage = true;
            this.metroTileBillManagement.UseVisualStyleBackColor = false;
            this.metroTileBillManagement.Click += new System.EventHandler(this.metroTile16_Click);
            // 
            // metroTilePayment
            // 
            this.metroTilePayment.ActiveControl = null;
            this.metroTilePayment.BackColor = System.Drawing.Color.SeaGreen;
            this.metroTilePayment.ForeColor = System.Drawing.Color.White;
            this.metroTilePayment.Location = new System.Drawing.Point(329, 237);
            this.metroTilePayment.Name = "metroTile13";
            this.metroTilePayment.Size = new System.Drawing.Size(276, 135);
            this.metroTilePayment.TabIndex = 41;
            this.metroTilePayment.Text = "Payment";
            this.metroTilePayment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTilePayment.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTilePayment.TileImage")));
            this.metroTilePayment.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTilePayment.UseCustomBackColor = true;
            this.metroTilePayment.UseCustomForeColor = true;
            this.metroTilePayment.UseSelectable = true;
            this.metroTilePayment.UseStyleColors = true;
            this.metroTilePayment.UseTileImage = true;
            this.metroTilePayment.UseVisualStyleBackColor = false;
            this.metroTilePayment.Click += new System.EventHandler(this.metroTile13_Click);
            // 
            // titleReports
            // 
            this.titleReports.ActiveControl = null;
            this.titleReports.BackColor = System.Drawing.Color.SeaGreen;
            this.titleReports.ForeColor = System.Drawing.Color.White;
            this.titleReports.Location = new System.Drawing.Point(625, 405);
            this.titleReports.Name = "title";
            this.titleReports.Size = new System.Drawing.Size(276, 135);
            this.titleReports.TabIndex = 36;
            this.titleReports.Text = "Reports";
            this.titleReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.titleReports.TileImage = ((System.Drawing.Image)(resources.GetObject("titleReports.TileImage")));
            this.titleReports.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleReports.UseCustomBackColor = true;
            this.titleReports.UseCustomForeColor = true;
            this.titleReports.UseSelectable = true;
            this.titleReports.UseStyleColors = true;
            this.titleReports.UseTileImage = true;
            this.titleReports.UseVisualStyleBackColor = false;
            this.titleReports.Click += new System.EventHandler(this.title_Click);
            // 
            // titleManageRoom
            // 
            this.titleManageRoom.ActiveControl = null;
            this.titleManageRoom.BackColor = System.Drawing.Color.SeaGreen;
            this.titleManageRoom.ForeColor = System.Drawing.Color.White;
            this.titleManageRoom.Location = new System.Drawing.Point(178, 404);
            this.titleManageRoom.Name = "titleManageRoom";
            this.titleManageRoom.Size = new System.Drawing.Size(135, 135);
            this.titleManageRoom.TabIndex = 34;
            this.titleManageRoom.Text = "Manage Rooms";
            this.titleManageRoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.titleManageRoom.TileImage = ((System.Drawing.Image)(resources.GetObject("titleManageRoom.TileImage")));
            this.titleManageRoom.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleManageRoom.UseCustomBackColor = true;
            this.titleManageRoom.UseCustomForeColor = true;
            this.titleManageRoom.UseSelectable = true;
            this.titleManageRoom.UseStyleColors = true;
            this.titleManageRoom.UseTileImage = true;
            this.titleManageRoom.UseVisualStyleBackColor = false;
            this.titleManageRoom.Click += new System.EventHandler(this.titleManageRoom_Click);
            // 
            // metroTileServiceManagement
            // 
            this.metroTileServiceManagement.ActiveControl = null;
            this.metroTileServiceManagement.BackColor = System.Drawing.Color.SeaGreen;
            this.metroTileServiceManagement.ForeColor = System.Drawing.Color.White;
            this.metroTileServiceManagement.Location = new System.Drawing.Point(330, 404);
            this.metroTileServiceManagement.Name = "metroTile2";
            this.metroTileServiceManagement.Size = new System.Drawing.Size(135, 135);
            this.metroTileServiceManagement.TabIndex = 32;
            this.metroTileServiceManagement.Text = "Manage Services";
            this.metroTileServiceManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileServiceManagement.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileServiceManagement.TileImage")));
            this.metroTileServiceManagement.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileServiceManagement.UseCustomBackColor = true;
            this.metroTileServiceManagement.UseCustomForeColor = true;
            this.metroTileServiceManagement.UseSelectable = true;
            this.metroTileServiceManagement.UseStyleColors = true;
            this.metroTileServiceManagement.UseTileImage = true;
            this.metroTileServiceManagement.UseVisualStyleBackColor = false;
            this.metroTileServiceManagement.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // metroTileManageProfile
            // 
            this.metroTileManageProfile.ActiveControl = null;
            this.metroTileManageProfile.BackColor = System.Drawing.Color.SeaGreen;
            this.metroTileManageProfile.ForeColor = System.Drawing.Color.White;
            this.metroTileManageProfile.Location = new System.Drawing.Point(31, 405);
            this.metroTileManageProfile.Name = "metroTile8";
            this.metroTileManageProfile.Size = new System.Drawing.Size(135, 135);
            this.metroTileManageProfile.TabIndex = 29;
            this.metroTileManageProfile.Text = "Manage Employees";
            this.metroTileManageProfile.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileManageProfile.TileImage")));
            this.metroTileManageProfile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileManageProfile.UseCustomBackColor = true;
            this.metroTileManageProfile.UseCustomForeColor = true;
            this.metroTileManageProfile.UseSelectable = true;
            this.metroTileManageProfile.UseStyleColors = true;
            this.metroTileManageProfile.UseTileImage = true;
            this.metroTileManageProfile.UseVisualStyleBackColor = false;
            this.metroTileManageProfile.Click += new System.EventHandler(this.metroTile8_Click);
            // 
            // titleRoomService
            // 
            this.titleRoomService.ActiveControl = null;
            this.titleRoomService.BackColor = System.Drawing.Color.SeaGreen;
            this.titleRoomService.ForeColor = System.Drawing.Color.White;
            this.titleRoomService.Location = new System.Drawing.Point(176, 73);
            this.titleRoomService.Name = "titlePay";
            this.titleRoomService.Size = new System.Drawing.Size(135, 300);
            this.titleRoomService.TabIndex = 27;
            this.titleRoomService.Text = "Room service";
            this.titleRoomService.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.titleRoomService.TileImage = ((System.Drawing.Image)(resources.GetObject("titleRoomService.TileImage")));
            this.titleRoomService.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleRoomService.UseCustomBackColor = true;
            this.titleRoomService.UseCustomForeColor = true;
            this.titleRoomService.UseSelectable = true;
            this.titleRoomService.UseStyleColors = true;
            this.titleRoomService.UseTileImage = true;
            this.titleRoomService.UseVisualStyleBackColor = false;
            this.titleRoomService.Click += new System.EventHandler(this.titlePay_Click);
            // 
            // titleRecieveRoom
            // 
            this.titleRecieveRoom.ActiveControl = null;
            this.titleRecieveRoom.BackColor = System.Drawing.Color.SeaGreen;
            this.titleRecieveRoom.ForeColor = System.Drawing.Color.White;
            this.titleRecieveRoom.Location = new System.Drawing.Point(328, 75);
            this.titleRecieveRoom.Name = "titleRecieveRoom";
            this.titleRecieveRoom.Size = new System.Drawing.Size(276, 135);
            this.titleRecieveRoom.TabIndex = 25;
            this.titleRecieveRoom.Text = "Checkout";
            this.titleRecieveRoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.titleRecieveRoom.TileImage = ((System.Drawing.Image)(resources.GetObject("titleRecieveRoom.TileImage")));
            this.titleRecieveRoom.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleRecieveRoom.UseCustomBackColor = true;
            this.titleRecieveRoom.UseCustomForeColor = true;
            this.titleRecieveRoom.UseSelectable = true;
            this.titleRecieveRoom.UseStyleColors = true;
            this.titleRecieveRoom.UseTileImage = true;
            this.titleRecieveRoom.UseVisualStyleBackColor = false;
            this.titleRecieveRoom.Click += new System.EventHandler(this.titleRecieveRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(23, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 37);
            this.label2.TabIndex = 21;
            this.label2.Text = "The Mandarin Inn - Hotel Manager";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(919, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 20;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // titleBookRoom
            // 
            this.titleBookRoom.ActiveControl = null;
            this.titleBookRoom.BackColor = System.Drawing.Color.SeaGreen;
            this.titleBookRoom.ForeColor = System.Drawing.Color.White;
            this.titleBookRoom.Location = new System.Drawing.Point(29, 223);
            this.titleBookRoom.Name = "titleBookRoom";
            this.titleBookRoom.Size = new System.Drawing.Size(135, 150);
            this.titleBookRoom.TabIndex = 17;
            this.titleBookRoom.Text = "Book Now";
            this.titleBookRoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.titleBookRoom.TileImage = ((System.Drawing.Image)(resources.GetObject("titleBookRoom.TileImage")));
            this.titleBookRoom.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleBookRoom.UseCustomBackColor = true;
            this.titleBookRoom.UseCustomForeColor = true;
            this.titleBookRoom.UseSelectable = true;
            this.titleBookRoom.UseStyleColors = true;
            this.titleBookRoom.UseTileImage = true;
            this.titleBookRoom.UseVisualStyleBackColor = false;
            this.titleBookRoom.Click += new System.EventHandler(this.titleSignUpRoom_Click);
            // 
            // metroTileAdvanceBooking
            // 
            this.metroTileAdvanceBooking.ActiveControl = null;
            this.metroTileAdvanceBooking.BackColor = System.Drawing.Color.SeaGreen;
            this.metroTileAdvanceBooking.ForeColor = System.Drawing.Color.White;
            this.metroTileAdvanceBooking.Location = new System.Drawing.Point(29, 73);
            this.metroTileAdvanceBooking.Name = "titleBookRoom";
            this.metroTileAdvanceBooking.Size = new System.Drawing.Size(135, 140);
            this.metroTileAdvanceBooking.TabIndex = 17;
            this.metroTileAdvanceBooking.Text = "Advance booking";
            this.metroTileAdvanceBooking.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileAdvanceBooking.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileAdvanceBooking.TileImage")));
            this.metroTileAdvanceBooking.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileAdvanceBooking.UseCustomBackColor = true;
            this.metroTileAdvanceBooking.UseCustomForeColor = true;
            this.metroTileAdvanceBooking.UseSelectable = true;
            this.metroTileAdvanceBooking.UseStyleColors = true;
            this.metroTileAdvanceBooking.UseTileImage = true;
            this.metroTileAdvanceBooking.UseVisualStyleBackColor = false;
            this.metroTileAdvanceBooking.Click += new System.EventHandler(this.metroTileAdvanceBooking_Click);
            // 
            // metroTileShowAllBookedRooms
            // 
            this.metroTileShowAllBookedRooms.ActiveControl = null;
            this.metroTileShowAllBookedRooms.BackColor = System.Drawing.Color.SeaGreen;
            this.metroTileShowAllBookedRooms.ForeColor = System.Drawing.Color.White;
            this.metroTileShowAllBookedRooms.Location = new System.Drawing.Point(623, 238);
            this.metroTileShowAllBookedRooms.Name = "titleShowAllBookedRooms";
            this.metroTileShowAllBookedRooms.Size = new System.Drawing.Size(276, 135);
            this.metroTileShowAllBookedRooms.TabIndex = 0;
            this.metroTileShowAllBookedRooms.Text = "All Current && Advance Bookings";
            this.metroTileShowAllBookedRooms.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileShowAllBookedRooms.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileShowAllBookedRooms.TileImage")));
            this.metroTileShowAllBookedRooms.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileShowAllBookedRooms.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.metroTileShowAllBookedRooms.UseCustomBackColor = true;
            this.metroTileShowAllBookedRooms.UseCustomForeColor = true;
            this.metroTileShowAllBookedRooms.UseSelectable = true;
            this.metroTileShowAllBookedRooms.UseStyleColors = true;
            this.metroTileShowAllBookedRooms.UseTileImage = true;
            this.metroTileShowAllBookedRooms.UseVisualStyleBackColor = false;
            this.metroTileShowAllBookedRooms.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeft.BackgroundImage")));
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeft.Controls.Add(this.bbtnUploadDB);
            this.panelLeft.Controls.Add(this.btnNavigationPanel);
            this.panelLeft.Controls.Add(this.btnAccountProfile);
            this.panelLeft.Controls.Add(this.btnLogOut);
            this.panelLeft.Controls.Add(this.btnHelp);
            this.panelLeft.Controls.Add(this.btnIntroduce);
            this.panelLeft.Controls.Add(this.bunifuFlatButton1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.GradientBottomLeft = System.Drawing.Color.SeaGreen;
            this.panelLeft.GradientBottomRight = System.Drawing.Color.SeaGreen;
            this.panelLeft.GradientTopLeft = System.Drawing.Color.SeaGreen;
            this.panelLeft.GradientTopRight = System.Drawing.Color.SeaGreen;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Quality = 10;
            this.panelLeft.Size = new System.Drawing.Size(171, 576);
            this.panelLeft.TabIndex = 0;
            // 
            // bbtnUploadDB
            // 
            this.bbtnUploadDB.Active = false;
            this.bbtnUploadDB.Activecolor = System.Drawing.Color.SeaGreen;
            this.bbtnUploadDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bbtnUploadDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bbtnUploadDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bbtnUploadDB.BorderRadius = 0;
            this.bbtnUploadDB.ButtonText = "Upload Database";
            this.bbtnUploadDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bbtnUploadDB.DisabledColor = System.Drawing.Color.Gray;
            this.bbtnUploadDB.Iconcolor = System.Drawing.Color.Transparent;
            this.bbtnUploadDB.Iconimage = global::HotelManager.Properties.Resources.database__2_;
            this.bbtnUploadDB.Iconimage_right = null;
            this.bbtnUploadDB.Iconimage_right_Selected = null;
            this.bbtnUploadDB.Iconimage_Selected = null;
            this.bbtnUploadDB.IconMarginLeft = 0;
            this.bbtnUploadDB.IconMarginRight = 0;
            this.bbtnUploadDB.IconRightVisible = true;
            this.bbtnUploadDB.IconRightZoom = 0D;
            this.bbtnUploadDB.IconVisible = true;
            this.bbtnUploadDB.IconZoom = 50D;
            this.bbtnUploadDB.IsTab = false;
            this.bbtnUploadDB.Location = new System.Drawing.Point(0, 490);
            this.bbtnUploadDB.Name = "bbtnUploadDB";
            this.bbtnUploadDB.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bbtnUploadDB.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bbtnUploadDB.OnHoverTextColor = System.Drawing.Color.White;
            this.bbtnUploadDB.selected = false;
            this.bbtnUploadDB.Size = new System.Drawing.Size(177, 40);
            this.bbtnUploadDB.TabIndex = 7;
            this.bbtnUploadDB.Text = "Upload Database";
            this.bbtnUploadDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bbtnUploadDB.Textcolor = System.Drawing.Color.White;
            this.bbtnUploadDB.TextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbtnUploadDB.Click += new System.EventHandler(this.bbtnUploadDB_Click);
            // 
            // btnNavigationPanel
            // 
            this.btnNavigationPanel.Active = false;
            this.btnNavigationPanel.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnNavigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNavigationPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNavigationPanel.BorderRadius = 0;
            this.btnNavigationPanel.ButtonText = "";
            this.btnNavigationPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavigationPanel.DisabledColor = System.Drawing.Color.Gray;
            this.btnNavigationPanel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNavigationPanel.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNavigationPanel.Iconimage")));
            this.btnNavigationPanel.Iconimage_right = null;
            this.btnNavigationPanel.Iconimage_right_Selected = null;
            this.btnNavigationPanel.Iconimage_Selected = null;
            this.btnNavigationPanel.IconMarginLeft = 0;
            this.btnNavigationPanel.IconMarginRight = 0;
            this.btnNavigationPanel.IconRightVisible = true;
            this.btnNavigationPanel.IconRightZoom = 0D;
            this.btnNavigationPanel.IconVisible = true;
            this.btnNavigationPanel.IconZoom = 50D;
            this.btnNavigationPanel.IsTab = false;
            this.btnNavigationPanel.Location = new System.Drawing.Point(0, 0);
            this.btnNavigationPanel.Name = "btnNavigationPanel";
            this.btnNavigationPanel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNavigationPanel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnNavigationPanel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNavigationPanel.selected = false;
            this.btnNavigationPanel.Size = new System.Drawing.Size(177, 40);
            this.btnNavigationPanel.TabIndex = 6;
            this.btnNavigationPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavigationPanel.Textcolor = System.Drawing.Color.White;
            this.btnNavigationPanel.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnNavigationPanel.Click += new System.EventHandler(this.btnNavigationPanel_Click_1);
            // 
            // btnAccountProfile
            // 
            this.btnAccountProfile.Active = false;
            this.btnAccountProfile.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnAccountProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccountProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAccountProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccountProfile.BorderRadius = 0;
            this.btnAccountProfile.ButtonText = "Account profile";
            this.btnAccountProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountProfile.DisabledColor = System.Drawing.Color.Gray;
            this.btnAccountProfile.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAccountProfile.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAccountProfile.Iconimage")));
            this.btnAccountProfile.Iconimage_right = null;
            this.btnAccountProfile.Iconimage_right_Selected = null;
            this.btnAccountProfile.Iconimage_Selected = null;
            this.btnAccountProfile.IconMarginLeft = 0;
            this.btnAccountProfile.IconMarginRight = 0;
            this.btnAccountProfile.IconRightVisible = true;
            this.btnAccountProfile.IconRightZoom = 0D;
            this.btnAccountProfile.IconVisible = true;
            this.btnAccountProfile.IconZoom = 50D;
            this.btnAccountProfile.IsTab = false;
            this.btnAccountProfile.Location = new System.Drawing.Point(0, 352);
            this.btnAccountProfile.Name = "btnAccountProfile";
            this.btnAccountProfile.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAccountProfile.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnAccountProfile.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAccountProfile.selected = false;
            this.btnAccountProfile.Size = new System.Drawing.Size(177, 40);
            this.btnAccountProfile.TabIndex = 5;
            this.btnAccountProfile.Text = "Account profile";
            this.btnAccountProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountProfile.Textcolor = System.Drawing.Color.White;
            this.btnAccountProfile.TextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountProfile.Click += new System.EventHandler(this.btnAccountProfile_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Active = false;
            this.btnLogOut.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogOut.BorderRadius = 0;
            this.btnLogOut.ButtonText = "Logout";
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogOut.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogOut.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Iconimage")));
            this.btnLogOut.Iconimage_right = null;
            this.btnLogOut.Iconimage_right_Selected = null;
            this.btnLogOut.Iconimage_Selected = null;
            this.btnLogOut.IconMarginLeft = 0;
            this.btnLogOut.IconMarginRight = 0;
            this.btnLogOut.IconRightVisible = true;
            this.btnLogOut.IconRightZoom = 0D;
            this.btnLogOut.IconVisible = true;
            this.btnLogOut.IconZoom = 50D;
            this.btnLogOut.IsTab = false;
            this.btnLogOut.Location = new System.Drawing.Point(0, 398);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLogOut.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnLogOut.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogOut.selected = false;
            this.btnLogOut.Size = new System.Drawing.Size(177, 40);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Textcolor = System.Drawing.Color.White;
            this.btnLogOut.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Active = false;
            this.btnHelp.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.BorderRadius = 0;
            this.btnHelp.ButtonText = "Help";
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.DisabledColor = System.Drawing.Color.Gray;
            this.btnHelp.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHelp.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHelp.Iconimage")));
            this.btnHelp.Iconimage_right = null;
            this.btnHelp.Iconimage_right_Selected = null;
            this.btnHelp.Iconimage_Selected = null;
            this.btnHelp.IconMarginLeft = 0;
            this.btnHelp.IconMarginRight = 0;
            this.btnHelp.IconRightVisible = true;
            this.btnHelp.IconRightZoom = 0D;
            this.btnHelp.IconVisible = true;
            this.btnHelp.IconZoom = 50D;
            this.btnHelp.IsTab = false;
            this.btnHelp.Location = new System.Drawing.Point(0, 444);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnHelp.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnHelp.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHelp.selected = false;
            this.btnHelp.Size = new System.Drawing.Size(177, 40);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Textcolor = System.Drawing.Color.White;
            this.btnHelp.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            // 
            // btnIntroduce
            // 
            this.btnIntroduce.Active = false;
            this.btnIntroduce.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnIntroduce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIntroduce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnIntroduce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIntroduce.BorderRadius = 0;
            this.btnIntroduce.ButtonText = "Info";
            this.btnIntroduce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntroduce.DisabledColor = System.Drawing.Color.Gray;
            this.btnIntroduce.Iconcolor = System.Drawing.Color.Transparent;
            this.btnIntroduce.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnIntroduce.Iconimage")));
            this.btnIntroduce.Iconimage_right = null;
            this.btnIntroduce.Iconimage_right_Selected = null;
            this.btnIntroduce.Iconimage_Selected = null;
            this.btnIntroduce.IconMarginLeft = 0;
            this.btnIntroduce.IconMarginRight = 0;
            this.btnIntroduce.IconRightVisible = true;
            this.btnIntroduce.IconRightZoom = 0D;
            this.btnIntroduce.IconVisible = true;
            this.btnIntroduce.IconZoom = 50D;
            this.btnIntroduce.IsTab = false;
            this.btnIntroduce.Location = new System.Drawing.Point(0, 535);
            this.btnIntroduce.Name = "btnIntroduce";
            this.btnIntroduce.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnIntroduce.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnIntroduce.OnHoverTextColor = System.Drawing.Color.White;
            this.btnIntroduce.selected = false;
            this.btnIntroduce.Size = new System.Drawing.Size(177, 40);
            this.btnIntroduce.TabIndex = 2;
            this.btnIntroduce.Text = "Info";
            this.btnIntroduce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntroduce.Textcolor = System.Drawing.Color.White;
            this.btnIntroduce.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnIntroduce.Click += new System.EventHandler(this.btnIntroduce_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Active = false;
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.Maroon;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Giới Thiệu";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(0, 670);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(206, 46);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "Giới Thiệu";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // fManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1113, 576);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Manager";
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuGradientPanel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private MetroFramework.Controls.MetroTile titleBookRoom;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTile titleManageRoom;
        private MetroFramework.Controls.MetroTile metroTileServiceManagement;
        private MetroFramework.Controls.MetroTile metroTileManageProfile;
        private MetroFramework.Controls.MetroTile titleRoomService;
        private MetroFramework.Controls.MetroTile titleRecieveRoom;
        private MetroFramework.Controls.MetroTile titleReports;
        private MetroFramework.Controls.MetroTile metroTileBillManagement;
        private MetroFramework.Controls.MetroTile metroTilePayment;
        private MetroFramework.Controls.MetroTile metroTileCustomerManagement;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton btnAccountProfile;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogOut;
        private Bunifu.Framework.UI.BunifuFlatButton btnHelp;
        private Bunifu.Framework.UI.BunifuFlatButton btnIntroduce;
        private Bunifu.Framework.UI.BunifuFlatButton btnNavigationPanel;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private MetroFramework.Controls.MetroTile metroTileShowAllBookedRooms;
        private MetroFramework.Controls.MetroTile metroTileAdvanceBooking;
        private Bunifu.Framework.UI.BunifuFlatButton bbtnUploadDB;
    }
}