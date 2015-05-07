using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels.Records
{
    public class RecordsPhysicalPeopleViewModel : RecordBaseViewModel<PhysicalPerson>
    {
        public override void AddCommandExecute(object obj)
        {
            Entities.Add(new PhysicalPerson
            {
                Name = "Nome"
            });
        }        
    }   
}
