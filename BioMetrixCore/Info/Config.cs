using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;

namespace BioMetrixCore.Info
{
    class Config
    {
        public Config()
        {
        }

        public static string connection()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug","") + "\\config.xml";
            FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read);

            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("config");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = "Data Source=" + xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + "; Initial Catalog=" + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + "; User ID=" + xmlnode[i].ChildNodes.Item(2).InnerText.Trim() + "; Password=" + xmlnode[i].ChildNodes.Item(3).InnerText.Trim() + ";";
            }

            fs.Dispose();
            fs.Close();
            return str;

            // return "Data Source=DESKTOP-94NC7HV; Initial Catalog=DTR;User ID=sa; Password=xx;";
            //return "Data Source=18.220.163.34; Initial Catalog=AMS;User ID=sa; Password=Serverdrop183;";
        }

        public static string connectionhris()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug", "") + "\\config.xml";
            FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read);

            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("config");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(4).InnerText.Trim();
                str = "Data Source=" + xmlnode[i].ChildNodes.Item(4).InnerText.Trim() + "; Initial Catalog=" + xmlnode[i].ChildNodes.Item(5).InnerText.Trim() + "; User ID=" + xmlnode[i].ChildNodes.Item(6).InnerText.Trim() + "; Password=" + xmlnode[i].ChildNodes.Item(7).InnerText.Trim() + ";";
            }

            fs.Dispose();
            fs.Close();
            return str;
            // return "Data Source=DESKTOP-94NC7HV; Initial Catalog=D+Gdb;User ID=sa; Password=xx;";
            //return "Data Source=18.220.163.34; Initial Catalog=OpenDBTwoFuture;User ID=sa; Password=Serverdrop183;";
        }
    }
 
}
