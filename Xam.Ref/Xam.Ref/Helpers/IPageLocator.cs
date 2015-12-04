using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xamarin.Forms;

namespace Xam.Ref.Helpers
{
    public interface IPageLocator
    {
        /// <summary>
        /// Resolves the page.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>Page.</returns>
        Page ResolvePage(IViewModel viewModel);

        /// <summary>
        /// Resolves the page.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>Page.</returns>
        Page ResolvePage(Type viewModelType, object args = null);
    }
}
