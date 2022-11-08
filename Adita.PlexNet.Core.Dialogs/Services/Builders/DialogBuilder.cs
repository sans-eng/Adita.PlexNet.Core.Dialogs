using Adita.PlexNet.Core.Dialogs.Services.ContainerFactories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Adita.PlexNet.Core.Dialogs
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
        /// <summary>
        /// Builds a dialog environment and return the result.
        /// </summary>
        /// <returns>A <see cref="IDialogEnvironment" />.</returns>
        public IDialogEnvironment Build()
        {
            return new DialogEnvironment(Services);
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
                Services.TryAddScoped(typeof(IDialogContainerFactory<>).MakeGenericType(typeof(TDialog)), typeof(DialogContainerFactory<>).MakeGenericType(typeof(TDialog)));

                Services.TryAddScoped(typeof(DialogService<>).MakeGenericType(typeof(TDialog)));
            }
            else if (IsDialogWithReturn(typeof(TDialog)))
            {
                Type returnType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<>)).GetGenericArguments()[0];

                Services.TryAddScoped(typeof(IDialogContainerFactory<,>).MakeGenericType(typeof(TDialog), returnType),
                    typeof(DialogContainerFactory<,>).MakeGenericType(typeof(TDialog), returnType));

                Services.TryAddScoped(typeof(DialogService<,>).MakeGenericType(typeof(TDialog), returnType));
            }
            else if (IsDialogWithReturnAndParam(typeof(TDialog)))
            {
                Type returnType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<,>)).GetGenericArguments()[0];
                Type paramType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<,>)).GetGenericArguments()[1];

                Services.TryAddScoped(typeof(IDialogContainerFactory<,,>).MakeGenericType(typeof(TDialog), returnType, paramType),
                   typeof(DialogContainerFactory<,,>).MakeGenericType(typeof(TDialog), returnType, paramType));

                Services.TryAddScoped(typeof(DialogService<,,>).MakeGenericType(typeof(TDialog), returnType, paramType));
            }
            else if (IsParamOnlyDialog(typeof(TDialog)))
            {
                Type paramType = typeof(TDialog).GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IParamOnlyDialog<>)).GetGenericArguments()[0];

                Services.TryAddScoped(typeof(IParamOnlyDialogContainerFactory<,>).MakeGenericType(typeof(TDialog), paramType),
                   typeof(ParamOnlyDialogContainerFactory<,>).MakeGenericType(typeof(TDialog), paramType));

                Services.TryAddScoped(typeof(IParamOnlyDialogService<,>).MakeGenericType(typeof(TDialog), paramType),
                    typeof(ParamOnlyDialogService<,>).MakeGenericType(typeof(TDialog), paramType));
            }
            else
            {
                throw new ArgumentException($"The specified {nameof(TDialog)} is not the implementation of dialog interface.");
            }

            Services.TryAddScoped<IDialogProvider<TDialog>, DialogProvider<TDialog>>();
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
            Services.RemoveAll<IDialogHostProvider>();
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
            Services.RemoveAll<IDialogViewProvider>();
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
        /// <summary>
        /// Adds message service to current builder.
        /// </summary>
        /// <remarks>Call this method multiple times will not affect anything.</remarks>
        /// <returns>Current <see cref="DialogBuilder"/> to chain operations.</returns>
        public IDialogBuilder AddMessageService()
        {
            Services.RemoveAll<MessageDialog>();
            Services.RemoveAll<IMessageDialogService>();
            Services.RemoveAll<IDialogProvider<MessageDialog>>();
            Services.RemoveAll<IParamOnlyDialogContainerFactory<MessageDialog, MessageParameter>>();

            Services.TryAddTransient<MessageDialog>();
            Services.TryAddScoped<IMessageDialogService, MessageDialogService>();
            Services.TryAddScoped<IDialogProvider<MessageDialog>, DialogProvider<MessageDialog>>();
            Services.TryAddScoped<IParamOnlyDialogContainerFactory<MessageDialog, MessageParameter>,
                ParamOnlyDialogContainerFactory<MessageDialog, MessageParameter>>();

            return this;
        }
        #endregion Public methods

        #region Private methods
        private static bool IsStandardDialog(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return typeof(IDialog).IsAssignableFrom(type);
        }
        private static bool IsDialogWithReturn(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<>));
        }
        private static bool IsDialogWithReturnAndParam(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<,>));
        }
        private static bool IsParamOnlyDialog(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IParamOnlyDialog<>));
        }
        #endregion Private methods
    }
}
