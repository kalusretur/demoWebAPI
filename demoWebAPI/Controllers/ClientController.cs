using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("allClientes")]
        public ActionResult<IEnumerable<ClientViewModel>> Get()
        {
            var result = new List<ClientViewModel>() { 
                new ClientViewModel {DocumentTye = "1", DocumentNumber = "48066128", Apellidos = "Salvador Calazada", Nombres = "Carlos Eduardo" },
                new ClientViewModel {DocumentTye = "1", DocumentNumber = "40509060", Apellidos = "Perez Luna", Nombres = "Juan" }
            };
            return Ok(result);
        }
    }
}