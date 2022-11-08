namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a message dialog service.
    /// </summary>
    public interface IMessageDialogService
    {
        #region Methods
        /// <summary>
        /// Show a dialog using specified <paramref name="caption"/>,
        /// <paramref name="header"/>, <paramref name="content"/>, <paramref name="details"/>, <paramref name="footer"/>,
        /// <paramref name="type"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="caption">The caption of the message.</param>
        /// <param name="header">The header of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="details">The details of the message.</param>
        /// <param name="footer">The footer of the message.</param>
        /// <param name="type">The <see cref="MessageType"/> of the message.</param>
        /// <param name="action">The <see cref="MessageAction"/> of the message.</param>
        /// <returns>A <see cref="DialogResult"/> as a result of the message callback.</returns>
        DialogResult ShowDialog(
            string caption,
            string header,
            string content,
            string details,
            string footer,
            MessageType type,
            MessageAction action);
        /// <summary>
        /// Show a dialog using specified <paramref name="caption"/>,
        /// <paramref name="header"/>, <paramref name="content"/>, <paramref name="details"/>,
        /// <paramref name="type"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="caption">The caption of the message.</param>
        /// <param name="header">The header of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="details">The details of the message.</param>
        /// <param name="type">The <see cref="MessageType"/> of the message.</param>
        /// <param name="action">The <see cref="MessageAction"/> of the message.</param>
        /// <returns>A <see cref="DialogResult"/> as a result of the message callback.</returns>
        DialogResult ShowDialog(
            string caption,
            string header,
            string content,
            string details,
            MessageType type,
            MessageAction action);
        /// <summary>
        /// Show a dialog using specified <paramref name="caption"/>,
        /// <paramref name="header"/>, <paramref name="content"/>,
        /// <paramref name="type"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="caption">The caption of the message.</param>
        /// <param name="header">The header of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="type">The <see cref="MessageType"/> of the message.</param>
        /// <param name="action">The <see cref="MessageAction"/> of the message.</param>
        /// <returns>A <see cref="DialogResult"/> as a result of the message callback.</returns>
        DialogResult ShowDialog(
            string caption,
            string header,
            string content,
            MessageType type,
            MessageAction action);
        #endregion Methods
    }
}
