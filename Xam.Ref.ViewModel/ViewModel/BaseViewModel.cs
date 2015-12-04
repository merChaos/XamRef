using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;

namespace Xam.Ref.ViewModel.ViewModel
{
    public class BaseViewModel : IViewModel
    {
        public virtual void Init(object args)
        {
            
        }

        public virtual void OnAppearing()
        {
            
        }

        public virtual void OnDisappearing()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual async Task NavigateToAsync<T>(object args = null)
        {
            await IocContainer.Resolve<INavigator>().NavigateToAsync<T>();
        }

        #region IDisposable Members
        //Implement IDisposable Correctly
        //http://msdn.microsoft.com/en-us/library/ms244737(VS.80).aspx
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            // free native resources if there are any.
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        /// <summary>
        /// Finalizes an instance of the <see cref="BaseView"/> class.
        /// </summary>
        ~BaseViewModel()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        #endregion
    }
}
