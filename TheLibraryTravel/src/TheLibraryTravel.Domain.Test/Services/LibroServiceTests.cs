using Moq;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Domain.Services.Interfaces;
using TheLibraryTravel.Domain.Services.Implementations;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Dtos;
using GenFu;

namespace TheLibraryTravel.Domain.Test.Services
{
    public class LibroServiceTests
    {
        private Mock<ILibroService>? libroService;
        private LibroService? service;

        [SetUp]
        public void Setup()
        {

            libroService = new Mock<ILibroService>();
            service = new LibroService();
        }


        [Test]
        public void ActualizarLibro_LibroDto_ActualizaPropiedadesCorrectamente()
        {
            // Arrange
            var libro = A.New<Libro>();
            var nuevoDto = A.New<LibroDto>();


            // Act
            var result = libro.ActualizarLibro(nuevoDto);

            // Assert
            Assert.AreEqual(nuevoDto.Isbn, result.Isbn);
            Assert.AreEqual(nuevoDto.Titulo, result.Titulo);
            Assert.AreEqual(nuevoDto.sinopsis, result.Sinopsis);
            Assert.AreEqual(nuevoDto.Paginas, result.Paginas);
            Assert.AreEqual(nuevoDto.IdEditorial, result.IdEditorial);
        }


    }
}
