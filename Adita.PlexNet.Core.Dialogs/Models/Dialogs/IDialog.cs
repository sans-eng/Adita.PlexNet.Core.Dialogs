namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog.
    /// </summary>
    public interface IDialog : IDialogBase
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
    }
}
