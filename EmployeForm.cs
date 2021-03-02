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
    public partial class EmployeForm : Form
    {
        EmployeControler employeControler = new EmployeControler();
        public EmployeForm()
        {
            InitializeComponent();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            employeControler.SendAnError += ShowMessage;
        }

        private void ShowMessage(object sender, SendErrorToUserEventArgs e)
        {
            MessageBox.Show(e.Error);
        }


        private void EmployeForm_Load(object sender, EventArgs e)
        {
            ReloadEmployeList();
            ReloadRoleCombo();
        }

        private void ReloadEmployeList()
        {
            lstAllEmploye.Items.Clear();
            List<Employe> employes = employeControler.GetAllEmployes();
            foreach (Employe employe in employes)
            {
                AddAnEmployeInTheList(employe);
            }
        }
        
        private void ReloadRoleCombo()
        {

            List<Role> roles = employeControler.GetAllRoles();
            foreach (Role role in roles)
            {
                AddRoleInComboBox(role);
            }
        }

        private void AddAnEmployeInTheList(Employe employe)
        {
            lstAllEmploye.Items.Add("Nom : " + employe.Name);
            lstAllEmploye.Items.Add("Email : " + employe.Email);
            lstAllEmploye.Items.Add("Role : " + employe.EmployeRole.Name);
            lstAllEmploye.Items.Add("=====================================================");
        }

        private void AddRoleInComboBox(Role role)
        {
            comboRole.Items.Add(role.Name);
        }

        private void btn_AddEmploye_Click(object sender, EventArgs e)
        {
            employeControler.AddNewEmploye(txtNameEmploye.Text, txtEmail.Text, comboRole.Text);
            ReloadEmployeList();
        }

        private void lstAllEmploye_SelectedIndexChanged(object sender, EventArgs e)
        {
            int test = lstAllEmploye.SelectedIndex;
            test++;
        }
    }
}
