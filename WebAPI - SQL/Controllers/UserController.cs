using WebAPI___SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI___SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT users.user_id, users.firstName, users.lastName, users.email, users.role_id, users.password, role.title, STRING_AGG (edu_user.edu_id, ', ') AS edu_id FROM users INNER JOIN role ON users.role_id = role.role_id INNER JOIN edu_user ON users.user_id = edu_user.user_id GROUP BY users.user_id, users.firstName, users.lastName, users.email, users.role_id, users.password, role.title";
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
                            users.Add(new User
                            {
                                user_id = Convert.ToInt32(sdr["user_id"]),
                                firstName = Convert.ToString(sdr["firstName"]),
                                lastName = Convert.ToString(sdr["firstName"]),
                                email = Convert.ToString(sdr["email"]),
                                password = Convert.ToString(sdr["password"]),
                                title = Convert.ToString(sdr["title"]),
                                role_id = Convert.ToInt32(sdr["role_id"]),
                                edu_id = Convert.ToString(sdr["edu_id"])
                            }) ;
                        }
                        con.Close();
                    }
                }
            }

            return users;
        }

        // GET: api/User/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {

            User userObj = new User();
            string query = "SELECT users.user_id, users.firstName, users.lastName, users.email, users.role_id, users.password, role.title, STRING_AGG (edu_user.edu_id, ', ') AS edu_id FROM users INNER JOIN role ON users.role_id = role.role_id INNER JOIN edu_user ON users.user_id = edu_user.user_id WHERE edu_user.user_id = " + id + "GROUP BY users.user_id, users.firstName, users.lastName, users.email, users.role_id, users.password, role.title";
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
                            userObj = new User
                            {
                                user_id = Convert.ToInt32(sdr["user_id"]),
                                firstName = Convert.ToString(sdr["firstName"]),
                                lastName = Convert.ToString(sdr["firstName"]),
                                email = Convert.ToString(sdr["email"]),
                                password = Convert.ToString(sdr["password"]),
                                title = Convert.ToString(sdr["title"]),
                                role_id = Convert.ToInt32(sdr["role_id"]),
                                edu_id = Convert.ToString(sdr["edu_id"])
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (userObj == null)
            {
                return NotFound();
            }
            return userObj;
        }

        // PUT: api/User/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.user_id)
            {
                return BadRequest();
            }
            User user = new User();
            if (ModelState.IsValid)
            {
                string query = "UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, password = @password, role_id = @roleId WHERE user_id = @user_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@user_id", User.user_id);
                        cmd.Parameters.AddWithValue("@firstName", User.firstName);
                        cmd.Parameters.AddWithValue("@lastName", User.lastName);
                        cmd.Parameters.AddWithValue("@email", User.email);
                        cmd.Parameters.AddWithValue("@password", User.password);
                        cmd.Parameters.AddWithValue("@roleId", User.role_id);
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

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO users (firstName, lastName, email, password, role_id) VALUES (@firstName, @lastName, @email, @password, @roleId)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@firstName", User.firstName);
                    cmd.Parameters.AddWithValue("@lastName", User.lastName);
                    cmd.Parameters.AddWithValue("@email", User.email);
                    cmd.Parameters.AddWithValue("@password", User.password);
                    cmd.Parameters.AddWithValue("@roleId", User.role_id);
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

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM users WHERE user_id='" + id + "'";
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

