using Adita.PlexNet.Core.Dialogs.Internals;
using Microsoft.Extensions.Options;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a message dialog service.
    /// </summary>
    public class MessageDialogService : IMessageDialogService
    {
        #region Private fields
        private readonly IDialogProvider<MessageDialog> _dialogProvider;
        private readonly IParamOnlyDialogContainerFactory<MessageDialog, MessageParameter> _dialogContainerFactory;
        private readonly IDialogHostProvider _dialogHostProvider;
        private readonly IDialogViewProvider _dialogViewProvider;
        private readonly DialogOptions _options;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="MessageDialogService"/> using specified 
        /// <paramref name="dialogProvider"/>, <paramref name="dialogContainerFactory"/>, <paramref name="dialogHostProvider"/> and <paramref name="dialogViewProvider"/>.
        /// </summary>
        /// <param name="dialogProvider">An <see cref="IDialogProvider{TDialog}"/> to retrieves the dialog from.</param>
        /// <param name="dialogContainerFactory">An <see cref="IParamOnlyDialogContainerFactory{TDialog, TParam}"/> to creates the container.</param>
        /// <param name="dialogHostProvider">An <see cref="IDialogHostProvider"/> to retrieves the host from.</param>
        /// <param name="dialogViewProvider">An <see cref="IDialogViewProvider"/> to retrieves the view from.</param>
        /// <param name="options">An <see cref="IOptions{TOptions}"/> of <see cref="DialogOptions"/> as the options of the dialog service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dialogProvider"/>, <paramref name="dialogContainerFactory"/>, <paramref name="dialogHostProvider"/>,
        /// <paramref name="dialogViewProvider"/> or <paramref name="options"/> is <c>null</c>.</exception>
        public MessageDialogService(
            IDialogProvider<MessageDialog> dialogProvider,
            IParamOnlyDialogContainerFactory<MessageDialog, MessageParameter> dialogContainerFactory,
            IDialogHostProvider dialogHostProvider,
            IDialogViewProvider dialogViewProvider,
            IOptions<DialogOptions> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _dialogProvider = dialogProvider ?? throw new ArgumentNullException(nameof(dialogProvider));
            _dialogContainerFactory = dialogContainerFactory ?? throw new ArgumentNullException(nameof(dialogContainerFactory));
            _dialogHostProvider = dialogHostProvider ?? throw new ArgumentNullException(nameof(dialogHostProvider));
            _dialogViewProvider = dialogViewProvider ?? throw new ArgumentNullException(nameof(dialogViewProvider));
            _options = options.Value;
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Show a dialog using specified <paramref name="caption" />,
        /// <paramref name="header" />, <paramref name="content" />, <paramref name="details" />, <paramref name="footer" />,
        /// <paramref name="type" /> and <paramref name="action" />.
        /// </summary>
        /// <param name="caption">The caption of the message.</param>
        /// <param name="header">The header of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="details">The details of the message.</param>
        /// <param name="footer">The footer of the message.</param>
        /// <param name="type">The <see cref="MessageType" /> of the message.</param>
        /// <param name="action">The <see cref="MessageAction" /> of the message.</param>
        /// <returns>A <see cref="DialogResult" /> as a result of the message callback.</returns>
        /// <exception cref="ArgumentException"><see cref="MessageDialog"/> is not registered as dialog.</exception>
        /// <exception cref="InvalidOperationException"><see cref="DialogOptions.MessageViewType"/>,
        /// <see cref="DialogOptions.HostType"/> or <see cref="DialogOptions.ContainerOnlyParamType"/> is <c>null</c>.</exception>
        public DialogResult ShowDialog(string caption, string header, string content, string details, string footer, MessageType type, MessageAction action)
        {
            MessageDialog? dialog = _dialogProvider.GetDialog();

            if (dialog == null)
            {
                throw new InvalidOperationException($"{nameof(MessageDialog)} is not registered as dialog.");
            }

            if (_options.MessageViewType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.MessageViewType)} is not set.");
            }

            if (_options.HostType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.HostType)} is not set.");
            }

            if (_options.ContainerOnlyParamType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.ContainerOnlyParamType)} is not set.");
            }


            if (_dialogViewProvider.GetView<MessageDialog>(_options.MessageViewType) is not IMessageView dialogView)
            {
                return new(DialogActionResult.None);
            }

            MessageParameter parameter = new(type, action, caption, header, content, details, footer);

            dialogView.Caption = parameter.Caption;
            dialogView.Header = parameter.Header;
            dialogView.Content = parameter.Content;
            dialogView.Details = parameter.Details;
            dialogView.Footer = parameter.Footer;
            dialogView.Type = parameter.Type;
            dialogView.Action = parameter.Action;

            dialogView.ActionInvoked += (sender, e) =>
            {
                switch (e.ActionResult)
                {
                    case MessageActionResult.Yes:
                        dialog.OnAccept();
                        break;
                    case MessageActionResult.No:
                        dialog.OnRefuse();
                        break;
                    case MessageActionResult.Ok:
                        dialog.OnSubmit();
                        break;
                    case MessageActionResult.Cancel:
                        dialog.OnCancel();
                        break;
                    case MessageActionResult.Ignore:
                        dialog.OnIgnore();
                        break;
                    case MessageActionResult.Abort:
                        dialog.OnAbort();
                        break;
                }
            };

            object? host = _dialogHostProvider.GetHost<MessageDialog>(_options.HostType);

            IParamOnlyDialogContainer<MessageParameter> container = _dialogContainerFactory.Create(dialog, dialogView, host, _options.ContainerOnlyParamType);

            return container.ShowDialog(parameter);

        }

        /// <summary>
        /// Show a dialog using specified <paramref name="caption" />,
        /// <paramref name="header" />, <paramref name="content" />, <paramref name="details" />,
        /// <paramref name="type" /> and <paramref name="action" />.
        /// </summary>
        /// <param name="caption">The caption of the message.</param>
        /// <param name="header">The header of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="details">The details of the message.</param>
        /// <param name="type">The <see cref="MessageType" /> of the message.</param>
        /// <param name="action">The <see cref="MessageAction" /> of the message.</param>
        /// <returns>A <see cref="DialogResult" /> as a result of the message callback.</returns>
        /// <exception cref="ArgumentException"><see cref="MessageDialog"/> is not registered as dialog.</exception>
        /// <exception cref="InvalidOperationException"><see cref="DialogOptions.MessageViewType"/>,
        /// <see cref="DialogOptions.HostType"/> or <see cref="DialogOptions.ContainerOnlyParamType"/> is <c>null</c>.</exception>
        public DialogResult ShowDialog(string caption, string header, string content, string details, MessageType type, MessageAction action)
        {
            return ShowDialog(caption, header, content, details, string.Empty, type, action);
        }

        /// <summary>
        /// Show a dialog using specified <paramref name="caption" />,
        /// <paramref name="header" />, <paramref name="content" />,
        /// <paramref name="type" /> and <paramref name="action" />.
        /// </summary>
        /// <param name="caption">The caption of the message.</param>
        /// <param name="header">The header of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="type">The <see cref="MessageType" /> of the message.</param>
        /// <param name="action">The <see cref="MessageAction" /> of the message.</param>
        /// <returns>A <see cref="DialogResult" /> as a result of the message callback.</returns>
        /// <exception cref="ArgumentException"><see cref="MessageDialog"/> is not registered as dialog.</exception>
        /// <exception cref="InvalidOperationException"><see cref="DialogOptions.MessageViewType"/>,
        /// <see cref="DialogOptions.HostType"/> or <see cref="DialogOptions.ContainerOnlyParamType"/> is <c>null</c>.</exception>
        public DialogResult ShowDialog(string caption, string header, string content, MessageType type, MessageAction action)
        {
            return ShowDialog(caption, header, content, string.Empty, string.Empty, type, action);
        }
        #endregion Public methods
    }
}
