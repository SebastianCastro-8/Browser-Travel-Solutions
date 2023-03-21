using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Domain.Entities;

namespace TheLibraryTravel.Domain.Dtos
{
    public class AutorLibroDto
    {
        public int IdAutor { get; set; }
        public int IsbnLibro { get; set; }
        public Libro Libro { get; set; }
        public Autor Autor { get; set; }
    }
}
