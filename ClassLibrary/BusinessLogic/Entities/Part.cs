using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Part
    {
        public Part() {
            UsedParts = new List<UsedPart>();
        }
        public Part(String Code, String Description, float UnitPrice, int CurrentQuantity, int MinimunQuantity, String UnitOfMeasure) : this()
        {
            this.Code = Code;
            this.Description = Description;
            this.UnitPrice = UnitPrice;
            this.CurrentQuantity = CurrentQuantity;
            this.MinimumQuantity = MinimunQuantity;
            this.UnitOfMeasure = UnitOfMeasure;
        }
    }
}
