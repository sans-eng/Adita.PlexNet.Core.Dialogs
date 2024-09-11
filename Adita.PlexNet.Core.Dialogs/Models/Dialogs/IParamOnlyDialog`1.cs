namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog that has parameter and no return value.
    /// </summary>
    /// <typeparam name="TParam">The type used for the parameter.</typeparam>
    public interface IParamOnlyDialog<TParam> : IDialogBase
    {
        #region Properties
        /// <summary>
        /// Gets a <see cref="Dialogs.DialogResult"/> of the dialog.
        /// </summary>
        DialogResult DialogResult { get; }
        #endregion Properties

        #region Events
        /// <summary>
        /// Occurs when dialog request for closing.
        /// </summary>
        event EventHandler<DialogRequestClosingEventArgs>? RequestClosing;
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
