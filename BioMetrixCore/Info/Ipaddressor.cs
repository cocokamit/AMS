using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Info
{
    static class Ipaddressor
    {
        private static string Ipaddress = "";

        public static string Ipaddressvar
        {
            get { return Ipaddress; }
            set { Ipaddress = value; }
        }
    }
}
