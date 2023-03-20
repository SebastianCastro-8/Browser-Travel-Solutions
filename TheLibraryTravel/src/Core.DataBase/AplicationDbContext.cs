using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TheLibraryTravel.Domain.Entities;

namespace Core.DataBase
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autor> autores { get; set; }
        public DbSet<Libro> libros { get; set; }
        public DbSet<Editorial> editoriales { get; set; }
        public DbSet<AutorLibro> autores_has_libros { get; set; }
    }
}
