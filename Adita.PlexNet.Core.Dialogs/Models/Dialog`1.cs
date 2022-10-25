namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a base class of a dialog that has return value.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value</typeparam>
    public abstract class Dialog<TReturn> : IDialog<TReturn>
    {
        #region Public Properties
        /// <summary>
        /// Gets a <see cref="DialogResult{TReturn}" /> of the dialog.
        /// </summary>
        public DialogResult<TReturn> DialogResult { get; private set; } = new DialogResult<TReturn>(DialogAction.None);
        #endregion Public Properties

        #region Events
        /// <summary>
        /// Occurs when dialog request for closing.
        /// </summary>
        public event DialogRequestClosingEventHandler<TReturn>? RequestClosing;
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
        /// Submits the dialog with specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">A value to submit.</param>
        protected void Submit(TReturn value)
        {
            RequestClose(DialogAction.Submit, value);
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
        protected virtual void OnRequestClose(DialogResult<TReturn> result)
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
        /// Request to close the dialog using specified <paramref name="action"/> and an optional <paramref name="value"/> as the dialog result.
        /// </summary>
        /// <param name="action">A <see cref="DialogAction"/> to set to <see cref="DialogResult"/>.</param>
        /// <param name="value">A return value of the dialog.</param>
        private void RequestClose(DialogAction action, TReturn? value = default)
        {
            DialogResult = new DialogResult<TReturn>(action, value);
            OnRequestClose(DialogResult);
        }
        #endregion Private methods
    }
}
