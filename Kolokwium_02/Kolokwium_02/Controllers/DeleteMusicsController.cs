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
    [Route("api/musicians/10")]
    [ApiController]
    public class DeleteMusicsController : ControllerBase
    {

        IDbService _service;

        public DeleteMusicsController(IDbService service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMusician (int id)
        {
            string wynik = _service.DeleteMusician(id);

            if (wynik.Equals(null))
            {
                throw new AppException("COS POSZLO NIE TAK W KONTROLERZE");
            }

            return Ok(wynik);
        }

    }
}