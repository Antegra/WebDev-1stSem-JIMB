using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace WebAPI___SQL.Models
{
	public class User
	{
        public int user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string title { get; set; }
    }
}

