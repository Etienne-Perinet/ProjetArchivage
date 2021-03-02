using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    public class Role
    {
        public string Name { set; get; }
        public int ID { set; get; }
        public Role(int inID, string inName)
        {
            Name = inName;
            ID = inID;
        }
        public Role()
        {
            Name = "";
            ID = 0;
        }
    }
}
