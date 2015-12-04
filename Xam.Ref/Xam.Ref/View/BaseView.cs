using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Ref.View
{
    internal class BaseView: ContentPage, IDisposable
    {
        protected BaseView()
        {
            NavigationPage.SetHasNavigationBar(this, false);    
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
        ~BaseView()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        #endregion
    }
}
