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
        /// Shows a dialog that has specified <typeparamref name="TDialog"/> type and return the result.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> of the dialog.</returns>
        DialogResult<TReturn> ShowDialog();
        #endregion Methods
    }
}
