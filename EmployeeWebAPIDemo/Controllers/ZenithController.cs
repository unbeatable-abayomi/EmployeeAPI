using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebAPIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZenithController : ControllerBase
    {
        private readonly EmployeeAppDBContext _context;
        public ZenithController(EmployeeAppDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZenithCustomer>>> GetZenithCustomers()
        {

            return await _context.ZenithCustomers.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ZenithCustomer>> GetZenithOneCustomer(int id)
        {
            var zenithCustomer = await _context.ZenithCustomers.FindAsync(id);

            if (zenithCustomer == null)
            {
                return NotFound();
            }

            return zenithCustomer;
        }

        [HttpPost]
        public async Task<ActionResult<ZenithCustomer>> PostEmployee(ZenithCustomer zenith)
        {
            _context.ZenithCustomers.Add(zenith);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZenithOneCustomer", new { id = zenith.Id }, zenith);
        }
    }
}
