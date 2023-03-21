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
    public class AutorService : IAutorService
    {
        public Autor ActualizarAutor(Autor autor, AutorDto dto)
        {
            autor.ActualizarAutor(dto);
            return autor;
        }
    }
}
