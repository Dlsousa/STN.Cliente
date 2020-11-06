using Microsoft.AspNetCore.Mvc;
using STN.Clientes.Api.Models;
using STN.Clientes.Domain.Contracts.Repositories;
using STN.Clientes.Domain.Entities;
using STN.Clientes.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace STN.Clientes.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _clienteRepository.GetAsync();

            var usuarios = data.Select(c => new ClienteVM { Id = c.Id, Nome = c.Nome, Estado = c.Estado, Cpf = c.Cpf });

            return Ok(usuarios);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            if (!CpfService.IsCpf(cpf))
                return BadRequest("CPF inválido");

            var data = await _clienteRepository.GetByCpfAsync(cpf.Trim().Replace(".", "").Replace("-", ""));

            if (data == null)
                return NotFound("Cliente não encontrado");

            var cliente = new ClienteVM() { Id = data.Id, Nome = data.Nome, Estado = data.Estado, Cpf = data.Cpf };

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClienteVM model)
        {
            if (ModelState.IsValid)
            {
                if (!CpfService.IsCpf(model.Cpf))
                    return BadRequest("CPF inválido");

                if (!EstadoService.IsValid(model.Estado))
                    return BadRequest("Estado inválido");

                var cl = await _clienteRepository.GetByCpfAsync(model.Cpf.Trim().Replace(".", "").Replace("-", ""));

                if (cl != null)
                    return BadRequest("Cliente já cadastrado");

                var cliente = new Cliente()
                {
                    Nome = model.Nome,
                    Estado = model.Estado,
                    Cpf = model.Cpf.Trim().Replace(".", "").Replace("-", "")
                };

                _clienteRepository.Add(cliente);
                return Ok(cliente);
            }

            return BadRequest(ModelState);
        }
    }
}