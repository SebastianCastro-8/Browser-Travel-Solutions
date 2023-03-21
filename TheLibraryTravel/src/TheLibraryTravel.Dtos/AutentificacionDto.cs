using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLibraryTravel.Dtos
{
    public class AutentificacionDto
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
