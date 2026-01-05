using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Area
    {
        public Area()
        {
            this.Incidents = new List<Incident>();
        }
        public Area(String Name, Master master) : this()
        {
            this.Name = Name;
            this.Master = master;
        }

        public List<Incident> notCompletedIncidents()
        {
            List<Incident> incidents = this.Incidents.Where(i => i.Status != Status.Completed).ToList();
            return incidents;
        }
    }
}
