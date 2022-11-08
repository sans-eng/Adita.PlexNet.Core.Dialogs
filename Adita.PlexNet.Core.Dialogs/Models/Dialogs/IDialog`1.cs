namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents an delegate that encapsulate an handler for <see cref="IDialog{TReturn}.RequestClosing"/>.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    /// <param name="sender">An event source.</param>
    /// <param name="e">An argument of event source.</param>
    public delegate void DialogRequestClosingEventHandler<TReturn>(IDialog<TReturn> sender, DialogRequestClosingEventArgs<TReturn> e);

    /// <summary>
    /// Provides a mechanism for dialog that has return value.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    public interface IDialog<TReturn> : IDialogBase
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
    }
}
