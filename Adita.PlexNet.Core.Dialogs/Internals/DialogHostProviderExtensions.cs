using System.Reflection;

namespace Adita.PlexNet.Core.Dialogs.Internals
{
    /// <summary>
    /// Provides extensions for <see cref="IDialogHostProvider"/>.
    /// </summary>
    internal static class DialogHostProviderExtensions
    {
        #region Public methods
        /// <summary>
        /// Gets a dialog host which has <see cref="Type"/> of specified <paramref name="hostType"/> for specified <typeparamref name="TDialog"/> type.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog host.</typeparam>
        /// <remarks>The <paramref name="hostType"/> is specific to target platform and should be
        /// specified on <see cref="DialogOptions"/> instance.</remarks>
        /// <param name="dialogHostProvider">The <see cref="IDialogHostProvider"/> to retrieve the dialog host from.</param>
        /// <param name="hostType">The <see cref="Type"/> of the host</param>
        /// <returns>The object of the dialog host.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dialogHostProvider"/> or <paramref name="hostType"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Unable to get or create generic method of <see cref="IDialogHostProvider.GetHost"/>.</exception>
        internal static object? GetHost<TDialog>(this IDialogHostProvider dialogHostProvider, Type hostType)
        {
            if (dialogHostProvider is null)
            {
                throw new ArgumentNullException(nameof(dialogHostProvider));
            }

            if (hostType is null)
            {
                throw new ArgumentNullException(nameof(hostType));
            }

            MethodInfo[] methodInfos = dialogHostProvider.GetType().GetMethods();

            MethodInfo? methodInfo = Array.Find(methodInfos,
                p => p.Name == nameof(IDialogHostProvider.GetHost) &&
                p.ReflectedType?.GetInterfaceMap(typeof(IDialogHostProvider)).TargetMethods.Contains(p) == true);

            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to retrieve {nameof(IDialogHostProvider.GetHost)} method.");
            }

            MethodInfo? genericMethod = methodInfo.MakeGenericMethod(hostType, typeof(TDialog));

            if (genericMethod == null)
            {
                throw new InvalidOperationException($"Unable to create generic method of {nameof(IDialogHostProvider.GetHost)}.");
            }

            return genericMethod.Invoke(dialogHostProvider, null);
        }
        #endregion Public methods
    }
}
