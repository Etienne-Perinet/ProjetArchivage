using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivage
{
    public partial class SearchResultForm : Form
    {
        private List<FileFromBD> FilesFromBD { get; set; }
        private List<Device> Devices { get; set; }
        private List<Employe> Employes { get; set; }

        public SearchResultForm()
        {
            InitializeComponent();
            SqlControler sqlControler = new SqlControler();
            Employes = sqlControler.GetAllEmployes();
        }

        public SearchResultForm(List<FileFromBD> inFilesFromBD)
        {
            InitializeComponent();

            FilesFromBD = inFilesFromBD;
            Devices = new List<Device>();
        }

        private void ExchangeDevicesPositionInList(int iFirst, int iSecond)
        {
            Device tempo;
            tempo = Devices[iFirst];
            Devices[iFirst] = Devices[iSecond];
            Devices[iSecond] = tempo;
        }

        private void SortDeviceList()
        { 
            for (int i = 0; i < Devices.Count - 1; i++)
            {
                if (Devices[i].BoxNum > Devices[i + 1].BoxNum)
                {
                    ExchangeDevicesPositionInList(i, i + 1);
                }
                else if (Devices[i].BoxNum == Devices[i + 1].BoxNum)
                {
                    if (Devices[i].ContainerNum > Devices[i + 1].ContainerNum)
                    {
                        ExchangeDevicesPositionInList(i, i + 1);
                    }
                    else if (Devices[i].ContainerNum == Devices[i + 1].ContainerNum)
                    {
                        if (Devices[i].DeviceNum > Devices[i + 1].DeviceNum)
                        {
                            ExchangeDevicesPositionInList(i, i + 1);
                        }
                    }
                }
            }
        }


        public void MakeDeviceList()
        {
            Device currentDevice = FilesFromBD[0].DeviceWhereIsTheFile; 
            Devices.Add(currentDevice);
            foreach (FileFromBD file in FilesFromBD)
            {
                if (currentDevice.ID != file.DeviceWhereIsTheFile.ID)
                {
                    currentDevice = file.DeviceWhereIsTheFile;
                    Devices.Add(currentDevice);
                }
            }
            SortDeviceList();
        }

        private void AddAFileIntoListBox(FileFromBD file)
        {
            listBox.Items.Add(" " + file.DateTimeLastWritten.Year + "-" + file.DateTimeLastWritten.Month + "-" + file.DateTimeLastWritten.Day +"        "+ file.Path );
        }

        private string GetDeviceStringFlagFromDeviceFlagEnum(DeviceFlag flag)
        {
            string onReturn = "";
            switch (flag)
            {
                case DeviceFlag.OlderVersion:
                    onReturn = "Vielle version";
                    break;
                case DeviceFlag.OnlyVersion:
                    onReturn = "Seule version";
                    break;
                case DeviceFlag.LastVersion:
                    onReturn = "Dernière version";
                    break;
                case DeviceFlag.Unknown:
                    onReturn = "Aucun";
                    break;
                case DeviceFlag.BestVersionFromAnOtherBD:
                    onReturn = "Meilleur version mais d'une autre BD";
                    break;
                case DeviceFlag.OlderVersionFromAnOtherBD:
                    onReturn = "Vielle version d'une autre BD";
                    break;
                default:
                    onReturn = "Inconnu";
                    break;
            }
            return onReturn;
        }


        private void ShowDeviceInfo(Device currentDevice)
        {
            AddSpaceIntoListBox(2);
            AddSmallSeparationIntoListBox();
            listBox.Items.Add("Numéros de support de stockage  : " + currentDevice.DeviceNum);
            listBox.Items.Add("Numéros complet supposé être sur le support de stockage : " + currentDevice.BoxNum + "." + currentDevice.ContainerNum + "." + currentDevice.DeviceNum);

            listBox.Items.Add("Nom du fichier représentant le support : " + currentDevice.FileName + "." + currentDevice.DeviceRecuperationFileType.Name);
            AddSpaceIntoListBox(1);
            listBox.Items.Add("Tag associé au support : " + GetDeviceStringFlagFromDeviceFlagEnum(currentDevice.Flag));
            
            AddSpaceIntoListBox(1);
            listBox.Items.Add("Employé chargé de la récupération des données : " + currentDevice.EmployeOperator.Name + " : " + currentDevice.EmployeOperator.Email);
            AddSpaceIntoListBox(1);
            listBox.Items.Add("Employé chargé de la vérification des données : " + currentDevice.EmployeVerificator.Name + " : " + currentDevice.EmployeVerificator.Email);
            AddSpaceIntoListBox(2);

            listBox.Items.Add("Date                    Fichier");
            AddReallySmallSeparationIntoListBox();
            AddSpaceIntoListBox(1);
        }

        private void AddAllFilesFromADeviceIntoListBox(Device currentDevice)
        {
            ShowDeviceInfo(currentDevice);
            foreach (FileFromBD file in FilesFromBD)
            {
                if (currentDevice == file.DeviceWhereIsTheFile)
                {
                    AddAFileIntoListBox(file);
                }
            }
        }

        private void IsolateBoxAndContainerInListBoxIfNecessary(ref int currentBoxNumber, int currentContainerNumber, int currentDeviceBoxNum)
        {
            if (currentBoxNumber != currentDeviceBoxNum && currentDeviceBoxNum != 0)
            {
                currentBoxNumber = currentDeviceBoxNum;
                AddBoxToTheListBox(currentDeviceBoxNum);
            }
        }
        private void AddBoxToTheListBox(int currentBoxNumber)
        {
            AddSpaceIntoListBox(2);
            AddBigSeparationIntoListBox();
            AddSpaceIntoListBox(1);
            listBox.Items.Add("Numéros de boîte : " + currentBoxNumber);
            AddSpaceIntoListBox(1);
            AddBigSeparationIntoListBox();
            AddSpaceIntoListBox(1);
        }


        private void IsolateContainerInListBoxIfNecessary(ref int currentContainerNumber, int containerNumberForCurrentDevice)
        {
            if (currentContainerNumber != containerNumberForCurrentDevice && currentContainerNumber != -1)
            {
                currentContainerNumber = containerNumberForCurrentDevice;
                AddContainerToTheListBox(containerNumberForCurrentDevice);
            }
        }

        private void AddContainerToTheListBox(int currentContainerNumber)
        {
            AddSpaceIntoListBox(2);
            AddMediumSeparationIntoListBox();
            listBox.Items.Add("Numéros de contenant : " + currentContainerNumber);
            AddMediumSeparationIntoListBox();
            AddSpaceIntoListBox(1);
        }

        public void SortTheListBoxByBox()
        {
            listBox.Items.Clear();
            int currentBoxNumber = -1;
            int currentContainerNumber = 0;
            MakeDeviceList();

            foreach (Device currentDevice in Devices)
            {
                IsolateBoxAndContainerInListBoxIfNecessary(ref currentBoxNumber, currentDevice.ContainerNum, currentDevice.BoxNum);
                IsolateContainerInListBoxIfNecessary(ref currentContainerNumber, currentDevice.ContainerNum);
                if (currentBoxNumber != -1)
                {
                    AddAllFilesFromADeviceIntoListBox(currentDevice);
                }
            }
        }

        private void AddBigSeparationIntoListBox()
        {
            listBox.Items.Add("==========================================================================================================================================================================================================================");
        }

        private void AddMediumSeparationIntoListBox()
        {
            listBox.Items.Add("***********************************************************************************");
        }
        private void AddSmallSeparationIntoListBox()
        {
            listBox.Items.Add("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
        }
        private void AddReallySmallSeparationIntoListBox()
        {
            listBox.Items.Add("-----------------------------------------------------------------------------------------------------------------------");
        }
        private void AddSpaceIntoListBox(int numberOfSpace)
        {
            for (int i = 0; i < numberOfSpace; i++)
            {
                listBox.Items.Add("");
            }  
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            SortTheListBoxByBox();
        }

    }
}
