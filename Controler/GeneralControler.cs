using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{

    abstract class FormControler
    {
        protected SqlControler sqlControler = new SqlControler();

        protected List<Employe> allEmployes = new List<Employe>();

        protected List<DeviceRecuperationFileType> allRecuperationFileType = new List<DeviceRecuperationFileType>();

        protected List<DeviceType> allDeviceType = new List<DeviceType>();

        public FormControler()
        {

        }

        public delegate void SendErrorToUserEventHandler(object sender, SendErrorToUserEventArgs e);
        public event SendErrorToUserEventHandler SendAnError;

        protected void SendNoBDDetectedMessage()
        {
            if (SendAnError != null)
            {
                SendAnError(this, new SendErrorToUserEventArgs("La base de données ne se trouve pas avec le programme. Veuillez remettre le fichier BDArchive.db avec le fichier exécutable et redémarrer le programme."));
            }
        }

        public List<Employe> GetAllEmployes()
        {
            try
            {
                allEmployes = sqlControler.GetAllEmployes();
            }
            catch (Exception)
            {
                SendNoBDDetectedMessage();
            }

            return allEmployes;
        }

        public List<DeviceRecuperationFileType> GetAllDeviceRecuperationFileType()
        {
            try
            {
                allRecuperationFileType = sqlControler.GetAllDeviceRecuperationFileType();
            }
            catch (Exception)
            {
                SendNoBDDetectedMessage();
            }
            
            return allRecuperationFileType;
            
        }

        public List<DeviceType> GetAllDeviceType()
        {
            try
            {
                allDeviceType = sqlControler.GetAllDeviceType();
            }
            catch (Exception)
            {
                SendNoBDDetectedMessage();
            }
            
            return allDeviceType;
        }
    }
}
