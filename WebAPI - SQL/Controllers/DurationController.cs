using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI___SQL.Models;
using Duration = WebAPI___SQL.Models.Duration;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DurationController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Duration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duration>>> GetAllSubjects()
        {
            List<Duration> durations = new List<Duration>();
            string query = "SELECT * FROM duration";
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
                            durations.Add(new Duration
                            {
                                duration_id = Convert.ToInt32(sdr["duration_id"]),
                                length = Convert.ToString(sdr["length"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return durations;
        }

        // GET: api/Duration/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Duration>> GetDuration(int id)
        {

            Duration durationObj = new Duration();
            string query = "SELECT * FROM duration WHERE duration_id=" + id;
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
                            durationObj = new Duration
                            {
                                duration_id = Convert.ToInt32(sdr["duration_id"]),
                                length = Convert.ToString(sdr["length"]),
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (durationObj == null)
            {
                return NotFound();
            }
            return durationObj;
        }

        // PUT: api/Duration/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuration(int id, Duration Duration)
        {
            if (id != Duration.duration_id)
            {
                return BadRequest();
            }
            Duration duration = new Duration();
            if (ModelState.IsValid)
            {
                string query = "UPDATE duration SET length = @length WHERE duration_id =@duration_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@length", Duration.length);
                        cmd.Parameters.AddWithValue("@duration_id", Duration.duration_id);
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

        // POST: api/Duration
        [HttpPost]
        public async Task<ActionResult<Duration>> PostDuration(Duration Duration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO duration VALUES (@length)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@length", Duration.length);
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

        // DELETE: api/Duration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuration(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM duration WHERE duration_id='" + id + "'";
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

