﻿namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for creating a dialog container.
    /// </summary>
    /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    /// <typeparam name="TParam">The type used for the parameter.</typeparam>
    public interface IDialogContainerFactory<TDialog, TReturn, TParam>
        where TDialog : class, IDialog<TReturn, TParam>
    {
        #region Methods
        /// <summary>
        /// Creates a dialog container for specified <paramref name="dialog"/>, <paramref name="view"/> and <paramref name="host"/>.
        /// </summary>
        /// <typeparam name="TView">The type used for the view of the dialog.</typeparam>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <typeparam name="TContainer">The type used for the container.</typeparam>
        /// <param name="dialog">The dialog as the content.</param>
        /// <param name="view">The view of the dialog.</param>
        /// <param name="host">An optional host of the dialog.</param>
        /// <returns>A <typeparamref name="TContainer"/>.</returns>
        TContainer Create<TView, THost, TContainer>(TDialog dialog, TView view, THost? host = default)
            where TView : class
            where THost : class
             where TContainer : class, IDialogContainer<TReturn, TParam>, new();
        #endregion Methods
    }
}
