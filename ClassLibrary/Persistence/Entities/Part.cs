using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Part
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int CurrentQuantity { get; set; }
        public int MinimumQuantity { get; set; }
        public string UnitOfMeasure { get; set; }

        // Relations
        public virtual ICollection<UsedPart> UsedParts { get; set; }
    }
}
