using System;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI___SQL.Models;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EduUserController  : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/SubjectCase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Edu_user>>> GetAllEduUsers()
        {
            List<Edu_user> edu_user = new List<Edu_user>();
            string query = "SELECT * FROM edu_user";
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
                            edu_user.Add(new Edu_user
                            {
                                edu_id = Convert.ToInt32(sdr["edu_id"]),
                                user_id = Convert.ToInt32(sdr["user_id"]),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return edu_user;
        }

        // POST: api/EduUser
        [HttpPost]
        public async Task<ActionResult<Subject_case>> PostEduUsers(Edu_user Edu_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                //inserting Patient data into database
                string query = "INSERT INTO edu_user (edu_id, user_id) VALUES (@edu_id, @user_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@user_id", Edu_user.user_id);
                    cmd.Parameters.AddWithValue("@edu_id", Edu_user.edu_id);
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

        // DELETE: api/EduUser/5
        [HttpDelete("{edu_id}, {user_id}")]
        public async Task<IActionResult> DeleteEduUsers(int edu_id, int user_id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM edu_user WHERE edu_id ='" + edu_id + "' AND user_id ='" + user_id + "'";
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

