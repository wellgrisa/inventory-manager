using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels.Sidebar
{
    public class SidebarTabItem
    {
        /// <summary>
        /// Tab Header text
        /// </summary>
        public string Header { get; set; }

        public SidebarTabItemTemplate TabItemTemplate { get; set; }

        public override string ToString()
        {
            return Header;
        }
    }
}
