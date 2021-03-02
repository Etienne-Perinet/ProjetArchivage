using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    public class DeviceType
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public DeviceRecuperationFileType UsualDeviceRecuperationFileType { set; get; }
        public DeviceType()
        {
            ID = 0;
            Name = "";
            UsualDeviceRecuperationFileType = null;
        }

        public DeviceType(int inID, string inName)
        {
            ID = inID;
            Name = inName;
            UsualDeviceRecuperationFileType = null;
        }

        public DeviceType(int inID, string inName, DeviceRecuperationFileType inDeviceRecuperationFileType)
        {
            ID = inID;
            Name = inName;
            UsualDeviceRecuperationFileType = inDeviceRecuperationFileType;
        }
    }
}
