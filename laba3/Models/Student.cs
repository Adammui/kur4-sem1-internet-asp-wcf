using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace laba3.Models
{
    [Table("students", Schema = "public")]
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        [NotMapped]
        public HateoasLinks _links;
    }
}