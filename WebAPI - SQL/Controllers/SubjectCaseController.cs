using System;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI___SQL.Models;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectCaseController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/SubjectCase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject_case>>> GetAllSubjectCases()
        {
            List<Subject_case> subject_cases = new List<Subject_case>();
            string query = "SELECT * FROM subject_case";
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
                            subject_cases.Add(new Subject_case
                            {
                                subject_id = Convert.ToInt32(sdr["subject_id"]),
                                case_id = Convert.ToInt32(sdr["case_id"]),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return subject_cases;
        }

        // POST: api/SubjectCase
        [HttpPost]
        public async Task<ActionResult<Subject_case>> PostSubjectCases(Subject_case Subject_case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO subject_case (subject_id, case_id) VALUES (@subject_id, @case_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@subject_id", Subject_case.subject_id);
                    cmd.Parameters.AddWithValue("@case_id", Subject_case.case_id);
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

        // DELETE: api/SubjectCase/5
        [HttpDelete("{subject_id}, {case_id}")]
        public async Task<IActionResult> DeleteSubjectCases(int subject_id, int case_id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM subject_case WHERE subject_id ='" + subject_id + "' AND case_id ='" + case_id + "'";
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

