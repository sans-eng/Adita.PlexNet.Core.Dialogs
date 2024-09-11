namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog container
    /// </summary>
    public interface IDialogContainer
    {
        #region Methods
        /// <summary>
        /// Opens a dialog and return the result after dialog is closed asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> that contains <see cref="DialogResult"/> as a result of the dialog.</returns>
        Task<DialogResult> ShowDialogAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Sets the host of type <typeparamref name="THost"/> to the dialog.
        /// </summary>
        /// <typeparam name="THost">The type used for the dialog.</typeparam>
        /// <param name="host">The host to set to.</param>
        void SetHost<THost>(THost? host) where THost : class;
        /// <summary>
        /// Sets the content of the dialog using specified <paramref name="content"/> and its <paramref name="contentView"/>.
        /// </summary>
        /// <typeparam name="TContent">The type used for the content.</typeparam>
        /// <typeparam name="TContentView">The type used for the view.</typeparam>
        /// <param name="content">The content to set.</param>
        /// <param name="contentView">The content view to set.</param>
        void SetContent<TContent, TContentView>(TContent content, TContentView contentView)
            where TContent : class, IDialog
            where TContentView : class;
        #endregion Methods
    }
}
