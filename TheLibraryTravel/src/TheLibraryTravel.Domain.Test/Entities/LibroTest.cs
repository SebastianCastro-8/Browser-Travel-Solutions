using GenFu;
using NUnit.Framework;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Domain.Test.Entities
{
    public class LibroTest
    {
        private Libro libro;

        [SetUp]
        public void Setup()
        {
            libro = new Libro();
        }


        [Test]
        public void Constructor_LibroDto_CreaObjetoCorrectamente()
        {
            // Arrange
            var dto = new LibroDto()
            {
                Isbn = 1234567890,
                Titulo = "El Gran Gatsby",
                sinopsis = "Novela ambientada en los años 20",
                Paginas = 180,
                IdEditorial = 1
            };

            // Act
            libro = new Libro(dto);

            // Assert
            Assert.AreEqual(dto.Isbn, libro.Isbn);
            Assert.AreEqual(dto.Titulo, libro.Titulo);
            Assert.AreEqual(dto.sinopsis, libro.Sinopsis);
            Assert.AreEqual(dto.Paginas, libro.Paginas);
            Assert.AreEqual(dto.IdEditorial, libro.IdEditorial);
        }

        [Test]
        public void ActualizarLibro_LibroDto_ActualizaPropiedadesCorrectamente()
        {
            // Arrange
            libro = A.New<Libro>();
            var nuevoDto = A.New<LibroDto>();

            // Act
            libro.ActualizarLibro(nuevoDto);

            // Assert
            Assert.AreEqual(nuevoDto.Isbn, libro.Isbn);
            Assert.AreEqual(nuevoDto.Titulo, libro.Titulo);
            Assert.AreEqual(nuevoDto.sinopsis, libro.Sinopsis);
            Assert.AreEqual(nuevoDto.Paginas, libro.Paginas);
            Assert.AreEqual(nuevoDto.IdEditorial, libro.IdEditorial);
        }



    }
}
