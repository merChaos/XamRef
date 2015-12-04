using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xam.Ref.Infra.Interfaces;
using Xamarin.Forms;
using Xam.Ref.Droid.Helpers;

[assembly: Dependency(typeof(UserDialogAndroid))]
namespace Xam.Ref.Droid.Helpers
{
    public class UserDialogAndroid : IUserDialog
    {
        public void ShowAlert(string heading, string message)
        {
            
        }
    }
}