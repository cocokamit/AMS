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
    public partial class Schedules : Form
    {
        public Schedules()
        {
            InitializeComponent();
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Schedules_Load(object sender, EventArgs e)
        {
            txt_shiftcode.Text = "Shift Code";
            loaders();

            if (cmb_role.Items.Count == 0)
            {
                btn_addsched.Enabled = false;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private bool mouseDown;
        private Point lastLocation;

        private void Schedules_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Schedules_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Schedules_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_shiftcode_Enter(object sender, EventArgs e)
        {
            txt_shiftcode.Text = "";
        }

        private void loaders()
        {
            Dictionary<string, string> test = new Dictionary<string, string>();

            DataTable dt2 = dbhelper.getdata("Select * from Role");

            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    test.Add(row[0].ToString(), row[1].ToString());
                }

                cmb_role.DataSource = new BindingSource(test, null);
                cmb_role.DisplayMember = "Value";
                cmb_role.ValueMember = "Key";
                string value = ((KeyValuePair<string, string>)cmb_role.SelectedItem).Value;

                DataTable dt = dbhelper.getdata("Select ShiftCode,[DaysOfWeek] [Day of Week],[TimeIn],[TimeOut],[NoOfhrs] [No. of hours] from ShiftSched ");
                dgv_schedules.DataSource = dt;

                dgv_schedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                UniversalStatic.ChangeGridProperties(dgv_schedules);
            }
        }

        private void btn_addsched_Click(object sender, EventArgs e)
        {
            string timein = DateTime.Parse(txt_timein.Text + " " + tt_1.Text).ToString("hh:mm tt");
            string timeout = DateTime.Parse(txt_timeout.Text + " " + tt_2.Text).ToString("hh:mm tt");
            DataTable dt = dbhelper.getdata("Insert into ShiftSched(ShiftCode,DaysOfWeek,Timein,Timeout,NoOfhrs,RoleId) values('"+txt_shiftcode.Text+"','"+daysOfweek.SelectedItem+"','"+timein+"','"+timeout+"',"+txt_noOfhrs.Text+","+cmb_role.SelectedValue+")");
            loaders();
        }
    } 
}
