namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents an delegate that encapsulate an handler for <see cref="IDialog.RequestClosing"/>.
    /// </summary>
    /// <param name="sender">An event source.</param>
    /// <param name="e">An argument of event source.</param>
    public delegate void DialogRequestClosingEventHandler(IDialog sender, DialogRequestClosingEventArgs e);

    /// <summary>
    /// Provides a mechanism for a dialog.
    /// </summary>
    public interface IDialog
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
        event DialogRequestClosingEventHandler? RequestClosing;
        #endregion Events
    }
}
