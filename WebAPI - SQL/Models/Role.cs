using System;
namespace WebAPI___SQL.Models
{
	public class Role
	{
        public int role_id { get; set; }
        public string title { get; set; }
        public virtual List<User> Users { get; set; }
    }
}

