using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relations
        public virtual ICollection<Incident> Incidents { get; set; }
        public virtual Master Master { get; set; }
    }
}
