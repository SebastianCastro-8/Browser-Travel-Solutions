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
    public class AutorQueryService : IAutorQueryService
    {
        private readonly AplicationDbContext Context;
        private readonly IMapper Mapper;

        public AutorQueryService(IMapper mapper, AplicationDbContext context)
        {
            Mapper = mapper;
            Context = context;
        }

        public async Task<AutorDto> ObtenerAutor(int id)
        {
            var autor = await Context.autores.FindAsync(id);
            if (autor is null)
            {
                throw new ArgumentException($"No se encontró el autor con ID {id}", nameof(id));
            }

            return Mapper.Map<AutorDto>(autor);
        }


        public async Task<IList<AutorDto>> ObtenerAutores()
        {
            var autores = await Context.autores.ToListAsync();
            var autoresDto = Mapper.Map<IList<Autor>, IList<AutorDto>>(autores);
            return autoresDto;
        }
    }
}
