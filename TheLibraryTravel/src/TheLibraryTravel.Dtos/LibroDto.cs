using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLibraryTravel.Dtos
{
    public class LibroDto
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string sinopsis { get; set; }
        public int Paginas { get; set; }
        public int IdEditorial { get; set; }
    }
}
