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
    public partial class Operator:Employee
    {
        

        public Shift Shift { get; set; }

        // 🔹 Relación N:M con WorkOrder
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        
    }
}
