namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Defines a dialog action for a <see cref="DialogResult{T}"/>.
    /// </summary>
    public enum DialogAction
    {
        /// <summary>
        /// A dialog has no action.
        /// </summary>
        None,
        /// <summary>
        /// A dialog has accepting action.
        /// </summary>
        Accept,
        /// <summary>
        /// A dialog has refusing action.
        /// </summary>
        Refuse,
        /// <summary>
        /// A dialog has submiting action.
        /// </summary>
        Submit,
        /// <summary>
        /// A dialog has canceling action.
        /// </summary>
        Cancel,
        /// <summary>
        /// A dialog has ignoring action.
        /// </summary>
        Ignore,
        /// <summary>
        /// A dialog has aborting action.
        /// </summary>
        Abort
    }
}
