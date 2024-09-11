namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog host provider.
    /// </summary>
    public interface IDialogHostProvider
    {
        #region Methods
        /// <summary>
        /// Gets a dialog host for specified <typeparamref name="TDialog"/> type if exist.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A dialog host otherwise <see langword="null"/>.</returns>
        object? GetHost<TDialog>();
        #endregion Methods
    }
}
