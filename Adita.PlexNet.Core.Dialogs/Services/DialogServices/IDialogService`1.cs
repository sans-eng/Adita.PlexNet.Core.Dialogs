namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog service.
    /// </summary>
    /// <typeparam name="TDialog">The type of the dialog.</typeparam>
    public interface IDialogService<TDialog>
        where TDialog : class, IDialog
    {
        #region Methods
        /// <summary>
        /// Shows a dialog that has specified <typeparamref name="TDialog"/> type and return the result asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> that contains <see cref="DialogResult"/> of the dialog.</returns>
        /// <exception cref="OperationCanceledException">The operation has been canceled.</exception>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        /// <exception cref="InvalidOperationException"><see cref="DialogOptions.TargetPlatformStandardContainerType"/> is <c>null</c>.</exception>
        Task<DialogResult> ShowDialogAsync(CancellationToken cancellationToken = default);
        #endregion Methods
    }
}
