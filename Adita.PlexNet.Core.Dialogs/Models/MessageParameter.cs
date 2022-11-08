namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a message parameter.
    /// </summary>
    public sealed class MessageParameter
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="MessageParameter"/>.
        /// </summary>
        /// <param name="type">The <see cref="MessageType"/> of the <see cref="MessageDialog"/>.</param>
        /// <param name="action">The <see cref="MessageAction"/> of the <see cref="MessageDialog"/></param>
        /// <param name="caption">The caption of the <see cref="MessageDialog"/>.</param>
        /// <param name="header">The header of the message.</param>
        /// <param name="content">The content of the <see cref="MessageDialog"/>.</param>
        /// <param name="details">The details of the <see cref="MessageDialog"/>.</param>
        /// <param name="footer">The footer of the <see cref="MessageDialog"/>.</param>
        public MessageParameter(MessageType type,
            MessageAction action,
            string caption,
            string header,
            string content,
            string details,
            string footer)
        {
            Type = type;
            Action = action;
            Caption = caption;
            Header = header;
            Content = content;
            Details = details;
            Footer = footer;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets a <see cref="MessageType"/> of the message.
        /// </summary>
        public MessageType Type { get;}
        /// <summary>
        /// Gets a <see cref="MessageAction"/> of the message.
        /// </summary>
        public MessageAction Action { get;}
        /// <summary>
        /// Gets the caption of the message.
        /// </summary>
        public string Caption { get;}
        /// <summary>
        /// Gets the header of the message.
        /// </summary>
        public string Header { get;}
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public string Content { get;}
        /// <summary>
        /// Gets the details of the message.
        /// </summary>
        public string Details { get;}
        /// <summary>
        /// Gets the footer of the message.
        /// </summary>
        public string Footer { get;}
        #endregion Public properties
    }
}
