using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Interfaces
{
    public interface IAutorCommandService
    {
        Task<AutorDto> CrearAutor(AutorDto dto);
        Task<AutorDto> ActualizarAutor(int id, AutorDto dto);
        Task<AutorDto> EliminarAutor(int id);
    }
}
