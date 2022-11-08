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
        public DialogResult DialogResult { get; private set; } = new DialogResult(DialogActionResult.None);
        /// <summary>
        /// Gets or sets the title of the dialog.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        #endregion Public Properties

        #region Events
        /// <summary>
        /// Occurs when dialog request for closing.
        /// </summary>
        public event EventHandler<DialogRequestClosingEventArgs>? RequestClosing;
        #endregion Events

        #region Protected methods
        /// <summary>
        /// Notify to <strong>OK</strong> the dialog.
        /// </summary>
        protected void OK()
        {
            RequestClose(DialogActionResult.Ok);
        }
        /// <summary>
        /// Accepts the dialog.
        /// </summary>
        protected void Accept()
        {
            RequestClose(DialogActionResult.Accept);
        }
        /// <summary>
        /// Refuses the dialog.
        /// </summary>
        protected void Refuse()
        {
            RequestClose(DialogActionResult.Refuse);
        }
        /// <summary>
        /// Submits the dialog.
        /// </summary>
        protected void Submit()
        {
            RequestClose(DialogActionResult.Submit);
        }
        /// <summary>
        /// Cancels the dialog.
        /// </summary>
        protected void Cancel()
        {
            RequestClose(DialogActionResult.Cancel);
        }
        /// <summary>
        /// Ignores the dialog.
        /// </summary>
        protected void Ignore()
        {
            RequestClose(DialogActionResult.Ignore);
        }
        /// <summary>
        /// Aborts the dialog.
        /// </summary>
        protected void Abort()
        {
            RequestClose(DialogActionResult.Abort);
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
        /// <param name="action">A <see cref="DialogActionResult"/> to set to <see cref="DialogResult"/>.</param>
        private void RequestClose(DialogActionResult action)
        {
            DialogResult = new DialogResult(action);
            OnRequestClose(DialogResult);
        }
        #endregion Private methods
    }
}
