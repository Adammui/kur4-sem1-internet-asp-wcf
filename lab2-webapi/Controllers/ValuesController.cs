using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
//using static System.Net.WebRequestMethods;

namespace lab2_webapi.Controllers
{
    public class ValuesController : ApiController
    {
        
        public static int Result = 0;
        public static Stack<int> stack = new Stack<int>();
        
        // GET api/values
        public string Get()
        {
            if (stack.Count > 0)
            {
                return JsonConvert.SerializeObject(new { result = Result + stack.Peek(), stack });
            }
            return JsonConvert.SerializeObject(new { result = Result, stack });
        }

        // POST api/values
        public void Post(int result)
        {
            Result = result;
        }

        // PUT api/values
        public void Put(int add)
        {
            stack.Push(add);
        }

        // DELETE api/values/5
        public void Delete()
        {
            stack.Pop();
        }
    }
}
