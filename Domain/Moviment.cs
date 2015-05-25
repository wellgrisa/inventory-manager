using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Moviment : Entity
    {
        public Moviment()
        {
            Products = new List<ProductMoviment>();
        }

        public virtual ICollection<ProductMoviment> Products { get; set; }

        public virtual void ProductMovimentAction(ProductMoviment productMoviment)
        {

        }
    }
}
