using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPIDemo.Models
{
    public class EmployeeAppDBContext : DbContext
    {


        public EmployeeAppDBContext(DbContextOptions<EmployeeAppDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
       public DbSet<UbaCustomer> ubaCustomers { get; set; }
       public DbSet<ZenithCustomer> ZenithCustomers { get; set; }
      
    }
}
