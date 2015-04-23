using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    public class CreateEditProductViewModel : CreateEditEntityViewModel<Product>
    {
        [ImportingConstructor]
        public CreateEditProductViewModel(ProductService productService)
        {
            CurrentEntity = new Product();

            Flyout = TempFlyoutResolver.Product;

            _entityService = productService;
        }
    }
}
