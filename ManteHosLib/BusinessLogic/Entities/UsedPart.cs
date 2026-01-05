using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class UsedPart
    {
        public UsedPart() { }
        public UsedPart(int quantity, Part part) :this() {
            if (part.CurrentQuantity >= quantity  && part.MinimunQuantity <=part.CurrentQuantity-quantity) { 
                Needed = false;
                part.CurrentQuantity = part.CurrentQuantity - quantity;
                if (part.CurrentQuantity < part.MinimunQuantity)
                {
                    Needed = true;
                }
            }
            else {  
                Needed = true; 
            }

            this.Part = part;
            this.Quantity = quantity;
            
        }
       
        public UsedPart(int quantity, bool needed, Part part)
            : this()
        {
            Part = part;
            Quantity = quantity;
            Needed = needed;
        }

    }
}
