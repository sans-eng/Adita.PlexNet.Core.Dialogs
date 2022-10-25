using Adita.PlexNet.Core.Dialogs;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for dialog provider.
    /// </summary>
    public interface IDialogProvider
    {
        #region Methods
        /// <summary>
        /// Gets a dialog that has specified <typeparamref name="TDialog"/> type.
        /// </summary>
        /// <typeparam name="TDialog">The type of dialog.</typeparam>
        /// <returns>The <see cref="IDialog"/> instance.</returns>
        IDialog? GetDialog<TDialog>() where TDialog : IDialog;
        /// <summary>
        /// Gets a dialog that has specified <typeparamref name="TDialog"/> type and specified <typeparamref name="TReturn"/> of return type.
        /// </summary>
        /// <typeparam name="TDialog">The type of dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <returns>The <see cref="IDialog"/> instance.</returns>
        IDialog<TReturn>? GetDialog<TDialog, TReturn>() where TDialog : IDialog<TReturn>;
        /// <summary>
        /// Gets a dialog that has specified <typeparamref name="TDialog"/> type and specified <typeparamref name="TReturn"/> of return type 
        /// with parameter type of specified <typeparamref name="TParam"/>.
        /// </summary>
        /// <typeparam name="TDialog">The type of dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <typeparam name="TParam">The type used for the dialog parameter.</typeparam>
        /// <returns>The <see cref="IDialog"/> instance.</returns>
        IDialog<TReturn, TParam>? GetDialog<TDialog, TReturn, TParam>() where TDialog : IDialog<TReturn, TParam>;
        #endregion Methods
    }
}
