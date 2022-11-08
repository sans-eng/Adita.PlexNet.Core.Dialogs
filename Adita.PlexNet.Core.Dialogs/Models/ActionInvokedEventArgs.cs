namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents event data for <see cref="IMessageView.ActionInvoked"/> event.
    /// </summary>
    public class ActionInvokedEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="ActionInvokedEventArgs"/> using specified <paramref name="actionResult"/>.
        /// </summary>
        /// <param name="actionResult">A <see cref="MessageActionResult"/> on event source.</param>
        public ActionInvokedEventArgs(MessageActionResult actionResult)
        {
            ActionResult = actionResult;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets a <see cref="MessageActionResult"/> on event source.
        /// </summary>
        public MessageActionResult ActionResult { get; }
        #endregion Public properties
    }
}
