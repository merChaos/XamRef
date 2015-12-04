using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xamarin.Forms;

namespace Xam.Ref.Helpers
{
    public class AutoFacPageLocator : PageLocator
    {
        #region RESOURSE KEY
        /// <summary>
        /// Page Type
        /// </summary>
        private const string PAGE_TYPE = "PAGE_TYPE";

        /// <summary>
        ///  Type
        /// </summary>
        private const string TYPE = "TYPE";

        #endregion
        #region DECLARATIONS
        /// <summary>
        /// The container
        /// </summary>
        private readonly ILifetimeScope container;
        #endregion

        #region AUTO FAC PAGE LOCATOR
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFacPageLocator" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public AutoFacPageLocator(ILifetimeScope container)
        {
            this.container = container;
        }
        #endregion

        #region CREATE PAGE
        /// <summary>
        /// Creates the page.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <returns>Page.</returns>
        /// <exception cref="ArgumentNullException">PageType</exception>
        protected override Page CreatePage(Type pageType)
        {
            if (pageType == null)
            {
                throw new ArgumentNullException("pageType");
            }
            return this.container.Resolve(pageType) as Page;
        }
        #endregion

        #region CREATE VIEW MODEL
        /// <summary>
        /// Creates the view model.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>IViewModel.</returns>
        /// <exception cref="ArgumentNullException">Type</exception>
        protected override IViewModel CreateViewModel(Type viewModelType)
        {
            if (viewModelType == null)
            {
                throw new ArgumentNullException("viewModelType");
            }
            return this.container.Resolve(viewModelType) as IViewModel;
        }
        #endregion
    }
}
