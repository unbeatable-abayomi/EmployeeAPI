using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebAPIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkWayProject2.HelperMethods;

namespace EmployeeWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbaController : ControllerBase
    {
        private readonly EmployeeAppDBContext _context;

        public UbaController(EmployeeAppDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbaCustomer>>> GetUbaCustomers()
        {
          
            return await _context.ubaCustomers.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<UbaCustomer>> GetUbaOneCustomer(int id)
        {
            var ubaCustomer = await _context.ubaCustomers.FindAsync(id);

            if (ubaCustomer == null)
            {
                return NotFound();
            }

            return ubaCustomer;
        }

        [HttpPost]
        public async Task<ActionResult<UbaCustomer>> PostEmployee(UbaCustomer ubaCustomer)
        {
            _context.ubaCustomers.Add(ubaCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbaOneCustomer", new { id = ubaCustomer.Id }, ubaCustomer);
        }
    }
}
