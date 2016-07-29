using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly StudentApi _studentApi;

        public StudentController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }
    }
}
