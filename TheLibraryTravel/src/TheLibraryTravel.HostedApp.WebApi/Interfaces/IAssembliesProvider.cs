using System.Collections.Generic;
using System.Reflection;

namespace TheLibraryTravel.HostedApp.WebApi.Interfaces
{
    public interface IAssembliesProvider
    {
        IEnumerable<Assembly> GetAssemblies();

    }
}
