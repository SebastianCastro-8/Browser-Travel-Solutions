using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Interfaces
{
    public interface ILibroCommandService
    {
        Task<LibroDto> CrearLibro(LibroDto dto);
        Task<LibroDto> ActualizarLibro(int id, LibroDto dto);
        Task<LibroDto> EliminarLibro(int id);
    }
}
