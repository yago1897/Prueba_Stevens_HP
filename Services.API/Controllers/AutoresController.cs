using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Core.Data;
using Services.Core.DTOs;
using Services.Core.Interfaces;
using Services.Core.Services;
using Services.Infraestructure.Data;

namespace Services.API.Controllers
{


    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly PruebaStevensNexosContext _context;
        private readonly IAutoreService _autoreService;
        private readonly IMapper _mapper;

        public AutoresController(IAutoreService autoreService, IMapper mapper, PruebaStevensNexosContext context)
        {
            _autoreService = autoreService;
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        //[Route("GetAutores")]
        public async Task<IActionResult> GetAutores()
        {
            var autor = await _autoreService.GetAutores();
            var autorDTO = _mapper.Map<IEnumerable<AutoreDTO>>(autor);
            return Ok(autorDTO);

        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetAutores(int id)
        {
            var autor = await _autoreService.GetAutores(id);
            var autorDTO = _mapper.Map<AutoreDTO>(autor);
            return Ok(autorDTO);
        }



        [HttpGet("[action]/{term}")]
        public async Task<IActionResult> ConsultarPorNombre(string term)
        {


            //List<string> usuario; Autore usu = new Autore();
            //usuario = await _context.Autores.Where(x => x.NombreAutor.StartsWith(term)).Select(e => e.NombreAutor).Distinct().ToListAsync();
            //return Ok(usuario);
            Autore usu = new Autore();
            List<string> usuario = new List<string>();
            usuario = (List<string>)await _autoreService.ConsultarPorNombre(term);
            //var autorDTO = _mapper.Map<AutoresDTO>(term);
            return Ok(usuario);

        }


        [HttpPost]
        [Route("InsertarAutores")]
        //ddfdfdfdf
        public async Task<IActionResult> InsertarAutores(AutoreDTO autorDTO)
        {
            var autor = _mapper.Map<Autore>(autorDTO);
            await _autoreService.InsertAutores(autor);
            return Ok(autor);

        }


        [HttpPut]
        [Route("ActualizarAutores/{id}")]
        public async Task<IActionResult> ActualizarAutores(int id, AutoreDTO autorDTO)
        {
            var autor = _mapper.Map<Autore>(autorDTO);
            autor.IdAutor = id;
            await _autoreService.ModificarAutores(autor);
            return Ok(autor);

        }


        [HttpDelete]
        [Route("EliminarAutores/{id}")]
        public async Task<IActionResult> EliminarAutores(int id)
        {

            var result = await _autoreService.EliminarAutores(id);
            return Ok(result);

        }
    }
}
