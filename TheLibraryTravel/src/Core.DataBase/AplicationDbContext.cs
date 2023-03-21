using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TheLibraryTravel.Domain.Entities;

namespace Core.DataBase
{
    public class AplicationDbContext : IdentityDbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AutorLibro>().HasKey(x => new { x.IdAutor, x.IsbnLibro });
        }

        public DbSet<Autor> autores { get; set; }
        public DbSet<Libro> libros { get; set; }
        public DbSet<Editorial> editoriales { get; set; }
        public DbSet<AutorLibro> autores_has_libros { get; set; }
    }
}
