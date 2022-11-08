namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a message dialog.
    /// </summary>
    public sealed class MessageDialog : ParamOnlyDialog<MessageParameter>, IMessageDialog
    {
        #region Public properties
        /// <summary>
        /// Gets or sets a <see cref="MessageType"/> of current <see cref="MessageDialog"/>.
        /// </summary>
        public MessageType Type { get; set; }
        /// <summary>
        /// Gets or sets a <see cref="MessageAction"/> of current <see cref="MessageDialog"/>.
        /// </summary>
        public MessageAction Action { get; set; }
        /// <summary>
        /// Gets or sets the caption of current <see cref="MessageDialog"/>.
        /// </summary>
        public string Caption { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the header of current <see cref="MessageDialog"/>.
        /// </summary>
        public string Header { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the content of current <see cref="MessageDialog"/>.
        /// </summary>
        public string Content { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the details of current <see cref="MessageDialog"/>.
        /// </summary>
        public string Details { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the footer of current <see cref="MessageDialog"/>.
        /// </summary>
        public string Footer { get; set; } = string.Empty;
        #endregion Public properties

        #region Public methods
        /// <summary>
        /// Initialize current <see cref="MessageDialog"/> using specified <paramref name="parameter" />.
        /// </summary>
        /// <param name="parameter">A <see cref="MessageParameter"/> for current <see cref="MessageDialog"/>.</param>
        public override void Initialize(MessageParameter parameter)
        {
            Title = parameter.Caption;

            Type = parameter.Type;
            Action = parameter.Action;
            Caption = parameter.Caption;
            Header = parameter.Header;
            Content = parameter.Content;
            Details = parameter.Details;
            Footer = parameter.Footer;
        }
        /// <summary>
        /// Invokes to accept the dialog.
        /// </summary>
        public void OnAccept()
        {
            Accept();
        }
        /// <summary>
        /// Invokes to refuse the dialog.
        /// </summary>
        public void OnRefuse()
        {
            Refuse();
        }
        /// <summary>
        /// Invokes to submit the dialog.
        /// </summary>
        public void OnSubmit()
        {
            Submit();
        }
        /// <summary>
        /// Invokes to cancel the dialog.
        /// </summary>
        public void OnCancel()
        {
            Cancel();
        }
        /// <summary>
        /// Invokes to ignore the dialog.
        /// </summary>
        public void OnIgnore()
        {
            Ignore();
        }
        /// <summary>
        /// Invokes to abort the dialog.
        /// </summary>
        public void OnAbort()
        {
            Abort();
        }
        #endregion Public methods
    }
}
