using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLibraryTravel.Domain.Entities
{
    public class AutorLibro
    {
        public int Id { get; protected set; }
        public int IdAutor { get; protected set; }
        public int IsbnLibro { get; protected set; }
        public Libro Libro { get; protected set; }
        public Autor Autor { get; protected set; }
    }
}
