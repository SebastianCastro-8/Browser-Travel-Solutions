using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLibraryTravel.Domain.Entities
{
    public class Editorial
    {
        public int Id { get; protected set; }
        public string Nombre { get; protected set; }
        public string Sede { get; protected set; }
    }
}
