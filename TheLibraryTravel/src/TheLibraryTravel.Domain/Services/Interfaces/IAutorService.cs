﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Domain.Services.Interfaces
{
    public interface IAutorService
    {
        Autor ActualizarAutor(Autor autor, AutorDto dto);
    }
}
