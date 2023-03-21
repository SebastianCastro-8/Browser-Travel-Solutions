using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Aplication.Services.Interfaces;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AutorController : ControllerBase
    {
        private IAutorCommandService CommandService { get; set; }
        private IAutorQueryService QueryService { get; set; }

        public AutorController(IAutorQueryService queryService, IAutorCommandService commandService)
        {
            QueryService = queryService;
            CommandService = commandService;
        }

        [Route("CrearAutor")]
        [HttpPost]
        public async Task<ActionResult<AutorDto>> Post(AutorDto dto)
        {
            var autorDto = await CommandService.CrearAutor(dto);
            return CreatedAtAction(nameof(Get), new { id = autorDto.Id }, autorDto);
        }

        [Route("ObtenerAutor/{id}")]
        [HttpGet]

        public async Task<ActionResult<AutorDto>> Get(int id)
        {
            return await QueryService.ObtenerAutor(id);
        }


        [Route("ObtenerAutores")]
        [HttpGet]
        public async Task<IList<AutorDto>> Get()
        {
            return await QueryService.ObtenerAutores();
        }

        [Route("ActualizarAutor/{id}")]
        [HttpPut]
        public async Task<ActionResult<AutorDto>> Put(int id, AutorDto dto)
        {

            var autorDto = await CommandService.ActualizarAutor(id, dto);

            if (autorDto == null)
            {
                return NotFound();
            }

            return Ok(autorDto);
        }


        [Route("EliminarAutor/{id}")]
        [HttpDelete]
        public async Task<ActionResult<AutorDto>> Delete(int id)
        {
            var autorDto = await CommandService.EliminarAutor(id);

            if (autorDto == null)
            {
                return NotFound();
            }

            return autorDto;
        }

    }
}
