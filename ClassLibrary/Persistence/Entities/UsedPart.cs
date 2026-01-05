using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class UsedPart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool Needed { get; set; }

        // Relation
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual Part Part { get; set; }
    }
}
