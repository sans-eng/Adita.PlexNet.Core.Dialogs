namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog provider.
    /// </summary>
    /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
    public interface IDialogProvider<TDialog>
        where TDialog : class
    {
        #region Methods
        /// <summary>
        /// Gets a dialog that has <typeparamref name="TDialog"/> type.
        /// </summary>
        /// <returns>An <typeparamref name="TDialog"/> instance.</returns>
        TDialog? GetDialog();
        #endregion Methods
    }
}
