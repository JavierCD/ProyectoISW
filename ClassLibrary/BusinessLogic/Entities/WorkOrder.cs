using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
        UsedParts = new List<UsedPart>();
        }
    public WorkOrder(DateTime StartDay, DateTime EndDay, String RepairReport)
        {
            this.RepairReport = RepairReport;
            this.StartDate = StartDay;
            EndDate = null;
        }
    }
}