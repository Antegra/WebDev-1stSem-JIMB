using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI___SQL.Models;
using Sex = WebAPI___SQL.Models.Sex;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Sex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sex>>> GetAllSubjects()
        {
            List<Sex> sexes = new List<Sex>();
            string query = "SELECT * FROM sex";
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
                            sexes.Add(new Sex
                            {
                                sex_id = Convert.ToInt32(sdr["sex_id"]),
                                name = Convert.ToString(sdr["name"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return sexes;
        }

        // GET: api/Sex/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Sex>> GetSex(int id)
        {

            Sex sexObj = new Sex();
            string query = "SELECT * FROM sex WHERE sex_id=" + id;
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
                            sexObj = new Sex
                            {
                                sex_id = Convert.ToInt32(sdr["sex_id"]),
                                name = Convert.ToString(sdr["name"]),
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (sexObj == null)
            {
                return NotFound();
            }
            return sexObj;
        }

        // PUT: api/Sex/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSex(int id, Sex Sex)
        {
            if (id != Sex.sex_id)
            {
                return BadRequest();
            }
            Sex sex = new Sex();
            if (ModelState.IsValid)
            {
                string query = "UPDATE sex SET name = @name WHERE sex_id =@sex_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@name", Sex.name);
                        cmd.Parameters.AddWithValue("@sex_id", Sex.sex_id);
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

        // POST: api/Sex
        [HttpPost]
        public async Task<ActionResult<Sex>> PostSex(Sex Sex)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO sex VALUES (@name)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", Sex.name);
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

        // DELETE: api/Sex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSex(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM sex WHERE sex_id='" + id + "'";
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

