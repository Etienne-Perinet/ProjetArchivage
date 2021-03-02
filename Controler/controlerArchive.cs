using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace Archivage
{
    class ArchiveControler : FormControler
    {
        private string generalPath;
        private List<FileInfo> informationForEachFiles = new List<FileInfo>();

        private Device currentDevice = new Device();

        public ArchiveControler():base()
        {
            generalPath = "";

            //SubscribeToEvents();
        }

        
        


        //private void SubscribeToEvents()
        //{
        //    sqlControler.SendAnError += SendNoBDDetectedMessage;
        //}

        //private void SendNoBDDetectedMessage(object sender, SendErrorToUserEventArgs e)
        //{
        //    if (SendAnError != null)
        //    {
        //        SendAnError(this, new SendErrorToUserEventArgs(e.Error));
        //    }
        //}

        public List<FileInfo> GetInformationForEachFiles()
        {
            return informationForEachFiles;
        }


        private Employe FindEmployeWithString(string employeNameSearching)
        {
            Employe result = null;
            foreach (Employe employe in allEmployes)
            {
                if (employe.Name == employeNameSearching)
                {
                    result = employe;
                }
            }
            return result;
        }


        #region SaveInformation

        public bool TryLetter(string letter)
        {
            bool response = false;
            if (Directory.Exists(letter + ":\\"))
            {
                response = true;
            }
            return response;
        }

        public void RemakeListFilePath(string path)
        {
            informationForEachFiles.Clear();
            generalPath = path.Replace("\\", "");
            ProcessFilesAndFolders(path);
        }

        private void ProcessFilesAndFolders(string path)
        {   
            string[] filePathsCreations = Directory.GetFiles(path);
            AddFileFromFolderToList(filePathsCreations);

            string[] allFoldersInThisPath = Directory.GetDirectories(path);

            foreach (string pathToAFolder in allFoldersInThisPath)
            {
                ProcessFilesAndFolders(pathToAFolder);
            }
        }

        private void AddFileFromFolderToList(string[] filePathsToIncludeInTheList)
        {
            FileInfo infoForThisFile;

            foreach (string filePath in filePathsToIncludeInTheList)
            {
                infoForThisFile = new FileInfo(filePath);
                informationForEachFiles.Add(infoForThisFile);
            }
        }

        private DeviceRecuperationFileType FindDeviceRecuperationFileTypeWithString(string fileTypeNameSearching)
        {
            DeviceRecuperationFileType result = null;
            foreach (DeviceRecuperationFileType fileType in allRecuperationFileType)
            {
                if (fileType.Name == fileTypeNameSearching)
                {
                    result = fileType;
                }
            }
            return result;
        }

        private DeviceType FindDeviceTypeWithString(string deviceTypeNameSearching)
        {
            DeviceType result = null;
            foreach (DeviceType deviceType in allDeviceType)
            {
                if (deviceType.Name == deviceTypeNameSearching)
                {
                    result = deviceType;
                }
            }
            return result;
        }

        public void CreateDevice(int numBox, int numContainer, int numDevice, string fileName, string typeFile, string storageContainer, string firstEmployeName, string secondEmployeName)
        {
            currentDevice.BoxNum = numBox;
            currentDevice.ContainerNum = numContainer;
            currentDevice.DeviceNum = numDevice;
            currentDevice.FileName = fileName;
            currentDevice.DeviceRecuperationFileType = FindDeviceRecuperationFileTypeWithString(typeFile);
            currentDevice.DeviceType = FindDeviceTypeWithString(storageContainer);
            currentDevice.EmployeOperator = FindEmployeWithString(firstEmployeName);
            currentDevice.EmployeVerificator = FindEmployeWithString(secondEmployeName);
        }

        public bool Save()
        {
            try
            {
                bool saved = false;
                bool idDeviceFound = sqlControler.AddNewDeviceToBD(ref currentDevice);

                if (idDeviceFound)
                {
                    sqlControler.SaveTheFiles(informationForEachFiles, currentDevice);
                    saved = true;
                }
                return saved;
            }
            catch (Exception e)
            {
                string test = e.Message;
                SendNoBDDetectedMessage();
                return true;
            }
        }

        public void ReplaceDeviceSaved()
        {
            try
            {
                sqlControler.ReplaceOldDeviceInBD(ref currentDevice);
                sqlControler.SaveTheFiles(informationForEachFiles, currentDevice);
            }
            catch (Exception e)
            {
                
                SendNoBDDetectedMessage();
            }
            
        }

        #endregion


          //==================================================================================================================================//
         //----------------------------------------------------------------------------------------------------------------------------------//
        //==================================================================================================================================//


        #region Search




        public SearchOption CreateSearchOption(string keyWord, string employe, string deviceType, int boxNum, int containerNum, int deviceNum, int year, int month, int day, bool tag)
        {            
            return new SearchOption(keyWord, FindEmployeWithString(employe), FindDeviceTypeWithString(deviceType), boxNum, containerNum, deviceNum, year, month, day, tag);
        }

        public List<FileFromBD> Search(string keyWord, string employe, string deviceType, int boxNum, int containerNum, int deviceNum, int year, int month, int day, bool tag)
        {
            informationForEachFiles.Clear();
            SearchOption option = CreateSearchOption(keyWord, employe, deviceType, boxNum, containerNum, deviceNum, year, month, day, tag);
            try
            {
                return sqlControler.RealSearchInBD(option);
            }
            catch (Exception e)
            {
                string t = e.Message;
                SendNoBDDetectedMessage();
                return null;
            }   
        }

        #endregion
    }
}
