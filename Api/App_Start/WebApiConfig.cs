﻿using Api.DependencyInjection;
using Interface.IRepo;
using Interface.IService;
using Interface.IUnityOfWork;
using Repository;
using Repository.UnityOfWork;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType(typeof(IEmployeeService),typeof(EmployeeService));
            container.RegisterType(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            container.RegisterType<IUnityOfWork, UnityOfWork>();
            config.DependencyResolver = new UnityResolver(container);

            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
