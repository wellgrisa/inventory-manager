using Domain;
using Services;

namespace InventoryManager.ViewModels
{
    public class OutwardsViewModel : BaseMovimentViewModel<Outward>
    {     
        public OutwardsViewModel(ProductService<Product> productService) : base(productService)
        {
            
        }

        public override MovimentType MovimentType { get { return MovimentType.Outward; } }
    }
}
