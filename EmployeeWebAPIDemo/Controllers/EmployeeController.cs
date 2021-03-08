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
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeAppDBContext _context;

       // string[] allUrl = { "https://localhost:44332/api/zenith", "https://localhost:44332/api/zenith", "https://localhost:44332/api/zenith" };
        public EmployeeController(EmployeeAppDBContext context)
        {
            _context = context;
        }

        [HttpGet("UBA")]
        public async Task<ActionResult<IEnumerable<UbaCustomer>>> GetUbaCustomers()
        {
            var helperDataClass = new HelperDataClass();

            var details = helperDataClass.GetAllEmployeeBankDetails();

            List<UbaCustomer> allubaCustomers = await _context.ubaCustomers.ToListAsync();
            List<CorrectBankDetails> correctBankDetails = new List<CorrectBankDetails>();
            foreach (var d in details.employee)
            {
                foreach (var x in allubaCustomers)
                {
                    if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
                    {
                        CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
                        {
                            AccountNumber = x.AccountNumber,
                            BankName = x.BankName
                        };



                        correctBankDetails.Add(correctBankDetails1);

                    }

                }
            }
            var allValidUbaBank = correctBankDetails.ToList();
            return await _context.ubaCustomers.ToListAsync();
        }



        [HttpGet("UBA/{id}")]
        public async Task<ActionResult<UbaCustomer>> GetUbaOneCustomer(int id)
        {
            var ubaCustomer = await _context.ubaCustomers.FindAsync(id);

            if (ubaCustomer == null)
            {
                return NotFound();
            }

            return ubaCustomer;
        }

        [HttpPost("UBA")]
        public async Task<ActionResult<UbaCustomer>> PostEmployee(UbaCustomer ubaCustomer)
        {
            _context.ubaCustomers.Add(ubaCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbaOneCustomer", new { id = ubaCustomer.Id }, ubaCustomer);
        }




        [HttpGet("ZenithBank")]
        public async Task<ActionResult<IEnumerable<ZenithCustomer>>> GetZenithCustomers()
        {
            var helperDataClass = new HelperDataClass();

            var details = helperDataClass.GetAllEmployeeBankDetails();

            List<ZenithCustomer> allZenithCustomers = await _context.ZenithCustomers.ToListAsync();
            List<CorrectBankDetails> correctBankDetails = new List<CorrectBankDetails>();
            var checkCount = details.employee.Take(5);
            foreach (var d in details.employee.Take(5))
            {
                await Task.Run(() => {
                    foreach (var x in allZenithCustomers)
                    {
                        if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
                        {
                            CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
                            {
                                AccountNumber = x.AccountNumber,
                                BankName = x.BankName,
                                AccountName = x.AccountName
                            };



                            correctBankDetails.Add(correctBankDetails1);

                        }

                    }
                });

            }
            var allValidZenithBank = correctBankDetails.ToList();

            return await _context.ZenithCustomers.ToListAsync();
        }



        [HttpGet("ZenithBank/{id}")]
        public async Task<ActionResult<ZenithCustomer>> GetZenithOneCustomer(int id)
        {
            var zenithCustomer = await _context.ZenithCustomers.FindAsync(id);

            if (zenithCustomer == null)
            {
                return NotFound();
            }

            return zenithCustomer;
        }

        [HttpPost("ZenithBank")]
        public async Task<ActionResult<ZenithCustomer>> PostEmployee(ZenithCustomer zenith)
        {
            _context.ZenithCustomers.Add(zenith);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZenithOneCustomer", new { id = zenith.Id }, zenith);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var helperDataClass = new HelperDataClass();

            var details = helperDataClass.GetAllEmployeeBankDetails();

            foreach (var d in details.employee)
            {
                
            }


            return await _context.Employees.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            return employee;
        }




        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee (Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Employee>> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;

                }

            }

            return NoContent();

        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null) {

                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;    


        }

    }
}