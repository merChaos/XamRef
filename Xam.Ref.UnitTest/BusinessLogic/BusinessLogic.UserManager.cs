using System;
using NUnit.Framework;
using Xam.Ref.BL;
using Xam.Ref.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Moq;
using Xam.Ref.UnitTest.Helper;
using Xam.Ref.Infra.Ioc;
using Autofac;

namespace Xam.Ref.UnitTest
{
    [TestFixture]
    public partial class BusinessLogic
    {

        [SetUp]
        public void TestSetup()
        {
            IocSetup.InatilizeMocContainer();
        }

        [TearDown]
        public void Cleanup()
        {

        }

        static LoginDetails d1 = new LoginDetails();
        public IEnumerable<TestCaseData> LoggedInUserTestCaseData
        {
            get
            {
                var t1 = new TestCaseData(d1, d1.UserId = "rastham.ka@cognizant.com", d1.Password = "helloworld");
                t1.ExpectedResult = true;
                yield return new TestCaseData(d1);
            }
        }

        [Test]
        //[TestCaseSource("LoggedInUserTestCaseData")]
        public async Task AuthenticateUserTest()//(LoginDetails loggedInUser)
        {

            //IServiceResult<User>
            var userServiceResultMock = new Mock<IServiceResult<User>>();
            userServiceResultMock
                .SetupProperty(i => i.IsSuccess, true)
                .SetupProperty(i => i.Message, "Success")
                .SetupProperty(i => i.Result, It.IsAny<User>())
                .SetupProperty(i => i.StatusCode, "200");

            //IServiceProxy
            var serviceProxyMock = new Mock<IServiceProxy>();
            var tcs = new TaskCompletionSource<IServiceResult<User>>();
            tcs.SetResult(userServiceResultMock.Object);
            serviceProxyMock.Setup(i => i.AuthenticateUserAsync(It.IsAny<LoginDetails>())).Returns(tcs.Task);
            //IocSetup.Builder.Update(IocContainer.Container);

            var builder = IocSetup.GetDefaultContainerBuilder();

            builder.RegisterInstance(userServiceResultMock.Object).As<IServiceResult<User>>();
            builder.RegisterInstance(serviceProxyMock.Object).As<IServiceProxy>().SingleInstance();

            builder.Update(IocContainer.Container);

            var isAuthenticated = await UserManager.AuthenticateUser(new LoginDetails());
            Assert.IsTrue(isAuthenticated);
        }
    }
}