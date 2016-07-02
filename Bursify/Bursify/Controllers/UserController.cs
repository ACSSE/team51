using System.Web.Mvc;
using Bursify.Api.Users;

namespace Bursify.Controllers
{
    public class UserController  : Controller
    {
        private readonly UserApi _userApi;
        private readonly ContactApi _contactApi;

        public UserController(UserApi userApi, ContactApi contactApi)
        {
            _userApi = userApi;
            _contactApi = contactApi;
        }


        [HttpGet]
        public ActionResult Index()
        {
            _userApi.CreateUser("hello");
            _contactApi.CreateUser("1234567899");

            return this.View();
        }
    }
}