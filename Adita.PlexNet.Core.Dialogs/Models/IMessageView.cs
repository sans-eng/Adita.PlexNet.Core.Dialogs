namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a delegate that encapsulate a method for handling <see cref="IMessageView.ActionInvoked"/> event.
    /// </summary>
    /// <param name="sender">An event source.</param>
    /// <param name="e">An event data.</param>
    public delegate void ActionInvokedHandler(IMessageView sender, ActionInvokedEventArgs e);

    /// <summary>
    /// Provides a mechanism for message view.
    /// </summary>
    public interface IMessageView : IMessage
    {
        #region Events
        /// <summary>
        /// Occurs when an action invoked.
        /// </summary>
        /// <remarks>
        /// This raised when an action button of the message is clicked.
        /// </remarks>
        public event ActionInvokedHandler? ActionInvoked;
        #endregion Events
    }
}
