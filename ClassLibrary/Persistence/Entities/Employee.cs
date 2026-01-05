using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Employee
    {public String FullName { get; set; }
        public String Id { get; set; }
       public String Pasword { get; set; }
        // Relations
        public virtual ICollection<Incident> ReportedIncidents { get; set; }
    }
}
