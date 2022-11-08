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
        /// Shows a dialog that has specified <typeparamref name="TDialog"/> type and return the result.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> of the dialog.</returns>
        DialogResult ShowDialog();
        #endregion Methods
    }
}
