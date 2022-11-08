namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Defines a dialog action result for a <see cref="DialogResult{T}"/>.
    /// </summary>
    public enum DialogActionResult
    {
        /// <summary>
        /// A dialog return nothing.
        /// </summary>
        None = 0,
        /// <summary>
        /// A dialog returns <strong>OK</strong> action result.
        /// </summary>
        Ok = 1,
        /// <summary>
        /// A dialog returns <strong>Cancel</strong> action result.
        /// </summary>
        Cancel = 2,
        /// <summary>
        /// A dialog returns <strong>Abort</strong> action result.
        /// </summary>
        Abort = 3,
        /// <summary>
        /// A dialog returns <strong>Retry</strong> action result.
        /// </summary>
        Retry = 4,
        /// <summary>
        /// A dialog returns <strong>Ignore</strong> action result.
        /// </summary>
        Ignore = 5,
        /// <summary>
        /// A dialog returns <strong>Yes</strong> action result.
        /// </summary>
        Yes = 6,
        /// <summary>
        /// A dialog returns <strong>No</strong> action result.
        /// </summary>
        No = 7,
        /// <summary>
        /// A dialog returns <strong>Try</strong> action result.
        /// </summary>
        Try = 10,
        /// <summary>
        /// A dialog returns <strong>Continue</strong> action result.
        /// </summary>
        Continue = 11,
        /// <summary>
        /// A dialog returns <strong>Accept</strong> action result.
        /// </summary>
        Accept = 12,
        /// <summary>
        /// A dialog returns <strong>Refuse</strong> action result.
        /// </summary>
        Refuse = 13,
        /// <summary>
        /// A dialog returns <strong>Submit</strong> action result.
        /// </summary>
        Submit = 14,
    }
}
