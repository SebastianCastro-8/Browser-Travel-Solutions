using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private ILibroCommandService CommandService { get; set; }
        private ILibroQueryService QueryService { get; set; }

        public LibroController(ILibroCommandService commandService, ILibroQueryService queryService)
        {

            CommandService = commandService;
            QueryService = queryService;
        }

        [HttpPost]
        public async Task<LibroDto> Post(LibroDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return await CommandService.CrearLibro(dto);
        }

        [HttpGet("{id}", Name = "ObtenerLibro")]
        public async Task<ActionResult<LibroDto>> Get(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await QueryService.ObtenerLibro(id);
        }

        [HttpGet(Name = "ObtenerLibros")]
        public async Task<ActionResult<LibroDto>> Get()
        {
            return await QueryService.ObtenerLibros();
        }

        [HttpPut("{id}", Name = "ActualizarLibro")]
        public async Task<ActionResult<LibroDto>> Put(int id, LibroDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await CommandService.ActualizarLibro(id, dto);
        }

        [HttpDelete("{id}", Name = "EliminarLibro")]
        public async Task<ActionResult<LibroDto>> Delete(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await CommandService.EliminarLibro(id);
        }



    }
}
