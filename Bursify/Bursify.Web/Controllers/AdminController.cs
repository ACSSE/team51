using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Bursify.Api.Administrators;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{ 

    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private AdminApi adminApi;

        public AdminController(AdminApi admin)
        {
            this.adminApi = admin;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("AddInstitution")]
        public HttpResponseMessage AddInstitution(HttpRequestMessage request, InstitutionViewModel institutionVm)
        {
            HttpResponseMessage response = null;

            if (institutionVm.Type.ToUpper().Equals("HIGHSCHOOL"))
            {
                adminApi.AddHighSchool(institutionVm.Name, institutionVm.Website);
            } else if (institutionVm.Type.ToUpper().Equals("UNIVERSITY"))
            {
                adminApi.AddUniversity(institutionVm.Name, institutionVm.Website);
            } else if (institutionVm.Type.ToUpper().Equals("COLLEGE"))
            {
                adminApi.AddCollege(institutionVm.Name, institutionVm.Website);
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }

            response = request.CreateResponse(HttpStatusCode.OK, new { success = true });

            return response;
        }


    }
}