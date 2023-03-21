using Microsoft.Extensions.DependencyInjection;
using TheLibraryTravel.Aplication.Services.Implementations;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Domain.Services.Implementations;
using TheLibraryTravel.Domain.Services.Interfaces;

namespace TheLibraryTravel.WebApi
{
    public class WebApiConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ILibroCommandService, LibroCommandService>();
            services.AddTransient<ILibroQueryService, LibroQueryService>();
            services.AddTransient<ILibroService, LibroService>();


            return services;
        }
    }
}
