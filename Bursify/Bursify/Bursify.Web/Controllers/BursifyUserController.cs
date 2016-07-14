using AutoMapper;
using Bursify.Data.Extensions;
using Bursify.Data.Repositories;
using Bursify.Data.UoW;
using Bursify.Entities;
using Bursify.Entities.UserEntities;
using Bursify.Web.Infrastructure.Core;
using Bursify.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Bursify.Web.Controllers
{
    [RoutePrefix("api/BursifyUser")]
    public class BursifyUserController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<BursifyUser> _bursifyUserRepository;


        public BursifyUserController(IEntityBaseRepository<BursifyUser> bursifyUserRepository,
          IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _bursifyUserRepository = bursifyUserRepository;
        }

        [AllowAnonymous]
        [Route("user")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var users = _bursifyUserRepository.GetAll();

                IEnumerable<BursifyUserViewModel> usersVM = Mapper.Map<IEnumerable<BursifyUser>, IEnumerable<BursifyUserViewModel>>(users);

                response = request.CreateResponse<IEnumerable<BursifyUserViewModel>>(HttpStatusCode.OK, usersVM);

                return response;
            });
        }
    }
}