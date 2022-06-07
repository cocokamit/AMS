using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Info
{
    class dal
    {
        public static string adduser(stateclass a)
        {

            SqlParameter[] p = new SqlParameter[10];

            string sql = "_adduser";
            p[0] = new SqlParameter("@MachineNumber", SqlDbType.Int);
            p[0].Direction = ParameterDirection.Input;
            p[0].Value = a.sa;


            p[1] = new SqlParameter("@EnrollNumber", SqlDbType.Int);
            p[1].Direction = ParameterDirection.Input;
            p[1].Value = a.sb;

            p[2] = new SqlParameter("@Name", SqlDbType.VarChar, 30);
            p[2].Direction = ParameterDirection.Input;
            p[2].Value = a.sc;

            p[3] = new SqlParameter("@FingerIndex", SqlDbType.Int);
            p[3].Direction = ParameterDirection.Input;
            p[3].Value = a.sd;

            p[4] = new SqlParameter("@TmpData", SqlDbType.VarChar);
            p[4].Direction = ParameterDirection.Input;
            p[4].Value = a.se;
            
            p[5] = new SqlParameter("@Privelage", SqlDbType.Int);
            p[5].Direction = ParameterDirection.Input;
            p[5].Value = a.sf;

            p[6] = new SqlParameter("@Password", SqlDbType.VarChar,30);
            p[6].Direction = ParameterDirection.Input;
            p[6].Value = a.sg;

            p[7] = new SqlParameter("@Enabled", SqlDbType.VarChar, 30);
            p[7].Direction = ParameterDirection.Input;
            p[7].Value = a.sh;

            p[8] = new SqlParameter("@iFlag", SqlDbType.Int);
            p[8].Direction = ParameterDirection.Input;
            p[8].Value = a.si;

            p[9] = new SqlParameter("@out", SqlDbType.VarChar, 50);
            p[9].Direction = ParameterDirection.Output;

            return dbhelper.exec_proc(sql, p);
        }
        public static string addCheckinout(stateclass a)
        {

            SqlParameter[] p = new SqlParameter[5];

            string sql = "_addCheckinout";
            p[0] = new SqlParameter("@EmpID", SqlDbType.Int);
            p[0].Direction = ParameterDirection.Input;
            p[0].Value = a.sa;

            p[1] = new SqlParameter("@DateTime", SqlDbType.DateTime);
            p[1].Direction = ParameterDirection.Input;
            p[1].Value = a.sb;

            p[2] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            p[2].Direction = ParameterDirection.Input;
            p[2].Value = a.sc;

            p[3] = new SqlParameter("@deviceId", SqlDbType.Int);
            p[3].Direction = ParameterDirection.Input;
            p[3].Value = a.sd;

            p[4] = new SqlParameter("@out", SqlDbType.VarChar, 50);
            p[4].Direction = ParameterDirection.Output;

            return dbhelper.exec_proc(sql, p);
        }


    }
}
