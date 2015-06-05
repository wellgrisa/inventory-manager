using AutoMapper;
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
    public class EntityBaseViewModel : PropertyValidateModel
    {
        public int ID { get; set; }
    }

    public static class EntityBaseExtensions
    {
        public static T MapTo<T>(this EntityBaseViewModel entityBaseViewModel) where T : Entity
        {
            return Mapper.Map(entityBaseViewModel.GetType(), typeof(T)) as T;
        }

        public static T MapTo<T>(this IEnumerable<EntityBaseViewModel> entityBaseViewModel) where T : Entity
        {
            return Mapper.Map(entityBaseViewModel.GetType(), typeof(T)) as T;
        }

        public static IEnumerable<T> MapTo<T>(this IEnumerable<Entity> entities) where T : EntityBaseViewModel
        {
            var sourceType = typeof(IEnumerable<>).MakeGenericType(entities.FirstOrDefault().GetType());

            return Mapper.Map(entities, sourceType, typeof(IEnumerable<T>)) as IEnumerable<T>;
        }
    }
}
