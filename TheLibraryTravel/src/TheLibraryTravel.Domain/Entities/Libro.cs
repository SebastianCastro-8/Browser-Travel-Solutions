using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Domain.Entities
{
    public class Libro
    {
        public int Id { get; protected set; }
        public int Isbn { get; protected set; }
        public string Titulo { get; protected set; }
        public string Sinopsis { get; protected set; }
        public int Paginas { get; protected set; }
        public int IdEditorial { get; protected set; }

        public Libro()
        {

        }
        public Libro(LibroDto dto)
        {

            Isbn = dto.Isbn;
            Titulo = dto.Titulo;
            Sinopsis = dto.sinopsis;
            Paginas = dto.Paginas;
            IdEditorial = dto.IdEditorial;
        }


        public Libro ActualizarLibro(LibroDto dto)
        {
            Isbn = dto.Isbn;
            Titulo = dto.Titulo;
            Sinopsis = dto.sinopsis;
            Paginas = dto.Paginas;
            IdEditorial = dto.IdEditorial;

            return this;
        }
    }
}
