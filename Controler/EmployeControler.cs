using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    class EmployeControler : FormControler
    {
        protected List<Role> allRoles = new List<Role>();
        public EmployeControler()
        {
            
        }

        

        public List<Role> GetAllRoles()
        {
            try
            {
                allRoles = sqlControler.GetAllRoles();
                return allRoles;
            }
            catch (Exception)
            {
                SendNoBDDetectedMessage();
                return null;
            }
        }

        public Role FindTheRightRoleWithString(string roleToFind)
        {
            Role roleToReturn = null;
            foreach (Role role in allRoles)
            {
                if (roleToFind == role.Name)
                {
                    roleToReturn = role;
                }
            }
            return roleToReturn;
        }

        private Employe CreateNewEmploye(string inName, string inEmail, string EmployeRole)
        {
            Employe currentEmploye = new Employe();
            currentEmploye.Email = inEmail;
            currentEmploye.Name = inName;
            currentEmploye.EmployeRole = FindTheRightRoleWithString(EmployeRole);

            return currentEmploye;
        }

        public void AddNewEmploye(string inName, string inEmail, string EmployeRole)
        {
            try
            {
                Employe currentEmploye = CreateNewEmploye(inName, inEmail, EmployeRole);
                sqlControler.SaveNewEmploye(currentEmploye);
            }
            catch (Exception)
            {
                SendNoBDDetectedMessage();
            }
        }
    }
}
