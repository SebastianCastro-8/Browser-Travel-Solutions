using AutoMapper;
using GenFu;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Domain.Services.Implementations;
using TheLibraryTravel.Domain.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.Aplication.Test.Services
{
    public class LibroCommandServiceTests
    {
        private Mock<IMapper>? Mapper;
        private Mock<ILibroService>? libroService;
        private Libro? libro;


        [SetUp]
        public void Setup()
        {
            Mapper = new Mock<IMapper>();
            libroService = new Mock<ILibroService>();
            libro = new Libro();
        }


    }
}
