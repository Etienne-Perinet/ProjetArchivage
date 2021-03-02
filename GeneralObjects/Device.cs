using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{

    public enum DeviceFlag
    {
        OlderVersion,
        OnlyVersion,
        LastVersion,
        BestVersionFromAnOtherBD,
        OlderVersionFromAnOtherBD,
        Unknown
    }

    public class Device
    {
        public int ID { set; get; }
        public int BoxNum { set; get; }
        public int ContainerNum { set; get; }
        public int DeviceNum { set; get; }
        public string FileName { set; get; }

        public Employe EmployeOperator { set; get; }
        public Employe EmployeVerificator { set; get; }
        public DeviceType DeviceType { set; get; }
        public DeviceRecuperationFileType DeviceRecuperationFileType { set; get; }

        public DeviceFlag Flag { set; get; }

        public Device()
        {
            ID = 0;
            BoxNum = 0;
            ContainerNum = 0;
            DeviceNum = 0;
            FileName = "";

            EmployeOperator = new Employe();
            EmployeVerificator = new Employe();

            DeviceType = new DeviceType();
            DeviceRecuperationFileType = new DeviceRecuperationFileType();

            Flag = DeviceFlag.Unknown;
        }

        static public bool operator ==(Device device1, Device device2)
        {
            return (device1.BoxNum == device2.BoxNum && device1.ContainerNum == device2.ContainerNum && device1.DeviceNum == device2.DeviceNum);
        }

        static public bool operator !=(Device device1, Device device2)
        {
            return !(device1 == device2);
        }

    }
}
