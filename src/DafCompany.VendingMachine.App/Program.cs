using DafCompany.VendingMachine.App.Services;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;

namespace DafCompany.VendingMachine.App
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static Container _container;
        static void Main()
        {
            RegisterServices();
            var vendingMachine = _serviceProvider.GetService<IVendingMachineService>();
            vendingMachine.Run();

            //Dispose services
            _container.Dispose();
        }

        private static void RegisterServices()
        {
            ServiceCollection collection = new ServiceCollection();
            _container = new Container();
            _container.Configure(config =>
            {
                config.Scan(_ =>
                            {
                                _.AssemblyContainingType<Program>();
                                _.WithDefaultConventions();
                            });
                config.Populate(collection);
            });

            _serviceProvider = _container.GetInstance<IServiceProvider>();
        }
    }
}
