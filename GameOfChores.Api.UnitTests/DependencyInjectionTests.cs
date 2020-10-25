using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GameOfChores.Api.UnitTests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void ApiControllersAreCorrectlyCreatedWithTheirDependencies()
        {
            Action createControllers = CreateControllers<Startup>;

            createControllers.Should().NotThrow();
        }

        private static void CreateControllers<TProjectStartupClass>() where TProjectStartupClass : class
        {
            IServiceProvider services = new WebHostBuilder().UseStartup<TProjectStartupClass>().Build().Services;
            var controllerActivator = services.GetService<IControllerActivator>();
            var serviceProvider = services.GetService<IServiceProvider>();

            List<Type> controllers = ControllerUtilities.GetControllers<TProjectStartupClass>().ToList();
            controllers.ForEach(c => ControllerUtilities.CreateInstance(c, controllerActivator, serviceProvider));
        }

        private static class ControllerUtilities
        {
            public static IEnumerable<Type> GetControllers<TProjectStartupClass>()
            {
                return typeof(TProjectStartupClass).Assembly.ExportedTypes.Where(x => typeof(ControllerBase).IsAssignableFrom(x));
            }

            public static void CreateInstance(Type controllerType, IControllerActivator activator, IServiceProvider serviceProvider)
            {
                var actionContext = new ActionContext(
                    new DefaultHttpContext { RequestServices = serviceProvider },
                    new RouteData(),
                    new ControllerActionDescriptor { ControllerTypeInfo = controllerType.GetTypeInfo() }
                );

                activator.Create(new ControllerContext(actionContext));
            }
        }
    }
}
