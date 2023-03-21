using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Domain.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Domain.Services.Implementations
{
    public class LibroService : ILibroService
    {
        public Libro ActualizarLibro(Libro libro, LibroDto dto)
        {
            libro.ActualizarLibro(dto);

            return libro;
        }


    }
}
