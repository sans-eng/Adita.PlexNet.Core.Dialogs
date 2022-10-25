namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides an abstraction for dialog service.
    /// </summary>
    public interface IDialogResult
    {
        #region Properties
        /// <summary>
        /// Gets a <see cref="DialogAction"/> of current <see cref="IDialogResult"/>.
        /// </summary>
        DialogAction Action { get; }
        #endregion Properties
    }
}
