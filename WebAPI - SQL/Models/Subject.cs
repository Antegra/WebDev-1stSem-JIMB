using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace WebAPI___SQL.Models
{
    public class Subject
    {
        public int subject_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}

