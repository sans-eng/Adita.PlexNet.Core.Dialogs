namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog options.
    /// </summary>
    public class DialogOptions
    {
        #region Public properties
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog host.
        /// </summary>
        public Type? HostType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog view.
        /// </summary>
        public Type? ViewType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the standard dialog container.
        /// </summary>
        public Type? ContainerStandardType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog container with return value.
        /// </summary>
        public Type? ContainerWithReturnType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog container with return value and has parameter.
        /// </summary>
        public Type? ContainerWithReturnAndParamType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the dialog container which has parameter only.
        /// </summary>
        public Type? ContainerOnlyParamType { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for the message view.
        /// </summary>
        public Type? MessageViewType { get; set; }
        #endregion Public properties
    }
}
