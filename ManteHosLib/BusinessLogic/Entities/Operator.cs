using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Operator:Employee
    {
        public Operator(): base()
        {
            WorkOrders = new List<WorkOrder>();

        }

        public Operator(string FullName, string Id, string Password, Shift shift) : base()
        {
            WorkOrders = new List<WorkOrder>();
            this.Id = Id;
            this.FullName = FullName;
            this.Password = Password;
            this.Shift = shift;
        }
    }
}

