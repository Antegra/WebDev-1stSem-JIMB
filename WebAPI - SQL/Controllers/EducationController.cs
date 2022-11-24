using WebAPI___SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        string constr = "data source=uclssdemo.database.windows.net; initial catalog=Studieservice; user id=awesomegroupx; password=t4prSlX1JCZ0Ujv";

        // GET: api/Educations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetAllEducations()
        {
            List<Education> educations = new List<Education>();
            string query = "SELECT * FROM edu";
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
                            educations.Add(new Education
                            {
                                edu_id = Convert.ToInt32(sdr["edu_id"]),
                                name = Convert.ToString(sdr["name"]),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return educations;
        }

        // GET: api/Education/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {

            Education educationObj = new Education();
            string query = "SELECT * FROM edu WHERE edu_id=" + id;
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
                            educationObj = new Education
                            {
                                edu_id = Convert.ToInt32(sdr["edu_id"]),
                                name = Convert.ToString(sdr["name"]),
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (educationObj == null)
            {
                return NotFound();
            }
            return educationObj;
        }

        // PUT: api/Education/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(int id, Education Education)
        {
            if (id != Education.edu_id)
            {
                return BadRequest();
            }
            Education education = new Education();
            if (ModelState.IsValid)
            {
                string query = "UPDATE edu SET name = @name WHERE edu_id =@edu_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@name", Education.name);
                        cmd.Parameters.AddWithValue("@edu_id", Education.edu_id);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            return NoContent();
                        }
                        con.Close();
                    }
                }

            }
            return BadRequest(ModelState);
        }

        // POST: api/Education
        [HttpPost]
        public async Task<ActionResult<Education>> PostEducation(Education Education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO edu VALUES (@name)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", Education.name);
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

        // DELETE: api/Education/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM edu WHERE edu_id='" + id + "'";
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