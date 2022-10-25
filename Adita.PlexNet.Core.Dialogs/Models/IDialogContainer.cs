namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog container
    /// </summary>
    public interface IDialogContainer
    {
        #region Methods
        /// <summary>
        /// Opens a dialog and return the result after dialog is closed.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> as a result of the dialog.</returns>
        DialogResult ShowDialog();
        #endregion Methods
    }
}
