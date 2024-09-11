namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog service.
    /// </summary>
    /// <typeparam name="TDialog">The type of the dialog.</typeparam>
    /// <typeparam name="TReturn">The type of the dialog return value.</typeparam>
    public interface IDialogService<TDialog, TReturn>
        where TDialog : class, IDialog<TReturn>
    {
        #region Methods
        /// <summary>
        /// Shows a dialog that has specified <typeparamref name="TDialog" /> type and return the result asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> that contains <see cref="DialogResult{TReturn}" /> of the dialog.</returns>
        /// <exception cref="OperationCanceledException">The operation has been canceled.</exception>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        /// <exception cref="InvalidOperationException"><see cref="DialogOptions.TargetPlatformWithReturnContainerType"/> is <c>null</c>.</exception>
        Task<DialogResult<TReturn>> ShowDialogAsync(CancellationToken cancellationToken = default);
        #endregion Methods
    }
}
