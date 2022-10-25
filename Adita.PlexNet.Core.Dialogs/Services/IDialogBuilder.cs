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
        #endregion Methods
    }
}
