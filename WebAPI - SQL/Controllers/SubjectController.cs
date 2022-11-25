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
    public class SubjectController : ControllerBase
    {
        string constr = "data source=uclssdemo.database.windows.net; initial catalog=Studieservice; user id=awesomegroupx; password=t4prSlX1JCZ0Ujv";

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            string query = "SELECT * FROM subject";
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
                            subjects.Add(new Subject
                            {
                                subject_id = Convert.ToInt32(sdr["subject_id"]),
                                name = Convert.ToString(sdr["name"]),
                                description = Convert.ToString(sdr["description"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return subjects;
        }

        // GET: api/Subject/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {

            Subject subjectObj = new Subject();
            string query = "SELECT * FROM subject WHERE subject_id=" + id;
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
                            subjectObj = new Subject
                            {
                                subject_id = Convert.ToInt32(sdr["subject_id"]),
                                name = Convert.ToString(sdr["name"]),
                                description = Convert.ToString(sdr["description"]),
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (subjectObj == null)
            {
                return NotFound();
            }
            return subjectObj;
        }

        // PUT: api/Subject/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject Subject)
        {
            if (id != Subject.subject_id)
            {
                return BadRequest();
            }
            Subject subject = new Subject();
            if (ModelState.IsValid)
            {
                string query = "UPDATE subject SET name = @name, description = @description WHERE subject_id =@subject_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@name", Subject.name);
                        cmd.Parameters.AddWithValue("@description", Subject.description);
                        cmd.Parameters.AddWithValue("@subject_id", Subject.subject_id);
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

        // POST: api/Subject
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject Subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO subject VALUES (@name, @description)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", Subject.name);
                    cmd.Parameters.AddWithValue("@description", Subject.description);
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

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM subject WHERE subject_id='" + id + "'";
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