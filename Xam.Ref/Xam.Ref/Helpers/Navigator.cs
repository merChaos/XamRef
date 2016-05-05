using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xamarin.Forms;

namespace Xam.Ref.Helpers
{
    public class Navigator: INavigator
    {
        private static INavigation _navigation = null;

        public Task NavigateToAsync<T>(object args = null)
        {
            if (_navigation == null) throw new ArgumentNullException("INavigation");

            var page = IocContainer.Resolve<IPageLocator>().ResolvePage(typeof(T), args);
            return _navigation.PushAsync(page);
        }

        public INavigator SetNavigator(object platformNavigator)
        {
            _navigation = (INavigation)platformNavigator;
            return this;
        }
    }
}
