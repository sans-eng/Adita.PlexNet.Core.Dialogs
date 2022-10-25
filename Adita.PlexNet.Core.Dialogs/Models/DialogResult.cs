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
        /// <param name="action">A <see cref="DialogAction"/> of a dialog.</param>
        public DialogResult(DialogAction action)
        {
            Action = action;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets a <see cref="DialogAction"/> of current <see cref="DialogResult{T}"/>.
        /// </summary>
        public DialogAction Action { get; }
        #endregion Public properties
    }
}
