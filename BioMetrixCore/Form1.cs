using BioMetrixCore.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioMetrixCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        static BranchID Deviceinfos = new BranchID();
        private void button1_Click(object sender, EventArgs e)
        {
            MyWaitForm f2 = new MyWaitForm();
            f2.Show();
            Application.DoEvents();

            Master dv = new Master(deviceipaddress.SelectedValue.ToString(),Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")), Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd")).AddDays(1));
            dv.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

                FormCollection fc = Application.OpenForms;

                foreach (Form frm in fc)
                {
                    //iterate through
                    if (frm.Name == "Form2")
                    {
                        frm.Hide();
                    }
                }

            try
            {
                DataTable dt = dbhelper.getdatahris("Select * from BranchBioDevices where status='allow'");
                deviceipaddress.DataSource = dt;
                deviceipaddress.DisplayMember = "BranchName";
                deviceipaddress.ValueMember = "Id";
                /* button1.PerformClick();*/
            }
            catch (Exception es)
            {
                Form2 f2 = new Form2();
                f2.Show();
                Application.DoEvents(); 
                DialogResult dialog = MessageBox.Show("Please enter a correct server IP address.", "", MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    Close();
                }
            }
        }
    }
}
