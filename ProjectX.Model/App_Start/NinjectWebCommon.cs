using Model.Nhibernate;
using ProjectX.Model.Entities;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Repositories;
[assembly: WebActivator.PreApplicationStartMethod(typeof(ProjectX.Model.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ProjectX.Model.App_Start.NinjectWebCommon), "Stop")]

namespace ProjectX.Model.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Modules;
    using NHibernate;
    using Ninject.Activation;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load<RepositoryModule>();
        }

        public class RepositoryModule : NinjectModule
        {
            public override void Load()
            {
                /* For demo only...this should be in the web.config. */
                //@"Data Source=mssql02.citynetwork.se;Initial Catalog=104820-spotquiz;User ID=104820-ve19602;Password=Admin123!"
                //@"Data Source=DANIEL-DATOR\DANIEL;Initial Catalog=SpotQuiz;Integrated Security=True"
                const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True;User Instance=True";

                var helper = new NhibernateHelper(connectionString);
                Bind<ISessionFactory>().ToConstant(helper.SessionFactory).InSingletonScope();

                Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                Bind<ISession>().ToProvider(new SessionProvider()).InRequestScope();
                Bind<IDataRepository>().To<NHibernateRepository>().InRequestScope();
            }
        }

        public class SessionProvider : Provider<ISession>
        {
            protected override ISession CreateInstance(IContext context)
            {
                var unitOfWork = (UnitOfWork)context.Kernel.Get<IUnitOfWork>();
                return unitOfWork.Session;

            }
        }
    }
}
