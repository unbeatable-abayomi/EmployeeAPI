using ConsumeAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeAPI.HelperClassData
{
    public class EmployeeAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44332/");
            return client;
        }

        public AllEmployeeDetails GetAllEmployeeBankDetails()
        {
            var webClient = new WebClient();

            var json = webClient.DownloadString(@"C:\Users\Limbot Express\Downloads\Compressed\EmployeeWebAPIDemo\ConsumeAPI\wwwroot\json\employee.config.json");


            var allEmployeeBankDetails = JsonConvert.DeserializeObject<AllEmployeeDetails>(json);

            return allEmployeeBankDetails;

        }
    }
}
