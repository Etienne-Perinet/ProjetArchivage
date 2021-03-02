using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    public class SearchOption
    {
        //public List<string> KeyWords { set; get; }
        public string KeyWord { set; get; }
        public Employe EmployeSearched { set; get; }
        public int BoxNum { set; get; }
        public int ContainerNum { set; get; }
        public int DeviceNum { set; get; }   
        public bool Flag { set; get; }
        public DeviceType DeviceType { set; get; }


        public int[] DateTimeLastWritten { set; get; }

        public SearchOption()
        {
            //KeyWords = new List<string>();
            KeyWord = "";
            BoxNum = -1;
            ContainerNum = -1;
            DeviceNum = -1;
            DateTimeLastWritten = new int[3];
            DateTimeLastWritten[0] = -1;
            DateTimeLastWritten[1] = -1;
            DateTimeLastWritten[2] = -1;
            Flag = false;
        }



        public SearchOption(string keyWords, Employe employe, DeviceType deviceType, int boxNum, int containerNum, int deviceNum, int year, int month, int day, bool flag)
        {
            DeviceType = deviceType;
            KeyWord = keyWords.ToUpper();
            EmployeSearched = employe;

            BoxNum = boxNum;
            ContainerNum = containerNum;
            DeviceNum = deviceNum;

            if (boxNum == 0)
            {
                BoxNum = -1;
            }
            if (containerNum == 0)
            {
                ContainerNum = -1;
            }
            if ( deviceNum == 0)
            {
                DeviceNum = -1;
            }

            DateTimeLastWritten = new int[3];
            DateTimeLastWritten[0] = year;
            DateTimeLastWritten[1] = month;
            DateTimeLastWritten[2] = day;
            Flag = flag;
        }

    }
}
