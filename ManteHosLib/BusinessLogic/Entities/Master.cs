using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Master :Employee
    {
        public Master() : base() { }

        public Master(string fullName, string id, string password) : base()
        {
            FullName = fullName;
            Id = id;
            Password = password;
        }

    }
}
