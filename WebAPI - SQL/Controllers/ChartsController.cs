using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        // GET: api/<ChartsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChartCasesPerMont>> GetChartCasesPerMonth(int id)
        {

            ChartCasesPerMonth ChartCasesPerMonthObj = new ChartCasesPerMonth();
            string query = "SELECT COUNT(*) AS 'CasesPerMonth' FROM cases WHERE month LIKE '2022-" + id "%'; ";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ChartCasesPerMonthObj = new ChartCasesPerMonth
                            {
                                duration_id = Convert.ToInt32(sdr["duration_id"]),
                                length = Convert.ToString(sdr["length"]),
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (ChartCasesPerMonthObj == null)
            {
                return NotFound();
            }
            return ChartCasesPerMonthObj;
        }

        // GET api/<ChartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChartsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
