namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog view provider.
    /// </summary>
    public interface IDialogViewProvider
    {
        #region Methods
        /// <summary>
        /// Gets a dialog view which has type of <typeparamref name="TView"/> for specified <typeparamref name="TDialog"/> type.
        /// </summary>
        /// <typeparam name="TView">The type used for the dialog view.</typeparam>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A <typeparamref name="TView"/> as dialog view.</returns>
        TView? GetView<TView, TDialog>() where TView : class;
        #endregion Methods
    }
}
