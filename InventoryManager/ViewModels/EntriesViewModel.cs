using Domain;
using Services;

namespace InventoryManager.ViewModels
{
    public class EntriesViewModel : BaseMovimentViewModel<Entry>
    {
        public EntriesViewModel(ProductService<Product> productService) : base(productService)
        {

        }

        public override MovimentType MovimentType { get { return MovimentType.Entry; } }
    }

    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }
    }
}
