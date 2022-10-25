using Adita.PlexNet.Core.Dialogs;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides mechanism for dialog service.
    /// </summary>
    public interface IDialogService
    {
        #region Methods
        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog"/> as dialog type and return the result.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A <see cref="DialogResult"/> of the dialog.</returns>
        DialogResult ShowDialog<TDialog>() where TDialog : class, IDialog;
        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog"/> as dialog type which has specified <typeparamref name="TReturn"/> of return type and return the result.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return type.</typeparam>
        /// <returns>A <see cref="DialogResult"/> of the dialog.</returns>
        DialogResult<TReturn> ShowDialog<TDialog, TReturn>() where TDialog : class, IDialog<TReturn>;
        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog"/> as dialog type which has specified <typeparamref name="TReturn"/> of return type
        /// using specified <paramref name="parameter"/> and return the result.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return type.</typeparam>
        /// <typeparam name="TParam">The type used for the parameter type.</typeparam>
        /// <returns>A <see cref="DialogResult"/> of the dialog.</returns>
        DialogResult<TReturn> ShowDialog<TDialog, TReturn, TParam>(TParam parameter) where TDialog : class, IDialog<TReturn, TParam>;
        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog"/> as dialog type which has specified <typeparamref name="TReturn"/> of return type
        /// using specified <paramref name="parameter"/> and return the result asynchronously.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return type.</typeparam>
        /// <typeparam name="TParam">The type used for the parameter type.</typeparam>
        /// <param name="parameter">The type used for the parameter type.</param>
        /// <param name="serviceContext">A <see cref="SynchronizationContext"/> to creates the dialog.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> that represents an asynchronous operation which contains a <see cref="DialogResult"/> of the dialog.</returns>
        Task<DialogResult<TReturn>> ShowDialogAsync<TDialog, TReturn, TParam>(TParam parameter, SynchronizationContext serviceContext, CancellationToken cancellationToken = default) where TDialog : class, IDialog<TReturn, TParam>;
        #endregion Methods
    }
}
