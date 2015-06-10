using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductMoviment : Entity
    {
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public int MovimentID { get; set; }

        public virtual Moviment Moviment { get; set; }        

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }
    }    
}
