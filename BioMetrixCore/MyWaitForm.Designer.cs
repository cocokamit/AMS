namespace BioMetrixCore
{
    partial class MyWaitForm
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
            this.lblDeviceInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDeviceInfo
            // 
            this.lblDeviceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeviceInfo.Location = new System.Drawing.Point(12, 30);
            this.lblDeviceInfo.Name = "lblDeviceInfo";
            this.lblDeviceInfo.Size = new System.Drawing.Size(269, 19);
            this.lblDeviceInfo.TabIndex = 893;
            this.lblDeviceInfo.Text = "Loading...Please Wait";
            this.lblDeviceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyWaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(293, 85);
            this.Controls.Add(this.lblDeviceInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyWaitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyWaitForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDeviceInfo;
    }
}