using ImplementationJWT.Models;
using ImplementationJWT.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ImplementationJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            var clients = _clientService.GetClients();
            if (clients.Any())
            {
                return Ok(clients);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<ClientController>/GetClientByName/{Name}
        [HttpGet("GetClientByName/{Name}")]
        public ActionResult GetClientByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return BadRequest();
            }

            var clients = _clientService.GetClientByName(Name);
            if (clients.Any())
            {
                return Ok(clients);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<ClientController>/GetClientByEmail/{Email}
        [HttpGet("GetClientByEmail/{Email}")]
        public ActionResult GetClientByEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return BadRequest();
            }

            var clients = _clientService.GetClientByEmail(Email);
            if (clients.Any())
            {
                return Ok(clients);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<ClientController>/DeleteClientByName/{Name}
        [HttpDelete("DeleteClientByName/{Name}")]
        public ActionResult DeleteClientByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return BadRequest();
            }

            var result = _clientService.DeleteClientByName(Name);
            if (result)
            {
                return Ok($"Client with name {Name} was deleted successfully.");
            }
            else
            {
                return NotFound($"Client with name {Name} not found.");
            }
        }
    }
}
