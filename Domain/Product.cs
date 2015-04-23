using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Quantity { get; set; }
        
        public decimal MinimumQuantity { get; set; }

        public decimal MaximumQuantity { get; set; }
    }
}
