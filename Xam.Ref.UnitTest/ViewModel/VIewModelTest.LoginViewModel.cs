using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xam.Ref.UnitTest.Helper;
using Xam.Ref.ViewModel.ViewModel;

namespace Xam.Ref.UnitTest.ViewModel
{
    [TestFixture]
    public partial class VIewModelTest
    {

        [SetUp]
        public void TestSetup()
        {
            IocSetup.InatilizeMocContainer();
        }

        [TearDown]
        public void Cleanup()
        {
            IocContainer.Container = null;
        }

        [Test]
        public async Task ExecuteLoginAsyncTest()
        {
            LoginViewModel vm = new LoginViewModel();

            vm.UserId = "rastham.ka@cognizant.com";
            vm.Password = "helloWorld";
            await vm.ExecuteLoginAsync();

        }
    }
}
