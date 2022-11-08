using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Represents a dialog environment.
    /// </summary>
    public class DialogEnvironment : IDialogEnvironment
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogEnvironment"/> using specified <paramref name="services"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to be associated with <see cref="DialogEnvironment"/>.</param>
        public DialogEnvironment(IServiceCollection services)
        {
            Services = services;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets a <see cref="IServiceCollection" /> of current dialog environment.
        /// </summary>
        public IServiceCollection Services { get; }
        #endregion Public properties
    }
}
