using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Dtos;
using TheLibraryTravel.WebApi.Controllers;

namespace TheLibraryTravel.WebApi.Tests
{
    public class LibroControllerTests
    {
        private Mock<ILibroCommandService>? commandService;
        private Mock<ILibroQueryService>? queryService;
        private LibroController? controller;

        [SetUp]
        public void Setup()
        {
            commandService = new Mock<ILibroCommandService>();
            queryService = new Mock<ILibroQueryService>();
            controller = new LibroController(commandService.Object, queryService.Object);
        }

        [Test]
        public async Task Post_Libro()
        {
            // Arrange
            var dto = A.New<LibroDto>();
            commandService!.Setup(x => x.CrearLibro(dto)).ReturnsAsync(dto).Verifiable();

            // Act
            var result = await controller!.Post(dto);

            // Assert
            result.ShouldNotBeNull();
            result.Result.Should().BeOfType<CreatedAtActionResult>();
            var libroCreado = (LibroDto)((ObjectResult)result.Result).Value;
            libroCreado.ShouldBeEquivalentTo(dto);
            commandService.VerifyAll();
        }


        [Test]
        public async Task Get_Libro_id()
        {
            // Arrange
            var idLibro = 2;
            var libroDto = A.New<LibroDto>();
            queryService.Setup(x => x.ObtenerLibro(idLibro)).ReturnsAsync(libroDto).Verifiable();

            // Act
            var resultado = await controller.Get(idLibro);

            // Assert
            resultado.ShouldNotBeNull();
            resultado.ShouldBeEquivalentTo(libroDto);
            queryService.Verify(x => x.ObtenerLibro(idLibro), Times.Once);
        }

        [Test]
        public void Get_Todos_Libros()
        {
            // Arrange            
            var libroDto = A.ListOf<LibroDto>();
            queryService!.Setup(x => x.ObtenerLibros()).ReturnsAsync(libroDto).Verifiable();

            // Act
            var result = controller!.Get();

            // Assert
            result.ShouldNotBeNull();
            queryService.VerifyAll();
        }

        [Test]
        public async Task Put_Libro()
        {
            // Arrange
            var dto = A.New<LibroDto>();

            var id = 2;
            commandService!.Setup(x => x.ActualizarLibro(id, dto)).ReturnsAsync(new LibroDto()).Verifiable();
            // Act
            LibroDto result = await controller!.Put(id, dto);
            // Assert
            result.ShouldNotBeNull();
            commandService.VerifyAll();
        }

        [Test]
        public async Task Delete_Libro()
        {
            // Arrange

            var id = 2;
            commandService!.Setup(x => x.EliminarLibro(id)).ReturnsAsync(new LibroDto()).Verifiable();

            // Act
            LibroDto result = await controller!.Delete(id);

            // Assert
            result.ShouldNotBeNull();
            commandService.VerifyAll();
        }



    }
}
