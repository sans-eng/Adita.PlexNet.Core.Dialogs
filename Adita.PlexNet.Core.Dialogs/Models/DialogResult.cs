namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog result.
    /// </summary>
    public sealed class DialogResult : IDialogResult
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogResult{T}"/> using specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">A <see cref="DialogActionResult"/> of a dialog.</param>
        public DialogResult(DialogActionResult action)
        {
            Action = action;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets a <see cref="DialogActionResult"/> of current <see cref="DialogResult"/>.
        /// </summary>
        public DialogActionResult Action { get; }
        #endregion Public properties
    }
}
