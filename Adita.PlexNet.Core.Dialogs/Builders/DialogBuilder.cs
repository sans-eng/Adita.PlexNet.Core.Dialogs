using Adita.PlexNet.Core.Dialogs.Abstractions.Builders;
using Adita.PlexNet.Core.Dialogs.Abstractions.Dialogs;
using Adita.PlexNet.Core.Dialogs.Abstractions.Factories;
using Adita.PlexNet.Core.Dialogs.Abstractions.Managers;
using Adita.PlexNet.Core.Dialogs.Abstractions.Providers;
using Adita.PlexNet.Core.Dialogs.Factories;
using Adita.PlexNet.Core.Dialogs.Managers;
using Adita.PlexNet.Core.Dialogs.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Adita.PlexNet.Core.Dialogs.Builders
{
    /// <summary>
    /// Represents a builder for dialog environment.
    /// </summary>
    public sealed class DialogBuilder : IDialogBuilder
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogBuilder"/> using specified <paramref name="services"/>.
        /// </summary>
        /// <param name="services">An <see cref="IServiceCollection"/> to register the dialog environment.</param>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> is <c>null</c>.</exception>
        public DialogBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets an <see cref="IServiceCollection" /> where the dialog environment is configured.
        /// </summary>
        public IServiceCollection Services { get; }
        #endregion Public properties

        #region Public methods
        /// <inheritdoc/>
        public IServiceCollection Build()
        {
            return Services;
        }
        /// <summary>
        /// Registers a dialog to current builder.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>Current <see cref="DialogBuilder"/> to chain operations.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not the implementation of dialog interface.</exception>
        public IDialogBuilder RegisterDialog<TDialog>() where TDialog : class
        {
            if (IsStandardDialog(typeof(TDialog)))
            {
                Services.TryAddTransient(typeof(IDialogContainerFactory<>).MakeGenericType(typeof(TDialog)), typeof(DialogContainerFactory<>).MakeGenericType(typeof(TDialog)));

                Services.TryAddTransient(typeof(IDialogManager<>).MakeGenericType(typeof(TDialog)),
                    typeof(DialogManager<>).MakeGenericType(typeof(TDialog)));
            }
            else if (IsDialogWithReturn(typeof(TDialog)))
            {
                Type returnType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<>)).GetGenericArguments()[0];

                Services.TryAddTransient(typeof(IDialogContainerFactory<,>).MakeGenericType(typeof(TDialog), returnType),
                    typeof(DialogContainerFactory<,>).MakeGenericType(typeof(TDialog), returnType));

                Services.TryAddTransient(typeof(IDialogManager<,>).MakeGenericType(typeof(TDialog), returnType),
                    typeof(DialogManager<,>).MakeGenericType(typeof(TDialog), returnType));
            }
            else if (IsDialogWithReturnAndParam(typeof(TDialog)))
            {
                Type returnType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<,>)).GetGenericArguments()[0];
                Type paramType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<,>)).GetGenericArguments()[1];

                Services.TryAddTransient(typeof(IDialogContainerFactory<,,>).MakeGenericType(typeof(TDialog), returnType, paramType),
                   typeof(DialogContainerFactory<,,>).MakeGenericType(typeof(TDialog), returnType, paramType));

                Services.TryAddTransient(typeof(IDialogManager<,,>).MakeGenericType(typeof(TDialog), returnType, paramType),
                    typeof(DialogManager<,,>).MakeGenericType(typeof(TDialog), returnType, paramType));
            }
            else if (IsParamOnlyDialog(typeof(TDialog)))
            {
                Type paramType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IParamOnlyDialog<>)).GetGenericArguments()[0];

                Services.TryAddTransient(typeof(IParamOnlyDialogContainerFactory<,>).MakeGenericType(typeof(TDialog), paramType),
                   typeof(ParamOnlyDialogContainerFactory<,>).MakeGenericType(typeof(TDialog), paramType));

                Services.TryAddTransient(typeof(IParamOnlyDialogService<,>).MakeGenericType(typeof(TDialog), paramType),
                    typeof(ParamOnlyDialogManager<,>).MakeGenericType(typeof(TDialog), paramType));
            }
            else
            {
                throw new ArgumentException($"The specified '{nameof(TDialog)}' is not the implementation of any dialog interface.");
            }

            Services.TryAddTransient<IDialogProvider<TDialog>, DialogProvider<TDialog>>();
            Services.TryAddTransient<TDialog>();
            return this;
        }
        /// <summary>
        /// Adds dialog host provider that is implements <see cref="IDialogHostProvider"/>.
        /// </summary>
        /// <typeparam name="TProvider">The type used for the host provider.</typeparam>
        /// <remarks>Call this method multiple times will replace the host provider.</remarks>
        /// <returns>Current <see cref="DialogBuilder"/> to chain operations.</returns>
        public IDialogBuilder AddDialogHostProvider<TProvider>()
            where TProvider : class, IDialogHostProvider
        {
            Services.TryAddScoped<IDialogHostProvider, TProvider>();
            return this;
        }
        /// <summary>
        /// Adds dialog view provider that is implements <see cref="IDialogViewProvider"/>.
        /// </summary>
        /// <typeparam name="TProvider">The type used for the view provider.</typeparam>
        /// <remarks>Call this method multiple times will replace the view provider.</remarks>
        /// <returns>Current <see cref="DialogBuilder"/> to chain operations.</returns>
        public IDialogBuilder AddDialogViewProvider<TProvider>()
            where TProvider : class, IDialogViewProvider
        {
            Services.TryAddScoped<IDialogViewProvider, TProvider>();
            return this;
        }
        /// <summary>
        /// Configures a <see cref="DialogOptions"/> to current <see cref="DialogBuilder"/> using specified <paramref name="configureAction"/>.
        /// </summary>
        /// <param name="configureAction">An <see cref="Action{T}"/> of <see cref="DialogOptions"/>.</param>
        /// <returns>Current <see cref="DialogBuilder"/> to chain operations.</returns>
        public IDialogBuilder ConfigureDialogOptions(Action<DialogOptions> configureAction)
        {
            Services.Configure(configureAction);
            return this;
        }
        #endregion Public methods

        #region Private methods
        private static bool IsStandardDialog(Type type)
        {
            return type is null ? throw new ArgumentNullException(nameof(type)) : typeof(IDialog).IsAssignableFrom(type);
        }
        private static bool IsDialogWithReturn(Type type)
        {
            return type is null
                ? throw new ArgumentNullException(nameof(type))
                : type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<>));
        }
        private static bool IsDialogWithReturnAndParam(Type type)
        {
            return type is null
                ? throw new ArgumentNullException(nameof(type))
                : type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<,>));
        }
        private static bool IsParamOnlyDialog(Type type)
        {
            return type is null
                ? throw new ArgumentNullException(nameof(type))
                : type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IParamOnlyDialog<>));
        }
        #endregion Private methods
    }
}
