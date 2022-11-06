using Company_CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using Npgsql;
using NuGet.Protocol;
using System;
using System.Runtime.InteropServices;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesReportController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public EmployeesReportController(IConfiguration configuration)
        {
            _configuration = configuration;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                connectionString = configuration.GetConnectionString("LaptopConnectionString");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                connectionString = configuration.GetConnectionString("WindowsConntectionString");
            else
                connectionString = configuration.GetConnectionString("MacConntectionString");
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReport>>> Get()
        {
            List<EmployeeReport> report = new();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM get_reports();";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    var emplQueryRes = await cmd.ExecuteReaderAsync();
                    
                    while(await emplQueryRes.ReadAsync())
                    {
                        report.Add(new EmployeeReport()
                        {
                            EmployeeId = emplQueryRes.GetInt32(0),
                            AllTasks = emplQueryRes.GetInt32(1),
                            InTimeCompleted = emplQueryRes.GetInt32(2),
                            NotInTimeCompleted = emplQueryRes.GetInt32(3),
                            FailedTasks = emplQueryRes.GetInt32(4),
                            InWorkTasks = emplQueryRes.GetInt32(5)
                        });
                    }
                }
                return report;
            }
        }
    }
}
