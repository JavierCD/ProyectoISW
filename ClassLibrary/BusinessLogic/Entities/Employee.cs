using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            this.ReportedIncidents = new List<Incident>();
        }
        public Employee(String FullName, String Id, String Password):this() 
        {
            this.FullName = FullName;
            this.Id = Id;
            this.Pasword = Password;
        }
    }
}
