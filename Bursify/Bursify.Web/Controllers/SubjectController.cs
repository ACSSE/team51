using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Subject")]
    public class SubjectController : ApiController
    {
        private readonly StudentApi _studentApi;

        public SubjectController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }
    }
}
