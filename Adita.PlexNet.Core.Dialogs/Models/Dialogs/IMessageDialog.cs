namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a message dialog.
    /// </summary>
    public interface IMessageDialog : IParamOnlyDialog<MessageParameter>, IMessage
    {
        #region Methods
        /// <summary>
        /// Invokes to accept the dialog.
        /// </summary>
        void OnAccept();
        /// <summary>
        /// Invokes to refuse the dialog.
        /// </summary>
        void OnRefuse();
        /// <summary>
        /// Invokes to submit the dialog.
        /// </summary>
        void OnSubmit();
        /// <summary>
        /// Invokes to cancel the dialog.
        /// </summary>
        void OnCancel();
        /// <summary>
        /// Invokes to ignore the dialog.
        /// </summary>
        void OnIgnore();
        /// <summary>
        /// Invokes to abort the dialog.
        /// </summary>
        void OnAbort();
        #endregion Methods
    }
}
