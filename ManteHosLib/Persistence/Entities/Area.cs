using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public virtual Master Master { get; set; }
    }
}
