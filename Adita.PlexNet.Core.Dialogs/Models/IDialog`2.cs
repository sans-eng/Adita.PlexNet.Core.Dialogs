﻿namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for dialog that has return value and parameter.
    /// </summary>
    public interface IDialog<TReturn, TParam> : IDialog<TReturn>
    {
        #region Methods
        /// <summary>
        /// Initialize the dialog using specified <paramref name="parameter"/>.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        void Initialize(TParam parameter);
        /// <summary>
        /// Initialize the dialog using specified <paramref name="parameter"/> asyncronously.
        /// </summary>
        /// <param name="parameter">A parameter for the dialog.</param>
        /// <returns>A <see cref="Task"/> that represents an asynchronous operation.</returns>
        Task InitializeAsync(TParam parameter);
        #endregion Methods
    }
}
