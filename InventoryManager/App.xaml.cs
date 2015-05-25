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

            base.OnStartup(e);
        }
    }
}
