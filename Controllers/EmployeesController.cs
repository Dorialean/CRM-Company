using Company_CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Npgsql;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public EmployeesController(IConfiguration configuration)
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
        public async Task<IActionResult> Get()
        {
            string json;
            using (var conn = new NpgsqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM get_reports();";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    NpgsqlDataReader emplQueryRes = await cmd.ExecuteReaderAsync();
                    //Выдаёт неправильно спаршенные строки
                    var r = Serialize(emplQueryRes);
                    json = JsonConvert.SerializeObject(r, Formatting.Indented);
                }
                return new JsonResult(json);
            }

            IEnumerable<Dictionary<string, object>> Serialize(NpgsqlDataReader reader)
            {
                var results = new List<Dictionary<string, object>>();
                var cols = new List<string>();
                for (var i = 0; i < reader.FieldCount; i++)
                    cols.Add(reader.GetName(i));

                while (reader.Read())
                    results.Add(SerializeRow(cols, reader));

                return results;
            }


            Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                NpgsqlDataReader reader)
            {
                var result = new Dictionary<string, object>();
                foreach (var col in cols)
                    result.Add(col, reader[col]);
                return result;
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
