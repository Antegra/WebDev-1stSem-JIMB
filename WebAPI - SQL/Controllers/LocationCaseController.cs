using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI___SQL.Models;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationCaseController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/LocationCase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location_case>>> GetAllLocationCases()
        {
            List<Location_case> location_cases = new List<Location_case>();
            string query = "SELECT * FROM location_case";
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
                            location_cases.Add(new Location_case
                            {
                                location_id = Convert.ToInt32(sdr["location_id"]),
                                case_id = Convert.ToInt32(sdr["case_id"]),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return location_cases;
        }

        // POST: api/LocationCase
        [HttpPost]
        public async Task<ActionResult<Location_case>> PostLocationCases(Location_case Location_case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO location_case (location_id, case_id) VALUES (@location_id, @case_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@location_id", Location_case.location_id);
                    cmd.Parameters.AddWithValue("@case_id", Location_case.case_id);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        return Ok();
                    }
                    con.Close();
                }
            }
            return BadRequest();

        }

        // DELETE: api/LocationCase/5
        [HttpDelete("{location_id}, {case_id}")]
        public async Task<IActionResult> DeleteLocationCases(int location_id, int case_id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM location_case WHERE location_id ='" + location_id + "' AND case_id ='" + case_id + "'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        return NoContent();
                    }
                    con.Close();
                }
            }
            return BadRequest();
        }

    }
}

