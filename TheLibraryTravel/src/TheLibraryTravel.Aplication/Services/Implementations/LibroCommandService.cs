using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Implementations
{
    public class LibroCommandService : ILibroCommandService
    {
        private readonly AplicationDbContext context;

        public LibroCommandService(AplicationDbContext context)
        {
            this.context = context;
        }
        public Task<LibroDto> ActualizarLibro(int id, LibroDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<LibroDto> CrearLibro(LibroDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<LibroDto> EliminarLibro(int id)
        {
            throw new NotImplementedException();
        }
    }
}
