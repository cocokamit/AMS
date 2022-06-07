namespace BioMetrixCore
{
    partial class Schedules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedules));
            this.Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_schedules = new System.Windows.Forms.DataGridView();
            this.btn_addsched = new System.Windows.Forms.Button();
            this.txt_noOfhrs = new System.Windows.Forms.TextBox();
            this.cmb_role = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_shiftcode = new System.Windows.Forms.TextBox();
            this.tt_2 = new System.Windows.Forms.ComboBox();
            this.tt_1 = new System.Windows.Forms.ComboBox();
            this.txt_timeout = new System.Windows.Forms.MaskedTextBox();
            this.txt_timein = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.daysOfweek = new System.Windows.Forms.ComboBox();
            this.btn_Addrole = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_schedules)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.IndianRed;
            this.Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Close.Location = new System.Drawing.Point(755, 3);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(33, 23);
            this.Close.TabIndex = 893;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_schedules);
            this.panel1.Location = new System.Drawing.Point(-2, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 281);
            this.panel1.TabIndex = 894;
            // 
            // dgv_schedules
            // 
            this.dgv_schedules.AllowUserToAddRows = false;
            this.dgv_schedules.AllowUserToDeleteRows = false;
            this.dgv_schedules.AllowUserToOrderColumns = true;
            this.dgv_schedules.BackgroundColor = System.Drawing.Color.White;
            this.dgv_schedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_schedules.Location = new System.Drawing.Point(0, 44);
            this.dgv_schedules.Name = "dgv_schedules";
            this.dgv_schedules.Size = new System.Drawing.Size(804, 234);
            this.dgv_schedules.TabIndex = 0;
            // 
            // btn_addsched
            // 
            this.btn_addsched.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_addsched.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addsched.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addsched.ForeColor = System.Drawing.Color.White;
            this.btn_addsched.Location = new System.Drawing.Point(681, 8);
            this.btn_addsched.Name = "btn_addsched";
            this.btn_addsched.Size = new System.Drawing.Size(74, 28);
            this.btn_addsched.TabIndex = 896;
            this.btn_addsched.Text = "ADD";
            this.btn_addsched.UseVisualStyleBackColor = false;
            this.btn_addsched.Click += new System.EventHandler(this.btn_addsched_Click);
            // 
            // txt_noOfhrs
            // 
            this.txt_noOfhrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_noOfhrs.Location = new System.Drawing.Point(570, 11);
            this.txt_noOfhrs.Name = "txt_noOfhrs";
            this.txt_noOfhrs.Size = new System.Drawing.Size(100, 21);
            this.txt_noOfhrs.TabIndex = 899;
            this.txt_noOfhrs.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // cmb_role
            // 
            this.cmb_role.FormattingEnabled = true;
            this.cmb_role.Location = new System.Drawing.Point(48, 35);
            this.cmb_role.Name = "cmb_role";
            this.cmb_role.Size = new System.Drawing.Size(145, 21);
            this.cmb_role.TabIndex = 901;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 902;
            this.label1.Text = "Role";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txt_shiftcode);
            this.panel2.Controls.Add(this.tt_2);
            this.panel2.Controls.Add(this.tt_1);
            this.panel2.Controls.Add(this.txt_timeout);
            this.panel2.Controls.Add(this.txt_timein);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.daysOfweek);
            this.panel2.Controls.Add(this.btn_addsched);
            this.panel2.Controls.Add(this.txt_noOfhrs);
            this.panel2.Location = new System.Drawing.Point(-2, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 42);
            this.panel2.TabIndex = 1;
            // 
            // txt_shiftcode
            // 
            this.txt_shiftcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_shiftcode.Location = new System.Drawing.Point(14, 9);
            this.txt_shiftcode.Name = "txt_shiftcode";
            this.txt_shiftcode.Size = new System.Drawing.Size(100, 21);
            this.txt_shiftcode.TabIndex = 907;
            this.txt_shiftcode.Text = "Shift Code";
            this.txt_shiftcode.Enter += new System.EventHandler(this.txt_shiftcode_Enter);
            // 
            // tt_2
            // 
            this.tt_2.FormattingEnabled = true;
            this.tt_2.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.tt_2.Location = new System.Drawing.Point(466, 11);
            this.tt_2.Name = "tt_2";
            this.tt_2.Size = new System.Drawing.Size(39, 21);
            this.tt_2.TabIndex = 906;
            this.tt_2.Text = "AM";
            // 
            // tt_1
            // 
            this.tt_1.FormattingEnabled = true;
            this.tt_1.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.tt_1.Location = new System.Drawing.Point(325, 11);
            this.tt_1.Name = "tt_1";
            this.tt_1.Size = new System.Drawing.Size(39, 21);
            this.tt_1.TabIndex = 903;
            this.tt_1.Text = "AM";
            // 
            // txt_timeout
            // 
            this.txt_timeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timeout.Location = new System.Drawing.Point(417, 11);
            this.txt_timeout.Mask = "90:00";
            this.txt_timeout.Name = "txt_timeout";
            this.txt_timeout.Size = new System.Drawing.Size(43, 21);
            this.txt_timeout.TabIndex = 904;
            this.txt_timeout.ValidatingType = typeof(System.DateTime);
            // 
            // txt_timein
            // 
            this.txt_timein.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timein.Location = new System.Drawing.Point(276, 11);
            this.txt_timein.Mask = "90:00";
            this.txt_timein.Name = "txt_timein";
            this.txt_timein.Size = new System.Drawing.Size(43, 21);
            this.txt_timein.TabIndex = 903;
            this.txt_timein.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 905;
            this.label4.Text = "No. of hrs";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 904;
            this.label3.Text = "Time out";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time In";
            // 
            // daysOfweek
            // 
            this.daysOfweek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daysOfweek.FormattingEnabled = true;
            this.daysOfweek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.daysOfweek.Location = new System.Drawing.Point(120, 9);
            this.daysOfweek.Name = "daysOfweek";
            this.daysOfweek.Size = new System.Drawing.Size(102, 23);
            this.daysOfweek.TabIndex = 903;
            this.daysOfweek.Text = "Days of week";
            // 
            // btn_Addrole
            // 
            this.btn_Addrole.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Addrole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Addrole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Addrole.ForeColor = System.Drawing.Color.White;
            this.btn_Addrole.Location = new System.Drawing.Point(199, 30);
            this.btn_Addrole.Name = "btn_Addrole";
            this.btn_Addrole.Size = new System.Drawing.Size(74, 28);
            this.btn_Addrole.TabIndex = 903;
            this.btn_Addrole.Text = "Add Role";
            this.btn_Addrole.UseVisualStyleBackColor = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.lblHeader.Location = new System.Drawing.Point(323, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(183, 19);
            this.lblHeader.TabIndex = 904;
            this.lblHeader.Text = "Schedule Management";
            // 
            // Schedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btn_Addrole);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_role);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Schedules";
            this.Text = "Schedules";
            this.Load += new System.EventHandler(this.Schedules_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Schedules_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Schedules_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Schedules_MouseUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_schedules)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_schedules;
        private System.Windows.Forms.Button btn_addsched;
        private System.Windows.Forms.TextBox txt_noOfhrs;
        private System.Windows.Forms.ComboBox cmb_role;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox daysOfweek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txt_timeout;
        private System.Windows.Forms.MaskedTextBox txt_timein;
        private System.Windows.Forms.ComboBox tt_2;
        private System.Windows.Forms.ComboBox tt_1;
        private System.Windows.Forms.Button btn_Addrole;
        private System.Windows.Forms.TextBox txt_shiftcode;
        public System.Windows.Forms.Label lblHeader;
    }
}