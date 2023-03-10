using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using laba3.Models;

namespace laba3.Controllers
{
    public class ErrorController : ApiController
    {
        [System.Web.Http.Route("api/error/{code}")]
        public IHttpActionResult Get(int code)
        {
            CustomErrorDetails errorDetails;
            switch (code)
            {
                case 4500:
                    errorDetails = new CustomErrorDetails(4500, "Server error");
                    break;

                case 4444:
                    errorDetails = new CustomErrorDetails(4444, "Model is invalid");
                    break;

                case 4404:
                    errorDetails = new CustomErrorDetails(4404, "Not found");
                    break;

                default:
                    errorDetails = new CustomErrorDetails(4999, "Unknown error code");
                    break;
            }

            return Ok(errorDetails);
        }
    }
}
