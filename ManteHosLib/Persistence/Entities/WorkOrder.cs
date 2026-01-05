using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string RepairReport { get; set; }

        // Relación con Incident
        [Required]
        public virtual Incident Incident { get; set; }

        // Relaciones con otras entidades
        public virtual ICollection<UsedPart> UsedParts { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }
    }
}
