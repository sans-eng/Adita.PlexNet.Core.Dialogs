namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a base class for a dialog that has parameter and no return value.
    /// </summary>
    /// <typeparam name="TParam">The type used for the parameter.</typeparam>
    public abstract class ParamOnlyDialog<TParam> : IParamOnlyDialog<TParam>
    {
        #region Public properties
        /// <summary>
        /// Gets or sets the title of the dialog.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Gets a <see cref="Dialogs.DialogResult"/> of the dialog.
        /// </summary>
        public DialogResult DialogResult { get; private set; } = new DialogResult(DialogActionResult.None);
        #endregion Public properties

        #region Events
        /// <summary>
        /// Occurs when dialog request for closing.
        /// </summary>
        public event EventHandler<DialogRequestClosingEventArgs>? RequestClosing;
        #endregion Events

        #region Public methods
        /// <summary>
        /// Initialize the dialog using specified <paramref name="parameter" />.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        public virtual void Initialize(TParam parameter) { }

        /// <summary>
        /// Initialize the dialog using specified <paramref name="parameter" /> asyncronously.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        /// <returns>A <see cref="Task" /> that represents an asynchronous operation.</returns>
        public virtual Task InitializeAsync(TParam parameter)
        {
            return Task.CompletedTask;
        }
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
