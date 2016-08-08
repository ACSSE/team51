using System;
using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Security;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Controllers
{

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly MembershipApi _membershipApi;
        private readonly StudentApi _studentApi;

        public AccountController(MembershipApi membershipApi, StudentApi studentApi)
        {
            _membershipApi = membershipApi;
            _studentApi = studentApi;
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                var loginSuccess = _membershipApi.Login(user.UserEmail, user.Password);

                if (loginSuccess)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }
            }

            return response;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
            }
            else
            {
                BursifyUser _user = _membershipApi.RegisterUser(user.Username, user.UserEmail, user.Password, user.UserType);

                if (_user != null)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true });                   
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }
            }

            return response;
        }
    }
}
