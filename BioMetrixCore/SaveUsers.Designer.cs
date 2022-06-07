namespace BioMetrixCore
{
    partial class SaveUsers
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_userlist = new System.Windows.Forms.DataGridView();
            this.dvg_temp = new System.Windows.Forms.DataGridView();
            this.Biometrix_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_temp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.txt_search);
            this.panel2.Location = new System.Drawing.Point(-2, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 42);
            this.panel2.TabIndex = 909;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 909;
            this.label1.Text = "Search Name";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(600, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 908;
            this.checkBox1.Text = "ALL";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(112, 14);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(199, 20);
            this.txt_search.TabIndex = 0;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.IndianRed;
            this.Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Close.Location = new System.Drawing.Point(610, 9);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(33, 23);
            this.Close.TabIndex = 908;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_userlist);
            this.panel1.Location = new System.Drawing.Point(-2, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 467);
            this.panel1.TabIndex = 910;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgv_userlist
            // 
            this.dgv_userlist.AllowUserToAddRows = false;
            this.dgv_userlist.AllowUserToDeleteRows = false;
            this.dgv_userlist.AllowUserToOrderColumns = true;
            this.dgv_userlist.BackgroundColor = System.Drawing.Color.White;
            this.dgv_userlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userlist.Location = new System.Drawing.Point(0, 81);
            this.dgv_userlist.Name = "dgv_userlist";
            this.dgv_userlist.Size = new System.Drawing.Size(659, 386);
            this.dgv_userlist.TabIndex = 0;
            this.dgv_userlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_userlist_CellClick);
            // 
            // dvg_temp
            // 
            this.dvg_temp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_temp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Biometrix_ID,
            this.Name,
            this.MachineNumber});
            this.dvg_temp.Location = new System.Drawing.Point(10, 530);
            this.dvg_temp.Name = "dvg_temp";
            this.dvg_temp.Size = new System.Drawing.Size(240, 150);
            this.dvg_temp.TabIndex = 913;
            this.dvg_temp.Visible = false;
            // 
            // Biometrix_ID
            // 
            this.Biometrix_ID.HeaderText = "Biometrix_ID";
            this.Biometrix_ID.Name = "Biometrix_ID";
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // MachineNumber
            // 
            this.MachineNumber.HeaderText = "MachineNumber";
            this.MachineNumber.Name = "MachineNumber";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Save.Location = new System.Drawing.Point(560, 530);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(83, 27);
            this.btn_Save.TabIndex = 912;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.lblHeader.Location = new System.Drawing.Point(275, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(96, 19);
            this.lblHeader.TabIndex = 911;
            this.lblHeader.Text = "Save Users";
            // 
            // SaveUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 576);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dvg_temp);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "SaveUsers";
            this.Load += new System.EventHandler(this.SaveUsers_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SaveUsers_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SaveUsers_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SaveUsers_MouseUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_temp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_userlist;
        private System.Windows.Forms.DataGridView dvg_temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Biometrix_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineNumber;
        private System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Label lblHeader;
    }
}