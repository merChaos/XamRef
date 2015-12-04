using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Ref.View
{
    internal class LoginView : BaseView
    {
        public LoginView()
        {
            // The root page of your application
            this.Content = new ContentView();
            {
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            };   
        }
    }
}
