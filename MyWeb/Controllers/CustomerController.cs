using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ChinbookContext _db;
        public CustomerController(ChinbookContext db)
        {
            _db = db;
        }

        [Route("api/customer")]
        public IActionResult Get()
        {
            return Ok(_db.Customers);
        }
    }
}