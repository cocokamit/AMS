using BioMetrixCore.Info;
///
///    Experimented By : Ozesh Thapa
///    Email: dablackscarlet@gmail.com
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace BioMetrixCore
{
    public partial class Master : Form
    {
        static BranchID branchIder = new BranchID();
        static List<deviceinfo> Deviceinfos = new List<deviceinfo>();
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        static DateTime From1,To1;
        private int temp = 0;
        private bool isDeviceConnected = false;
        public bool IsDeviceConnected
        {

            get { return isDeviceConnected; }
            set
            {
                isDeviceConnected = value;
                if (isDeviceConnected)
                {
                    ShowStatusBar("The device is connected !!", true);
                    ToggleControls(true);

                }
                else
                {
                    ShowStatusBar("The device is disconnected !!", true);
                    objZkeeper.Disconnect();
                    ToggleControls(false);

                }
            }
        }

        public object MetroMessageBox { get; private set; }

        private void SetMyButtonIcon()
        {
        }

        private void ToggleControls(bool value)
        {
            btnDownloadFingerPrint.Enabled = value;
            btnPullData.Enabled = value;
        }

        public Master(string deviceid,DateTime FormFrom,DateTime FormTo)
        {
            MyWaitForm f2 = new MyWaitForm();
            f2.Show();
            Application.DoEvents();
            From1 = FormFrom;
            To1 = FormTo;
            branchIder.branchid = deviceid;
            InitializeComponent();
            InitializeInputs();
            ToggleControls(false);
            ShowStatusBar(string.Empty, true);
            DisplayEmpty();
        }

        void InitializeInputs()
        {
            ZkemClient.mainForm = this;
            ZkemClient.button = button2;
            ZkemClient.buttonOnSave = button1;
        }

        /// <summary>
        /// Your Events will reach here if implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="actionType"></param>
        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                        ShowStatusBar("The device is switched off", true);
                        DisplayEmpty();
                        ToggleControls(false);
                        break;
                    }

                default:
                    break;
            }

        }

        private void connect()
        {
            string ipAddress = "";
            string port = "";
            string machineNumber = "";
            string location = "";
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;

            DataTable dt = dbhelper.getdatahris("Select * from BranchBioDevices where status='allow' and Id="+ branchIder.branchid+ "");
            Deviceinfos.Clear();
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    ipAddress = row["IpAddress"].ToString();
                    port = row["Port"].ToString();
                    machineNumber = row["Id"].ToString();
                    location = row["BranchName"].ToString();
                    this.Cursor = Cursors.WaitCursor;
                    ShowStatusBar(string.Empty, true);

                    if (ipAddress == string.Empty || port == string.Empty)
                        throw new Exception("The Device IP Address and Port is mandatory !!");

                    int portNumber = 4370;
                    if (!int.TryParse(port, out portNumber))
                        throw new Exception("Not a valid port number");

                    bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                    if (!isValidIpA)
                        throw new Exception("The Device IP is invalid !!");

                    isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                    if (!isValidIpA)
                        throw new Exception("The device at " + ipAddress + ":" + port + " did not respond!!");

                    objZkeeper = new ZkemClient(RaiseDeviceEvent, ipAddress, machineNumber);
                    IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);

                    if (IsDeviceConnected)
                    {
                        string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, int.Parse(machineNumber));
                        lblDeviceInfo.Text = deviceInfo;

                        Deviceinfos.Add(new deviceinfo { IpAddress = ipAddress, DeviceId = row["Id"].ToString(), MachineNumber = machineNumber, Port = port, SerialNo = deviceInfo, CountAllLog = "", Message = "", Status = "", Name = location });
                         LogUpdater();

                    }
                }
                catch (Exception ex)
                {
                    ShowStatusBar(ex.Message, false);
                }
                this.Cursor = Cursors.Default;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public void ShowStatusBar(string message, bool type)
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.White;

            if (type)
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            else
                lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }


        private void btnPingDevice_Click(object sender, EventArgs e)
        {
            MyWaitForm f2 = new MyWaitForm();
            f2.Show();
            Application.DoEvents();

            connect();
            ShowStatusBar(string.Empty, true);

            if (Deviceinfos.Count > 0)
            {
                foreach (deviceinfo a in Deviceinfos)
                {
                    var dd = Deviceinfos.FindIndex(c => c.IpAddress == a.IpAddress);
                    string ipAddress = a.IpAddress.Trim();

                    bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                    if (!isValidIpA)
                    {
                        Deviceinfos[dd].Message = "The Device IP is invalid !!";
                    }
                    //throw new Exception("The Device IP is invalid !!");

                    isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                    if (isValidIpA)
                    {
                        // ShowStatusBar("The device is active", true);
                        Deviceinfos[dd].Message = "The device is active!";
                    }
                    else
                    {
                        Deviceinfos[dd].Message = "Could not read any response!";
                        //ShowStatusBar("Could not read any response", false);
                    }
                }
            }
            else
            {
                ShowStatusBar("Device(s) not found!", false);
            }
            f2.Hide();
        }

        private void btnDownloadFingerPrint_Click(object sender, EventArgs e)
        {
            MyWaitForm f2 = new MyWaitForm();
            f2.Show();
            Application.DoEvents();


            ICollection<UserInfo> Alldata = null;
            if (Deviceinfos.Count > 0)
            {
                foreach (deviceinfo a in Deviceinfos)
                {
                    try
                    {
                        ShowStatusBar(string.Empty, true);
                        ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber.Trim()));
                        Alldata = lstFingerPrintTemplates.ToList();
                        DisplayListOutput("");
                    }
                    catch (Exception ex)
                    {
                        Alldata = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber.Trim()));
                        DisplayListOutput(ex.Message);
                    }

                    if (Alldata != null && Alldata.Count > 0)
                    {
                        BindToGridView(Alldata);
                        ShowStatusBar(Alldata.Count + " records found !!", true);
                    }
                    else
                        DisplayListOutput("No records found");

                    string ipAddress = a.IpAddress.Trim();
                    int portNumber = Convert.ToInt32(a.Port.Trim());
                    IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);
                }
            }
            f2.Hide();

            IntervalTimer.Stop();
            //string ipAddress = deviceinfo.IpAddress.Trim();
            //int portNumber = Convert.ToInt32(deviceinfo.Port.Trim());
            //IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);
            //btn_cld.Visible = false;
        }

        internal IEnumerable<UserInfo> Combine(IEnumerable<UserInfo> col1, IEnumerable<UserInfo> col2)
        {
            foreach (UserInfo item in col1)
                yield return item;

            foreach (UserInfo item in col2)
                yield return item;
        }

        private System.Windows.Forms.Timer IntervalTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer IntervalTimer2 = new System.Windows.Forms.Timer();
        public void btnPullData_Click(object sender, EventArgs e)
        {
            DataTable dt = dbhelper.getdata("Select Distinct a.[EmpID],CONVERT(varchar(25), a.[DateTime], 109),a.[Type] from CHECKINOUT a where (DATEPART(yy, DateTime) = '" + logTimePicker.Value.ToString("yyyy") + "' AND DATEPART(MM, DateTime) = '" + logTimePicker.Value.ToString("MM") + "' AND DATEPART(dd, DateTime) = '" + logTimePicker.Value.ToString("dd") + "')");
            ClearGrid();
            dgvRecords.DataSource = dt;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UniversalStatic.ChangeGridProperties(dgvRecords);

            IntervalTimer.Start();
            //btn_cld.Visible = true;
        } 

        private void ClearGrid()
        {
            if (dgvRecords.Controls.Count > 2)
            { dgvRecords.Controls.RemoveAt(2); }

            dgvRecords.DataSource = null;
            dgvRecords.Controls.Clear();
            dgvRecords.Rows.Clear();
            dgvRecords.Columns.Clear();
        }
        private void BindToGridView(object list)
        {
            ClearGrid();
            dgvRecords.DataSource = list;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UniversalStatic.ChangeGridProperties(dgvRecords);
        }

        private void DisplayListOutput(string message)
        {
            if (dgvRecords.Controls.Count > 2)
            { dgvRecords.Controls.RemoveAt(2); }

            ShowStatusBar(message, false);
        }

        private void DisplayEmpty()
        {
            ClearGrid();
            dgvRecords.Controls.Add(new DataEmpty());
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        { UniversalStatic.DrawLineInFooter(pnlHeader, Color.FromArgb(204, 204, 204), 2); }

        private void logTimePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Minimize_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void Master_Load(object sender, EventArgs e)
        {

            btn_logout.Visible = false;

            connect();


            button2.PerformClick();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
           
            IntervalTimer.Enabled = true; 
           

        }

        public void LogUpdater()
        {
            try
            {
                if (Deviceinfos.Count > 0)
                {
                    foreach (deviceinfo a in Deviceinfos)
                    {
                        var dd = Deviceinfos.FindIndex(c => c.IpAddress == a.IpAddress);
                        ShowStatusBar(string.Empty, true);
                        DateTime dtFrom = From1;
                        DateTime dtTo = To1;

                        ICollection<MachineInfo> lstFingerPrintTemplates = manipulator.GetLogData(objZkeeper, int.Parse(a.MachineNumber.Trim()));
                        List<MachineInfo> newList = lstFingerPrintTemplates.Where(x => Convert.ToDateTime(x.DateTimeRecord) >= dtFrom && Convert.ToDateTime(x.DateTimeRecord) <= dtTo).ToList();
                        if (newList != null && newList.Count > 0)
                        {
                            if (tempgridview.Controls.Count > 2)
                            { tempgridview.Controls.RemoveAt(2); }

                            tempgridview.DataSource = null;
                            tempgridview.Controls.Clear();
                            tempgridview.Rows.Clear();
                            tempgridview.Columns.Clear();
                            tempgridview.DataSource = newList;

                            foreach (DataGridViewRow row in tempgridview.Rows)
                            {
                                DataTable dtbio = dbhelper.getdatahris("Select * from BranchBioDevicesEmp where empid=" + row.Cells["IndRegID"].Value.ToString() + " and deviceid=(Select Id from BranchBioDevices where IpAddress='" + a.IpAddress + "' and Id='" + a.MachineNumber + "')");
                                DataTable bio = dbhelper.getdatahris("Select * from BranchBioDevicesEmp where empid=" + row.Cells["IndRegID"].Value.ToString() + "");

                                if (dtbio.Rows.Count > 0)
                                {
                                    Deviceinfos[dd].CountAllLog = row.Index.ToString();
                                    stateclass sc = new stateclass();
                                    string dateform = DateTime.Parse(row.Cells["DateTimeRecord"].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    string datef = DateTime.Parse(row.Cells["DateTimeRecord"].Value.ToString()).ToString("yyyy-MM-dd 00:00:00");
                                    string datel = DateTime.Parse(datef).AddHours(23).ToString("yyyy-MM-dd HH:mm:ss");
                                    string dateb = DateTime.Parse(row.Cells["DateTimeRecord"].Value.ToString()).AddDays(-1).ToString("yyyy-MM-dd 00:00:00");

                                    DataTable dt = new DataTable();
                                    sc.sa = row.Cells["IndRegID"].Value.ToString();
                                    sc.sb = row.Cells["DateTimeRecord"].Value.ToString();
                                    sc.sc = row.Cells["type"].Value.ToString() == "In" ? "Break In" : row.Cells["type"].Value.ToString() == "Out" ? "Break Out" : row.Cells["type"].Value.ToString();
                                    sc.sd = "1";

                                    dt = dbhelper.getdatahris("Select * from MEmployee where BiometricIdNumber='" + row.Cells["IndRegID"].Value.ToString() + "'");

                                    if (dt.Rows.Count > 0)
                                    {
                                        string x = bol.addCheckinout(sc);
                                        DataTable ddt = dbhelper.getdatahris("Select * from tdtrperpayrolperline where dtrperpayrol_id=0 and empid='" + dt.Rows[0]["Id"].ToString() + "' and  idnumber='" + dt.Rows[0]["IdNumber"].ToString() + "' and biotime='" + row.Cells["DateTimeRecord"].Value.ToString() + "' and checktype='" + row.Cells["Type"].Value.ToString() + "'");
                                        if (ddt.Rows.Count == 0)
                                        {
                                            dt = dbhelper.getdatahris("Insert into tdtrperpayrolperline(dtrperpayrol_id,empid,idnumber,biotime,checktype) values(0,'" + dt.Rows[0]["Id"].ToString() + "','" + dt.Rows[0]["IdNumber"].ToString() + "','" + row.Cells["DateTimeRecord"].Value.ToString() + "','" + row.Cells["Type"].Value.ToString() + "')  SELECT  SCOPE_IDENTITY() ids");
                                            dbhelper.getdatahris("Insert into tdtrperpayrol_LogLocation(Location,tdtrid) values('" + a.Name + "'," + dt.Rows[0]["ids"].ToString() + ")");
                                        }
                                    }
                                }

                                if (bio.Rows.Count == 0)
                                {
                                    Deviceinfos[dd].CountAllLog = row.Index.ToString();
                                    stateclass sc = new stateclass();
                                    string dateform = DateTime.Parse(row.Cells["DateTimeRecord"].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    string datef = DateTime.Parse(row.Cells["DateTimeRecord"].Value.ToString()).ToString("yyyy-MM-dd 00:00:00");
                                    string datel = DateTime.Parse(datef).AddHours(23).ToString("yyyy-MM-dd HH:mm:ss");
                                    string dateb = DateTime.Parse(row.Cells["DateTimeRecord"].Value.ToString()).AddDays(-1).ToString("yyyy-MM-dd 00:00:00");

                                    DataTable dt = new DataTable();
                                    sc.sa = row.Cells["IndRegID"].Value.ToString();
                                    sc.sb = row.Cells["DateTimeRecord"].Value.ToString();
                                    sc.sc = row.Cells["type"].Value.ToString() == "In" ? "Break In" : row.Cells["type"].Value.ToString() == "Out" ? "Break Out" : row.Cells["type"].Value.ToString();
                                    sc.sd = "1";

                                    dt = dbhelper.getdatahris("Select * from MEmployee where BiometricIdNumber='" + row.Cells["IndRegID"].Value.ToString() + "'");
                                    if (dt.Rows.Count > 0)
                                    {
                                        string x = bol.addCheckinout(sc);
                                        DataTable ddt = dbhelper.getdatahris("Select * from tdtrperpayrolperline where dtrperpayrol_id=0 and empid='" + dt.Rows[0]["Id"].ToString() + "' and  idnumber='" + dt.Rows[0]["IdNumber"].ToString() + "' and biotime='" + row.Cells["DateTimeRecord"].Value.ToString() + "' and checktype='" + row.Cells["Type"].Value.ToString() + "'");
                                        if (ddt.Rows.Count == 0)
                                        {
                                            dt = dbhelper.getdatahris("Insert into tdtrperpayrolperline(dtrperpayrol_id,empid,idnumber,biotime,checktype) values(0,'" + dt.Rows[0]["Id"].ToString() + "','" + dt.Rows[0]["IdNumber"].ToString() + "','" + row.Cells["DateTimeRecord"].Value.ToString() + "','" + row.Cells["Type"].Value.ToString() + "') SELECT  SCOPE_IDENTITY() ids");
                                            dbhelper.getdatahris("Insert into tdtrperpayrol_LogLocation(Location,tdtrid) values('" + a.Name + "'," + dt.Rows[0]["ids"].ToString() + ")");
                                        }
                                    }
                                }

                            }
                        }

                        string ipAddress = a.IpAddress.Trim();
                        int portNumber = Convert.ToInt32(a.Port.Trim());
                        IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }

            IntervalTimer.Interval = 300000;
            IntervalTimer.Enabled = true;
            IntervalTimer.Tick += new EventHandler(timer_Tick);

            //btnPullData.PerformClick();
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "MyWaitForm" || frm.Name == "Form1")
                {
                    frm.Hide();
                }
            }
            //ShowWaitForm("Please wait, Recovering Data...");
        }

        private bool mouseDown;
        private Point lastLocation;
        private void Master_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
            IntervalTimer.Stop();
        }
        private void Master_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Master_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            IntervalTimer.Start();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void copyAlltoClipboard()
        {
            dgvRecords.SelectAll();
            DataObject dataObj = dgvRecords.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btn_onduty_Click(object sender, EventArgs e)
        {

        }
        static ICollection<UserInfo> lstFingerPrintTemplates2=null;
        static int getcode=0;
        private void autosaver()
        {
            try
            {
                if (Deviceinfos.Count > 0)
                {
                    foreach (deviceinfo a in Deviceinfos)
                    {
                        if (lstFingerPrintTemplates2 == null)
                        {
                            lstFingerPrintTemplates2 = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber)).ToList();
                        }
                        DataTable dataAuthorized = dbhelper.getdatahris("Select distinct empid from BranchBioDevicesEmp");

                        DataTable dataTable = dbhelper.getdata("Select * from UserInfo");

                        if (dataAuthorized.Rows.Count > 0)
                        {
                            List<string> strs = new List<string>();
                            foreach (DataRow row3 in dataAuthorized.Rows)
                            {
                                if (dataTable.Select("EnrollNumber=" + row3["empid"].ToString()).Count() == 0)
                                {
                                    string sds = row3["empid"].ToString();
                                    strs.Add(sds);
                                }
                            }

                            if (strs.Count > 0)
                            {

                                ICollection<UserInfo> lstFingerPrintTemplates = lstFingerPrintTemplates2.Where(x => strs.Contains(x.EnrollNumber)).ToList();
                                if (lstFingerPrintTemplates != null && lstFingerPrintTemplates.Count > 0)
                                {
                                    stateclass sc = new stateclass();
                                    foreach (var items in lstFingerPrintTemplates)
                                    {
                                        if (dataTable.Select("EnrollNumber=" + items.EnrollNumber + " AND FingerIndex=" + items.FingerIndex.ToString() + "").Count() == 0)
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
                        }

                        if (dataTable.Rows.Count > 0)
                        {
                            List<string> strs = new List<string>();
                            foreach (DataRow row3 in dataTable.Rows)
                            {
                                string sds = row3["EnrollNumber"].ToString();
                                strs.Add(sds);
                            }

                            ICollection<UserInfo> lstFingerPrintTemplates= lstFingerPrintTemplates2;

                            if (lstFingerPrintTemplates.Count != 0)
                            {
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    if (lstFingerPrintTemplates.Where(x => x.EnrollNumber == row["EnrollNumber"].ToString()).ToList().Count() == 0)
                                    {
                                        int MachineNumber = Convert.ToInt32(a.MachineNumber);
                                        string EnrollNumber = row["EnrollNumber"].ToString();
                                        string Name = row["Name"].ToString();
                                        string Password = row["Password"].ToString();
                                        int Privilege = 0;
                                        bool Enabled = Convert.ToBoolean(row["Enabled"].ToString());
                                        int indexfinger = Convert.ToInt32(row["FingerIndex"].ToString());
                                        string iflag = row["iFlag"].ToString();

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
                                        manipulator.UploadFTPTemplate(objZkeeper, MachineNumber, lstUserInfo);
                                        getcode = 1;
                                    }
                                }
                                if (getcode == 1)
                                {
                                    lstFingerPrintTemplates2 = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber)).ToList();
                                }

                            }
                            else
                            {
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    int MachineNumber = Convert.ToInt32(a.MachineNumber);
                                    string EnrollNumber = row["EnrollNumber"].ToString();
                                    string Name = row["Name"].ToString();
                                    string Password = row["Password"].ToString();
                                    int Privilege = 0;
                                    bool Enabled = Convert.ToBoolean(row["Enabled"].ToString());
                                    int indexfinger = Convert.ToInt32(row["FingerIndex"].ToString());
                                    string iflag = row["iFlag"].ToString();

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
                                    manipulator.UploadFTPTemplate(objZkeeper, MachineNumber, lstUserInfo);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Schedules schd = new Schedules();
            schd.Show();*/
            try
            {
                if (Deviceinfos.Count > 0)
                {
                    foreach (deviceinfo a in Deviceinfos)
                    {
                        DataTable dataTable = dbhelper.getdata("Select * from UserInfo");

                        List<string> strs = new List<string>();
                        foreach (DataRow row3 in dataTable.Rows)
                        {
                            string sds = row3["EnrollNumber"].ToString();
                            strs.Add(sds);

                        }

                        ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber)).Where(x => !strs.Contains(x.EnrollNumber)).ToList();
                        if (lstFingerPrintTemplates != null && lstFingerPrintTemplates.Count > 0)
                        {
                            stateclass sc = new stateclass();
                            foreach (var items in lstFingerPrintTemplates)
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
            }
            catch (Exception ex)
            {

            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            SaveUsers frm = new SaveUsers(objZkeeper, Deviceinfos);
            frm.Show();
        }

        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void Master_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon.Visible = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void btn_cld_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Temporarily Removed!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_tlate_Click(object sender, EventArgs e)
        {

        }

        private void btn_tabsent_Click(object sender, EventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            MyWaitForm f2 = new MyWaitForm();
            f2.Show();
            Application.DoEvents();

            DialogResult dr = MessageBox.Show("This action will upload all user information from the 'database' to the connected 'device'. Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (Deviceinfos.Count > 0)
                {
                    foreach (deviceinfo a in Deviceinfos)
                    {
                        ShowStatusBar(string.Empty, true);
                        ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(a.MachineNumber.Trim()));
                        DataTable dataTable = dbhelper.getdata("Select * from UserInfo where MachineNumber=" + a.MachineNumber + "");

                        List<string> strs = new List<string>();
                        foreach (DataRow row3 in dataTable.Rows)
                        {
                            string sds = row3["EnrollNumber"].ToString();
                            strs.Add(sds);

                        }
                        DataTable dt = dbhelper.getdata("Select a.* from UserInfo a where a.MachineNumber!=" + a.MachineNumber + " and a.EnrollNumber!=(case when (Select Distinct b.EnrollNumber from UserInfo b where b.MachineNumber=" + a.MachineNumber + " and b.EnrollNumber=a.EnrollNumber) IS NULL then 0 else (Select Distinct b.EnrollNumber from UserInfo b where b.MachineNumber=" + a.MachineNumber + " and b.EnrollNumber=a.EnrollNumber) end)");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                int MachineNumber = Convert.ToInt32(row["MachineNumber"].ToString());
                                string EnrollNumber = row["EnrollNumber"].ToString();
                                string Name = row["Name"].ToString();
                                string Password = row["Password"].ToString();
                                int Privilege = 0;
                                bool Enabled = Convert.ToBoolean(row["Enabled"].ToString());
                                int indexfinger = Convert.ToInt32(row["FingerIndex"].ToString());
                                string iflag = row["iFlag"].ToString();

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
                                manipulator.UploadFTPTemplate(objZkeeper, MachineNumber, lstUserInfo);
                                // manipulator.PushUserDataToDevice(objZkeeper,1,"13", lstUserInfo);
                            }
                        }
                        string ipAddress = a.IpAddress.Trim();
                        int portNumber = Convert.ToInt32(a.Port);
                        IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);
                    }
                }
            }
            f2.Hide();
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            if (btn_login.Visible)
            {
                txt_password.Visible = false;
                txt_username.Visible = false;
                btn_login.Visible = false;
            }
            else
            {

                txt_password.Visible = true;
                txt_username.Visible = true;
                btn_login.Visible = true;
            }

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "admin" && txt_password.Text == "123123")
            {
                panel_login.Visible = false;
                panel_adbuttons.Visible = true;
                btn_logout.Visible = true;
            }
            else
            {
                txt_password.Clear();
                txt_username.Clear();
                MessageBox.Show("Login failed! Please check the username and password and try again.");
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            btn_logout.Visible = false;
            panel_adbuttons.Visible = false;
            panel_login.Visible = true;
            txt_password.Clear();
            txt_username.Clear();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void activitylog()
        {
            listBox1.Items.Clear();
            if (Deviceinfos.Count > 0)
            {
                foreach (deviceinfo a in Deviceinfos)
                {
                    listBox1.Items.Insert(0, "-----------------");
                    listBox1.Items.Insert(0, "Message: " + a.Message);
                    listBox1.Items.Insert(0, "Status: " + a.Status);
                    listBox1.Items.Insert(0, "Count all logs: " + a.CountAllLog);
                    listBox1.Items.Insert(0, "Time: " + DateTime.Now.ToString());
                    listBox1.Items.Insert(0, "Serial No: " + a.SerialNo);
                    listBox1.Items.Insert(0, "MachineNumber: " + a.MachineNumber);
                    listBox1.Items.Insert(0, "Port: " + a.Port);
                    listBox1.Items.Insert(0, "DeviceId: " + a.DeviceId);
                    listBox1.Items.Insert(0, "IpAddress: " + a.IpAddress);
                }
            }

        }


        private MyWaitForm _waitForm;

        protected void ShowWaitForm(string message)
        {
            // don't display more than one wait form at a time
            if (_waitForm != null && !_waitForm.IsDisposed)
            {
                return;
            }

            _waitForm = new MyWaitForm();
            _waitForm.Text = message; // "Loading data. Please wait..."
            _waitForm.TopMost = true;
            _waitForm.StartPosition = FormStartPosition.CenterScreen;
            _waitForm.Show();
            _waitForm.Refresh();

            // force the wait window to display for at least 700ms so it doesn't just flash on the screen
            System.Threading.Thread.Sleep(700);
            Application.Idle += OnLoaded;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            _waitForm.Close();
        }

        private void btnremoveadmin_Click(object sender, EventArgs e)
        {
            MyWaitForm f2 = new MyWaitForm();
            f2.Show();
            Application.DoEvents();

            DialogResult dr = MessageBox.Show("This action will remove all admin privileges on all accounts from the connected device... Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (Deviceinfos.Count > 0)
                {
                    foreach (deviceinfo a in Deviceinfos)
                    {
                        try
                        {
                            ShowStatusBar(string.Empty, true);
                            objZkeeper.ClearAdministrators(Convert.ToInt32(a.MachineNumber));
                        }
                        catch (Exception ex)
                        {
                            DisplayListOutput(ex.Message);
                        }
                        string ipAddress = a.IpAddress.Trim();
                        int portNumber = Convert.ToInt32(a.Port);
                        IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);
                    }
                }
            }
            f2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = dbhelper.getdata("Select distinct a.[EmpID],CONVERT(varchar(25), a.[DateTime], 109),a.[Type] from CHECKINOUT a where (DATEPART(yy, DateTime) = '" + logTimePicker.Value.ToString("yyyy") + "' AND DATEPART(MM, DateTime) = '" + logTimePicker.Value.ToString("MM") + "' AND DATEPART(dd, DateTime) = '" + logTimePicker.Value.ToString("dd") + "')");
            ClearGrid();
            dgvRecords.DataSource = dt;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UniversalStatic.ChangeGridProperties(dgvRecords);

            IntervalTimer.Start();

        }

        private void tempgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            activitylog();
            autosaver();
            if ((CheckForInternetConnection() && temp == 1))
            {
                LogUpdater();
                temp = 0;
            }
            else
            {
                if (CheckForInternetConnection() == false)
                {

                    temp = 1;
                    ShowStatusBar("No internet connection: Data logs will temporarily stored in the device.", false);
                }
            }

        }
       /* private static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }*/
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
           /* progressBar2.Value = e.ProgressPercentage;
            label2.Text = e.ProgressPercentage.ToString() + " %";
            label3.Text = getcode2+"/3";*/
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }

        
        public void display(string text)
        {
            MessageBox.Show(text);
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

    }
}
