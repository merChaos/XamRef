using Autofac;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.BL.Service;
using Xam.Ref.Dal.SqLite;
using Xam.Ref.Infra.Helpers;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xam.Ref.Infra.Util;
using Xam.Ref.Models;

namespace Xam.Ref.UnitTest.Helper
{
    internal static class IocSetup
    {
        internal static ContainerBuilder Builder = null;

        public static void InatilizeMocContainer()
        {
              IocContainer.Container = GetDefaultContainerBuilder().Build();
        }

        internal static ContainerBuilder GetDefaultContainerBuilder()
        {
            var builder = new ContainerBuilder();
            //IDataConnection
            var dataConnectionMoc = new Mock<IDataConnection>();

            //IUserDialog
            var userDialogMoc = new Mock<IUserDialog>();

            //IRepository<User>
            var userRepositoryMock = new Mock<IRepository<User>>();

            //IServiceResult<User>
            var userServiceResultMock = new Mock<IServiceResult<User>>();

            //IServiceProxy
            var serviceProxyMock = new Mock<IServiceProxy>();

            //INavigator
            var navigatorMock = new Mock<INavigator>();

            //ILogger
            var loggerMock = new Mock<ILogger>();

            Builder = new ContainerBuilder();

            #region Register Views and ViewModels

            //builder.RegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly, typeof(BaseViewModel).GetTypeInfo().Assembly);

            #endregion

            #region Register Platform dependencies

            builder.RegisterInstance(dataConnectionMoc.Object).As<IDataConnection>().SingleInstance();
            builder.RegisterInstance(userDialogMoc.Object).As<IUserDialog>().SingleInstance();

            #endregion

            #region Register Repositories

            builder.RegisterInstance(userRepositoryMock.Object).As<IRepository<User>>().SingleInstance();

            #endregion

            #region Register Service Results & Service Proxie

            builder.RegisterInstance(userServiceResultMock.Object).As<IServiceResult<User>>();
            builder.RegisterInstance(serviceProxyMock.Object).As<IServiceProxy>().SingleInstance();

            #endregion

            #region Register Other dependencies

            builder.RegisterInstance(navigatorMock.Object).As<INavigator>().SingleInstance();
            builder.RegisterInstance(loggerMock.Object).As<ILogger>().SingleInstance();

            #endregion

            return builder;
        }
    }
}
