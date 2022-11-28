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
    public class CaseController : ControllerBase
    {
        string constr = "Server=tcp:uclssdemo.database.windows.net,1433;Initial Catalog=studieservice;Persist Security Info=False;User ID=awesomegroupx;Password=t4prSlX1JCZ0Ujv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Case
        [HttpGet]
        public async Task<ActionResult<List<Case>>> GetAllCases()
        {
            List<Case> cases = new List<Case>();
            string query = "SELECT cases.case_id, month, CONCAT(users.firstName, ' ', users.lastName) AS supervisor, duration.length, type.name, sex.name AS sex, edu.name AS education, locations.name AS location, subject.name AS subject FROM cases INNER JOIN users ON cases.user_id = users.user_id INNER JOIN duration ON cases.duration_id = duration.duration_id INNER JOIN sex ON cases.sex_id = sex.sex_id INNER JOIN type ON cases.type_id = type.type_id INNER JOIN subject_case ON cases.case_id = subject_case.case_id INNER JOIN subject ON subject_case.subject_id = subject.subject_id\nINNER JOIN location_case ON location_case.case_id = cases.case_id\nINNER JOIN locations ON locations.location_id = location_case.location_id INNER JOIN edu_case ON cases.case_id = edu_case.case_id INNER JOIN edu ON edu_case.edu_id = edu.edu_id;";
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
                            cases.Add(new Case
                            {
                                case_id = Convert.ToInt32(sdr["case_id"]),
                                month = Convert.ToDateTime(sdr["month"]),
                                name = Convert.ToString(sdr["name"]),
                                supervisor = Convert.ToString(sdr["supervisor"]),
                                sex = Convert.ToString(sdr["sex"]),
                                length = Convert.ToString(sdr["length"]),
                                education= Convert.ToString(sdr["education"]),
                                location = Convert.ToString(sdr["location"]),
                                subject = Convert.ToString(sdr["subject"])
                            });
                        }
                        con.Close();
                    }
                }
            }

            return cases;
        }

        // GET: api/Case/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetUsers(int id)
        {

            Case caseObj = new Case();
            string query = "SELECT cases.case_id, month, CONCAT(users.firstName, ' ', users.lastName) AS Vejleder, duration.length, type.name, sex.name AS Køn, edu.name AS Uddannelse, locations.name AS Uddannelsested, subject.name AS Emne FROM cases INNER JOIN users ON cases.user_id = users.user_id INNER JOIN duration ON cases.duration_id = duration.duration_id INNER JOIN sex ON cases.sex_id = sex.sex_id INNER JOIN type ON cases.type_id = type.type_id INNER JOIN subject_case ON cases.case_id = subject_case.case_id INNER JOIN subject ON subject_case.subject_id = subject.subject_id\nINNER JOIN location_case ON location_case.case_id = cases.case_id\nINNER JOIN locations ON locations.location_id = location_case.location_id INNER JOIN edu_case ON cases.case_id = edu_case.case_id INNER JOIN edu ON edu_case.edu_id = edu.edu_id WHERE cases.case_id=" + id;
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
                            caseObj = new Case
                            {
                                case_id = Convert.ToInt32(sdr["case_id"]),
                                month = Convert.ToDateTime(sdr["month"]),
                                name = Convert.ToString(sdr["name"]),
                                supervisor = Convert.ToString(sdr["supervisor"]),
                                sex = Convert.ToString(sdr["sex"]),
                                length = Convert.ToString(sdr["length"]),
                                education = Convert.ToString(sdr["education"]),
                                location = Convert.ToString(sdr["location"]),
                                subject = Convert.ToString(sdr["subject"])
                            };
                        }
                    }
                    con.Close();
                }
            }
            if (caseObj == null)
            {
                return NotFound();
            }
            return caseObj;
        }


        // PUT: api/Case/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCase(int id, Case Case)
        {
            if (id != Case.case_id)
            {
                return BadRequest();
            }
            Case @case = new Case();
            if (ModelState.IsValid)
            {
                string query = "UPDATE cases SET month = @month, user_id = @user_id, sex_id = @sex_id, duration_id = @duration_id, type_id = @type_id, primeEdu = @primeEdu, niveau = @niveau, nationality = @nationality, edu_id = @edu_id, location_id = @location_id, subject_id = @subject_id  WHERE case_id = @case_id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@case_id", Case.case_id);
                        cmd.Parameters.AddWithValue("@month", Case.month);
                        cmd.Parameters.AddWithValue("@user_id", Case.user_id);
                        cmd.Parameters.AddWithValue("@sex_id", Case.sex_id);
                        cmd.Parameters.AddWithValue("@duration_id", Case.duration_id);
                        cmd.Parameters.AddWithValue("@type_id", Case.type_id);
                        cmd.Parameters.AddWithValue("@primeEdu", Case.primeEdu);
                        cmd.Parameters.AddWithValue("@niveau", Case.niveau);
                        cmd.Parameters.AddWithValue("@nationality", Case.nationality);
                        cmd.Parameters.AddWithValue("@edu_id", Case.edu_id);
                        cmd.Parameters.AddWithValue("@location_id", Case.location_id);
                        cmd.Parameters.AddWithValue("@subject_id", Case.subject_id);

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

        // POST: api/Case
        [HttpPost]
        public async Task<ActionResult<User>> PostCase(Case Case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO cases (month, user_id, sex_id, duration_id, type_id, primeEdu, edu_id, location_id, subject_id, niveau, nationality) VALUES (@month, @user_id, @sex_id, @duration_id, @type_id, @primeEdu, @edu_id, @location_id, @subject_id, @niveau, @nationality) SELECT edu_id FROM edu_case  INNER JOIN cases ON  cases.case_id = edu_case.case_id SELECT location_id FROM location_case  INNER JOIN cases ON  cases.case_id = location_case.case_id SELECT subject_id FROM subject_case  INNER JOIN cases ON  cases.case_id = subject_case.case_id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@month", Case.month);
                    cmd.Parameters.AddWithValue("@user_id", Case.user_id);
                    cmd.Parameters.AddWithValue("@sex_id", Case.sex_id);
                    cmd.Parameters.AddWithValue("@duration_id", Case.duration_id);
                    cmd.Parameters.AddWithValue("@type_id", Case.type_id);
                    cmd.Parameters.AddWithValue("@primeEdu", Case.primeEdu);
                    cmd.Parameters.AddWithValue("@niveau", Case.niveau);
                    cmd.Parameters.AddWithValue("@nationality", Case.nationality);
                    cmd.Parameters.AddWithValue("@edu_id", Case.edu_id);
                    cmd.Parameters.AddWithValue("@location_id", Case.location_id);
                    cmd.Parameters.AddWithValue("@subject_id", Case.subject_id);
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

        // DELETE: api/Case/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM cases WHERE case_id='" + id + "'";
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

