using Adita.PlexNet.Core.Dialogs.Abstractions.Containers;
using Adita.PlexNet.Core.Dialogs.Abstractions.Dialogs;
using Adita.PlexNet.Core.Dialogs.Abstractions.Factories;

namespace Adita.PlexNet.Core.Dialogs.Factories
{
    /// <summary>
    /// Represents a dialog container factory.
    /// </summary>
    /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
    /// <typeparam name="TParam">The type used for the dialog parameter.</typeparam>
    public class ParamOnlyDialogContainerFactory<TDialog, TParam> : IParamOnlyDialogContainerFactory<TDialog, TParam>
        where TDialog : class, IParamOnlyDialog<TParam>
    {
        #region Public methods
        /// <summary>
        /// Creates a dialog container for specified <paramref name="dialog" />, <paramref name="view" /> and <paramref name="host" />.
        /// </summary>
        /// <typeparam name="TView">The type used for the view of the dialog.</typeparam>
        /// <typeparam name="TContainer">The type used for the container.</typeparam>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <param name="dialog">The dialog as the content.</param>
        /// <param name="view">The view of the dialog.</param>
        /// <param name="host">An optional host of the dialog.</param>
        /// <returns>A container of type <typeparamref name="TContainer" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dialog"/> or <paramref name="view"/> is <c>null</c>.</exception>
        public TContainer Create<TView, TContainer, THost>(TDialog dialog, TView view, THost? host = null)
            where TView : class
            where TContainer : class, IParamOnlyDialogContainer<TParam>, new()
            where THost : class
        {
            ArgumentNullException.ThrowIfNull(dialog);

            ArgumentNullException.ThrowIfNull(view);

            TContainer container = new();
            container.SetHost(host);
            container.SetContent(dialog, view);
            return container;
        }
        #endregion Public methods
    }
}
