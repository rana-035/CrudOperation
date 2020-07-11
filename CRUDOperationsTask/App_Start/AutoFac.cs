
using Autofac;
using Autofac.Integration.Mvc;
using Repositires;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace CRUDOperationsTask.App_Start
{
    public  class AutoFac
    {
        public static void RegisterAutoFac()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                .InstancePerRequest();
            builder.RegisterType<EntitiesContext>
                ().InstancePerRequest();
            builder.RegisterGeneric(typeof(GenaricRepository<>))
               .InstancePerRequest();
            builder.RegisterType<UnitOfWork>()
               .InstancePerRequest();

            builder.RegisterAssemblyTypes
                (
                typeof(EmployeeService).Assembly
                ).Where(i => i.Name.EndsWith("Service"))
                .InstancePerRequest();
            Autofac.IContainer c = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(c));


        }

    }
}