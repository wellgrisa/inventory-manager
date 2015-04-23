using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Entry : Moviment
    {
        public override bool ChangeInventory
        {
            get { return true; }
        }


        public override Action<Inventory, ProductMoviment> InventoryAction
        {
            get { return (inventory, productMoviment) => inventory.Quantity += productMoviment.Quantity; }
        }
    }
}
