using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Security;
using Bursify.Api.Students;
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
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel userVm)
        {
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                var loginSuccess = _membershipApi.Login(userVm.UserEmail, userVm.Password);

                if (loginSuccess)
                {
                    var user = _membershipApi.GetUserByEmail(userVm.UserEmail);
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true, user });
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
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel newUser)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
            }
            else
            {
                BursifyUser user = _membershipApi.RegisterUser(newUser.UserEmail, newUser.Password, newUser.UserType);

                if (user != null)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true, user});                   
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
