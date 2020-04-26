using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CTP.API.Models;
using CTP.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ICTPInfoRepository _cTPInfoRepository;
        private readonly ILogger<UsuariosController> _logger;
        private readonly IMapper _mapper;

        public UsuariosController(ICTPInfoRepository cTPInfoRepository, 
            ILogger<UsuariosController> logger, 
            IMapper mapper)
        {
            _cTPInfoRepository = cTPInfoRepository ?? 
                throw new ArgumentNullException(nameof(cTPInfoRepository));
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarios =_cTPInfoRepository.GetUsuarios();

                //var usuariosDTO = new List<UsuarioDTO>();

                //foreach (var usuario in usuarios)
                //{
                //    usuariosDTO.Add(new UsuarioDTO
                //    {
                //        Id = usuario.Id,
                //        NombreUsuario = usuario.NombreUsuario,
                //        Nombre = usuario.Nombre,
                //        Apellido = usuario.Apellido,
                //        Contrasena = usuario.Contrasena,
                //        Correo = usuario.Correo
                //    });
                //}

                return Ok(_mapper.Map<IEnumerable<UsuarioDTO>>(usuarios));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error al consultar {ex.Message}");
                return StatusCode(500, "Ocurrió un problema al manejar la solicitud");
            }
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult Get(int id)
        {
            try
            {
                var usuario = _cTPInfoRepository.GetUsuario(id);

                if (usuario == null)
                    return NotFound();

                //var usuarioDTO = new UsuarioDTO()
                //{
                //    Id = usuario.Id,
                //    NombreUsuario = usuario.NombreUsuario,
                //    Nombre = usuario.Nombre,
                //    Apellido = usuario.Apellido,
                //    Contrasena = usuario.Contrasena,
                //    Correo = usuario.Correo
                //};

                return Ok(_mapper.Map<UsuarioDTO>(usuario));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error al consultar {ex.Message}");
                return StatusCode(500, "Ocurrió un problema al manejar la solicitud");
            }
        }

        // POST: api/Usuarios
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (_cTPInfoRepository.ExisteUsuario(usuarioDTO.NombreUsuario))
                    ModelState.AddModelError("NombreUsuario", "El nombre de usuario ingresado ya existe.");

                if (_cTPInfoRepository.ExisteCorreo(usuarioDTO.Correo))
                    ModelState.AddModelError("Correo", "El correo ingresado ya existe.");

                var usuario = _mapper.Map<Entities.Usuario>(usuarioDTO);
                
                _cTPInfoRepository.Save();

                var newUsuario = _mapper.Map<UsuarioDTO>(usuario);

                return CreatedAtRoute("GetUsuario", newUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error al ingresar {ex.Message}");
                return StatusCode(500, "Ocurrió un problema al manejar la solicitud");
            }
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
