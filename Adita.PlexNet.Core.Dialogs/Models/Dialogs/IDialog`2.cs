namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for dialog that has return value and parameter.
    /// </summary>
    public interface IDialog<TReturn, TParam> : IDialogBase
    {
        #region Properties
        /// <summary>
        /// Gets a <see cref="DialogResult{TReturn}"/> of the dialog.
        /// </summary>
        DialogResult<TReturn> DialogResult { get; }
        #endregion Properties

        #region Events
        /// <summary>
        /// Occurs when dialog request for closing.
        /// </summary>
        event EventHandler<DialogRequestClosingEventArgs<TReturn>>? RequestClosing;
        #endregion Events

        #region Methods
        /// <summary>
        /// Initialize the dialog using specified <paramref name="parameter"/> asyncronously.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        /// <returns>A <see cref="Task"/> that represents an asynchronous operation.</returns>
        Task InitializeAsync(TParam parameter);
        #endregion Methods
    }
}
