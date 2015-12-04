using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xam.Ref.Infra.Ioc
{
    public static class IocContainer
    {

        #region Variables

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        public static IContainer Container { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// This method builds the IOC container.
        /// </summary>
        public static void Build()
        {

            //// Register all the platform dependencies here
            //    .RegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly) // will register the AutoFacPageLocator and all the View Models 
            //    .RegisterPlatformDependency<INetworkService>() // will resolve the platform specific dependency of INetworkService
            //    .RegisterPlatformDependency<IUserDialog>()
            //    .RegisterPlatformDependency<IPhoneCallTask>()
            //    .RegisterPlatformDependency<IGoogleAnalytics>()
            //    .RegisterPlatformDependency<IDeviceSpecs>()
            //    .RegisterPlatformDependency<IExternalBrowser>()
            //    .RegisterPlatformDependency<ISocial>()
            //    .RegisterPlatformDependency<ILocalNotification>()
            //    .RegisterPlatformDependency<IDataSync>();



            //// register all the other Dependencies here. 
            //builder.RegisterType<ServiceProxy>().As<IServiceProxy>().SingleInstance();
            //builder.RegisterType<UserDAL>().As<IUserDAL>().SingleInstance();
            //builder.RegisterType<Repository<BenefitLocation>>().As<IRepository<BenefitLocation>>().SingleInstance();
            //builder.RegisterType<Repository<BenefitDetails>>().As<IRepository<BenefitDetails>>().SingleInstance();
            //builder.RegisterType<Repository<AppSettings>>().As<IRepository<AppSettings>>().SingleInstance();
            //builder.RegisterType<Repository<BenefitSyncStatus>>().As<IRepository<BenefitSyncStatus>>().SingleInstance();
            //builder.RegisterType<Repository<ProductDetails>>().As<IRepository<ProductDetails>>().SingleInstance();
            //builder.RegisterType<Repository<ProductBenefitType>>().As<IRepository<ProductBenefitType>>().SingleInstance();
            //builder.RegisterType<Repository<MembershipData>>().As<IRepository<MembershipData>>().SingleInstance();
            //builder.RegisterType<Repository<UserProductBenefitType>>().As<IRepository<UserProductBenefitType>>().SingleInstance();
            //builder.RegisterType<Repository<ContentMaster>>().As<IRepository<ContentMaster>>().SingleInstance();
            //builder.RegisterType<Repository<GeoFenceLocations>>().As<IRepository<GeoFenceLocations>>().SingleInstance();
            //Container = builder.Build();

        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        #endregion
    }
}
