using Microsoft.Extensions.DependencyInjection;
using TheLibraryTravel.Aplication.Services.Implementations;
using TheLibraryTravel.Aplication.Services.Interfaces;

namespace TheLibraryTravel.WebApi
{
    public class WebApiConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ILibroCommandService, LibroCommandService>();
            services.AddTransient<ILibroQueryService, LibroQueryService>();


            return services;
        }
    }
}
