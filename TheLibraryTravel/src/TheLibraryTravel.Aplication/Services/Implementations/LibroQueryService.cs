using AutoMapper;
using Core.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Implementations
{
    public class LibroQueryService : ILibroQueryService
    {

        private readonly AplicationDbContext Context;
        private readonly IMapper Mapper;

        public LibroQueryService(AplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }


        public async Task<LibroDto> ObtenerLibro(int id)
        {
            var libro = await Context.libros.FirstOrDefaultAsync(x => x.Id == id);
            if (libro == null)
            {
                throw new ArgumentException($"No se encontró el libro con ID {id}");
            }

            return Mapper.Map<Libro, LibroDto>(libro);
        }




        public async Task<IList<LibroDto>> ObtenerLibros()
        {
            var libros = await Context.libros.ToListAsync();
            var librosDto = Mapper.Map<IList<Libro>, IList<LibroDto>>(libros);
            return librosDto;
        }
    }
}
