using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Models;

namespace Xam.Ref.ViewModel.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {

        #region BINDABLE PROPERTIES

        
        private string _userName = string.Empty;

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserName
        {
            get
            {
                return _userName;
            }

            set { _userName = value; OnPropertyChanged(); }
        }
        #endregion

        #region OVERRIDE METHODS

        public override void Init(object args)
        {
            // do the inital stuff.

            var loggedInUser = args as User;
            if (loggedInUser != null)
            {
                this.UserName = loggedInUser.Name;
            }
        }

        public override void OnAppearing()
        {
            // this will be called when the view OnAppearing is called. 
        }

        public override void OnDisappearing()
        {
            // this will be called when the view OnDisappearing is called. 
        }

        #endregion

        #region DISPOSE
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            // Rmove anything that you want to dispose here
            
        }
        #endregion
    }
}
