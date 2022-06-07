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
using zkemkeeper;

namespace BioMetrixCore
{
    public partial class SaveUsers : Form
    {
        DeviceManipulator manipulator = new DeviceManipulator();
        static List<deviceinfo> Deviceinfos = new List<deviceinfo>();
        public ZkemClient objZkeeper;
        public SaveUsers(ZkemClient objk,List<deviceinfo> devinfo)
        {
            InitializeComponent();
            objZkeeper = objk;
            Deviceinfos = devinfo;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This action will save all user information from the connected 'device' to the 'database'. Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                MyWaitForm f2 = new MyWaitForm();
                f2.Show();
                Application.DoEvents();
                if (Deviceinfos.Count > 0)
                {
                    foreach (deviceinfo a in Deviceinfos)
                    {
                        if (dvg_temp.Controls.Count > 2)
                        { dvg_temp.Controls.RemoveAt(2); }

                        dvg_temp.DataSource = null;
                        dvg_temp.Controls.Clear();
                        dvg_temp.Rows.Clear();
                        List<string> strs = new List<string>();
                        foreach (DataGridViewRow row3 in dgv_userlist.Rows)
                        {
                            if (row3.Cells["Check"].Value.ToString() == "  ✔")
                            {
                                dvg_temp.Rows.Add(row3.Cells["IdNumber"].Value.ToString(), row3.Cells["Name"].Value.ToString(), row3.Cells["Privilege"].Value.ToString());
                                string sds = row3.Cells["IdNumber"].Value.ToString();
                                strs.Add(sds);
                            }
                        }

                        try
                        {
                            DataTable dt = dbhelper.getdata("Select * from UserInfo");
                            ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber.Trim())).Where(x => strs.Contains(x.EnrollNumber)).ToList();
                            if (lstFingerPrintTemplates != null && lstFingerPrintTemplates.Count > 0)
                            {
                                stateclass sc = new stateclass();
                                foreach (var items in lstFingerPrintTemplates)
                                {
                                    if (dt.Select("EnrollNumber=" + items.EnrollNumber + " AND FingerIndex=" + items.FingerIndex.ToString() + "").Count() == 0)
                                    {
                                        sc.sa = items.MachineNumber.ToString();
                                        sc.sb = items.EnrollNumber;
                                        sc.sc = items.Name;
                                        sc.sd = items.FingerIndex.ToString();
                                        sc.se = items.TmpData.ToString();
                                        sc.sf = items.Privelage.ToString();
                                        sc.sg = items.Password;
                                        sc.sh = items.Enabled.ToString();
                                        sc.si = items.iFlag;
                                        string x = bol.adduser(sc);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                f2.Hide();
            }
        }

        private static DataTable ConvertListToDataTable(ICollection<UserInfo> list)
        {
            // New table.
            DataTable table = new DataTable();
            // Get max columns.
            IEnumerable<UserInfo> row = list.Select(x => new UserInfo { EnrollNumber = x.EnrollNumber, Name = x.Name, Privelage=x.Privelage }).GroupBy(x => x.EnrollNumber).Select(x => x.First());
          

            // Add columns.
            table.Columns.Add("IdNumber");
            table.Columns.Add("Name");
            table.Columns.Add("Privilege");
            table.Columns.Add("Check");
            int count = 0;
            // Add rows.
            foreach (UserInfo array in row)
            {

                table.Rows.Add();
                table.Rows[count]["IdNumber"]=array.EnrollNumber;
                table.Rows[count]["Name"] = array.Name;
                table.Rows[count]["Privilege"] = array.Privelage;

                ++count;
            }

           
            return table;
        }

  
        private void SaveUsers_Load(object sender, EventArgs e)
        {
          
            loader();

        }

        private void Close_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private bool mouseDown;
        private Point lastLocation;
  


        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgv_userlist.DataSource;
            bs.Filter = "[Name] like '%" + txt_search.Text + "%'";
            dgv_userlist.DataSource = bs;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow row in dgv_userlist.Rows)
                {
                    row.Cells["Check"].Value = "  ✔";
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgv_userlist.Rows)
                {
                    row.Cells["Check"].Value = "";
                }
            }

        }

        private void loader()
        {
            if (Deviceinfos.Count > 0)
            {
                foreach (deviceinfo a in Deviceinfos)
                {
                    ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber.Trim()));

                    DataTable dt = new DataTable();
                    dt = ConvertListToDataTable(lstFingerPrintTemplates);
                    ClearGrid();
                    dgv_userlist.DataSource = dt;
                    dgv_userlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    UniversalStatic.ChangeGridProperties(dgv_userlist);
                    DataGridViewColumn column = dgv_userlist.Columns[3];
                    column.Width = 60;
                    foreach (DataGridViewRow row in dgv_userlist.Rows)
                    {
                        row.Cells["Check"].Value = "";
                    }
                }
            }
        }
        private void ClearGrid()
        {
            if (dgv_userlist.Controls.Count > 2)
            { dgv_userlist.Controls.RemoveAt(2); }

            dgv_userlist.DataSource = null;
            dgv_userlist.Controls.Clear();
            dgv_userlist.Rows.Clear();
            dgv_userlist.Columns.Clear();
        }

        private void dgv_userlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgv_userlist.Rows[e.RowIndex].Cells["Check"].Value.ToString() == "  ✔")
            {
                dgv_userlist.Rows[e.RowIndex].Cells["Check"].Value = "";
            }
            else
            {

                dgv_userlist.Rows[e.RowIndex].Cells["Check"].Value = "  ✔";
            }
        }

       

        private void SaveUsers_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void SaveUsers_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }

        }

        private void SaveUsers_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
