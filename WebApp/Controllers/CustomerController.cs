using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CustomerController : ControllerBase
    {
        [Route("api/customer")]
        public IActionResult Index()
        {
            return Ok("Done!");
        }
    }
}