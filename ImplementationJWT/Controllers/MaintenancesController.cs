using ImplementationJWT.Models;
using ImplementationJWT.Services.Interfaces;
using ImplementationJWT.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ImplementationJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaintenancesController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenancesController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        // GET: api/<MaintenanceController>
        [HttpGet]
        public ActionResult<IEnumerable<Maintenance>> Get()
        {
            var maintenances = _maintenanceService.GetMaintenanceByName("");
            if (maintenances.Any())
            {
                return Ok(maintenances);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<MaintenanceController>/GetMaintenanceByName/{name}
        [HttpGet("GetMaintenanceByName/{name}")]
        public ActionResult GetMaintenanceByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var maintenances = _maintenanceService.GetMaintenanceByName(name);
            if (maintenances.Any())
            {
                return Ok(maintenances);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<MaintenanceController>/GetMaintenanceByType/{type}
        [HttpGet("GetMaintenanceByType/{type}")]
        public ActionResult GetMaintenanceByType(MaintenanceType type)
        {
            var maintenances = _maintenanceService.GetMaintenanceByType(type);
            if (maintenances.Any())
            {
                return Ok(maintenances);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<MaintenanceController>/GetMaintenanceByMonth/{month}
        [HttpGet("GetMaintenanceByMonth/{month}")]
        public ActionResult GetMaintenanceByMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                return BadRequest();
            }

            var maintenances = _maintenanceService.GetMaintenanceByMonth(month);
            if (maintenances.Any())
            {
                return Ok(maintenances);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<MaintenanceController>/DeleteMaintenanceByName/{name}
        [HttpDelete("DeleteMaintenanceByName/{name}")]
        public ActionResult DeleteMaintenanceByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var result = _maintenanceService.DeleteMaintenanceByName(name);
            if (result)
            {
                return Ok($"Maintenance with name {name} was deleted successfully.");
            }
            else
            {
                return NotFound($"Maintenance with name {name} not found.");
            }
        }
    }
}
