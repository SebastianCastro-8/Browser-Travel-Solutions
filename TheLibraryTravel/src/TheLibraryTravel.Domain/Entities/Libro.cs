using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLibraryTravel.Domain.Entities
{
    public class Libro
    {
        public int Id { get; protected set; }
        public int Isbn { get; protected set; }
        public string Titulo { get; protected set; }
        public string sinopsis { get; protected set; }
        public int Paginas { get; protected set; }
        public int IdEditorial { get; protected set; }
    }
}
