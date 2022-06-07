namespace BioMetrixCore
{
    partial class Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master));
            this.btnPingDevice = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPullData = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDeviceInfo = new System.Windows.Forms.Label();
            this.logTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Close = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.tempgridview = new System.Windows.Forms.DataGridView();
            this.btnDownloadFingerPrint = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_admin = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cld = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.panel_adbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnremoveadmin = new System.Windows.Forms.Button();
            this.panel_login = new System.Windows.Forms.Panel();
            this.btn_login = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempgridview)).BeginInit();
            this.panel_adbuttons.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPingDevice
            // 
            this.btnPingDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPingDevice.Location = new System.Drawing.Point(714, 9);
            this.btnPingDevice.Name = "btnPingDevice";
            this.btnPingDevice.Size = new System.Drawing.Size(75, 23);
            this.btnPingDevice.TabIndex = 5;
            this.btnPingDevice.Text = "Ping Device";
            this.btnPingDevice.UseVisualStyleBackColor = true;
            this.btnPingDevice.Click += new System.EventHandler(this.btnPingDevice_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(0, 591);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblStatus.Size = new System.Drawing.Size(1110, 25);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "label3";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // btnPullData
            // 
            this.btnPullData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPullData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPullData.ForeColor = System.Drawing.Color.White;
            this.btnPullData.Location = new System.Drawing.Point(568, 5);
            this.btnPullData.Name = "btnPullData";
            this.btnPullData.Size = new System.Drawing.Size(104, 24);
            this.btnPullData.TabIndex = 10;
            this.btnPullData.Text = "Get Log Data";
            this.btnPullData.UseVisualStyleBackColor = false;
            this.btnPullData.Visible = false;
            this.btnPullData.Click += new System.EventHandler(this.btnPullData_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.pnlHeader.Controls.Add(this.btnPingDevice);
            this.pnlHeader.Controls.Add(this.btn_logout);
            this.pnlHeader.Location = new System.Drawing.Point(0, 43);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(809, 42);
            this.pnlHeader.TabIndex = 712;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Salmon;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_logout.Location = new System.Drawing.Point(18, 7);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(71, 23);
            this.btn_logout.TabIndex = 884;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(259, 19);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Attendance Management System";
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.AllowUserToOrderColumns = true;
            this.dgvRecords.AllowUserToResizeColumns = false;
            this.dgvRecords.AllowUserToResizeRows = false;
            this.dgvRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Location = new System.Drawing.Point(0, 37);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.Size = new System.Drawing.Size(796, 369);
            this.dgvRecords.TabIndex = 883;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvRecords);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 403);
            this.panel1.TabIndex = 891;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.logTimePicker);
            this.flowLayoutPanel1.Controls.Add(this.btnPullData);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(797, 34);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDeviceInfo);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 28);
            this.panel2.TabIndex = 12;
            // 
            // lblDeviceInfo
            // 
            this.lblDeviceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeviceInfo.Location = new System.Drawing.Point(0, 5);
            this.lblDeviceInfo.Name = "lblDeviceInfo";
            this.lblDeviceInfo.Size = new System.Drawing.Size(341, 19);
            this.lblDeviceInfo.TabIndex = 892;
            this.lblDeviceInfo.Text = "Device Info : --";
            // 
            // logTimePicker
            // 
            this.logTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logTimePicker.Location = new System.Drawing.Point(354, 6);
            this.logTimePicker.Name = "logTimePicker";
            this.logTimePicker.Size = new System.Drawing.Size(208, 22);
            this.logTimePicker.TabIndex = 11;
            this.logTimePicker.ValueChanged += new System.EventHandler(this.logTimePicker_ValueChanged);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.Location = new System.Drawing.Point(678, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 905;
            this.button2.Text = "Get Log Data";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 884;
            this.button1.Text = "Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ZKTECO";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.IndianRed;
            this.Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Close.Location = new System.Drawing.Point(776, 5);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(33, 23);
            this.Close.TabIndex = 892;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.DimGray;
            this.Minimize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Minimize.Location = new System.Drawing.Point(746, 5);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(24, 23);
            this.Minimize.TabIndex = 893;
            this.Minimize.Text = "__";
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            this.Minimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Minimize_MouseClick);
            // 
            // tempgridview
            // 
            this.tempgridview.AllowUserToAddRows = false;
            this.tempgridview.AllowUserToDeleteRows = false;
            this.tempgridview.AllowUserToOrderColumns = true;
            this.tempgridview.AllowUserToResizeColumns = false;
            this.tempgridview.AllowUserToResizeRows = false;
            this.tempgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tempgridview.Location = new System.Drawing.Point(130, 91);
            this.tempgridview.Name = "tempgridview";
            this.tempgridview.Size = new System.Drawing.Size(679, 48);
            this.tempgridview.TabIndex = 899;
            this.tempgridview.Visible = false;
            this.tempgridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tempgridview_CellContentClick);
            // 
            // btnDownloadFingerPrint
            // 
            this.btnDownloadFingerPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDownloadFingerPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDownloadFingerPrint.FlatAppearance.BorderSize = 0;
            this.btnDownloadFingerPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadFingerPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadFingerPrint.ForeColor = System.Drawing.Color.White;
            this.btnDownloadFingerPrint.Image = global::BioMetrixCore.Properties.Resources.user_16x16;
            this.btnDownloadFingerPrint.Location = new System.Drawing.Point(12, 91);
            this.btnDownloadFingerPrint.Name = "btnDownloadFingerPrint";
            this.btnDownloadFingerPrint.Size = new System.Drawing.Size(112, 48);
            this.btnDownloadFingerPrint.TabIndex = 9;
            this.btnDownloadFingerPrint.Text = "User Info";
            this.btnDownloadFingerPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownloadFingerPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownloadFingerPrint.UseVisualStyleBackColor = false;
            this.btnDownloadFingerPrint.Click += new System.EventHandler(this.btnDownloadFingerPrint_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Export.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Export.FlatAppearance.BorderSize = 0;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.ForeColor = System.Drawing.Color.White;
            this.btn_Export.Image = global::BioMetrixCore.Properties.Resources.export_16x16;
            this.btn_Export.Location = new System.Drawing.Point(727, 553);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(81, 24);
            this.btn_Export.TabIndex = 894;
            this.btn_Export.Text = "Export";
            this.btn_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_admin
            // 
            this.btn_admin.Location = new System.Drawing.Point(3, 2);
            this.btn_admin.Name = "btn_admin";
            this.btn_admin.Size = new System.Drawing.Size(68, 24);
            this.btn_admin.TabIndex = 886;
            this.btn_admin.Text = "Admin";
            this.btn_admin.UseVisualStyleBackColor = true;
            this.btn_admin.Visible = false;
            this.btn_admin.Click += new System.EventHandler(this.btn_admin_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(3, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(68, 24);
            this.btn_save.TabIndex = 885;
            this.btn_save.Text = "Save users";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cld
            // 
            this.btn_cld.Location = new System.Drawing.Point(287, 3);
            this.btn_cld.Name = "btn_cld";
            this.btn_cld.Size = new System.Drawing.Size(151, 23);
            this.btn_cld.TabIndex = 900;
            this.btn_cld.Text = "Clear Device Log Data";
            this.btn_cld.UseVisualStyleBackColor = true;
            this.btn_cld.Visible = false;
            this.btn_cld.Click += new System.EventHandler(this.btn_cld_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(77, 3);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(86, 24);
            this.btn_upload.TabIndex = 901;
            this.btn_upload.Text = "Upload users";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Visible = false;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // panel_adbuttons
            // 
            this.panel_adbuttons.Controls.Add(this.btn_save);
            this.panel_adbuttons.Controls.Add(this.btn_upload);
            this.panel_adbuttons.Controls.Add(this.btnremoveadmin);
            this.panel_adbuttons.Controls.Add(this.btn_cld);
            this.panel_adbuttons.Location = new System.Drawing.Point(18, 550);
            this.panel_adbuttons.Name = "panel_adbuttons";
            this.panel_adbuttons.Size = new System.Drawing.Size(587, 27);
            this.panel_adbuttons.TabIndex = 902;
            // 
            // btnremoveadmin
            // 
            this.btnremoveadmin.Location = new System.Drawing.Point(169, 3);
            this.btnremoveadmin.Name = "btnremoveadmin";
            this.btnremoveadmin.Size = new System.Drawing.Size(112, 23);
            this.btnremoveadmin.TabIndex = 902;
            this.btnremoveadmin.Text = "Remove Admin";
            this.btnremoveadmin.UseVisualStyleBackColor = true;
            this.btnremoveadmin.Click += new System.EventHandler(this.btnremoveadmin_Click);
            // 
            // panel_login
            // 
            this.panel_login.Controls.Add(this.btn_login);
            this.panel_login.Controls.Add(this.btn_admin);
            this.panel_login.Controls.Add(this.txt_password);
            this.panel_login.Controls.Add(this.txt_username);
            this.panel_login.Location = new System.Drawing.Point(16, 550);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(438, 39);
            this.panel_login.TabIndex = 884;
            this.panel_login.Visible = false;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(380, 3);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(51, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(224, 3);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(149, 22);
            this.txt_password.TabIndex = 1;
            this.txt_password.Tag = "Password";
            this.txt_password.Text = "password";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(78, 3);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(140, 22);
            this.txt_username.TabIndex = 0;
            this.txt_username.Tag = "Username";
            this.txt_username.Text = "********";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(815, 95);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(283, 485);
            this.listBox1.TabIndex = 903;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.label1.Location = new System.Drawing.Point(916, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 904;
            this.label1.Text = "Activity";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1110, 616);
            this.Controls.Add(this.panel_adbuttons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel_login);
            this.Controls.Add(this.tempgridview);
            this.Controls.Add(this.btnDownloadFingerPrint);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(615, 425);
            this.Name = "Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biometric Device";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Master_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Master_FormClosed);
            this.Load += new System.EventHandler(this.Master_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Master_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Master_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Master_MouseUp);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tempgridview)).EndInit();
            this.panel_adbuttons.ResumeLayout(false);
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPingDevice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDownloadFingerPrint;
        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblDeviceInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker logTimePicker;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.DataGridView tempgridview;
        private System.Windows.Forms.Button btn_admin;
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cld;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.FlowLayoutPanel panel_adbuttons;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnPullData;
        private System.Windows.Forms.Button btnremoveadmin;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

