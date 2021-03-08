using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIDemo.Models
{
    public class AllEmployeeDetails
    {
        public IEnumerable<EmployeeDetails> employee { get; set; }
    }
}
