namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog service.
    /// </summary>
    /// <typeparam name="TDialog">The type of the dialog.</typeparam>
    /// <typeparam name="TParam">The type of the dialog parameter.</typeparam>
    public interface IParamOnlyDialogService<TDialog, TParam>
        where TDialog : class, IParamOnlyDialog<TParam>
    {
        #region Methods
        /// <summary>
        /// Shows a dialog that has specified <typeparamref name="TDialog"/> type using specified <paramref name="parameter"/> and return the result.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        /// <returns>A <see cref="DialogResult"/> of the dialog.</returns>
        DialogResult ShowDialog(TParam parameter);
        #endregion Methods
    }
}
