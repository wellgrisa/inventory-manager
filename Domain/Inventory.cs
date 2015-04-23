using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Inventory : Entity
    {
        public virtual Product Product { get; set; }

        public decimal Quantity { get; set; }
    }
}
