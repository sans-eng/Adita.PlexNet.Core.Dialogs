namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Determines the type of message.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The message contains no meaningful message.
        /// </summary>
        None = 0,
        /// <summary>
        /// The message contains an error message.
        /// </summary>
        Error = 16,
        /// <summary>
        /// The message is contains a question.
        /// </summary>
        Question = 32,
        /// <summary>
        /// The message contains a warning message.
        /// </summary>
        Warning = 48,
        /// <summary>
        /// The message contains an information.
        /// </summary>
        Information = 64
    }
}
