namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog host provider.
    /// </summary>
    public interface IDialogHostProvider
    {
        #region Methods
        /// <summary>
        /// Gets a dialog host of specified <typeparamref name="THost"/> type for specified <typeparamref name="TDialog"/> type.
        /// </summary>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A <typeparamref name="THost"/> as dialog host.</returns>
        THost? GetHost<THost, TDialog>() where THost : class;
        #endregion Methods
    }
}
