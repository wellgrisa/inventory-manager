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

        [NotMapped]
        public abstract bool ChangeInventory { get; }

        [NotMapped]
        public abstract Action<Inventory, ProductMoviment> InventoryAction { get; }

        public virtual ICollection<ProductMoviment> Products { get; set; }
    }
}
