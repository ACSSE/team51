using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Security;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/BursifyUser")]
    public class BursifyUserController : ApiController
    {
        private readonly MembershipApi _membershipApi;

        public BursifyUserController(MembershipApi membershipApi)
        {
            _membershipApi = membershipApi;
        }

        /*public JsonResult Get()
        {
            return new JsonResult { Data = new BursifyUserViewModel(/*new BursifyUser()#1#) {Name="Yo mamma"} };
        }*/

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("user/{email:string}")]
        public HttpResponseMessage Get(HttpRequestMessage request, string email)
        {
            //var user = _userApi.GetUserByEmail(email);
            var user = _membershipApi.GetUserByEmail(email);

            BursifyUserViewModel model = new BursifyUserViewModel(user);

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);

            return response;
        }
    }
}