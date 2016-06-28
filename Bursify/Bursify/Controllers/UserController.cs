using System.Web.Mvc;
using Bursify.Api.Users;

namespace Bursify.Controllers
{
    public class UserController  : Controller
    {
        private readonly UserApi _userApi;

        public UserController(UserApi userApi
            )
        {
            _userApi = userApi;
        }


        [HttpGet]
        public ActionResult Index()
        {
            _userApi.CreateUser("hello");

            return this.View();
        }
    }
}