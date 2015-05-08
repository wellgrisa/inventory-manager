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

        public decimal Quantity { get; set; }
        
        public decimal MinimumQuantity { get; set; }

        public decimal MaximumQuantity { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public int UnitOfMeasureID { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
