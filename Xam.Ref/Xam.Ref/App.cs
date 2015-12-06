using Autofac;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam.Ref.Helpers;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xamarin.Forms;
using System.Reflection;
using Xam.Ref.Dal.SqLite;
using Xam.Ref.Models;
using Xam.Ref.Infra.Helpers;
using Xam.Ref.BL.Service;
using Xam.Ref.ViewModel.ViewModel;
using Xam.Ref.Infra.Util;

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
            var builder = new ContainerBuilder();

            #region Register Views and ViewModels

            builder.RegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly, typeof(BaseViewModel).GetTypeInfo().Assembly);

            #endregion

            #region Register Platform dependencies

            builder.RegisterPlatformDependency<IDataConnection>()
            .RegisterPlatformDependency<IUserDialog>();

            #endregion

            #region Register Repositories

            builder.RegisterType<Repository<User>>().As<IRepository<User>>().SingleInstance();

            #endregion

            #region Register Service Results & Service Proxie

            builder.RegisterType<ServiceResult<User>>().As<IServiceResult<User>>();
            builder.RegisterType<ServiceProxy>().As<IServiceProxy>().SingleInstance();

            #endregion

            #region Register Other dependencies

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();

            #endregion

            IocContainer.Container = builder.Build();

        }
    }
}

