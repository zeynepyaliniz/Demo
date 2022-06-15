using Microsoft.Extensions.DependencyInjection;
using System;

namespace Adesso.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Run();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMathematic, Mathematic>();

        }
        private static void Run()
        {
            Console.WriteLine("Mathematic program running!");
            Mathematic mathematic = new Mathematic();
            var div = mathematic.Divide(4, 3);
            Console.WriteLine(div);

        }
    }
}
