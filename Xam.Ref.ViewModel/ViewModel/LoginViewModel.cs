using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam.Ref.BL;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xam.Ref.Models;
using Xam.Ref.ViewModel.Helpers;


namespace Xam.Ref.ViewModel.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region BINDABLE PROPERTIES

        #region USER ID
        /// <summary>
        /// The _ user identifier
        /// </summary>
        private string _userId = string.Empty;
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId
        {
            get
            {
                return _userId;
            }

            set { _userId = value; OnPropertyChanged(); }
        }
        #endregion

        #region PASSWORD
        /// <summary>
        /// The _ password
        /// </summary>
        private string _password = string.Empty;
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get
            {
                return _password;
            }

            set { _password = value; OnPropertyChanged(); }
        }
        #endregion


        #endregion

        #region OVERRIDE METHODS

        public override void Init(object args)
        {
            
        }

        public override void OnAppearing()
        {

        }

        public override void OnDisappearing()
        {

        }
 
        #endregion

        #region COMMANDS

        #region SUBMIT LOGIN COMMAND

        /// <summary>
        /// Gets or sets the submit login command.
        /// </summary>
        /// <value>The submit login command.</value>
        private ICommand _submitLoginCommand = null;

        /// <summary>
        /// Gets the submit login command.
        /// </summary>
        /// <value>The submit login command.</value>
        public ICommand SubmitLoginCommand
        {
            get { return _submitLoginCommand ?? (_submitLoginCommand = new Command(async () => await ExecuteLoginAsync())); }
        }
        /// <summary>
        /// Executes the login.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task ExecuteLoginAsync()
        {
            try
            {
                var result = await UserManager.AuthenticateUser(new LoginDetails() {UserId = this.UserId, Password = this.Password});
                if (result)
                {
                    // Get the user details from the database or from the service etc. 
                    var user = new User()
                    {
                        Name = "Tom Cruise",
                        Id = 1
                    };
                    // Navigate to Home Page. 
                    await NavigateToAsync<HomePageViewModel>(user);
                }
                else
                {
                    //Show message. 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        #endregion

        #endregion
       
        #region DISPOSE
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            // Rmove anything that you want to dispose here
            _submitLoginCommand = null;
        }
        #endregion
    }
}
