using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WSTowerApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { mensagem = "Ok" });
        }
    }
}
