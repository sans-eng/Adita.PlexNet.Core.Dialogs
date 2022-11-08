using System.Reflection;

namespace Adita.PlexNet.Core.Dialogs.Internals
{
    /// <summary>
    /// Provides extensions for <see cref="IDialogViewProvider"/>.
    /// </summary>
    internal static class DialogViewProviderExtensions
    {
        /// <summary>
        /// Gets a dialog view which has <see cref="Type"/> of <paramref name="viewType"/> for specified <typeparamref name="TDialog"/> type.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <remarks>The <paramref name="viewType"/> is specific to target platform and should be
        /// specified on <see cref="DialogOptions"/> instance.</remarks>
        /// <param name="dialogViewProvider">The <see cref="IDialogHostProvider"/> to retrieve the dialog host from.</param>
        /// <param name="viewType">The <see cref="Type"/> of the host</param>
        /// <returns>The object of the dialog view.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dialogViewProvider"/> or <paramref name="viewType"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Unable to get or create generic method of <see cref="IDialogViewProvider.GetView"/>.</exception>
        internal static object? GetView<TDialog>(this IDialogViewProvider dialogViewProvider, Type viewType)
        {
            if (dialogViewProvider is null)
            {
                throw new ArgumentNullException(nameof(dialogViewProvider));
            }

            if (viewType is null)
            {
                throw new ArgumentNullException(nameof(viewType));
            }

            MethodInfo[] methodInfos = dialogViewProvider.GetType().GetMethods();

            MethodInfo? methodInfo = Array.Find(methodInfos,
                p => p.IsGenericMethod && p.Name == nameof(IDialogViewProvider.GetView) &&
                p.ReflectedType?.GetInterfaceMap(typeof(IDialogViewProvider)).TargetMethods.Contains(p) == true);

            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to retrieve {nameof(IDialogViewProvider.GetView)} method.");
            }

            MethodInfo? genericMethod = methodInfo.MakeGenericMethod(viewType, typeof(TDialog));

            if (genericMethod == null)
            {
                throw new InvalidOperationException($"Unable to create generic method of {nameof(IDialogViewProvider.GetView)}.");
            }

            return genericMethod.Invoke(dialogViewProvider, null);
        }
    }
}
