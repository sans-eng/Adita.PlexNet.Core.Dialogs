namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog options.
    /// </summary>
    public class DialogOptions
    {
        #region Public properties
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the standard dialog container for the target platform.
        /// </summary>
        public Type? TargetPlatformStandardContainerType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog container with return value for the target platform.
        /// </summary>
        public Type? TargetPlatformWithReturnContainerType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog container with return value and has parameter for the target platform.
        /// </summary>
        public Type? TargetPlatformWithReturnAndParamContainerType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog container which has parameter only for the target platform.
        /// </summary>
        public Type? TargetPlatformOnlyParamContainerType { get; set; }
        #endregion Public properties
    }
}
