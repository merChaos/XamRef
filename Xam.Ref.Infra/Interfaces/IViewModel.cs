using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xam.Ref.Infra.Interfaces
{
    public interface IViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Methods

        /// <summary>
        /// Initializes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        void Init(object args);

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        void OnAppearing();

        /// <summary>
        /// Called when [disappearing].
        /// </summary>
        void OnDisappearing();

        #endregion
    }
}
