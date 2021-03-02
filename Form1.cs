using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivage
{
    public partial class Myform : Form
    {

        ArchiveControler archiveControler = new ArchiveControler();

        public Myform()
        {
            InitializeComponent();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            archiveControler.SendAnError += ShowMessage;
        }

        private void ShowMessage(object sender, SendErrorToUserEventArgs e)
        {
            MessageBox.Show(e.Error);
        }

        private void btnVerification_Click(object sender, EventArgs e)
        {
            if (archiveControler.TryLetter(txtLettre.Text.ToUpper()))
            {
                archiveControler.RemakeListFilePath(txtLettre.Text.ToUpper() + ":\\");
                DisplayFilePaths();
            }
            else
            {
                MessageBox.Show("Lettre inconnu");
            }
            

        }

        private void DisplayFilePaths()
        {

            List<FileInfo> informationForEachFiles = archiveControler.GetInformationForEachFiles();
            lstArchivage.Items.Clear();
            
            for (int i = 0; i < informationForEachFiles.Count; i++)
            {
               lstArchivage.Items.Add(informationForEachFiles[i].FullName );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            archiveControler.CreateDevice(Convert.ToInt32(numBox.Value), Convert.ToInt32(numContainer.Value), Convert.ToInt32(numDevice.Value), txtFileName.Text, comboTypeFile.Text, combotxtStorageContainer.Text, comboBoxFirst.Text, comboBoxSecond.Text);
            
            // Si le "Device existe déjà il faut demandé à l'utilisateur s'il veut le remplacer.
            if (!(archiveControler.Save())) 
            {
                DialogResult result = MessageBox.Show("L'enregistrement de l'appareil numéros " + numBox.Value + "." + numContainer.Value + "." + numDevice.Value +
                    " existe déjà. Voulez-vous le remplacer?", "Erreur dans l'enregistrement!", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    archiveControler.ReplaceDeviceSaved();
                }
            }
            else
            {
                MessageBox.Show("Enregistrement terminé!");
            }
        }


        private void HelpUserToGoFasterAfterSave()
        {
            txtLettre.Text = "";
            numDevice.Value++;
        }

        private void OkMessage(bool working)
        {
            if (working)
            {
                MessageBox.Show("It just works!");
            }
            else
            {
                MessageBox.Show("It does not really work...");
            }
        }

        private void LoadEmployes()
        {
            List<Employe> employes = archiveControler.GetAllEmployes();
            foreach (Employe employe in employes)
            {
                comboBoxFirst.Items.Add(employe.Name);
                comboBoxSecond.Items.Add(employe.Name);
                comboEmployeSearch.Items.Add(employe.Name);
            }
        }

        private void LoadDeviceType()
        {
            List<DeviceType> deviceTypes = archiveControler.GetAllDeviceType();
            foreach (DeviceType deviceType in deviceTypes)
            {
                combotxtStorageContainer.Items.Add(deviceType.Name);
                comboDeviceTypeSearch.Items.Add(deviceType.Name);
            }
        }

        private void LoadDeviceRecuperationFileType()
        {
            List<DeviceRecuperationFileType> deviceRecuperationFileTypes = archiveControler.GetAllDeviceRecuperationFileType();
            foreach (DeviceRecuperationFileType deviceRecuperationFileType in deviceRecuperationFileTypes)
            {
                comboTypeFile.Items.Add(deviceRecuperationFileType.Name);
            }
        }

        private void Myform_Load(object sender, EventArgs e)
        {
            LoadEmployes();
            LoadDeviceType();
            LoadDeviceRecuperationFileType();

            LoadMonths();

            LoadTestValue();
        }

        private void LoadMonths()
        {
            comboMonths.Items.Add("Janvier");
            comboMonths.Items.Add("Février");
            comboMonths.Items.Add("Mars");
            comboMonths.Items.Add("Avril");
            comboMonths.Items.Add("Mai");
            comboMonths.Items.Add("Juin");
            comboMonths.Items.Add("Juillet");
            comboMonths.Items.Add("Août");
            comboMonths.Items.Add("Septembre");
            comboMonths.Items.Add("Octobre");
            comboMonths.Items.Add("Novembre");
            comboMonths.Items.Add("Décembre");
        }

        private void LoadTestValue()
        {
            numBox.Value = 1;
            numContainer.Value = 2;
            numDevice.Value = 3;
            txtFileName.Text = "FileNameTest";
            combotxtStorageContainer.Text = "Disquette 3 pouces 1/2";
            comboTypeFile.Text = "aff";
            comboBoxFirst.Text = "Étienne Périnet";
            comboBoxSecond.Text = "Simon Noël";
        }

        

        private int ConvertToIntForTextBox(string value)
        {
            int valueToReturn = -1;
            if (value != "")
            {
                valueToReturn = Convert.ToInt32(value);
            }
            return valueToReturn;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int month = comboMonths.SelectedIndex;
            if (month > -1)
            {
                month ++;
            }

            List<FileFromBD>  searchedResult = archiveControler.Search(txtKeyword.Text, comboEmployeSearch.Text, comboDeviceTypeSearch.Text,
                 Convert.ToInt32(numBoxSearch.Value), Convert.ToInt32(numContainerSearch.Value), Convert.ToInt32(numDeviceSearch.Value),
                 ConvertToIntForTextBox(txtYear.Text), month, ConvertToIntForTextBox(txtDay.Text),
                 checkFlag.Checked);

            if (searchedResult.Count != 0)
            {
                SearchResultForm searchResultForm = new SearchResultForm(searchedResult);
                searchResultForm.Show();
            }
            else
            {
                MessageBox.Show("Aucun résultat n'a été trouvé.");
            }
        }

        private void btnEmploye_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Si vous utilisez une base de données secondaire, sachez que l'application" +
                " ne pourra pas supporter la fusion de cette base de données à la base de données principale si vous effectuez cette manoeuvre" +
                "\n\nLa fusion de votre base de données risque très fortement de ne plus être possible si celle-ci est défini comme étant base de " +
                "données secondaire. Voulez-vous vraiment continuer?", "AVERTISSEMENT!", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                EmployeForm employeForm = new EmployeForm();
                employeForm.Show();
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            MergeBD mergeBDForm = new MergeBD();
            mergeBDForm.Show();
        }
    }
}
