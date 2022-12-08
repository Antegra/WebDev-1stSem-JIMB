using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI___SQL.Models;
using Type = WebAPI___SQL.Models.Type;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetAllSubjects()
        {
            List<Type> types = new List<Type>();
            string query = "SELECT * FROM type";
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
                            types.Add(new Type
                            {
                                type_id = Convert.ToInt32(sdr["type_id"]),
                                name = Convert.ToString(sdr["name"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return types;
        }

        // GET: api/Type/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Type>> GetType(int id)
        {

            Type typeObj = new Type();
            string query = "SELECT * FROM type WHERE type_id=" + id;
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
                            typeObj = new Type
                            {
                                type_id = Convert.ToInt32(sdr["type_id"]),
                                name = Convert.ToString(sdr["name"]),
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (typeObj == null)
            {
                return NotFound();
            }
            return typeObj;
        }

        // PUT: api/Type/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType(int id, Type Type)
        {
            if (id != Type.type_id)
            {
                return BadRequest();
            }
            Type type = new Type();
            if (ModelState.IsValid)
            {
                string query = "UPDATE type SET name = @name WHERE type_id =@type_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@name", Type.name);
                        cmd.Parameters.AddWithValue("@type_id", Type.type_id);
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

        // POST: api/Type
        [HttpPost]
        public async Task<ActionResult<Type>> PostType(Type Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO type VALUES (@name)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", Type.name);
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

        // DELETE: api/Type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM type WHERE type_id='" + id + "'";
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

