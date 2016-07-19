using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Bursify.Api.Users;
using Bursify.Data.EF.User;
using Microsoft.Ajax.Utilities;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/BursifyUser")]
    public class BursifyUserController : ApiController
    {
        private readonly UserApi _userApi;

        public BursifyUserController(UserApi userApi)
        {
            _userApi = userApi;
        }

        public JsonResult Get()
        {
            return new JsonResult { Data = new BursifyUserViewModel(new BursifyUser()) {Name="Yo mamma"} };
        }


        //[System.Web.Mvc.AllowAnonymous]
        ////[System.Web.Mvc.Route("user/{email:string}")]
        //public HttpResponseMessage Get(HttpRequestMessage request, string email)
        //{
        //    var user = _userApi.GetUserByEmail(email);

        //    BursifyUserViewModel model = new BursifyUserViewModel(user);

        //    HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);

        //    return response;
        //}
    }
}