using DataProvider;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class EntityService
    {
        public virtual int Save<T>(T obj) where T : Entity
        {
            using (var db = new ApplicationDbContext())
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                var dbEntity = db.Set<T>().Find(obj.ID);

                if (dbEntity == null)
                {
                    db.Set<T>().Add(obj);
                }
                else
                {
                    db.Entry(dbEntity).CurrentValues.SetValues(obj);
                    dbEntity.UpdatedDate = DateTime.UtcNow;
                }

                return db.SaveChanges();
            }
        }

        public virtual bool Remove<T>(T obj) where T : Entity
        {
            using (var db = new ApplicationDbContext())
            {
                db.Set<T>().Attach(obj);
                obj.Deleted = true;

                try
                {
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        //public virtual ICollection<ValidationResult> Validate<T>(T obj) where T : Entity
        //{
        //    var results = new List<ValidationResult>();

        //    Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);

        //    return results;
        //}

        //public static T Clone<T>(T source) where T : Entity
        //{
        //    if (source == null)
        //        return null;

        //    if (source == default(T))
        //        return default(T);

        //    using (var db = MefBootstrap.Resolve<ApplicationDbContext>())
        //    {
        //        db.Set<T>().Attach(source);
        //        return db.Entry(source).OriginalValues.ToObject() as T;
        //    }
        //}
    }

    [Export]
    public class ProductService : EntityService
    {
        public IEnumerable<Product> GetProducts()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products
                    .OrderBy(o => o.Name)
                    .ToList();
            }
        }

        public Inventory GetInventoryByProduct(Product product)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Inventory.FirstOrDefault(x => x.Product.ID == product.ID);
            }
        }

        public void UpdateInventoryByMoviment(Moviment moviment)
        {
            if (moviment.ChangeInventory)
            {
                foreach (var productMoviment in moviment.Products)
                {
                    var inventory = GetInventoryByProduct(productMoviment.Product) ?? new Inventory();

                    moviment.InventoryAction(inventory, productMoviment);

                    Save(inventory);
                }
            }
        }

        public void SaveEntry(Entry entry)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Set<Entry>().Add(entry);

                db.SaveChanges();

                foreach (var productMoviment in entry.Products)
                {
                    var product = db.Products.Find(productMoviment.ProductID);

                    product.Quantity += productMoviment.Quantity;

                    db.SaveChanges();
                }
            }
        }
    }
}
