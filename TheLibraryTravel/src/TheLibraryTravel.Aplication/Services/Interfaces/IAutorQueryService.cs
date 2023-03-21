using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Interfaces
{
    public interface IAutorQueryService
    {
        Task<IList<AutorDto>> ObtenerAutores();
        Task<AutorDto> ObtenerAutor(int id);
    }
}
