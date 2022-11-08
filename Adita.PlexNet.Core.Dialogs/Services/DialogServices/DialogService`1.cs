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
        /// <summary>
        /// Shows a dialog that has specified <typeparamref name="TDialog" /> type and return the result.
        /// </summary>
        /// <returns>A <see cref="DialogResult" /> of the dialog.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        /// <exception cref="InvalidOperationException"><see cref="DialogOptions.ViewType"/>,
        /// <see cref="DialogOptions.HostType"/> or <see cref="DialogOptions.ContainerStandardType"/> is <c>null</c>.</exception>
        public DialogResult ShowDialog()
        {
            TDialog? dialog = _dialogProvider.GetDialog();

            if (dialog == null)
            {
                throw new ArgumentException($"Specified {nameof(TDialog)} is not registered as dialog.");
            }

            if (_options.ViewType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.ViewType)} is not set.");
            }

            if (_options.HostType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.HostType)} is not set.");
            }

            if (_options.ContainerStandardType == null)
            {
                throw new InvalidOperationException($"{nameof(DialogOptions.ContainerStandardType)} is not set.");
            }

            object? dialogView = _dialogViewProvider.GetView<TDialog>(_options.ViewType);

            if (dialogView == null)
            {
                return new(DialogActionResult.None);
            }

            object? host = _dialogHostProvider.GetHost<TDialog>(_options.HostType);

            IDialogContainer container = _dialogContainerFactory.Create(dialog, dialogView, host, _options.ContainerStandardType);

            return container.ShowDialog();
        }
        #endregion Public methods
    }
}
