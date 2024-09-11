namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog view provider.
    /// </summary>
    public interface IDialogViewProvider
    {
        #region Methods
        /// <summary>
        /// Gets a dialog view for specified <typeparamref name="TDialog"/> type if exist.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A dialog view otherwise <see langword="null"/>.</returns>
        object? GetView<TDialog>();
        #endregion Methods
    }
}
