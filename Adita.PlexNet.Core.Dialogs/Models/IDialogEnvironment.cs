using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides an abstraction for dialog envirenment.
    /// </summary>
    public interface IDialogEnvironment
    {
        #region Properties
        /// <summary>
        /// Gets a <see cref="IServiceCollection"/> of current dialog environment.
        /// </summary>
        IServiceCollection Services { get; }
        #endregion Properties
    }
}
