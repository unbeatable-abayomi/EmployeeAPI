using EmployeeWebAPIDemo.Models;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ParkWayProject2.HelperMethods
{
    public class HelperDataClass
    {

        public AllEmployeeDetails GetAllEmployeeBankDetails()
        {
            var webClient = new WebClient();

            var json = webClient.DownloadString(@"C:\Users\Limbot Express\Downloads\Compressed\EmployeeWebAPIDemo\EmployeeWebAPIDemo\json\employee.config.json");


            var allEmployeeBankDetails = JsonConvert.DeserializeObject<AllEmployeeDetails>(json);

            return allEmployeeBankDetails;

        }
    }
}
