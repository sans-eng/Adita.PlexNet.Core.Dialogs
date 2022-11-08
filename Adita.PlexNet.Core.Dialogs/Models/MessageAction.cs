namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Specifies the action of a message that should display.
    /// </summary>
    public enum MessageAction
    {
        /// <summary>
        /// The message contains an <strong>OK</strong> action.
        /// </summary>
        OK = 0,
        /// <summary>
        /// The message contains an <strong>OK</strong> and <strong>Cancel</strong> action.
        /// </summary>
        OKCancel = 1,
        /// <summary>
        /// The message contains an <strong>Abort</strong> and <strong>Ignore</strong> action.
        /// </summary>
        AbortIgnore = 2,
        /// <summary>
        /// The message contains a <strong>Yes</strong>, <strong>No</strong> and <strong>Cancel</strong> action.
        /// </summary>
        YesNoCancel = 3,
        /// <summary>
        /// The message contains a <strong>Yes</strong> and <strong>No</strong> action.
        /// </summary>
        YesNo = 4,
    }
}
