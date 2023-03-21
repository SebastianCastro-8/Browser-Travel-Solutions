using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Interfaces
{
    public interface ILibroQueryService
    {
        Task<IList<LibroDto>> ObtenerLibros();
        Task<LibroDto> ObtenerLibro(int id);
    }
}
