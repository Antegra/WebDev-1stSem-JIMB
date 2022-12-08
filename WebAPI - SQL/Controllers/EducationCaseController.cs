using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI___SQL.Models;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationCaseController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/EducationCase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education_case>>> GetAllEducationCases()
        {
            List<Education_case> education_cases = new List<Education_case>();
            string query = "SELECT * FROM edu_case";
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
                            education_cases.Add(new Education_case
                            {
                                edu_id = Convert.ToInt32(sdr["edu_id"]),
                                case_id = Convert.ToInt32(sdr["case_id"]),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return education_cases;
        }

        // POST: api/EducationCase
        [HttpPost]
        public async Task<ActionResult<Education_case>> PostEducationCases(Education_case Education_case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO edu_case (edu_id, case_id) VALUES (@edu_id, @case_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@edu_id", Education_case.edu_id);
                    cmd.Parameters.AddWithValue("@case_id", Education_case.case_id);
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

        // DELETE: api/EducationCase/5
        [HttpDelete("{edu_id}, {case_id}")]
        public async Task<IActionResult> DeleteEducationCases(int edu_id, int case_id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM edu_case WHERE edu_id ='" + edu_id + "' AND case_id ='" + case_id + "'";
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
