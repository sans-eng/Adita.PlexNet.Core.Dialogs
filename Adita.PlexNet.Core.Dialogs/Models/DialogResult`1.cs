namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog result that has a return value.
    /// </summary>
    /// <typeparam name="T">The type used for the return value.</typeparam>
    public sealed class DialogResult<T> : IDialogResult
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
        /// <summary>
        /// Initialize a new instance of <see cref="DialogResult{T}"/> using specified <paramref name="action"/> and an optional <paramref name="value"/>.
        /// </summary>
        /// <param name="action">A <see cref="DialogAction"/> of a dialog.</param>
        /// <param name="value">An optional return value of a dialog.</param>
        public DialogResult(DialogAction action, T? value = default)
        {
            Action = action;
            Value = value;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets a <see cref="DialogAction"/> of current <see cref="DialogResult{T}"/>.
        /// </summary>
        public DialogAction Action { get; }
        /// <summary>
        /// Gets the return value of current <see cref="DialogResult{T}"/>.
        /// </summary>
        public T? Value { get; }
        #endregion Public properties
    }
}
