using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PurchaseOrder : Moviment
    {
        public override bool ChangeInventory
        {
            get { return false; }
        }


        public override Action<Inventory, ProductMoviment> InventoryAction
        {
            get { return null; }
        }
    }
}
