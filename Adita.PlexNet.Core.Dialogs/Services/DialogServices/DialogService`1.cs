using Adita.PlexNet.Core.Dialogs.Internals;
using Microsoft.Extensions.Options;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog service.
    /// </summary>
    /// <typeparam name="TDialog">The type of the dialog.</typeparam>
    public class DialogService<TDialog> : IDialogService<TDialog>
        where TDialog : class, IDialog
    {
        #region Private fields
        private readonly IDialogProvider<TDialog> _dialogProvider;
        private readonly IDialogContainerFactory<TDialog> _dialogContainerFactory;
        private readonly IDialogHostProvider _dialogHostProvider;
        private readonly IDialogViewProvider _dialogViewProvider;
        private readonly DialogOptions _options;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogService{TDialog}"/> using specified <paramref name="dialogProvider"/>
        /// and <paramref name="dialogContainerFactory"/>.
        /// </summary>
        /// <param name="dialogProvider">An <see cref="IDialogProvider{TDialog}"/> to retrieves the dialog from.</param>
        /// <param name="dialogContainerFactory">An <see cref="IDialogContainerFactory{TDialog}"/> to creates the container.</param>
        /// <param name="dialogHostProvider">An <see cref="IDialogHostProvider"/> to retrieves the host from.</param>
        /// <param name="dialogViewProvider">An <see cref="IDialogViewProvider"/> to retrieves the view from.</param>
        /// <param name="options">An <see cref="IOptions{TOptions}"/> of <see cref="DialogOptions"/> as the options of the dialog service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dialogProvider"/>, <paramref name="dialogContainerFactory"/>, <paramref name="dialogHostProvider"/>,
        /// <paramref name="dialogViewProvider"/> or <paramref name="options"/> is <c>null</c>.</exception>
        public DialogService(
            IDialogProvider<TDialog> dialogProvider,
            IDialogContainerFactory<TDialog> dialogContainerFactory,
            IDialogHostProvider dialogHostProvider,
            IDialogViewProvider dialogViewProvider,
            IOptions<DialogOptions> options)
        {
            if (options == null)
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
        /// <inheritdoc/>
        public async Task<DialogResult> ShowDialogAsync(CancellationToken cancellationToken = default)
        {
            TDialog? dialog = _dialogProvider.GetDialog() ?? throw new ArgumentException($"Specified {nameof(TDialog)} is not registered.");

            if (_options.TargetPlatformStandardContainerType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.TargetPlatformStandardContainerType)} is not set.");
            }

            var dialogView = _dialogViewProvider.GetView<TDialog>() ?? throw new ArgumentException($"The view for specifiied {typeof(TDialog)} is not registered.");
            var host = _dialogHostProvider.GetHost<TDialog>() ?? throw new ArgumentException($"The host for specifiied {typeof(TDialog)} is not registered.");

            IDialogContainer container = _dialogContainerFactory.Create(dialog, dialogView, host, _options.TargetPlatformStandardContainerType);

            return await container.ShowDialogAsync(cancellationToken);
        }
        #endregion Public methods
    }
}
