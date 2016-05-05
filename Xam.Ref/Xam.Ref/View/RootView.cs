using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Ref.View
{
    internal class RootView
    {
        private Page _rootPage;

        public RootView()
        {
            
        }

        public Page FirstView
        {
           get
            {
                return _rootPage ?? (_rootPage = new NavigationPage(new SplashView())); 
            }
        }
    }
}
