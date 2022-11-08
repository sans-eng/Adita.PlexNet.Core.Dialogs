namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog container that has parameter and no return value.
    /// </summary>
    /// <typeparam name="TParam">The type used for the parameter.</typeparam>
    public interface IParamOnlyDialogContainer<TParam>
    {
        #region Methods
        /// <summary>
        /// Opens a dialog using specified <paramref name="param"/> and return the result after dialog is closed.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="DialogResult"/> as a result of the dialog.</returns>
        DialogResult ShowDialog(TParam param);
        /// <summary>
        /// Opens a dialog using specified <paramref name="param"/> and return the result after dialog is closed asynchronously.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="Task"/> that represents an asynchronous operation which contans a <see cref="DialogResult"/> as a result of the dialog.</returns>
        Task<DialogResult> ShowDialogAsync(TParam param);
        /// <summary>
        /// Sets the host of type <typeparamref name="THost"/> to the dialog.
        /// </summary>
        /// <typeparam name="THost">The type used for the dialog.</typeparam>
        /// <param name="host">The host to set to.</param>
        void SetHost<THost>(THost? host) where THost : class;
        /// <summary>
        /// Sets the content of the dialog using specified <paramref name="content"/> and its <paramref name="contentView"/>.
        /// </summary>
        /// <typeparam name="TContent">The type used for the content.</typeparam>
        /// <typeparam name="TContentView">The type used for the view.</typeparam>
        /// <param name="content">The content to set.</param>
        /// <param name="contentView">The content view to set.</param>
        void SetContent<TContent, TContentView>(TContent content, TContentView contentView)
            where TContent : class, IParamOnlyDialog<TParam>
            where TContentView : class;
        #endregion Methods
    }
}
