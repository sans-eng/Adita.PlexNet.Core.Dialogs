using Microsoft.Extensions.DependencyInjection;

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
        public DialogBuilder(IServiceCollection services)
        {
            Services = services;
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
        /// Registers a dialog to current builder.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>Current <see cref="DialogBuilder"/> to chain operations.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not the implementation of dialog interface.</exception>
        public IDialogBuilder RegisterDialog<TDialog>() where TDialog : class
        {
            if (!IsCorrectDialogType(typeof(TDialog)))
            {
                throw new ArgumentException($"The specified {nameof(TDialog)} is not the implementation of dialog interface.");
            }

            Services.AddScoped<TDialog>();

            return this;
        }
        #endregion Public methods

        #region Private methods
        private static bool IsCorrectDialogType(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            bool isDialogWithReturn = type.GetInterfaces()
                            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<>))
;

            bool isDialogWithReturnAndParam = type.GetInterfaces()
                            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDialog<,>))
;

            return typeof(IDialog).IsAssignableFrom(type) || isDialogWithReturn || isDialogWithReturnAndParam;
        }
        #endregion Private methods
    }
}
