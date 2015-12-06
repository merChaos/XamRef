using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xamarin.Forms;


namespace Xam.Ref.Helpers
{
    internal static class Extensions
    {
        public static void BindViewModel(this Page page, IViewModel viewModel)
        {
            page.BindingContext = viewModel;

            page.Appearing += (sender, args1) => viewModel.OnAppearing();
            page.Disappearing += (sender, args1) => viewModel.OnDisappearing();
        }

        public static ContainerBuilder RegisterPlatformDependency<T>(this ContainerBuilder builder) where T : class
        {
            builder.Register(x => DependencyService.Get<T>()).SingleInstance();
            return builder;
        }

        public static ContainerBuilder RegisterMvvmComponents(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            // Note: Can use AppDomain.CurrentDomain.GetAssemblies() instead of passing in the assemblies??

            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            try
            {
                builder
                      .RegisterType<AutoFacPageLocator>()
                      .As<IPageLocator>()
                      .SingleInstance();

                builder
                    .RegisterViewModels(assemblies)
                    .RegisterViews(assemblies);
            }
            catch (Exception )
            {
                // Log exception
                throw;
            }

            return builder;
        }

        private static ContainerBuilder RegisterViewModels(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(x =>
                    x.GetTypeInfo().IsClass &&
                    !x.GetTypeInfo().IsAbstract &&
                    x.GetTypeInfo().ImplementedInterfaces.Any(y => y == typeof(IViewModel))
                )
                .InstancePerDependency();

            return builder;
        }


        /// <summary>
        /// Extension Method will register all the class inherited from base Xamarin.Forms.Page class
        /// </summary>
        /// <param name="builder">IOC container</param>
        /// <param name="assemblies">assembly</param>
        /// <returns>IOC Container</returns>
        private static ContainerBuilder RegisterViews(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(x =>
                    x.GetTypeInfo().IsClass &&
                    !x.GetTypeInfo().IsAbstract &&
                    x.GetTypeInfo().IsSubclassOf(typeof(Page))
                )
                .InstancePerDependency();

            return builder;
        }
    }
}
