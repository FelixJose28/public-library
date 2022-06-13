using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorReporitory _authorReporitory;

        public AuthorController(IAuthorReporitory authorReporitory)
        {
            _authorReporitory = authorReporitory;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_authorReporitory.GetAll());
        }
    }
}
