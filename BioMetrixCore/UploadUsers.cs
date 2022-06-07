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
    public partial class UploadUsers : Form
    {
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        public CZKEM axCZKEM1 = new CZKEM();
        public UploadUsers()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool mouseDown;
        private Point lastLocation;

        private void UploadUsers_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void UploadUsers_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void UploadUsers_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgv_userlist.DataSource;
            bs.Filter = "[Name] like '%" + txt_search.Text + "%'";
            dgv_userlist.DataSource = bs;
        }

        private void loader()
        {
            DataTable dt = dbhelper.getdata("Select Distinct [EnrollNumber] as [Biometrix_ID],[Name],[MachineNumber],[Enabled] as [Check] from UserInfo order by [EnrollNumber] asc");
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

        private void ClearGrid()
        {
            if (dgv_userlist.Controls.Count > 2)
            { dgv_userlist.Controls.RemoveAt(2); }

            dgv_userlist.DataSource = null;
            dgv_userlist.Controls.Clear();
            dgv_userlist.Rows.Clear();
            dgv_userlist.Columns.Clear();
        }

        private void UploadUsers_Load(object sender, EventArgs e)
        {
            loader();

          
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (IsDeviceConnected)
                {
                    IsDeviceConnected = false;
                    this.Cursor = Cursors.Default;

                    return;
                }

                string ipAddress ="192.168.1.201";
                string port = "4370";
                if (ipAddress == string.Empty || port == string.Empty)
                    throw new Exception("The Device IP Address and Port is mandotory !!");

                int portNumber = 4370;
                if (!int.TryParse(port, out portNumber))
                    throw new Exception("Not a valid port number");

                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The Device IP is invalid !!");

                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The device at " + ipAddress + ":" + port + " did not respond!!");

                objZkeeper = new ZkemClient(RaiseDeviceEvent,ipAddress,"10");
                IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);

                if (IsDeviceConnected)
                {
                    string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, int.Parse("1"));
                }

            }
            catch (Exception ex)
            {
            }
            this.Cursor = Cursors.Default;
        }


        private bool isDeviceConnected = false;

        public bool IsDeviceConnected
        {
            get { return isDeviceConnected; }
            set
            {
                isDeviceConnected = value;
                if (isDeviceConnected)
                {
                }
                else
                {
                    objZkeeper.Disconnect();
                }
            }
        }
        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                       
                        break;
                    }

                default:
                    break;
            }

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

        private void btn_Upload_Click(object sender, EventArgs e)
        {


            if (dvg_temp.Controls.Count > 2)
            { dvg_temp.Controls.RemoveAt(2); }

            dvg_temp.DataSource = null;
            dvg_temp.Controls.Clear();
            dvg_temp.Rows.Clear();
            foreach (DataGridViewRow row3 in dgv_userlist.Rows)
            {
                if (row3.Cells["Check"].Value.ToString() == "  ✔")
                {
                    dvg_temp.Rows.Add(row3.Cells["Biometrix_ID"].Value.ToString(), row3.Cells["Name"].Value.ToString(), row3.Cells["MachineNumber"].Value.ToString());
                }
            }



            try
            {
                btn_Upload.Enabled = false;
                dgv_userlist.Enabled = false;
                foreach (DataGridViewRow row2 in dvg_temp.Rows)
                {
                    if (row2.Index != dvg_temp.Rows.Count-1)
                    {

                        DataTable dt = dbhelper.getdata("Select * from UserInfo where EnrollNumber=" + row2.Cells["Biometrix_ID"].Value.ToString() + "");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                int MachineNumber = Convert.ToInt32(row["MachineNumber"].ToString());
                                string EnrollNumber = row["EnrollNumber"].ToString();
                                string Name = row["Name"].ToString();
                                string Password = row["Password"].ToString();
                                int Privilege = Convert.ToInt32(row["Privelage"].ToString());
                                bool Enabled = Convert.ToBoolean(row["Enabled"].ToString());
                                int indexfinger = Convert.ToInt32(row["FingerIndex"].ToString());
                                string iflag = row["iFlag"].ToString();
                                //byte[] bytes = (byte[])row["TmpData"];

                                List<UserInfo> lstUserInfo = new List<UserInfo>();
                                UserInfo fpInfo = new UserInfo();
                                fpInfo.EnrollNumber = EnrollNumber;
                                fpInfo.Name = Name;
                                fpInfo.Password = Password;
                                fpInfo.Privelage = Privilege;
                                fpInfo.Enabled = Enabled;
                                fpInfo.FingerIndex = indexfinger;
                                fpInfo.iFlag = iflag;
                                fpInfo.TmpData = row["TmpData"].ToString();

                                lstUserInfo.Add(fpInfo);
                                manipulator.UploadFTPTemplate(objZkeeper, 1, lstUserInfo);

                               // manipulator.PushUserDataToDevice(objZkeeper,1,"13", lstUserInfo);
                            }
                        }

                    }

                }

                dgv_userlist.Enabled = true;
                btn_Upload.Enabled = true;
            }
            catch(Exception ex) { 
            
            }
        }


    }
}
