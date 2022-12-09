using System;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI___SQL.Models;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationUserController  : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/SubjectCase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location_user>>> GetAllLocationUser()
        {
            List<Location_user> location_user = new List<Location_user>();
            string query = "SELECT * FROM location_user";
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
                            location_user.Add(new Location_user
                            {
                                location_id = Convert.ToInt32(sdr["location_id"]),
                                user_id = Convert.ToInt32(sdr["user_id"]),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return location_user;
        }

        // POST: api/EduUser
        [HttpPost]
        public async Task<ActionResult<Location_user>> PostLocationUser(Location_user Location_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO location_user (location_id, user_id) VALUES (@location_id, @user_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@user_id", Location_user.user_id);
                    cmd.Parameters.AddWithValue("@location_id", Location_user.location_id);
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

        // Update: api/EduUser/5
        [HttpDelete("{CurrentLocation_id},{location_id}, {user_id}")]
        public async Task<IActionResult> UpdateEduUsers(int CurrentLocation_id, int location_id, int user_id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "UPDATE location_user SET location_id = " + location_id + " WHERE location_id = "+ CurrentLocation_id + " AND user_id = " + user_id +"";
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

