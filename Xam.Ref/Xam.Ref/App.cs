using Autofac;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam.Ref.Helpers;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xamarin.Forms;

namespace Xam.Ref
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void SertupIoc()
        {
            //IocContainer.Container = new ContainerBuilder()
            //.RegisterPlatformDependency<IDataConnection>()

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
    }
}
