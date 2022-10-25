namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents an event data for <see cref="IDialog{TReturn}.RequestClosing"/> event.
    /// </summary>
    /// <typeparam name="T">The type used for the return type of a dialog.</typeparam>
    public sealed class DialogRequestClosingEventArgs<T> : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogRequestClosingEventArgs{T}"/> using specified <paramref name="dialogResult"/>.
        /// </summary>
        /// <param name="dialogResult">A <see cref="DialogResult{T}"/> of event source.</param>
        public DialogRequestClosingEventArgs(DialogResult<T> dialogResult)
        {
            DialogResult = dialogResult;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets a <see cref="DialogResult{T}"/> of event source.
        /// </summary>
        public DialogResult<T> DialogResult { get; }
        #endregion Properties
    }
}
