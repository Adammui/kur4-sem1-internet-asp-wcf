using System.Web.Http;
using System.Web.WebPages;
using System.Linq;
using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using laba3.DataContext;
using laba3.Models;

namespace laba3.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentsContext DB = new StudentsContext();

        [HttpGet]
        [Route("api/students{format:regex([.](json)|[.](xml))}")]
        public object GetStudents(string format, [FromUri] string[] parameters)
        {
            var students = DB.Students.ToList();
            var localhost = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            // var format = "";
            // string path = "students.json";

            var requestParams = Request.GetQueryNameValuePairs();

            var limit = requestParams.Where(p => p.Key.Equals("limit")).ToList(); // +
            var sort = requestParams.Where(p => p.Key.Equals("sort")).ToList(); // +
            var offset = requestParams.Where(p => p.Key.Equals("offset")).ToList(); // +
            var minid = requestParams.Where(p => p.Key.Equals("minid")).ToList(); // +
            var maxid = requestParams.Where(p => p.Key.Equals("maxid")).ToList();// +
            var like = requestParams.Where(p => p.Key.Equals("like")).ToList(); // not sure about this so changed it +
            var columns = requestParams.Where(p => p.Key.Equals("columns")).ToList(); // +
            var globalike = requestParams.Where(p => p.Key.Equals("globalike")).ToList(); // not sure +-
            // var xml = requestParams.Where(p => p.Key.Equals("xml")).ToList(); // not like this. should be like api.xml -

            var resultList = students;

            if (limit.Count == 1 || offset.Count == 1)
            {
                if (limit.Count == 1 && offset.Count == 1)
                {
                    resultList = students.Skip(int.Parse(offset[0].Value)).Take(int.Parse(limit[0].Value)).ToList();
                }
                else if (limit.Count == 1 && offset.Count < 1)
                {
                    resultList = students.Take(int.Parse(limit[0].Value)).ToList();
                }
                else if (offset.Count == 1 && limit.Count < 1)
                {
                    resultList = students.Skip(int.Parse(offset[0].Value)).ToList();
                }
            }

            if (sort.Count == 1)
            {
                resultList = resultList.OrderBy(s => s.name).ToList();
            }

            if (minid.Count == 1)
            {
                int min = int.Parse(minid[0].Value);
                resultList = resultList.Where(s => s.id >= min).ToList();
            }

            if (maxid.Count == 1)
            {
                int max = int.Parse(maxid[0].Value);
                resultList = resultList.Where(s => s.id <= max).ToList();
            }

            if (like.Count == 1)
            {
                string name = like[0].Value;
                resultList = resultList.Where(s => s.name.Contains(name)).ToList();
            }

            var studentApi = new List<StudentApi>();

            foreach (var student in resultList)
            {
                studentApi.Add(new StudentApi(student, new HateoasMethods( new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "GET"),
                new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "PUT"),
                new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "POST"),
                new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "DELETE")
                )));
            }

            if (globalike.Count() == 1)
            {
                string columnValue = globalike[0].Value;
                studentApi = studentApi.Where(s => string.Concat(s.Id.ToString(), s.Name, s.Phone).Contains(columnValue)).ToList();
            }

            if (columns.Count() == 1)
            {
                string columnValue = columns[0].Value;
                string[] arr = columnValue.Split(",".ToCharArray());
                bool id = false, name = false, phone = false;

                foreach (string val in arr)
                {
                    if (val == "id")
                        id = true;

                    if (val == "name")
                        name = true;

                    if (val == "phone")
                        phone = true;
                }

                if (!id)
                {
                    foreach (var field in studentApi)
                    {
                        field.Id = 0;
                    }
                }
                if (!name)
                {
                    foreach (var field in studentApi)
                    {
                        field.Name = "";
                    }
                }
                if (!phone)
                {
                    foreach (var field in studentApi)
                    {
                        field.Phone = "";
                    }
                }
            }

            //var jsonSerialiser = new JavaScriptSerializer();
            //string resultHateoasString;
            //if (format == "xml")
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(List<StudentApi>));
            //    var stringwriter = new System.IO.StringWriter();
            //    serializer.Serialize(stringwriter, studentApi);
            //    resultHateoasString = stringwriter.ToString();
            //    return Ok(resultHateoasString);
            //}
            //else
            //{
            //   
            //    return Ok(studentApi);
            //}
            //return JsonSerializer.Serialize(studentApi);
            // if (path.Equals("students.json")) { return Json(studentApi); }

            if (format.Equals(".xml"))
            {

                return Ok(studentApi);
            }

            return Json(studentApi);
        }
        [HttpGet]
        [Route("api/students{format:regex([.](json)|[.](xml))}/{id}")]
        public object GetStudent(string format, int id)
        {
            var localhost = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            Student student = DB.Students.FirstOrDefault(s => s.id == id);
            //if (student == null)
            //    return Content(HttpStatusCode.BadRequest,
            //        new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            if (student == null)
                return Content(HttpStatusCode.BadRequest, new Hateoas($"{localhost}/api/error/4404", "error 404", "GET"));

            var studentApi = new List<StudentApi>();
            studentApi.Add(new StudentApi(student, new HateoasMethods(new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "GET"),
                new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "PUT"),
                new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "POST"),
                new Hateoas($"{localhost}/api/students{format}/" + student.id, student.id.ToString(), "DELETE"))));

            if (format.Equals(".xml"))
            {
                return Ok(studentApi);
            }

            return Json(studentApi);
        }
        




        //[HttpGet]
        //[ResponseType(typeof(Student))]
        //public object GetStudent(int id)
        //{
        //    var localhost = Request.RequestUri.GetLeftPart(UriPartial.Authority);
        //    Student student = _context.Students.FirstOrDefault(s => s.id == id);
        //    if (student == null)
        //        return Content(HttpStatusCode.NotFound, new Hateoas($"{localhost}/api/error/404", "error.404", "GET"));

        //    return Ok(new StudentApi(student, new Hateoas($"{localhost}/api/students/" + id, "self", "GET")));
        //}

        [HttpPost]
        [ResponseType(typeof(Student))]
        public object AddStudent(Student student)
        {
            var localhost = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, hateoas = new Hateoas($"{localhost}/api/error/4400", "error 400", "POST") });
            }

            DB.Students.Add(student);
            DB.SaveChanges();
            student.id = DB.Students.ToList().OrderByDescending(s => s.id).First().id;

            return Content(HttpStatusCode.Created, new StudentApi(student, new HateoasMethods(new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "GET"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "PUT"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "POST"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "DELETE"))));
        }

        [HttpPut]
        [ResponseType(typeof(Student))]
        public object UpdateStudent(Student student)
        {
            var localhost = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, hateoas = new Hateoas($"{localhost}/api/error/4400", "error 400", "PUT") });
            }

            Student new_student = DB.Students.FirstOrDefault(s => s.id == student.id);
            if (new_student != null)
            {
                new_student.name = student.name;
                new_student.phone = student.phone;

                DB.SaveChanges();
            }

            student.id = DB.Students.ToList().OrderByDescending(s => s.id).First().id;

            return Content(HttpStatusCode.OK, new StudentApi(student, new HateoasMethods(new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "GET"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "PUT"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "POST"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "DELETE"))));
        }

        [HttpDelete]
        [ResponseType(typeof(Student))]
        public object DeleteStudent(int id)
        {
            var localhost = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            Student student = DB.Students.FirstOrDefault(s => s.id == id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new Hateoas($"{localhost}/api/error/4404", "error 404", "DELETE"));

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, hateoas = new Hateoas($"{localhost}/api/error/4400", "error 400", "DELETE") });
            }

            DB.Students.Remove(student);
            DB.SaveChanges();

            return Content(HttpStatusCode.OK, new StudentApi(student, new HateoasMethods(new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "GET"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "PUT"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "POST"),
                new Hateoas($"{localhost}/api/students/" + student.id, student.id.ToString(), "DELETE"))));
        }
    }
}
