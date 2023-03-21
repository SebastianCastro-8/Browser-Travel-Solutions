using AutoMapper;
using System;
using TheLibraryTravel.Domain.Dtos;
using TheLibraryTravel.Domain.Entities;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.ObjectMapper.Automapper
{
    public class TheLibraryTravelSistemaProfile : Profile
    {
        public TheLibraryTravelSistemaProfile()
        {
            CreateMap<Autor, AutorDto>();
            CreateMap<AutorLibro, AutorLibroDto>();
            CreateMap<Editorial, EditorialDto>();
            CreateMap<Libro, LibroDto>();
        }



    }
}
