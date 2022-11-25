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
        string constr = "data source=uclssdemo.database.windows.net; initial catalog=Studieservice; user id=awesomegroupx; password=t4prSlX1JCZ0Ujv";

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT users.user_id, users.firstName, users.lastName, users.email, users.password, role.title FROM users INNER JOIN role ON users.role_id = role.role_id";
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
                                title = Convert.ToString(sdr["title"])
                            }) ;
                        }
                        con.Close();
                    }
                }
            }

            return users ;
        }

        // GET: api/User/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {

            User usersObj = new User();
            string query = "SELECT users.user_id, users.firstName, users.lastName, users.email, users.password, role.title FROM users INNER JOIN role ON users.role_id = role.role_id WHERE user_id=" + id;
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
                            usersObj = new User
                            {
                                user_id = Convert.ToInt32(sdr["user_id"]),
                                firstName = Convert.ToString(sdr["firstName"]),
                                lastName = Convert.ToString(sdr["firstName"]),
                                email = Convert.ToString(sdr["email"]),
                                password = Convert.ToString(sdr["password"]),
                                title = Convert.ToString(sdr["title"])
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (usersObj == null)
            {
                return NotFound();
            }
            return usersObj;
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
                string query = "UPDATE users SET users.firstName = @firstName, users.lastName = @lastName, users.email = @email, users.password = @password, role.title = @title FROM users INNER JOIN role ON users.role_id = role.role_id WHERE users.user_id =" + id;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@firstName", User.firstName);
                        cmd.Parameters.AddWithValue("@lastName", User.lastName);
                        cmd.Parameters.AddWithValue("@email", User.email);
                        cmd.Parameters.AddWithValue("@password", User.password);
                        cmd.Parameters.AddWithValue("@title", User.title);
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
                string query = "INSERT INTO users (users.firstName, users.lastName, users.email, users.password) VALUES (@firstName, @lastName, @email, @password)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@firstName", User.firstName);
                    cmd.Parameters.AddWithValue("@lastName", User.lastName);
                    cmd.Parameters.AddWithValue("@email", User.email);
                    cmd.Parameters.AddWithValue("@password", User.password);
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

    }

}

