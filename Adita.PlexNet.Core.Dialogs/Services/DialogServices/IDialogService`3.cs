namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog service.
    /// </summary>
    /// <typeparam name="TDialog">The type of the dialog.</typeparam>
    /// <typeparam name="TReturn">The type of the dialog return value.</typeparam>
    /// <typeparam name="TParam">The type of the dialog parameter.</typeparam>
    public interface IDialogService<TDialog, TReturn, TParam>
        where TDialog : class, IDialog<TReturn, TParam>
    {
        #region Methods
        /// <summary>
        /// Shows a dialog that has specified <typeparamref name="TDialog" /> type using specified <paramref name="parameter"/> and return the result asynchronously.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> <see cref="DialogResult{TReturn}" /> of the dialog.</returns>
        /// <exception cref="OperationCanceledException">The operation has been canceled.</exception>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        /// <exception cref="InvalidOperationException"><see cref="DialogOptions.TargetPlatformWithReturnAndParamContainerType"/> is <c>null</c>.</exception>
        Task<DialogResult<TReturn>> ShowDialogAsync(TParam parameter, CancellationToken cancellationToken = default);
        #endregion Methods
    }
}
