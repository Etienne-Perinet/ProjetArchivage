using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

using System.Diagnostics;
using System.IO;

namespace Archivage
{
    class SqlControler
    {
        SQLiteConnection connection;

        public SqlControler()
        {
            CreateConnection();
        }

        public string GetPathToProgram()
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule myProcessModule = currentProcess.MainModule;

            return Path.GetDirectoryName(myProcessModule.FileName).Replace("Archivage.exe", "");
        }

        public void CreateConnection()
        {
            string pathToProgram = GetPathToProgram();
            string cs = "URI=file:" + GetPathToProgram() + "\\BDArchive.db";

            connection = new SQLiteConnection(cs);
        }

       

        public SqlControler(string path)
        {
            connection = new SQLiteConnection(path);
        }

        public delegate void SendErrorToUserEventHandler(object sender, SendErrorToUserEventArgs e);
        public event SendErrorToUserEventHandler SendAnError;

        private List<T> CombineTwoList<T>(List<T> firstList, List<T> secondList)
        {
            List<T> onReturn = new List<T>();
            foreach (T item in firstList)
            {
                onReturn.Add(item);
            }
            foreach (T item in secondList)
            {
                onReturn.Add(item);
            }
            return onReturn;
        }

        private DeviceFlag GetDeviceFlagFromString(string flagString)
        {
            DeviceFlag onReturn = new DeviceFlag();
            switch (flagString)
            {
                case "LastVersion":
                    onReturn = DeviceFlag.LastVersion;
                    break;
                case "OlderVersion":
                    onReturn = DeviceFlag.OlderVersion;
                    break;
                case "OnlyVersion":
                    onReturn = DeviceFlag.OnlyVersion;
                    break;
                case "BestVersionFromAnOtherBD":
                    onReturn = DeviceFlag.BestVersionFromAnOtherBD;
                    break;
                case "OlderVersionFromAnOtherBD":
                    onReturn = DeviceFlag.OlderVersionFromAnOtherBD;
                    break;
                default:
                    onReturn = DeviceFlag.Unknown;
                    break;
            }
            return onReturn;
        }
        private string GetDeviceStringFlagFromDeviceFlagEnum(DeviceFlag flag)
        {
            string onReturn = "";
            switch (flag)
            {
                case DeviceFlag.OlderVersion:
                    onReturn = "OlderVersion";
                    break;
                case DeviceFlag.OnlyVersion:
                    onReturn = "OnlyVersion";
                    break;
                case DeviceFlag.LastVersion:
                    onReturn = "LastVersion";
                    break;
                case DeviceFlag.Unknown:
                    onReturn = "Unknown";
                    break;
                case DeviceFlag.BestVersionFromAnOtherBD:
                    onReturn = "BestVersionFromAnOtherBD";
                    break;
                case DeviceFlag.OlderVersionFromAnOtherBD:
                    onReturn = "OlderVersionFromAnOtherBD";
                    break;
                default:
                    break;
            }
            return onReturn;
        }


        private void SendNoBDDetectedMessage()
        {
            if (SendAnError != null)
            {
                SendAnError(this, new SendErrorToUserEventArgs("La base de données ne se trouve pas avec le programme."));
            }
        }


        private int GetLastIDInserted(SQLiteConnection inConnection)
        {
            using var commandToGetID = new SQLiteCommand("select last_insert_rowid()", inConnection);
            Int64 LastRowID64 = (Int64)commandToGetID.ExecuteScalar();

            return (int)LastRowID64;
        }


        public DeviceRecuperationFileType GetDeviceRecuperationFileTypeFromBDWithID(int id, SQLiteConnection secondConnection)
        {
            string sqlCommand = "SELECT FileTypeName FROM tbl_DeviceRecuperationFileType WHERE DeviceRecuperationFileTypeID = " + id;

            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);

            
            string DeviceRecuperationFileTypeNameFound = commandToExecute.ExecuteScalar().ToString();

            return new DeviceRecuperationFileType(id, DeviceRecuperationFileTypeNameFound);
        }

        public DeviceRecuperationFileType GetDeviceRecuperationFileTypeFromBDWithID(int id)
        {
            string sqlCommand = "SELECT FileTypeName FROM tbl_DeviceRecuperationFileType WHERE DeviceRecuperationFileTypeID = " + id;

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);


            string DeviceRecuperationFileTypeNameFound = commandToExecute.ExecuteScalar().ToString();

            return new DeviceRecuperationFileType(id, DeviceRecuperationFileTypeNameFound);
        }

        public Role GetRoleForAnEmployeWithID(int id)
        {
            string sqlCommand = "SELECT NameRole FROM tbl_Role WHERE RoleID = " + id;

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);

            string RoleNameFound = commandToExecute.ExecuteScalar().ToString();

            return new Role(id, RoleNameFound);
        }
        public Role GetRoleForAnEmployeWithID(int id, SQLiteConnection secondConnection)
        {
            string sqlCommand = "SELECT NameRole FROM tbl_Role WHERE RoleID = " + id;

            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);

            string RoleNameFound = commandToExecute.ExecuteScalar().ToString();

            return new Role(id, RoleNameFound);
        }

        public Employe GetEmployeWithID(int id, SQLiteConnection secondConnection)
        {
            string sqlCommand = "SELECT * FROM tbl_Employe WHERE EmployeID = " + id;
            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);

            SQLiteDataReader employeReader = commandToExecute.ExecuteReader();
            employeReader.Read();

            return new Employe(
                id,
                employeReader["NameEmploye"].ToString(),
                employeReader["Email"].ToString(),
                GetRoleForAnEmployeWithID(Convert.ToInt32(employeReader["RoleID"]), secondConnection)
                );
        }
        public Employe GetEmployeWithID(int id)
        {
            string sqlCommand = "SELECT * FROM tbl_Employe WHERE EmployeID = " + id;
            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);

            SQLiteDataReader employeReader = commandToExecute.ExecuteReader();
            employeReader.Read();

            return new Employe(
                id,
                employeReader["NameEmploye"].ToString(),
                employeReader["Email"].ToString(),
                GetRoleForAnEmployeWithID(Convert.ToInt32(employeReader["RoleID"]))
                );
        }

        public DeviceType GetDeviceTypeWithID(int id, SQLiteConnection secondConnection)
        {
            string sqlCommand = "SELECT * FROM tbl_DeviceType WHERE DeviceTypeID = " + id;
            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);

            SQLiteDataReader deviceTypeReader = commandToExecute.ExecuteReader();
            deviceTypeReader.Read();

            return new DeviceType(id,
                deviceTypeReader["DeviceTypeName"].ToString(),
                GetDeviceRecuperationFileTypeFromBDWithID(Convert.ToInt32(deviceTypeReader["UsualDeviceRecuperationFileTypeID"]), secondConnection)
                );
        }
        public DeviceType GetDeviceTypeWithID(int id)
        {
            string sqlCommand = "SELECT * FROM tbl_DeviceType WHERE DeviceTypeID = " + id;
            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);

            SQLiteDataReader deviceTypeReader = commandToExecute.ExecuteReader();
            deviceTypeReader.Read();

            return new DeviceType(id,
                deviceTypeReader["DeviceTypeName"].ToString(),
                GetDeviceRecuperationFileTypeFromBDWithID(Convert.ToInt32(deviceTypeReader["UsualDeviceRecuperationFileTypeID"]))
                );
        }


        public List<DeviceRecuperationFileType> GetAllDeviceRecuperationFileType()
        {
            string sqlCommand = "SELECT * FROM tbl_DeviceRecuperationFileType";
            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader readerDeviceRecuperationFileType = commandToExecute.ExecuteReader();
            List<DeviceRecuperationFileType> listToReturn = GetAllDeviceRecuperationFileTypeFromReader(readerDeviceRecuperationFileType);
            connection.Close();
            return listToReturn;
        }

        private List<DeviceRecuperationFileType> GetAllDeviceRecuperationFileTypeFromReader(SQLiteDataReader readerDeviceRecuperationFileType)
        {
            DeviceRecuperationFileType currentDeviceRecuperationFileTypes;
            List<DeviceRecuperationFileType> listForDeviceRecuperationFileTypes = new List<DeviceRecuperationFileType>();
            while (readerDeviceRecuperationFileType.Read())
            {
                currentDeviceRecuperationFileTypes = new DeviceRecuperationFileType();
                currentDeviceRecuperationFileTypes.ID = Convert.ToInt32(readerDeviceRecuperationFileType["DeviceRecuperationFileTypeID"]);
                currentDeviceRecuperationFileTypes.Name = readerDeviceRecuperationFileType["FileTypeName"].ToString();
                listForDeviceRecuperationFileTypes.Add(currentDeviceRecuperationFileTypes);
            }
            return listForDeviceRecuperationFileTypes;
        }

        public List<DeviceType> GetAllDeviceType()
        {
            string sqlCommand = "SELECT * FROM tbl_DeviceType";
            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader readerDeviceType = commandToExecute.ExecuteReader();
            List<DeviceType> listToReturn = GetAllDeviceTypeFromReader(readerDeviceType);
            connection.Close();
            return listToReturn;
        }

        private List<DeviceType> GetAllDeviceTypeFromReader(SQLiteDataReader readerDeviceType)
        {
            DeviceType currentDeviceType;
            List<DeviceType> listForEmployes = new List<DeviceType>();
            while (readerDeviceType.Read())
            {
                currentDeviceType = new DeviceType();
                currentDeviceType.ID = Convert.ToInt32(readerDeviceType["DeviceTypeID"]);
                currentDeviceType.Name = readerDeviceType["DeviceTypeName"].ToString();
                currentDeviceType.UsualDeviceRecuperationFileType =
                    GetDeviceRecuperationFileTypeFromBDWithID(Convert.ToInt32(readerDeviceType["UsualDeviceRecuperationFileTypeID"]));
                listForEmployes.Add(currentDeviceType);
            }
            return listForEmployes;
        }

        public List<Employe> GetAllEmployes()
        {
            string sqlCommand = "SELECT * FROM tbl_Employe";
            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader readerEmploye = commandToExecute.ExecuteReader();
            List<Employe> listToReturn = GetAllEmployesFromReader(readerEmploye);
            connection.Close();
            return listToReturn;
        }

        private List<Employe> GetAllEmployes(SQLiteConnection secondConnection)
        {
            string sqlCommand = "SELECT * FROM tbl_Employe";
            secondConnection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);
            SQLiteDataReader readerEmploye = commandToExecute.ExecuteReader();
            List<Employe> listToReturn = GetAllEmployesFromReader(readerEmploye, secondConnection);
            secondConnection.Close();
            return listToReturn;
        }

        private List<Employe> GetAllEmployesFromReader(SQLiteDataReader readerEmploye)
        {
            Employe currentEmploye;
            List<Employe> listForEmployes = new List<Employe>();
            while (readerEmploye.Read())
            {
                currentEmploye = new Employe();
                currentEmploye.ID = Convert.ToInt32(readerEmploye["EmployeID"]);
                currentEmploye.Name = readerEmploye["NameEmploye"].ToString();
                currentEmploye.Email = readerEmploye["Email"].ToString();
                currentEmploye.EmployeRole = GetRoleForAnEmployeWithID(Convert.ToInt32(readerEmploye["RoleID"]));
                listForEmployes.Add(currentEmploye);
            }
            return listForEmployes;
        }

        private List<Employe> GetAllEmployesFromReader(SQLiteDataReader readerEmploye, SQLiteConnection secondConnection)
        {
            Employe currentEmploye;
            List<Employe> listForEmployes = new List<Employe>();
            while (readerEmploye.Read())
            {
                currentEmploye = new Employe();
                currentEmploye.ID = Convert.ToInt32(readerEmploye["EmployeID"]);
                currentEmploye.Name = readerEmploye["NameEmploye"].ToString();
                currentEmploye.Email = readerEmploye["Email"].ToString();
                currentEmploye.EmployeRole = GetRoleForAnEmployeWithID(Convert.ToInt32(readerEmploye["RoleID"]), secondConnection);
                listForEmployes.Add(currentEmploye);
            }
            return listForEmployes;
        }

        public List<Role> GetAllRoles()
        {
            string sqlCommand = "SELECT * FROM tbl_Role";
            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader readerRole = commandToExecute.ExecuteReader();
            List<Role> listToReturn = GetAllRolesFromReader(readerRole);
            connection.Close();
            return listToReturn;
        }

        private List<Role> GetAllRolesFromReader(SQLiteDataReader readerRole)
        {
            Role currentRole;
            List<Role> listForRoles = new List<Role>();
            while (readerRole.Read())
            {
                currentRole = new Role();
                currentRole.ID = Convert.ToInt32(readerRole["RoleID"]);
                currentRole.Name = readerRole["NameRole"].ToString();

                listForRoles.Add(currentRole);
            }
            return listForRoles;
        }

        #region SaveInformation

        //Return "true" if something is found.
        private bool LookForSameDeviceInBD(Device device)
        {
            bool result = false;
            string sqlCommand = "SELECT COUNT(*) FROM tbl_Device  WHERE BoxNum LIKE '" + device.BoxNum + "' AND ContainerNum LIKE '" + device.ContainerNum + "' AND DeviceNum LIKE '" + device.DeviceNum + "'"; 
            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            int deviceCount = Convert.ToInt32(commandToExecute.ExecuteScalar());
            if (deviceCount > 0)
            {
                result = true;
            }
            
            connection.Close();

            return result;
        }

        private bool LookForSameDeviceInSecondBD(SQLiteConnection secondConnection, Device device)
        {
            bool result = false;
            string sqlCommand = "SELECT COUNT(*) FROM tbl_Device  WHERE BoxNum LIKE '" + device.BoxNum + "' AND ContainerNum LIKE '" + device.ContainerNum + "' AND DeviceNum LIKE '" + device.DeviceNum + "'";
            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            int deviceCount = Convert.ToInt32(commandToExecute.ExecuteScalar());
            if (deviceCount > 0)
            {
                result = true;
            }
            connection.Close();

            return result;
        }

        private void AlterOldDevice(Device device)
        {
            string sqlCommand = "UPDATE tbl_Device SET Flag = 'OlderVersion' WHERE BoxNum LIKE '" + device.BoxNum + "' AND ContainerNum LIKE '" + device.ContainerNum + "'AND DeviceNum LIKE '" + device.DeviceNum + "'" +
                "AND Flag='OnlyVersion' OR Flag='LastVersion'";

            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            commandToExecute.ExecuteNonQuery();

            connection.Close();
        }

        private void SaveNewDevice(ref Device device, string flag)
        {
            string sqlCommand = "INSERT INTO tbl_Device " +
                "(BoxNum, ContainerNum, DeviceNum, FileName, EmployeOperatorID, EmployeVerificatorID, DeviceTypeID, DeviceRecuperationFileTypeID, Flag)" +
                "VALUES ('" +
                device.BoxNum + "', '" +
                device.ContainerNum + "', '" +
                device.DeviceNum + "', '" +
                device.FileName + "', '" +
                device.EmployeOperator.ID + "', '" +
                device.EmployeVerificator.ID + "', '" +
                device.DeviceType.ID + "', '" +
                device.DeviceRecuperationFileType.ID + "', '" +
                flag + "')";

            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            commandToExecute.ExecuteNonQuery();


            device.ID = GetLastIDInserted(connection);
            connection.Close();
        }

        private void SaveNewDevice(ref Device device)
        {
            string sqlCommand = "INSERT INTO tbl_Device " +
                "(BoxNum, ContainerNum, DeviceNum, FileName, EmployeOperatorID, EmployeVerificatorID, DeviceTypeID, DeviceRecuperationFileTypeID, Flag)" +
                "VALUES ('" +
                device.BoxNum + "', '" +
                device.ContainerNum + "', '" +
                device.DeviceNum + "', '" +
                device.FileName + "', '" +
                device.EmployeOperator.ID + "', '" +
                device.EmployeVerificator.ID + "', '" +
                device.DeviceType.ID + "', '" +
                device.DeviceRecuperationFileType.ID + "', '" +
                GetDeviceStringFlagFromDeviceFlagEnum(device.Flag) + "')";

            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            commandToExecute.ExecuteNonQuery();

            using var commandToGetID = new SQLiteCommand("select last_insert_rowid()", connection);

            Int64 LastRowID64 = (Int64)commandToGetID.ExecuteScalar();
            device.ID = (int)LastRowID64;
            connection.Close();
        }


        public void SaveTheFiles(List<FileInfo> informationForEachFiles, Device device)
        {
            connection.Open();
            
            foreach (FileInfo aFile in informationForEachFiles)
            {
                SaveAFile(aFile, device);               
            }
            connection.Close();
        }

        private void SaveAFile(FileInfo fileInfo, Device device)
        {
            string sqlCommand = "INSERT INTO tbl_File " +
                "(DeviceID, Path, Year, Month, Day)" +
                "VALUES ('" +
                device.ID + "', '" +
                fileInfo.FullName.Substring(2, fileInfo.FullName.Length - 2).Replace("'", "`") + "', '" +
                fileInfo.LastWriteTime.Year + "', '" +
                fileInfo.LastWriteTime.Month + "', '" +
                fileInfo.LastWriteTime.Day +
                "')";

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            commandToExecute.ExecuteNonQuery();
        }

        //Retourne l'id du "Device" trouvé dans la BD s'il en existe un, mais s'il n'existe pas de "Device" pereille à celui demandé,
        //il enregistre le nouveau "Device". 
        public bool AddNewDeviceToBD(ref Device device)
        {
            bool result = !LookForSameDeviceInBD(device);
            if (result)
            {
                SaveNewDevice(ref device, "OnlyVersion");
            }
            return result;
        }

        public void ReplaceOldDeviceInBD(ref Device device)
        {
            AlterOldDevice(device);
            SaveNewDevice(ref device, "LastVersion");
        }

        public int SaveNewEmploye(Employe newEmploye)
        {
            string sqlCommand = "INSERT INTO tbl_Employe " +
                "(NameEmploye, RoleID, Email)" +
                "VALUES ('" +
                newEmploye.Name + "', '" +
                newEmploye.EmployeRole.ID + "', '" +
                newEmploye.Email + "')";

            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            commandToExecute.ExecuteNonQuery();
            int idEmployeAdded = GetLastIDInserted(connection);
            connection.Close();
            return idEmployeAdded;
        }
        public int SaveNewEmploye(Employe newEmploye, SQLiteConnection secondConnection)
        {
            string sqlCommand = "INSERT INTO tbl_Employe " +
                "(NameEmploye, RoleID, Email)" +
                "VALUES ('" +
                newEmploye.Name + "', '" +
                newEmploye.EmployeRole.ID + "', '" +
                newEmploye.Email + "')";

            secondConnection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);
            commandToExecute.ExecuteNonQuery();
            int idEmployeAdded = GetLastIDInserted(secondConnection);
            secondConnection.Close();
            return idEmployeAdded;
        }
        #endregion



        #region Search

        // Le code ici présent se trouve à ne pas fonctionner pour les Box, Container et .

        private string TakeOffTheANDInString(string stringToWorkWith)
        {
            if (stringToWorkWith.Substring(Math.Max(0, stringToWorkWith.Length - 3)) == "AND")
            {
                stringToWorkWith = stringToWorkWith.Substring(0, stringToWorkWith.Length - 3);
            }
            return stringToWorkWith;
        }

        private string GetDeviceStringSQLConditionForFlag(bool flag)
        {
            string onReturn = "";
            if (flag == false)
            {
                onReturn += "Flag IN ('LastVersion','OnlyVersion')";
            }
            return onReturn;
        }
        private string GetDeviceStringSQLConditionForBoxContainerDevice(int box, int container, int device)
        {
            string onReturn = "(";
            if (box != -1)
            {
                onReturn += " BoxNum = '" + box + "' AND";
            }
            if (container != -1)
            {
                onReturn += " ContainerNum = '" + container + "' AND";
            }
            if (device != -1)
            {
                onReturn += " DeviceNum = '" + device + "'";
            }
            onReturn = TakeOffTheANDInString(onReturn);
            if (onReturn == "(")
            {
                onReturn = "";
            }
            else
            {
                onReturn += ") AND ";
            }
            return onReturn;
        }

        private string GetDeviceStringSQLConditionForEmploye(Employe emplye)
        {
            string onReturn = "(";
            if (emplye != null)
            {
                onReturn += " EmployeOperatorID = '" + emplye.ID + "' OR ";
                onReturn += " EmployeVerificatorID = '" + emplye.ID + "' ";
            }
            if (onReturn == "(")
            {
                onReturn = "";
            }
            else
            {
                onReturn += ") AND ";
            }
            return onReturn;
        }

        private string GetDeviceStringSQLConditionForDeviceType(DeviceType deviceType)
        {
            string onReturn = "(";
            if (deviceType != null)
            {
                onReturn += " DeviceTypeID = '" + deviceType + "'";
            }
            if (onReturn == "(")
            {
                onReturn = "";
            }
            else
            {
                onReturn += ") AND ";
            }
            return onReturn;
        }

        private string GetDeviceStringSQLCondition(SearchOption condition)
        {
            string onReturn = "WHERE ";

            onReturn += GetDeviceStringSQLConditionForBoxContainerDevice(condition.BoxNum, condition.ContainerNum, condition.DeviceNum);

            onReturn += GetDeviceStringSQLConditionForEmploye(condition.EmployeSearched);

           
            onReturn += GetDeviceStringSQLConditionForFlag(condition.Flag);
            if (onReturn == "WHERE ")
            {
                onReturn = "";
            }
            return TakeOffTheANDInString(onReturn);
        }

        private string GetFileStringSQLCondition(SearchOption condition)
        {
            string onReturn = "";
            if (condition.KeyWord != "")
            {
                onReturn += " AND Path LIKE '%" + condition.KeyWord + "%' ";
            }
            if (condition.DateTimeLastWritten[0] != -1)
            {
                onReturn += " AND Year = '" + condition.DateTimeLastWritten[0] + "' ";
            }
            if (condition.DateTimeLastWritten[1] != -1)
            {
                onReturn += " AND Month = '" + condition.DateTimeLastWritten[1] + "' ";
            }
            if (condition.DateTimeLastWritten[2] != -1)
            {
                onReturn += " AND Day = '" + condition.DateTimeLastWritten[2] + "' ";
            }
            return onReturn;
        }



        public List<FileFromBD> RealSearchInBD(SearchOption condition)
        {
            string sqlCommand = "SELECT * FROM tbl_Device " + GetDeviceStringSQLCondition(condition);
            string sqlCommandCaseSensitive = "PRAGMA case_sensitive_like=OFF;";

            connection.Open();
            SQLiteCommand commandToExecuteCaseSensitive = new SQLiteCommand(sqlCommandCaseSensitive, connection);
            commandToExecuteCaseSensitive.ExecuteNonQuery();

            SQLiteCommand commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader deviceReader = commandToExecute.ExecuteReader();


            List<FileFromBD> listToReturn = GetAllFilesFromDeviceReader(deviceReader, condition);
            connection.Close();

            return listToReturn;
        }

        private List<FileFromBD> GetAllFilesFromDeviceReader(SQLiteDataReader deviceReader, SearchOption condition)
        {
            List<FileFromBD> listToReturn = new List<FileFromBD>();

            while (deviceReader.Read())
            {
                listToReturn = CombineTwoList<FileFromBD>(GetAllFilesWithConditionAndDeviceID(Convert.ToInt32(deviceReader["DeviceID"]), condition), listToReturn);
            }
            return listToReturn;
        }

        private List<FileFromBD> GetAllFilesWithConditionAndDeviceID(int deviceID, SearchOption condition)
        {
            List<FileFromBD> listToReturn = new List<FileFromBD>();
            string sqlCommand = "SELECT * FROM tbl_File  WHERE  DeviceID = '" + deviceID + "' " + GetFileStringSQLCondition(condition);

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader fileReader = commandToExecute.ExecuteReader();
            listToReturn = GetAllFilesReader(fileReader);


            return listToReturn;
        }

        private List<FileFromBD> GetAllFilesReader(SQLiteDataReader fileReader)
        {
            List<FileFromBD> listToReturn = new List<FileFromBD>();

            while (fileReader.Read())
            {
                listToReturn.Add(CreateAFileFromReader(fileReader));
            }

            return listToReturn;
        }

        private FileFromBD CreateAFileFromReader(SQLiteDataReader readerFile)
        {
            FileFromBD currentFile = new FileFromBD();
            currentFile.ID = Convert.ToInt32(readerFile["FileID"]);
            currentFile.DeviceWhereIsTheFile = GetDeviceWithID(Convert.ToInt32(readerFile["DeviceID"]));
            currentFile.Path = readerFile["Path"].ToString();
            int Year = Convert.ToInt32(readerFile["Year"]);
            int Month = Convert.ToInt32(readerFile["Month"]);
            int Day = Convert.ToInt32(readerFile["Day"]);
            currentFile.DateTimeLastWritten = new DateTime(Year, Month, Day);
            return currentFile;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        public List<FileFromBD> SearchInBD(SearchOption condition)
        {
            string sqlCommand = "SELECT * FROM tbl_File";
            connection.Open();

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader readerFile = commandToExecute.ExecuteReader();
            List<FileFromBD> listToReturn = GetAllFilesFromReader(readerFile, condition);
            connection.Close();
            
            return listToReturn;
        }

        private List<FileFromBD> GetAllFilesFromReader(SQLiteDataReader readerFile, SearchOption condition)
        {
            List<FileFromBD> allFilesFromBD = new List<FileFromBD>();

            Device currentDevice;
            bool lastDeviceOK = false;
            Device lastDeviceUsed = new Device();

            while (readerFile.Read())
            {
                currentDevice = GetDeviceWithID(Convert.ToInt32(readerFile["DeviceID"]));
                if (lastDeviceUsed != currentDevice)
                {

                    if (CanUseTheDeviceInTheSearch(currentDevice, condition))
                    {
                        lastDeviceOK = true;
                        TestTheFileToAddToTheListThenAddIt(ref allFilesFromBD, readerFile, lastDeviceUsed, condition);
                    }
                    else
                    {
                        lastDeviceOK = false;
                    }
                    lastDeviceUsed = currentDevice;
                }
                else
                {
                    if (lastDeviceOK)
                    {
                        TestTheFileToAddToTheListThenAddIt(ref allFilesFromBD, readerFile, lastDeviceUsed, condition);
                    }
                }
            }
            return allFilesFromBD;
        }

        private List<FileFromBD> TestTheFileToAddToTheListThenAddIt(ref List<FileFromBD> allFilesFromBD, SQLiteDataReader readerFile, Device currentDevice, SearchOption condition)
        {
            FileFromBD currentFile = CreateAFileFromReader(readerFile, currentDevice);
            if (CanUseTheFile(currentFile, condition))
            {
                allFilesFromBD.Add(currentFile);
            }


            return allFilesFromBD;
        }


        private FileFromBD CreateAFileFromReader(SQLiteDataReader readerFile, Device currentDevice)
        {
            FileFromBD currentFile = new FileFromBD();
            currentFile.ID = Convert.ToInt32(readerFile["FileID"]);
            currentFile.DeviceWhereIsTheFile = currentDevice;
            currentFile.Path = readerFile["Path"].ToString();
            int Year = Convert.ToInt32(readerFile["Year"]);
            int Month = Convert.ToInt32(readerFile["Month"]);
            int Day = Convert.ToInt32(readerFile["Day"]);
            currentFile.DateTimeLastWritten = new DateTime(Year, Month, Day);
            return currentFile;
        }


        #region DeviceCondition

        private bool CanUseTheDeviceInTheSearch(Device device, SearchOption condition)
        {
            bool allowed = false;
            if (FlagOK(condition.Flag, device.Flag))
            {
                if (BoxContainerDeviceNumberOK(device, condition))
                {
                    if (condition.EmployeSearched == null)
                    {
                        allowed = true;
                    }
                    else if (NumbersOK(device.EmployeOperator.ID, condition.EmployeSearched.ID) ||
                        NumbersOK(device.EmployeVerificator.ID, condition.EmployeSearched.ID))
                    {
                        allowed = true;
                    }
                }
            }
            return allowed;
        }


        private bool BoxContainerDeviceNumberOK(Device device, SearchOption condition)
        {
            bool ok = false;
            if (NumbersOK(condition.BoxNum, device.BoxNum))
            {
                if (NumbersOK(condition.ContainerNum, device.ContainerNum))
                {
                    if (NumbersOK(condition.DeviceNum, device.DeviceNum))
                    {
                        ok = true;
                    }
                }
            }
            return ok;
        }

        private bool FlagOK(bool conditionFlag, DeviceFlag deviceFlag)
        {
            bool ok = true;

            if (conditionFlag == false)
            {
                if (deviceFlag == DeviceFlag.OlderVersion || deviceFlag == DeviceFlag.Unknown)
                {
                    ok = false;
                }
            }

            return ok;
        }

        #endregion



        #region FileCondition

        private bool CanUseTheFile(FileFromBD file, SearchOption condition)
        {
            bool allowed = false;
            if (LastTimeWrittenOK(file.DateTimeLastWritten, condition.DateTimeLastWritten))
            {
                if (LookingForKeyWordInThisFile(file.Path, condition.KeyWord.Replace("`", "'")))
                {
                    allowed = true;
                }
            }
            return allowed;
        }

        private bool LastTimeWrittenOK(DateTime file,  int[] condition)
        {
            bool ok = false;
            if (condition[0] == -1 && condition[1] == -1 && condition[2] == -1)
            {
                ok = true;
            }
            else if (NumbersOK(condition[0], file.Year) || condition[0] == -1)
            {
                if (NumbersOK(condition[1], file.Month)|| condition[1] == -1)
                {
                    if (NumbersOK(condition[2], file.Day) || condition[2] == -1)
                    {
                        ok = true;
                    }
                }
            }
            return ok;
        }

        private bool LookingForKeyWordInThisFile(string filePath, string keyword)
        {
            bool ok = false;
            if (filePath.ToUpper().Contains(keyword))
            {
                ok = true;
            }
            return ok;
        }

        #endregion

        public Device GetDeviceWithID(int id)
        {
            string sqlCommand = "SELECT * FROM tbl_Device WHERE DeviceID = " + id;

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            SQLiteDataReader readerDevice = commandToExecute.ExecuteReader();
            readerDevice.Read();
            Device deviceToReturn = GetDeviceFromSingleLineInADataReader(readerDevice);
            return deviceToReturn;
        }

        private Device GetDeviceFromSingleLineInADataReader(SQLiteDataReader readerDevice, SQLiteConnection secondConnection)
        {
            Device deviceToReturn = new Device();

            deviceToReturn.ID = Convert.ToInt32(readerDevice["DeviceID"]);
            deviceToReturn.BoxNum = Convert.ToInt32(readerDevice["BoxNum"]);
            deviceToReturn.ContainerNum = Convert.ToInt32(readerDevice["ContainerNum"]);
            deviceToReturn.DeviceNum = Convert.ToInt32(readerDevice["DeviceNum"]);
            deviceToReturn.FileName = readerDevice["FileName"].ToString();
            deviceToReturn.Flag = GetDeviceFlagFromString(readerDevice["Flag"].ToString());
            deviceToReturn.EmployeOperator = GetEmployeWithID(Convert.ToInt32(readerDevice["EmployeOperatorID"]), secondConnection);
            deviceToReturn.EmployeVerificator = GetEmployeWithID(Convert.ToInt32(readerDevice["EmployeVerificatorID"]), secondConnection);
            deviceToReturn.DeviceType = GetDeviceTypeWithID(Convert.ToInt32(readerDevice["DeviceTypeID"]), secondConnection);
            deviceToReturn.DeviceRecuperationFileType = GetDeviceRecuperationFileTypeFromBDWithID(Convert.ToInt32(readerDevice["DeviceRecuperationFileTypeID"]), secondConnection);

            return deviceToReturn;
        }
        private Device GetDeviceFromSingleLineInADataReader(SQLiteDataReader readerDevice)
        {
            Device deviceToReturn = new Device();

            deviceToReturn.ID = Convert.ToInt32(readerDevice["DeviceID"]);
            deviceToReturn.BoxNum = Convert.ToInt32(readerDevice["BoxNum"]);
            deviceToReturn.ContainerNum = Convert.ToInt32(readerDevice["ContainerNum"]);
            deviceToReturn.DeviceNum = Convert.ToInt32(readerDevice["DeviceNum"]);
            deviceToReturn.FileName = readerDevice["FileName"].ToString();
            deviceToReturn.Flag = GetDeviceFlagFromString(readerDevice["Flag"].ToString());
            deviceToReturn.EmployeOperator = GetEmployeWithID(Convert.ToInt32(readerDevice["EmployeOperatorID"]));
            deviceToReturn.EmployeVerificator = GetEmployeWithID(Convert.ToInt32(readerDevice["EmployeVerificatorID"]));
            deviceToReturn.DeviceType = GetDeviceTypeWithID(Convert.ToInt32(readerDevice["DeviceTypeID"]));
            deviceToReturn.DeviceRecuperationFileType = GetDeviceRecuperationFileTypeFromBDWithID(Convert.ToInt32(readerDevice["DeviceRecuperationFileTypeID"]));

            return deviceToReturn;
        }

        private bool NumbersOK(int conditionNum, int realNum)
        {
            bool ok = true;
            if (conditionNum == -1)
            {
                ok = true;
            }
            else if (conditionNum != realNum)
            {
                ok = false;
            }
            return ok;
        }



        #endregion


        #region MergeOfThe2BDs

        private List<int> GetListOfIDForListOfEmploye(List<Employe> listOfEmployes)
        {
            List<int> listToReturn = new List<int>();
            foreach (Employe employe in listOfEmployes)
            {
                listToReturn.Add(employe.ID);
            }
            return listToReturn;
        }

        private List<Employe> GetDifferentEmployeFromSecondBDToFirstBD(List<Employe> firstListOfEmployes, List<Employe> secondListOfEmployes)
        {
            List<Employe> EmployeToAddToBD= new List<Employe>();
            int imax = secondListOfEmployes.Count;
            for (int i = 0; i < secondListOfEmployes.Count; i++)
            {
                if (i >= firstListOfEmployes.Count || firstListOfEmployes[i] != secondListOfEmployes[i])
                {
                    EmployeToAddToBD.Add(secondListOfEmployes[i]);
                }
            }
            return EmployeToAddToBD;
        }

        private List<int> AddEmployeToFirstBD(List<Employe> employeToAddToFirstBD, SQLiteConnection firstBD)
        {
            List<int> idEmployeAdded = new List<int>();
            foreach (Employe employe in employeToAddToFirstBD)
            {
                idEmployeAdded.Add(SaveNewEmploye(employe, firstBD));
            }
            return idEmployeAdded;
        }

        private void AddEmployeToSecondBD(List<Employe> listsCombined, List<Employe> employeToAddToSecondBD, SQLiteConnection bd) 
        {
            foreach (Employe employe in employeToAddToSecondBD)
            {
                DeletEmployeFromBD(employe.ID, bd);
            }
            foreach (Employe employe in listsCombined)
            {
                bd.Close();
                SaveNewEmploye(employe, bd);
            }

        }

        private void DeletEmployeFromBD(int employeID, SQLiteConnection bd)
        {
            string sqlCommand = "DELETE FROM tbl_Employe WHERE EmployeID = '" + employeID+"'";


            var commandToExecute = new SQLiteCommand(sqlCommand, bd);
            commandToExecute.ExecuteNonQuery();
        }

        private void ChangeEmployeIDInsideDevice(int oldIDEmploye, int newIDEmploye, SQLiteConnection bd)
        {
            string sqlCommand1 = "UPDATE tbl_Device SET EmployeOperatorID = '"+ newIDEmploye + "' WHERE EmployeOperatorID = '" + oldIDEmploye + "'";
            string sqlCommand2 = "UPDATE tbl_Device SET EmployeVerificatorID = '" + newIDEmploye + "' WHERE EmployeVerificatorID = '" + oldIDEmploye + "'";


            var commandToExecute = new SQLiteCommand(sqlCommand1, bd);
            commandToExecute.ExecuteNonQuery();
            commandToExecute = new SQLiteCommand(sqlCommand2, bd);
            commandToExecute.ExecuteNonQuery();
        }


        private void ChangeEmployeIDForSecondBD(List<Employe> employeToAddToFirstBD, List<int> IDEnteredInsideFirstBD, SQLiteConnection secondBD)
        {
            for (int i = 0; i < employeToAddToFirstBD.Count-1; i++)
            {
                ChangeEmployeIDInsideDevice(employeToAddToFirstBD[i].ID, IDEnteredInsideFirstBD[i], secondBD);
            }
        }

        private void AddMissingEmployeToEachBDs(List<Employe> listForFirstBD, List<Employe> listForSecondBD, SQLiteConnection firstBD, SQLiteConnection secondBD)
        {
            List<Employe> employeToAddToSecondBD = 
                GetDifferentEmployeFromSecondBDToFirstBD(listForSecondBD, listForFirstBD);
            List<Employe> employeToAddToFirstBD =
                GetDifferentEmployeFromSecondBDToFirstBD(listForFirstBD, listForSecondBD);

            List<int> IDEnteredInsideFirstBD = AddEmployeToFirstBD(employeToAddToFirstBD, firstBD);
            List<Employe> listsCombined = CombineTwoList<Employe>(employeToAddToSecondBD, employeToAddToFirstBD);
            secondBD.Open();
            ChangeEmployeIDForSecondBD(employeToAddToFirstBD, IDEnteredInsideFirstBD, secondBD);
            AddEmployeToSecondBD(listsCombined, employeToAddToFirstBD, secondBD);
            secondBD.Close();
        }

        public bool CanMergeTheSecondBDs(string pathFirstBD, string pathSecondBD)
        {
            SQLiteConnection firstBD = new SQLiteConnection(pathFirstBD);
            SQLiteConnection secondBD = new SQLiteConnection(pathSecondBD);

            bool AlwaysTheSameEmployesFound = true;
            List<Employe> listForFirstBD = GetAllEmployes(firstBD);
            List<Employe> listForSecondBD = GetAllEmployes(secondBD);
            for (int i = 0; i < listForSecondBD.Count - 1; i++)
            {
                if (listForSecondBD[i] != listForFirstBD[i])
                {
                    AlwaysTheSameEmployesFound = false;
                }
            }
            AddMissingEmployeToEachBDs(listForFirstBD, listForSecondBD, firstBD, secondBD);
            return AlwaysTheSameEmployesFound;
        }



        public void MergeTheBDs(string pathFirstBD, string pathSecondBD)
        {
            try
            {
                connection.Close();
            }
            catch (Exception)
            {
            }
            connection = new SQLiteConnection(pathFirstBD);
            SQLiteConnection secondConnection = new SQLiteConnection(pathSecondBD);
            GetAllDevicesFromSecondBDThenAddItToTheFirstBD(secondConnection);
        }

        private void GetAllDevicesFromSecondBDThenAddItToTheFirstBD(SQLiteConnection secondConnection)
        {
            secondConnection.Open();

            string sqlCommand = "SELECT * FROM tbl_Device";


            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);
            SQLiteDataReader readerDevice = commandToExecute.ExecuteReader();
            AddAllDevicesAndThenTheFilesToTheOtherBD(secondConnection, readerDevice);

            secondConnection.Close();
        }

        private bool CanSaveTheFileFromTheSecondBD(ref Device currentDeviceFromOtherBD)
        {
            bool canSave = true;
            if (currentDeviceFromOtherBD.Flag == DeviceFlag.LastVersion || currentDeviceFromOtherBD.Flag == DeviceFlag.OnlyVersion)
            {
                if (LookForSameDeviceInBD(currentDeviceFromOtherBD) )
                {
                    canSave = false;
                }
            }
            else
            {
                if (LookForSameDeviceInBD(currentDeviceFromOtherBD))
                {
                    canSave = false;
                    currentDeviceFromOtherBD.Flag = DeviceFlag.OlderVersionFromAnOtherBD;
                }
            }
            return canSave;
        }


        private void AddAllDevicesAndThenTheFilesToTheOtherBD(SQLiteConnection secondConnection, SQLiteDataReader readerDevice)
        {
            while (readerDevice.Read())
            {
                Device currentDeviceFromOtherBD = GetDeviceFromSingleLineInADataReader(readerDevice, secondConnection);
                if (CanSaveTheFileFromTheSecondBD(ref currentDeviceFromOtherBD))
                {
                    SaveNewDevice(ref currentDeviceFromOtherBD);
                    GetAllFilesFromSecondBDThenAddItToTheFirstOne(secondConnection, currentDeviceFromOtherBD.ID);
                }
            }
        }

        private void GetAllFilesFromSecondBDThenAddItToTheFirstOne(SQLiteConnection secondConnection, int DeviceID)
        {
            connection.Open();
            string sqlCommand = "SELECT * FROM tbl_File Where DeviceID=" + DeviceID;

            using var commandToExecute = new SQLiteCommand(sqlCommand, secondConnection);
            SQLiteDataReader readerFile = commandToExecute.ExecuteReader();
            AddAllFilesToTheOtherBD(readerFile);

            connection.Close();
        }

        private void AddAllFilesToTheOtherBD(SQLiteDataReader readerFile)
        {
            while (readerFile.Read())
            {
                FileFromBD currentFileFromOtherBD = CreateAFileFromReader(readerFile, GetDeviceWithID(Convert.ToInt32(readerFile["DeviceID"])));
                SaveAFile(currentFileFromOtherBD);
            }
        }

        private void SaveAFile(FileFromBD fileInfo)
        {
            string sqlCommand = "INSERT INTO tbl_File " +
                "(DeviceID, Path, Year, Month, Day)" +
                "VALUES ('" +
                fileInfo.DeviceWhereIsTheFile.ID + "', '" +
                fileInfo.Path.Substring(2, fileInfo.Path.Length - 2).Replace("'", "`") + "', '" +
                fileInfo.DateTimeLastWritten.Year + "', '" +
                fileInfo.DateTimeLastWritten.Month + "', '" +
                fileInfo.DateTimeLastWritten.Day +
                "')";

            using var commandToExecute = new SQLiteCommand(sqlCommand, connection);
            commandToExecute.ExecuteNonQuery();
        }
        #endregion

    }

}
