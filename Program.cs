using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncRefactoringBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediator>();
            Run(mediator, args.FirstOrDefault()).Wait();
        }

        private static async Task Run(IMediator mediator, string name)
        {
            var greeting = await mediator.Send(new GreetingRequest(name));
            Console.WriteLine(greeting);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
