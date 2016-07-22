using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using Bursify.Api.Security;
using Bursify.Api.Users;
using Bursify.Data.EF.User;
using Microsoft.Ajax.Utilities;

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