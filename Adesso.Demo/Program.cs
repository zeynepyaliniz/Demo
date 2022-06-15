using Adesso.Demo.ApiConsumer;
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
            services.AddTransient<IService , Service>();
            services.AddTransient<IClient , Client>();

        }
        private static void Run()
        {
            Console.WriteLine("Mathematic program running!");
            Mathematic mathematic = new Mathematic();
            var div = mathematic.Divide(4, 3);
            Console.WriteLine(div);
            IClient client = new Client();
            IService service = new Service(client);
            var response = service.GetUsers();
            foreach (var user in response) { 
                Console.WriteLine($"name: {user.Name}");
            }

        }
    }
}
