namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents an event data for <see cref="IDialog.RequestClosing"/> event.
    /// </summary>
    public sealed class DialogRequestClosingEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogRequestClosingEventArgs"/> using specified <paramref name="dialogResult"/>.
        /// </summary>
        /// <param name="dialogResult">A <see cref="Dialogs.DialogResult"/> of event source.</param>
        public DialogRequestClosingEventArgs(DialogResult dialogResult)
        {
            DialogResult = dialogResult;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets a <see cref="Dialogs.DialogResult"/> of event source.
        /// </summary>
        public DialogResult DialogResult { get; }
        #endregion Properties
    }
}
