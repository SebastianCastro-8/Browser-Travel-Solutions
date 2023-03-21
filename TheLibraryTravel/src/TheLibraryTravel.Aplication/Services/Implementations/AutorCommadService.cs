using AutoMapper;
using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Domain.Services.Implementations;
using TheLibraryTravel.Domain.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Implementations
{
    public class AutorCommadService : IAutorCommandService
    {
        private readonly AplicationDbContext Context;
        private readonly IMapper Mapper;
        private readonly IAutorService AutorService;

        public AutorCommadService(IAutorService autorService, AplicationDbContext context, IMapper mapper)
        {
            AutorService = autorService;
            Context = context;
            Mapper = mapper;
        }

        public async Task<AutorDto> ActualizarAutor(int id, AutorDto dto)
        {
            var autor = await Context.autores.FindAsync(id);
            autor = AutorService.ActualizarAutor(autor, dto);
            Context.Update(autor);
            await Context.SaveChangesAsync();
            return Mapper.Map<AutorDto>(autor);
        }

        public async Task<AutorDto> CrearAutor(AutorDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var autor = Mapper.Map<Autor>(dto);
            Context.Add(autor);
            await Context.SaveChangesAsync();
            dto.Id = autor.Id;
            return dto;
        }

        public async Task<AutorDto> EliminarAutor(int id)
        {
            var autor = await Context.autores.FindAsync(id);
            if (autor == null)
            {
                throw new Exception("Autor no encontrado");
            }

            Context.Remove(autor);
            await Context.SaveChangesAsync();

            return Mapper.Map<AutorDto>(autor);
        }
    }
}
