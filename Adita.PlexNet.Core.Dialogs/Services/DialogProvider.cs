using Adita.PlexNet.Core.Dialogs;
using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog provider.
    /// </summary>
    public sealed class DialogProvider : IDialogProvider
    {
        #region Private fields
        private readonly IServiceProvider serviceProvider;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogProvider"/> using specified <paramref name="serviceProvider"/>.
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> to retrieve the dialogs.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceProvider"/> is <c>null</c>.</exception>
        public DialogProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Gets a dialog that has specified <typeparamref name="TDialog" /> type.
        /// </summary>
        /// <typeparam name="TDialog">The type of dialog.</typeparam>
        /// <returns>The <see cref="IDialog" /> instance.</returns>
        public IDialog? GetDialog<TDialog>() where TDialog : IDialog
        {
            return serviceProvider.GetService<TDialog>();
        }

        /// <summary>
        /// Gets a dialog that has specified <typeparamref name="TDialog" /> type and specified <typeparamref name="TReturn" /> of return type.
        /// </summary>
        /// <typeparam name="TDialog">The type of dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <returns>The <see cref="IDialog" /> instance.</returns>
        public IDialog<TReturn>? GetDialog<TDialog, TReturn>() where TDialog : IDialog<TReturn>
        {
            return serviceProvider.GetService<TDialog>();
        }

        /// <summary>
        /// Gets a dialog that has specified <typeparamref name="TParam" /> type and specified <typeparamref name="TReturn" /> of return type 
        /// with parameter type of specified <typeparamref name="TParam" />.
        /// </summary>
        /// <typeparam name="TDialog">The type of dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <typeparam name="TParam">The type used for the dialog parameter.</typeparam>
        /// <returns>The <see cref="IDialog" /> instance.</returns>
        public IDialog<TReturn, TParam>? GetDialog<TDialog, TReturn, TParam>() where TDialog : IDialog<TReturn, TParam>
        {
            return serviceProvider.GetService<TDialog>();
        }
        #endregion Public methods
    }
}
