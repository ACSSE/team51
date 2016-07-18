using Bursify.Data.UoW;
using Bursify.Data.Repositories;
using Bursify.Web.Infrastructure.Core;
using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Services.Abstract;
using Bursify.Services.Utilitities;
using Bursify.Entities;

namespace Bursify.Web.Controllers
{
    
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _membershipService = membershipService;
        }



        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {

            
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.UserEmail, user.Password);

                    if (_userContext.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                
                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    Bursify.Entities.UserEntities.BursifyUser _user = _membershipService.CreateUser(user.Username, user.UserEmail, user.Password, user.UserType);

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
            });
        }
    }
}
