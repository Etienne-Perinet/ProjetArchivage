using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    public class DeviceRecuperationFileType
    {
        public int ID { set; get; }
        public string Name { set; get; }
        
        public DeviceRecuperationFileType()
        {
            ID = 0;
            Name = "";
        }

        public DeviceRecuperationFileType(int inID, string inName)
        {
            ID = inID;
            Name = inName;
        }
    }
}
