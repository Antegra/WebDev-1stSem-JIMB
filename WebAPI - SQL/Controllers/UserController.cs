﻿using WebAPI___SQL.Models;
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
        string constr = "";

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = new List<User>();
            List<Role> roles = new List<Role>();
            string query = "SELECT users.user_id, users.firstName, users.lastName, users.email, role.title FROM users INNER JOIN role ON users.role_id = role.role_id";
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
                            // var x = from user in users
                            //             join role in roles on user.role_id equals role.role_id
                            //             select new { user.firstName, user.lastName, user.email, role.title };

                            // foreach (var item in x)
                            // {
                            //     Console.WriteLine($"{item.firstName} - {item.title}");
                            // }
                        }
                        con.Close();
                    }
                }
            }

            return users ;
        }
    }

 }

