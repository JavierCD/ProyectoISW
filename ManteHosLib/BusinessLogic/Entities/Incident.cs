using ManteHos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Incident
    {
        // Constructor vacío
        public Incident()
        {
            // Inicializar WorkOrder y Area como null para seguridad
            WorkOrder = null;
            Area = null;
        }

        
        public Incident(string department, string description, DateTime reportDate, Employee reporter, Priority priority=Priority.Low, Status status = Status.Created)
        {
            Department = department;
            Description = description;
            ReportDate = reportDate;
            Reporter = reporter;
            Priority = priority;
            Status = status;
            RejectionReason = null;
            Area = null;
            WorkOrder = null;
        }

        public void acceptIncident(Priority priority, Area area)
        {                                                                           
            this.Status = Status.Accepted;
            this.Priority = priority;
            this.Area = area;
            
        }

        public void rejectIncident(String reason)
        {
            this.Status = Status.Rejected;
            this.RejectionReason = reason;
        }

        public void AddWorkOrder()
        {
            if (this.WorkOrder == null)
            {
                this.WorkOrder = new WorkOrder();
                this.WorkOrder.StartDate = DateTime.Now.Date;
            }
        }
    }
}


