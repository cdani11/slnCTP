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
    public class ClientesController : ControllerBase
    {
        private readonly ICTPInfoRepository _cTPInfoRepository;
        private readonly ILogger<ClientesController> _logger;
        private readonly IMapper _mapper;

        public ClientesController(ICTPInfoRepository cTPInfoRepository,
            ILogger<ClientesController> logger,
            IMapper mapper)
        {
            _cTPInfoRepository = cTPInfoRepository ??
                throw new ArgumentNullException(nameof(cTPInfoRepository));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Clientes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clientes = _cTPInfoRepository.GetClientes();

                return Ok(_mapper.Map<IEnumerable<ClienteDTO>>(clientes));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error al consultar {ex.Message}");
                return StatusCode(500, "Ocurrió un problema al manejar la solicitud");
            }
        }

        // GET: api/Clientes/5
        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = _cTPInfoRepository.GetCliente(id);

                if (cliente == null)
                    return NotFound();

                return Ok(_mapper.Map<ClienteDTO>(cliente));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error al consultar {ex.Message}");
                return StatusCode(500, "Ocurrió un problema al manejar la solicitud");
            }
        }

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (_cTPInfoRepository.ExisteCorreo(clienteDTO.Correo))
                    ModelState.AddModelError("Correo", "El correo ingresado ya existe.");

                if (_cTPInfoRepository.ExisteTelefono(clienteDTO.Telefono))
                    ModelState.AddModelError("Telefono", "El telefono ingresado ya existe.");

                var cliente = _mapper.Map<Entities.Cliente>(clienteDTO);

                _cTPInfoRepository.Save();

                var newCliente = _mapper.Map<ClienteDTO>(cliente);

                return CreatedAtRoute("GetCliente", newCliente);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error al ingresar {ex.Message}");
                return StatusCode(500, "Ocurrió un problema al manejar la solicitud");
            }
        }

        // PUT: api/Clientes/5
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
