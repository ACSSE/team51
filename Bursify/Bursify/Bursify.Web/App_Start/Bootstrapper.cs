using AutoMapper;
using Bursify.Entities.UserEntities;
using Bursify.Web.Mappings;
using Bursify.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Bursify.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<BursifyUser, BursifyUserViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();
        }
    }
}