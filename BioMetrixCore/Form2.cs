using BioMetrixCore.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BioMetrixCore
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            loader();
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "Form1")
                {
                    frm.Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug", "") + "\\config.xml";
            FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read);

            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("config");

                xmlnode[0].ChildNodes.Item(0).InnerText= textBox1.Text;
                xmlnode[0].ChildNodes.Item(4).InnerText = textBox1.Text;


            fs.Dispose();
            fs.Close();
            xmldoc.Save(str);

            Form1 f2 = new Form1();
            f2.Show();
            Application.DoEvents();


        }

        private void loader()
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
                textBox1.Text=xmlnode[i].ChildNodes.Item(1).InnerText;
                textBox1.Text=xmlnode[i].ChildNodes.Item(4).InnerText;
            }
            fs.Dispose();
            fs.Close();

            
        }
    }
}
