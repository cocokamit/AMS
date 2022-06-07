using System;

namespace BioMetrixCore
{
    public class MachineInfo
    {
        //public int MachineNumber { get; set; }
        //public int EmpID { get; set; }
        //public string DateTimeRecord { get; set; }

        //public DateTime DateOnlyRecord
        //{
        //    get { return DateTime.Parse(DateTime.Parse(DateTimeRecord).ToString("yyyy-MM-dd")); }
        //}
        //public string Time_in
        //{
        //    get;set;
        //}

        //public string Time_out
        //{
        //    get;set;
        //}

        public int MachineNumber { get; set; }
        public int IndRegID { get; set; }
        public string DateTimeRecord { get; set; }

        public string DateOnlyRecord
        {
            get { return DateTime.Parse(DateTimeRecord).ToString("yyyy-MM-dd"); }
        }
        public string type
        {
            get; set;
        }

       
    }
}
