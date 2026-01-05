using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class UsedPart
    {
        public UsedPart() { }
        public UsedPart(int Quantity, Boolean Needed, Part part, WorkOrder workOrder)
            { 
            this.Part = part;
            this.WorkOrder = workOrder;
            this.Quantity = Quantity;
            this.Needed = Needed;
        }
    }
}
