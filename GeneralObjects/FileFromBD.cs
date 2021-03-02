using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    public class FileFromBD
    {
        public int ID { set; get; }
        public string Path { set; get; }
        public DateTime DateTimeLastWritten { set; get; }

        public Device DeviceWhereIsTheFile { set; get; }

        public FileFromBD()
        {
            ID = 0;
            Path = "";
            DateTimeLastWritten = new DateTime();
            DeviceWhereIsTheFile = new Device();
        }
        public FileFromBD(int inID, string inPath, DateTime inDateTimeLastWritten, Device inDeviceWhereTheFileIs)
        {
            ID = inID;
            Path = inPath;
            DateTimeLastWritten = inDateTimeLastWritten;
            DeviceWhereIsTheFile = inDeviceWhereTheFileIs;
        }
    }
}
