using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    public class Employe
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public Role EmployeRole { set; get; }
        public int ID { set; get; }
        public Employe(int inID, string inName, string inEmail, Role role)
        {
            Name = inName;
            ID = inID;
            EmployeRole = role;
        }
        public Employe()
        {
            Name = "";
            ID = 0;
            EmployeRole = null;
        }

        static public bool operator ==(Employe employe1, Employe employe2)
        {
            bool finalValue = false;

            if (object.ReferenceEquals(employe1, null))
            {
                finalValue = object.ReferenceEquals(employe2, null);
            }
            if (object.ReferenceEquals(employe2, null))
            {
                finalValue = object.ReferenceEquals(employe1, null);
            }
            else if ((employe1.Email == employe2.Email && employe1.ID == employe2.ID && employe1.Name == employe2.Name && employe1.EmployeRole.Name == employe2.EmployeRole.Name))
            {
                finalValue = true;
            }
            return finalValue;
        }

        static public bool operator !=(Employe employe1, Employe employe2)
        {
            return !(employe1 == employe2);
        }


    }
}
