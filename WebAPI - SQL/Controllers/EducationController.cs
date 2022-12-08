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
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Education
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetAllEducations()
        {
            List<Education> educations = new List<Education>();
            string query = "SELECT edu.edu_id, edu.name,  \r\n(select string_agg(value,', ') from (select distinct value from string_split(string_agg(locations.name, ','),',')) q) AS location  FROM edu\r\nINNER JOIN edu_location ON edu.edu_id = edu_location.edu_id\r\nINNER JOIN locations ON edu_location.location_id = locations.location_id\r\nGROUP BY edu.edu_id, edu.name";
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
                                location = Convert.ToString(sdr["location"])
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
            string query = "SELECT edu.edu_id, edu.name,  \r\n(select string_agg(value,', ') from (select distinct value from string_split(string_agg(locations.name, ','),',')) q) AS location  FROM edu\r\nINNER JOIN edu_location ON edu.edu_id = edu_location.edu_id\r\nINNER JOIN locations ON edu_location.location_id = locations.location_id\r\nWHERE edu.edu_id =" + id + "\r\nGROUP BY edu.edu_id, edu.name" ;
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
                                location = Convert.ToString(sdr["location"])
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