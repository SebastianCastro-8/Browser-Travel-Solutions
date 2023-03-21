using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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


        [Route("CrearLibro")]
        [HttpPost]
        public async Task<ActionResult<LibroDto>> Post(LibroDto dto)
        {
            var libroDto = await CommandService.CrearLibro(dto);
            return CreatedAtAction(nameof(Get), new { id = libroDto.Id }, libroDto);
        }

        [Route("ObtenerLibro/{id}")]
        [HttpGet]

        public async Task<ActionResult<LibroDto>> Get(int id)
        {
            return await QueryService.ObtenerLibro(id);
        }

        [Route("ObtenerLibros")]
        [HttpGet]
        public async Task<IList<LibroDto>> Get()
        {
            return await QueryService.ObtenerLibros();
        }


        [Route("ActualizarLibro/{id}")]
        [HttpPut]
        public async Task<ActionResult<LibroDto>> Put(int id, LibroDto dto)
        {

            var libroDto = await CommandService.ActualizarLibro(id, dto);

            if (libroDto == null)
            {
                return NotFound();
            }

            return Ok(libroDto);
        }

        [Route("EliminarLibro/{id}")]
        [HttpDelete]
        public async Task<ActionResult<LibroDto>> Delete(int id)
        {
            var libroDto = await CommandService.EliminarLibro(id);

            if (libroDto == null)
            {
                return NotFound();
            }

            return libroDto;
        }




    }
}
