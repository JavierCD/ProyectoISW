using System;
using System.Collections.Generic;
using System.Linq;

namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            UsedParts = new List<UsedPart>();
            Operators = new List<Operator>();
        }

        public WorkOrder(DateTime startDate, Incident incident, DateTime? endDate = null, string repairReport = null)
            : this()
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.RepairReport = repairReport;
            this.Incident = incident;
        }

        public void AddOperator(Operator op1)
        {
            if (!Operators.Contains(op1))
                Operators.Add(op1);
        }

        public UsedPart AddUsedPart(int aQuantity, Part aPart)
        {
            UsedPart uP = new UsedPart(aQuantity, aPart);
            UsedParts.Add(uP);
            return uP;
        }

        public void stablishRepairReport(String report)
        {
            this.RepairReport = report;
        }

        public void removeOp(Operator op1)
        {
            Operators.Remove(op1);
        }

        // =====================================================
        // MÉTODOS AÑADIDOS PARA EL CU 7 – Cerrar orden
        // =====================================================

        public bool HasPendingParts()
        {
            return UsedParts.Any(up => up.Needed);
        }

        public float TotalPartsCost()
        {
            float total = 0;
            foreach (var up in UsedParts)
            {
                total += up.Quantity * up.Part.UnitPrice;
            }
            return total;
        }

        public void Close(string report, DateTime closeDate)
        {
            RepairReport = report;
            EndDate = closeDate;
        }

    }
}
