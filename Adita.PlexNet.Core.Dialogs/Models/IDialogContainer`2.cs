namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog container that returns a value and has parameter.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    /// <typeparam name="TParam">The type used for the parameter.</typeparam>
    public interface IDialogContainer<TReturn, TParam>
    {
        #region Methods
        /// <summary>
        /// Opens a dialog using specified <paramref name="param"/> and return the result after dialog is closed.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="DialogResult{TReturn}"/> as a result of the dialog.</returns>
        DialogResult<TReturn> ShowDialog(TParam param);
        /// <summary>
        /// Opens a dialog using specified <paramref name="param"/> and return the result after dialog is closed asynchronously.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="Task"/> that represents an asynchronous operation which contans a <see cref="DialogResult{TReturn}"/> as a result of the dialog.</returns>
        Task<DialogResult<TReturn>> ShowDialogAsync(TParam param);
        #endregion Methods
    }
}
