using AutoMapper;
using Domain;
using InventoryManager.ViewModels.Records;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, Product>();

            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();

            Mapper.CreateMap<UnitOfMeasure, UnitOfMeasureViewModel>();
            Mapper.CreateMap<UnitOfMeasureViewModel, UnitOfMeasure>();

            base.OnStartup(e);
        }
    }
}
