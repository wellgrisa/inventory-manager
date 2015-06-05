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
    public class UnitOfMeasureViewModel : EntityBaseViewModel
    {
        [Required(ErrorMessage = "Unidade de Medida é obrigatório")]
        public string Name { get; set; }
    }
}
