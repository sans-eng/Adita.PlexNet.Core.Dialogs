using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for configuring dialog environment.
    /// </summary>
    public interface IDialogBuilder
    {
        #region Properties
        /// <summary>
        /// Gets an <see cref="IServiceCollection"/> where the dialog environment is configured.
        /// </summary>
        IServiceCollection Services { get; }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Registers a dialog to current builder.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>Current builder to chain operations.</returns>
        IDialogBuilder RegisterDialog<TDialog>() where TDialog : class;
        /// <summary>
        /// Adds dialog host provider that is implements <see cref="IDialogHostProvider"/>.
        /// </summary>
        /// <typeparam name="TProvider">The type used for the host provider.</typeparam>
        /// <remarks>Call this method multiple times will replace the host provider.</remarks>
        /// <returns>Current builder to chain operations.</returns>
        IDialogBuilder AddDialogHostProvider<TProvider>()
            where TProvider : class, IDialogHostProvider;
        /// <summary>
        /// Adds dialog view provider that is implements <see cref="IDialogViewProvider"/>.
        /// </summary>
        /// <typeparam name="TProvider">The type used for the view provider.</typeparam>
        /// <remarks>Call this method multiple times will replace the view provider.</remarks>
        /// <returns>Current builder to chain operations.</returns>
        IDialogBuilder AddDialogViewProvider<TProvider>()
            where TProvider : class, IDialogViewProvider;
        /// <summary>
        /// Configures a <see cref="DialogOptions"/> to current builder using specified <paramref name="configureAction"/>.
        /// </summary>
        /// <param name="configureAction">An <see cref="Action{T}"/> of <see cref="DialogOptions"/>.</param>
        /// <returns>Current builder to chain operations.</returns>
        IDialogBuilder ConfigureDialogOptions(Action<DialogOptions> configureAction);
        /// <summary>
        /// Builds a dialog environment and return the result.
        /// </summary>
        /// <returns>A <see cref="IDialogEnvironment"/>.</returns>
        IDialogEnvironment Build();
       
        #endregion Methods
    }
}
