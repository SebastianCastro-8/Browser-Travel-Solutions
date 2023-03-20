using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Implementations
{
    public class LibroQueryService : ILibroQueryService
    {
        public Task<LibroDto> ObtenerLibro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LibroDto> ObtenerLibros()
        {
            throw new NotImplementedException();
        }
    }
}
