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

        [Route("api/customer/list")]
        public IActionResult GetList()
        {
            var ids=new long[] { 1,3,9,25};
            var q = _db.Customers.Where(c=> ids.Contains(c.CustomerId));
            return Ok(q.ToList());
        }
    }
}