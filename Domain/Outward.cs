using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Outward : Moviment
    {
        public override void ProductMovimentAction(ProductMoviment productMoviment)
        {
            productMoviment.Product.Quantity -= productMoviment.Quantity;
        }
    }
}
