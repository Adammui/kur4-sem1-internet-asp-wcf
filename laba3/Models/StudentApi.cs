using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace laba3.Models
{
    public class StudentApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        [XmlIgnore]
        public HateoasMethods HateOas { get; set; }

        public StudentApi()
        {

        }

        public StudentApi(Student student, HateoasMethods hateoas)
        {
            Id = student.id;
            Name = student.name;
            Phone = student.phone;
            HateOas = hateoas;
        }
    }
}