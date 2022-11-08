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
        /// Shows a dialog that has specified <typeparamref name="TDialog"/> type using specified <paramref name="parameter"/> and return the result.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        /// <returns>A <see cref="DialogResult"/> of the dialog.</returns>
        DialogResult<TReturn> ShowDialog(TParam parameter);
        #endregion Methods
    }
}
