namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog container that returns a value.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    public interface IDialogContainer<TReturn>
    {
        #region Methods
        /// <summary>
        /// Opens a dialog and return the result after dialog is closed.
        /// </summary>
        /// <returns>A <see cref="DialogResult{TReturn}"/> as a result of the dialog.</returns>
        DialogResult<TReturn> ShowDialog();
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
            where TContent : class, IDialog<TReturn>
            where TContentView : class;
        #endregion Methods
    }
}
