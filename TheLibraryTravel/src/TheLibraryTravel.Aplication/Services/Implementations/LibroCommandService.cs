﻿using AutoMapper;
using Core.DataBase;
using System;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Domain.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Services.Implementations
{
    public class LibroCommandService : ILibroCommandService
    {
        private readonly AplicationDbContext Context;
        private readonly IMapper Mapper;
        private readonly ILibroService LibroService;



        public LibroCommandService(AplicationDbContext context, IMapper mapper, ILibroService libroService)
        {
            Context = context;
            Mapper = mapper;
            LibroService = libroService;
        }
        public async Task<LibroDto> ActualizarLibro(int id, LibroDto dto)
        {
            var libro = await Context.libros.FindAsync(id);
            libro = LibroService.ActualizarLibro(libro, dto);
            Context.Update(libro);
            await Context.SaveChangesAsync();
            return Mapper.Map<LibroDto>(libro);
        }


        public async Task<LibroDto> CrearLibro(LibroDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var libro = Mapper.Map<Libro>(dto);
            Context.Add(libro);
            await Context.SaveChangesAsync();
            dto.Id = libro.Id;
            return dto;
        }

        public async Task<LibroDto> EliminarLibro(int id)
        {
            var libro = await Context.libros.FindAsync(id);
            if (libro == null)
            {
                throw new Exception("Libro no encontrado");
            }

            Context.Remove(libro);
            await Context.SaveChangesAsync();

            return Mapper.Map<LibroDto>(libro);
        }
    }
}
