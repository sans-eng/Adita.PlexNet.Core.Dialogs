namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a base class of a dialog that has return value and parameter.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value</typeparam>
    /// <typeparam name="TParam">The type used for the return parameter</typeparam>
    public abstract class Dialog<TReturn, TParam> : IDialog<TReturn, TParam>
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the title of the dialog.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Gets a <see cref="DialogResult{TReturn}" /> of the dialog.
        /// </summary>
        public DialogResult<TReturn> DialogResult { get; private set; } = new DialogResult<TReturn>(DialogActionResult.None);
        #endregion Public Properties

        #region Events
        /// <summary>
        /// Occurs when dialog request for closing.
        /// </summary>
        public event EventHandler<DialogRequestClosingEventArgs<TReturn>>? RequestClosing;
        #endregion Events

        #region Public methods
        /// <summary>
        /// When implemented, use this to initialize the dialog using specified <paramref name="parameter" /> asyncronously.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        /// <returns>A <see cref="Task" /> that represents an asynchronous operation.</returns>
        public abstract Task InitializeAsync(TParam parameter);
        #endregion Public methods

        #region Protected methods
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
        /// Submits the dialog with specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">A value to submit.</param>
        protected void Submit(TReturn value)
        {
            RequestClose(DialogActionResult.Submit, value);
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
        /// <param name="action">A <see cref="DialogActionResult"/> to set to <see cref="DialogResult"/>.</param>
        /// <param name="value">A return value of the dialog.</param>
        private void RequestClose(DialogActionResult action, TReturn? value = default)
        {
            DialogResult = new DialogResult<TReturn>(action, value);
            OnRequestClose(DialogResult);
        }
        #endregion Private methods
    }
}
