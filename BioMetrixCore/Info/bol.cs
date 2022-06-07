using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Info
{
    class bol
    {
        public static string adduser(stateclass sc)
        {
            return dal.adduser(sc);
        }
        public static string addCheckinout(stateclass sc)
        {
            return dal.addCheckinout(sc);
        }
    }
}
