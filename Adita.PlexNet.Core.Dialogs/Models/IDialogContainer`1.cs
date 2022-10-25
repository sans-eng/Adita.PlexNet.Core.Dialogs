namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog container that returns a value.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    public interface IDialogContainer<TReturn>
    {
        #region Methods
        /// <summary>
        /// Opens a dialog and return the result after dialog is closed.
        /// </summary>
        /// <returns>A <see cref="DialogResult{TReturn}"/> as a result of the dialog.</returns>
        DialogResult<TReturn> ShowDialog();
        #endregion Methods
    }
}
