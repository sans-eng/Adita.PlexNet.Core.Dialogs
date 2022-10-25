namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a base class of a dialog.
    /// </summary>
    public abstract class Dialog : IDialog
    {
        #region Public Properties
        /// <summary>
        /// Gets a <see cref="Dialogs.DialogResult" /> of the dialog.
        /// </summary>
        public DialogResult DialogResult { get; private set; } = new DialogResult(DialogAction.None);
        #endregion Public Properties

        #region Events
        /// <summary>
        /// Occurs when dialog request for closing.
        /// </summary>
        public event DialogRequestClosingEventHandler? RequestClosing;
        #endregion Events

        #region Protected methods
        /// <summary>
        /// Accepts the dialog.
        /// </summary>
        protected void Accept()
        {
            RequestClose(DialogAction.Accept);
        }
        /// <summary>
        /// Refuses the dialog.
        /// </summary>
        protected void Refuse()
        {
            RequestClose(DialogAction.Refuse);
        }
        /// <summary>
        /// Submits the dialog.
        /// </summary>
        protected void Submit()
        {
            RequestClose(DialogAction.Submit);
        }
        /// <summary>
        /// Cancels the dialog.
        /// </summary>
        protected void Cancel()
        {
            RequestClose(DialogAction.Cancel);
        }
        /// <summary>
        /// Ignores the dialog.
        /// </summary>
        protected void Ignore()
        {
            RequestClose(DialogAction.Ignore);
        }
        /// <summary>
        /// Aborts the dialog.
        /// </summary>
        protected void Abort()
        {
            RequestClose(DialogAction.Abort);
        }
        /// <summary>
        /// Invokes <see cref="RequestClosing"/> event using specified <paramref name="result"/>
        /// </summary>
        /// <param name="result">A <see cref="DialogResult"/> to use for event args.</param>
        /// <exception cref="ArgumentNullException"><paramref name="result"/> is <c>null</c>.</exception>
        protected virtual void OnRequestClose(DialogResult result)
        {
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            RequestClosing?.Invoke(this, new(result));
        }
        #endregion Protected methods

        #region Private methods
        /// <summary>
        /// Request to close the dialog using specified <paramref name="action"/> as the dialog result.
        /// </summary>
        /// <param name="action">A <see cref="DialogAction"/> to set to <see cref="DialogResult"/>.</param>
        private void RequestClose(DialogAction action)
        {
            DialogResult = new DialogResult(action);
            OnRequestClose(DialogResult);
        }
        #endregion Private methods
    }
}
