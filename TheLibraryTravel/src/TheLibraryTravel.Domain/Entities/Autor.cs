using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Domain.Entities
{
    public class Autor
    {
        public int Id { get; protected set; }
        public string Nombre { get; protected set; }
        public string Apellido { get; protected set; }

        public Autor()
        {

        }

        public Autor(AutorDto dto)
        {
            Nombre = dto.Nombre;
            Apellido = dto.Apellido;
        }
        internal Autor ActualizarAutor(AutorDto dto)
        {
            Nombre = dto.Nombre;
            Apellido = dto.Apellido;
            return this;
        }
    }


}
