using WebAPI___SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

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
            string query = "SELECT cases.case_id, month, CONCAT(users.firstName, ' ', users.lastName) AS supervisor, duration.length, type.name, sex.name AS sex, cases.niveau as niveau, \r\n (select string_agg(value,', ') from (select distinct value from string_split(string_agg(edu.name, ','),',')) edu) AS  education,\r\n (select string_agg(value,', ') from (select distinct value from string_split(string_agg(locations.name, ','),',')) q) AS location, \r\n (select string_agg(value,', ') from (select distinct value from string_split(string_agg(subject.name, ','),',')) w) AS subject \r\n \r\nFROM  cases\r\nINNER JOIN users ON cases.user_id = users.user_id \r\nINNER JOIN duration ON cases.duration_id = duration.duration_id \r\nINNER JOIN sex ON cases.sex_id = sex.sex_id \r\nINNER JOIN type ON cases.type_id = type.type_id \r\nINNER JOIN subject_case ON cases.case_id = subject_case.case_id \r\nINNER JOIN subject ON subject_case.subject_id = subject.subject_id\r\nINNER JOIN location_case ON location_case.case_id = cases.case_id\r\nINNER JOIN locations ON locations.location_id = location_case.location_id\r\nINNER JOIN edu_case ON cases.case_id = edu_case.case_id\r\nINNER JOIN edu ON edu_case.edu_id = edu.edu_id\r\nGROUP BY cases.case_id, month, users.firstName, users.lastName, duration.length, type.name, sex.name, cases.niveau ";
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
                                niveau = Convert.ToBoolean(sdr["niveau"]),
                                length = Convert.ToString(sdr["length"]),
                                education = Convert.ToString(sdr["education"]),
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


        // GET: api/Case/2
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Case>>> GetACases(int id)
        {

            List<Case> cases = new List<Case>();
            string query = " SELECT cases.case_id, month, CONCAT(users.firstName, ' ', users.lastName) AS supervisor, duration.length, type.name, sex.name AS sex, cases.niveau as niveau, \r\n (select string_agg(value,', ') from (select distinct value from string_split(string_agg(edu.name, ','),',')) edu) AS  education,\r\n (select string_agg(value,', ') from (select distinct value from string_split(string_agg(locations.name, ','),',')) q) AS location, \r\n (select string_agg(value,', ') from (select distinct value from string_split(string_agg(subject.name, ','),',')) w) AS subject \r\n \r\nFROM  cases\r\nINNER JOIN users ON cases.user_id = users.user_id \r\nINNER JOIN duration ON cases.duration_id = duration.duration_id \r\nINNER JOIN sex ON cases.sex_id = sex.sex_id \r\nINNER JOIN type ON cases.type_id = type.type_id \r\nINNER JOIN subject_case ON cases.case_id = subject_case.case_id \r\nINNER JOIN subject ON subject_case.subject_id = subject.subject_id\r\nINNER JOIN location_case ON location_case.case_id = cases.case_id\r\nINNER JOIN locations ON locations.location_id = location_case.location_id\r\nINNER JOIN edu_case ON cases.case_id = edu_case.case_id\r\nINNER JOIN edu ON edu_case.edu_id = edu.edu_id\r\nWHERE users.user_id = " + id + "\r\nGROUP BY cases.case_id, month, users.firstName, users.lastName, duration.length, type.name, sex.name, cases.niveau ";
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
                                niveau = Convert.ToBoolean(sdr["niveau"]),
                                length = Convert.ToString(sdr["length"]),
                                education = Convert.ToString(sdr["education"]),
                                location = Convert.ToString(sdr["location"]),
                                subject = Convert.ToString(sdr["subject"])
                            });
                        }
                    }
                    con.Close();
                }
            }
      
            return cases;
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
                //string query = "UPDATE cases SET month = @month, user_id = @user_id, sex_id = @sex_id, duration_id = @duration_id, type_id = @type_id, primeEdu = @primeEdu, niveau = @niveau, nationality = @nationality, edu_id = @edu_id, location_id = @location_id, subject_id = @subject_id  WHERE case_id = @case_id";
                string query = "BEGIN TRANSACTION\n ALTER TABLE cases nocheck constraint all;\n DECLARE @caseid int;\n UPDATE cases SET month = @month, user_id = @user_id, sex_id = @sex_id, duration_id = @duration_id, type_id = @type_id, primeEdu = @primeEdu, niveau = @niveau, nationality = @nationality \n WHERE case_id = @case_id;\n ALTER TABLE cases check constraint all;\n SELECT @caseid = scope_identity(); \n UPDATE edu_case SET case_id = @caseid, edu_id = @edu_id\n WHERE case_id = @caseid;\n UPDATE location_case SET case_id = @caseid, location_id = @location_id\n WHERE case_id = @caseid;\n UPDATE subject_case SET case_id = @caseid, subject_id = @subject_id\n WHERE case_id = @caseid;\nCOMMIT;\n";
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
                //string query = "INSERT INTO cases (month, niveau, nationality, user_id, sex_id, duration_id, type_id, primeEdu) VALUES (@month, @niveau, @nationality, @user_id, @sex_id, @duration_id, @type_id, @primeEdu); INSERT INTO edu_case(edu_id) VALUES (@edu_id) SELECT SCOPE_IDENTITY(); INSERT INTO location_case(location_id) VALUES (@location_id) SELECT SCOPE_IDENTITY(); INSERT INTO subject_case(subject_id) VALUES (@subject_id) SELECT SCOPE_IDENTITY()";
                string query = "INSERT INTO cases (month, niveau, nationality, user_id, sex_id, duration_id, type_id) VALUES (@month, @niveau, @nationality, @user_id, @sex_id, @duration_id, @type_id) SELECT SCOPE_IDENTITY();";
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


                    int modified = Convert.ToInt32(cmd.ExecuteScalar());
                    Case.case_id = modified;
                    if (modified > 0)
                    {
                        //return Ok();
                        return Ok(Case);
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
                //string query = "DELETE FROM cases WHERE case_id='" + id + "'";
                string query = "ALTER TABLE edu_case nocheck constraint all; ALTER TABLE location_case nocheck constraint all; ALTER TABLE subject_case nocheck constraint all; DELETE FROM cases WHERE case_id = '" + id + "'; DELETE FROM edu_case WHERE case_id = '" + id + "'; DELETE FROM location_case WHERE case_id = '" + id + "'; DELETE FROM subject_case WHERE case_id = '" + id + "';ALTER TABLE subject_case check constraint all; ALTER TABLE subject_case check constraint all; ALTER TABLE subject_case check constraint all";
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

