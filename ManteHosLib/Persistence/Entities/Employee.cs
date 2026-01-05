using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Employee
    {
        
        public String FullName { get; set; }
        
        public string Id { get; set; }
        public String Password { get; set; }
        // Relations
        public virtual ICollection<Incident> ReportedIncidents { get; set; }
    }
}
