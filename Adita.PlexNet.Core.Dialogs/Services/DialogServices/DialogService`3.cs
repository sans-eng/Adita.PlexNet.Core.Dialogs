using Adita.PlexNet.Core.Dialogs.Internals;
using Microsoft.Extensions.Options;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog service.
    /// </summary>
    /// <typeparam name="TDialog">The type of the dialog.</typeparam>
    /// <typeparam name="TReturn">The type of the dialog return value.</typeparam>
    /// <typeparam name="TParam">The type of the dialog parameter.</typeparam>
    public class DialogService<TDialog, TReturn, TParam> : IDialogService<TDialog, TReturn, TParam>
        where TDialog : class, IDialog<TReturn, TParam>
    {
        #region Private fields
        private readonly IDialogProvider<TDialog> _dialogProvider;
        private readonly IDialogContainerFactory<TDialog, TReturn, TParam> _dialogContainerFactory;
        private readonly IDialogHostProvider _dialogHostProvider;
        private readonly IDialogViewProvider _dialogViewProvider;
        private readonly DialogOptions _options;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogService{TDialog, TReturn, TParam}"/> using specified <paramref name="dialogProvider"/>
        /// and <paramref name="dialogContainerFactory"/>.
        /// </summary>
        /// <param name="dialogProvider">An <see cref="IDialogProvider{TDialog}"/> to retrieves the dialog from.</param>
        /// <param name="dialogContainerFactory">An <see cref="IDialogContainerFactory{TDialog, TReturn, TParam}"/> to creates the container.</param>
        /// <param name="dialogHostProvider">An <see cref="IDialogHostProvider"/> to retrieves the host from.</param>
        /// <param name="dialogViewProvider">An <see cref="IDialogViewProvider"/> to retrieves the view from.</param>
        /// <param name="options">An <see cref="IOptions{TOptions}"/> of <see cref="DialogOptions"/> as the options of the dialog service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dialogProvider"/>, <paramref name="dialogContainerFactory"/>, <paramref name="dialogHostProvider"/>,
        /// <paramref name="dialogViewProvider"/> or <paramref name="options"/> is <c>null</c>.</exception>
        public DialogService(
            IDialogProvider<TDialog> dialogProvider,
            IDialogContainerFactory<TDialog, TReturn, TParam> dialogContainerFactory,
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
        public async Task<DialogResult<TReturn>> ShowDialogAsync(TParam parameter, CancellationToken cancellationToken = default)
        {
            TDialog? dialog = _dialogProvider.GetDialog() ?? throw new ArgumentException($"Specified {nameof(TDialog)} is not registered.");

            if (_options.TargetPlatformWithReturnAndParamContainerType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.TargetPlatformWithReturnAndParamContainerType)} is not set.");
            }

            var dialogView = _dialogViewProvider.GetView<TDialog>() ?? throw new ArgumentException($"The view for specifiied {typeof(TDialog)} is not registered.");
            var host = _dialogHostProvider.GetHost<TDialog>() ?? throw new ArgumentException($"The host for specifiied {typeof(TDialog)} is not registered.");

            IDialogContainer<TReturn, TParam> container = _dialogContainerFactory.Create(dialog, dialogView, host, _options.TargetPlatformWithReturnAndParamContainerType);

            return await container.ShowDialogAsync(parameter, cancellationToken);
        }
        #endregion Public methods
    }
}
