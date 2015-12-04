using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xamarin.Forms;

namespace Xam.Ref.Helpers
{
    public class PageLocator : IPageLocator
    {

        #region IPageLocator

        /// <summary>
        /// Resolve page by viewModel type
        /// </summary>
        /// <param name="viewModel">viewModel type</param>
        /// <returns>Xamarin Page</returns>
        public Page ResolvePage(IViewModel viewModel)
        {
            var pageType = this.FindPageForViewModel(viewModel.GetType());
            var page = this.CreatePage(pageType);
            page.BindViewModel(viewModel);
            return page;
        }

        /// <summary>
        /// Resolve page by viewModel type
        /// </summary>
        /// <param name="viewModelType">viewModel type</param>
        /// <param name="args">Arguments to be passed</param>
        /// <returns>Xamarin Page</returns>
        public Page ResolvePage(Type viewModelType, object args = null)
        {
            var viewModel = this.CreateViewModel(viewModelType);
            viewModel.Init(args);
            return this.ResolvePage(viewModel);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Creates the view model.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>IViewModel.</returns>
        protected virtual IViewModel CreateViewModel(Type viewModelType)
        {
            return Activator.CreateInstance(viewModelType) as IViewModel;
        }

        /// <summary>
        /// Creates the page.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <returns>Page.</returns>
        protected virtual Page CreatePage(Type pageType)
        {
            return Activator.CreateInstance(pageType) as Page;
        }

        /// <summary>
        /// Finds the page for view model.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>Type.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        protected virtual Type FindPageForViewModel(Type viewModelType)
        {
            var pageTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace("ViewModel", "View");

            var pageType = Type.GetType(pageTypeName);
            if (pageType == null)
                throw new Exception(string.Format("page not found for type {0} ", viewModelType.Name));
            return pageType;
        }

        #endregion
    }
}
