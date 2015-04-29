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

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Set<T>().ToList();
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
    public class ProductService<T> : EntityService where T: Entity
    {
        public IEnumerable<T> GetAll(params string[] includeItems)
        {
            using (var db = new ApplicationDbContext())
            {
                if (includeItems.Any())
                {
                    var dbSet = db.Set<T>();

                    foreach (var include in includeItems)
                    {
                        dbSet.Include(include).ToList();
                    }

                    return dbSet.ToList();
                }

                return db.Set<T>().ToList();
            }
        }        

        public void SaveEntities(params T[] entities)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (var entity in entities)
                {
                    //db.Set<T>().Add(entity);
                    Save(entity);
                    //db.SaveChanges();
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
//https://msdn.microsoft.com/en-us/data/jj574514.aspx