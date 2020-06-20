using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium_02.Exceptions;
using Kolokwium_02.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_02.Controllers
{
    [Route("api/music-labels/1 ")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IDbService _service;

        public ClientController (IDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetLabels(int id)
        {
            var a = _service.GetLabel(id);

            if(a == null)
            {
                throw new AppException("COS POSZLO NIE TAK");
            }
        

            return Ok(a);

        }

    }
}