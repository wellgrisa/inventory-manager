using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels.Records
{
    [PropertyChanged.ImplementPropertyChanged]
    public class ProductViewModel : PropertyValidateModel
    {
        [Required(ErrorMessage="O nome é obrigatório")]
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public Category Category { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
