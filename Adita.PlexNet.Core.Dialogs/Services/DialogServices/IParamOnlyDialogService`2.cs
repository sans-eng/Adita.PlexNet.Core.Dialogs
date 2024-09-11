namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog service.
    /// </summary>
    /// <typeparam name="TDialog">The type of the dialog.</typeparam>
    /// <typeparam name="TParam">The type of the dialog parameter.</typeparam>
    public interface IParamOnlyDialogService<TDialog, TParam>
        where TDialog : class, IParamOnlyDialog<TParam>
    {
        #region Methods
        /// <summary>
        /// Shows a dialog that has specified <typeparamref name="TDialog" /> type using specified <paramref name="parameter"/> and return the result asynchronously.
        /// </summary>
        /// <param name="parameter">A <typeparamref name="TParam"/> to pass to the dialog.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="DialogResult" /> of the dialog.</returns>
        /// <exception cref="OperationCanceledException">The operation has been canceled.</exception>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        /// /// <exception cref="InvalidOperationException"><see cref="DialogOptions.TargetPlatformOnlyParamContainerType"/> is <c>null</c>.</exception>
        Task<DialogResult> ShowDialogAsync(TParam parameter, CancellationToken cancellationToken = default);
        #endregion Methods
    }
}
