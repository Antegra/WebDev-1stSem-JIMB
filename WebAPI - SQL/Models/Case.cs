using System;
using WebAPI___SQL.Models;

namespace WebAPI___SQL.Models
{
	public class Case
	{
        public int case_id { get; set; }
        public DateTime month { get; set; }
        public string name { get; set; }
        public string supervisor { get; set; }
        public string sex { get; set; }
        public string length { get; set; }
        public string education { get; set; }
        public string location { get; set; }
        public string subject { get; set; }
        public int user_id { get; set; }
        public int sex_id { get; set; }
        public int duration_id { get; set; }
        public int type_id { get; set; }
        public int edu_id { get; set; }
        public int location_id { get; set; }
        public int subject_id { get; set; }
        public int primeEdu { get; set; }
        public bool niveau { get; set; }
        public bool nationality { get; set; }
    }
}

