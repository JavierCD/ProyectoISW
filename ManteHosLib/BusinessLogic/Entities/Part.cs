using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Part
    {
        public Part()
        {
            UsedParts = new List<UsedPart>();
        }
        public Part(String Code, int CurrentQuantity , String Description, int MinimunQuantity, String UnitOfMeasure, float UnitPrice) : this()
        {
            this.Code = Code;
            this.CurrentQuantity = CurrentQuantity;
            this.Description = Description;
            this.MinimunQuantity = MinimunQuantity;
            this.UnitOfMeasure = UnitOfMeasure;
            this.UnitPrice = UnitPrice;
            
            
        }
    }
}
