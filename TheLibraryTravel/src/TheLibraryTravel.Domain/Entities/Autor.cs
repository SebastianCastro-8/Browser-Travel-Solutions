using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLibraryTravel.Domain.Entities
{
    public class Autor
    {
        public int Id { get; protected set; }
        public string Nombre { get; protected set; }
        public string Apellido { get; protected set; }
    }
}
