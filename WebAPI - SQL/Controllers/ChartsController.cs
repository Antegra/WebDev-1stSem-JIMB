using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI___SQL.Models;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        

        [HttpGet("{id}")]
        public async Task<ActionResult<Chart>> GetChartCasesPerMonth(int id)
        {

            Chart ChartCasesPerMonthObj = new Chart();
            string query = "SELECT COUNT(*) AS 'CasesPerMonth' FROM cases WHERE month LIKE '2022-" + id + "%'; ";
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
                            ChartCasesPerMonthObj = new Chart
                            {
                                ChartCasesPerMonth = Convert.ToInt32(sdr["CasesPerMonth"])
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
