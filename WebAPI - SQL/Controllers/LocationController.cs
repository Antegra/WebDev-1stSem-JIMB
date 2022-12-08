using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI___SQL.Models;
using Location = WebAPI___SQL.Models.Location;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllSubjects()
        {
            List<Location> locations = new List<Location>();
            string query = "SELECT * FROM locations";
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
                            locations.Add(new Location
                            {
                                location_id = Convert.ToInt32(sdr["location_id"]),
                                name = Convert.ToString(sdr["name"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return locations;
        }

        // GET: api/Location/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {

            Location locationObj = new Location();
            string query = "SELECT * FROM locations WHERE location_id=" + id;
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
                            locationObj = new Location
                            {
                                location_id = Convert.ToInt32(sdr["location_id"]),
                                name = Convert.ToString(sdr["name"]),
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (locationObj == null)
            {
                return NotFound();
            }
            return locationObj;
        }

        // PUT: api/Location/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location Location)
        {
            if (id != Location.location_id)
            {
                return BadRequest();
            }
            Location location = new Location();
            if (ModelState.IsValid)
            {
                string query = "UPDATE locations SET name = @name WHERE location_id =@location_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@name", Location.name);
                        cmd.Parameters.AddWithValue("@location_id", Location.location_id);
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

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location Location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO locations VALUES (@name)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", Location.name);
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

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM locations WHERE location_id='" + id + "'";
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

