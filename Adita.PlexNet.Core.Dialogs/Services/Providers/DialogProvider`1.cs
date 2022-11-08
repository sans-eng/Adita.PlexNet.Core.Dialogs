using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog provider.
    /// </summary>
    /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
    public sealed class DialogProvider<TDialog> : IDialogProvider<TDialog>
        where TDialog : class
    {
        #region Private fields
        private readonly IServiceProvider serviceProvider;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogProvider{TDialog}"/> using specified <paramref name="serviceProvider"/>.
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> to retrieve the dialogs.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceProvider"/> is <c>null</c>.</exception>
        public DialogProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        #endregion Constructors

        #region Public Methods
        /// <summary>
        /// Gets a dialog that has <typeparamref name="TDialog" /> type.
        /// </summary>
        /// <returns>An <typeparamref name="TDialog" /> instance.</returns>
        public TDialog? GetDialog()
        {
            return serviceProvider.GetService<TDialog>();
        }
        #endregion Public Methods
    }
}
