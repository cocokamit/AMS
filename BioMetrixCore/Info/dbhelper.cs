using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BioMetrixCore.Info
{
    class dbhelper
    {
        public dbhelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable getdata(string sql)
        {
            string con = Config.connection();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            conn.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable getdatahris(string sql)
        {
            string conhris = Config.connectionhris();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(conhris);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            conn.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            conn.Close();
            return dt;
        }

        public static string exec_proc(string proc, SqlParameter[] p)
        {
            string con = Config.connection();
            SqlConnection conn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(proc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(p);
            conn.Open();
            cmd.ExecuteNonQuery();
            string ret = cmd.Parameters["@out"].Value.ToString();
            conn.Close();
            return ret;
        }

    }
}
