using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Core.Data;
using Services.Core.DTOs;
using Services.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Services.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _ilibroServiceE;
        private readonly IMapper _mapper;

        public LibrosController(ILibroService ilibroService, IMapper mapper)
        {
            _ilibroServiceE = ilibroService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Route("Get")]
        public async Task<IActionResult> GetLibros()
        {
            var libro = await _ilibroServiceE.GetLibros();
            var libroDTO = _mapper.Map<IEnumerable<LibroDTO>>(libro);
            return Ok(libroDTO);

        }

        [HttpGet("{id}")]
        //[Route("GetLibros")]
        public async Task<IActionResult> GetLibros(int id)
        {
            var libro = await _ilibroServiceE.GetLibros(id);
            var libroDTO = _mapper.Map<LibroDTO>(libro);
            return Ok(libroDTO);
        }

        [HttpPost]
        [Route("InsertLibros")]
        public async Task<IActionResult> InsertLibros(LibroDTO libroDTO)
        {
            var libro = _mapper.Map<Libro>(libroDTO);
            await _ilibroServiceE.InsertLibros(libro);
            return Ok(libro);
        }


        [HttpPut]
        [Route("ModificarLibros/{id}")]
        public async Task<IActionResult> ModificarLibros(int id, LibroDTO libroDTO)
        {
            var libro = _mapper.Map<Libro>(libroDTO);
            libro.IdLibro = id;
            await _ilibroServiceE.ModificarLibros(libro);
            return Ok(libro);

        }


        [HttpDelete]
        [Route("EliminarLibros/{id}")]
        public async Task<IActionResult> EliminarLibros(int id)
        {

            var result = await _ilibroServiceE.EliminarLibros(id);
            return Ok(result);

        }
    }
}
