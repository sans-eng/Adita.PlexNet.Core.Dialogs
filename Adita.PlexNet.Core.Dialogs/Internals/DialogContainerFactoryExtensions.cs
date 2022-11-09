using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Core.Dialogs.Internals
{
    /// <summary>
    /// Provides extensions for dialog container factories.
    /// </summary>
    internal static class DialogContainerFactoryExtensions
    {
        #region Public methods
        /// <summary>
        /// Creates a dialog container for specified <paramref name="dialog" />, <paramref name="dialogView" />, <paramref name="host" /> and <paramref name="containerType"/>.
        /// </summary>
        /// <remarks>The <paramref name="containerType"/> is specific to target platform and should be
        /// specified on <see cref="DialogOptions"/> instance.</remarks>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TView">The type used for the view of the dialog.</typeparam>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <param name="factory">The <see cref="IDialogContainerFactory{TDialog}"/> to create the container.</param>
        /// <param name="dialog">The dialog as the content.</param>
        /// <param name="dialogView">The view of the dialog.</param>
        /// <param name="host">A host of the dialog.</param>
        /// <param name="containerType">The <see cref="Type"/> of the container.</param>
        /// <returns>A container that has type of <paramref name="containerType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/>, <paramref name="dialog"/>, <paramref name="dialogView"/>, <paramref name="containerType"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="containerType"/> is not a valid container.</exception>
        /// <exception cref="InvalidOperationException">Unable to get or retrieve generic method of <see cref="IDialogContainerFactory{TDialog}.Create{TView, THost, TContainer}"/>.</exception>
        /// <exception cref="InvalidOperationException">Unable to create container of type that specified on <paramref name="containerType"/>.</exception>
        public static IDialogContainer Create<TDialog, TView, THost>(this IDialogContainerFactory<TDialog> factory, TDialog dialog, TView dialogView, THost? host, Type containerType)
            where TDialog : class, IDialog
            where TView : class
            where THost : class
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogView is null)
            {
                throw new ArgumentNullException(nameof(dialogView));
            }

            if (containerType is null)
            {
                throw new ArgumentNullException(nameof(containerType));
            }

            if (!typeof(IDialogContainer).IsAssignableFrom(containerType))
            {
                throw new ArgumentException($"{nameof(containerType)} is not the implementation of {nameof(IDialogContainer)}");
            }

            MethodInfo[] methodInfos = factory.GetType().GetMethods();

            MethodInfo? methodInfo = Array.Find(
                methodInfos,
                p => p.Name == nameof(factory.Create) &&
                p.ReflectedType?.GetInterfaceMap(typeof(IDialogContainerFactory<TDialog>)).TargetMethods.Contains(p) == true);

            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to retrieve {nameof(IDialogContainerFactory<TDialog>.Create)} method.");
            }

            MethodInfo? genericMethod = methodInfo.MakeGenericMethod(dialogView.GetType(), typeof(THost), containerType);

            if (genericMethod == null)
            {
                throw new InvalidOperationException($"Unable to create generic method of {nameof(IDialogContainerFactory<TDialog>.Create)}.");
            }

            if (genericMethod.Invoke(factory, new object?[] { dialog, dialogView, host }) is not IDialogContainer container)
            {
                throw new InvalidOperationException($"Unable to create container of type {containerType.Name}.");
            }

            return container;
        }
        /// <summary>
        /// Creates a dialog container for specified <paramref name="dialog" />, <paramref name="dialogView" />, <paramref name="host" /> and <paramref name="containerType"/>.
        /// </summary>
        /// <remarks>The <paramref name="containerType"/> is specific to target platform and should be
        /// specified on <see cref="DialogOptions"/> instance.</remarks>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the dialog return value.</typeparam>
        /// <typeparam name="TView">The type used for the view of the dialog.</typeparam>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <param name="factory">The <see cref="IDialogContainerFactory{TDialog, TReturn}"/> to create the container.</param>
        /// <param name="dialog">The dialog as the content.</param>
        /// <param name="dialogView">The view of the dialog.</param>
        /// <param name="host">A host of the dialog.</param>
        /// <param name="containerType">The <see cref="Type"/> of the container.</param>
        /// <returns>A container that has type of <paramref name="containerType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/>, <paramref name="dialog"/>, <paramref name="dialogView"/>, <paramref name="containerType"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="containerType"/> is not valid container.</exception>
        /// <exception cref="InvalidOperationException">Unable to get or retrieve generic method of <see cref="IDialogContainerFactory{TDialog, TReturn}.Create{TView, THost, TContainer}"/>.</exception>
        /// <exception cref="InvalidOperationException">Unable to create container of type that specified on <paramref name="containerType"/>.</exception>
        public static IDialogContainer<TReturn> Create<TDialog, TReturn, TView, THost>(this IDialogContainerFactory<TDialog, TReturn> factory, TDialog dialog, TView dialogView, THost? host, Type containerType)
            where TDialog : class, IDialog<TReturn>
            where TView : class
            where THost : class
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogView is null)
            {
                throw new ArgumentNullException(nameof(dialogView));
            }

            if (containerType is null)
            {
                throw new ArgumentNullException(nameof(containerType));
            }

            if (!containerType.GetInterfaces().Any(p => p.IsGenericType && p.GetGenericTypeDefinition() == typeof(IDialogContainer<>)))
            {
                throw new ArgumentException($"{nameof(containerType)} is not valid container.");
            }

            Type genericContainerType = containerType.MakeGenericType(typeof(TReturn));

            MethodInfo[] methodInfos = factory.GetType().GetMethods();

            MethodInfo? methodInfo = Array.Find(
                methodInfos,
                p => p.Name == nameof(factory.Create) &&
                p.ReflectedType?.GetInterfaceMap(typeof(IDialogContainerFactory<TDialog, TReturn>)).TargetMethods.Contains(p) == true);

            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to retrieve {nameof(IDialogContainerFactory<TDialog, TReturn>.Create)} method.");
            }

            MethodInfo? genericMethod = methodInfo.MakeGenericMethod(dialogView.GetType(), typeof(THost), genericContainerType);

            if (genericMethod == null)
            {
                throw new InvalidOperationException($"Unable to create generic method of {nameof(IDialogContainerFactory<TDialog, TReturn>.Create)}.");
            }

            if (genericMethod.Invoke(factory, new object?[] { dialog, dialogView, host }) is not IDialogContainer<TReturn> container)
            {
                throw new InvalidOperationException($"Unable to create container of type {genericContainerType.Name}.");
            }

            return container;
        }
        /// <summary>
        /// Creates a dialog container for specified <paramref name="dialog" />, <paramref name="dialogView" />, <paramref name="host" /> and <paramref name="containerType"/>.
        /// </summary>
        /// <remarks>The <paramref name="containerType"/> is specific to target platform and should be
        /// specified on <see cref="DialogOptions"/> instance.</remarks>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the dialog return value.</typeparam>
        /// <typeparam name="TParam">The type used for the dialog parameter.</typeparam>
        /// <typeparam name="TView">The type used for the view of the dialog.</typeparam>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <param name="factory">The <see cref="IDialogContainerFactory{TDialog, TReturn, TParam}"/> to create the container.</param>
        /// <param name="dialog">The dialog as the content.</param>
        /// <param name="dialogView">The view of the dialog.</param>
        /// <param name="host">A host of the dialog.</param>
        /// <param name="containerType">The <see cref="Type"/> of the container.</param>
        /// <returns>A container that has type of <paramref name="containerType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/>, <paramref name="dialog"/>, <paramref name="dialogView"/>, <paramref name="containerType"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="containerType"/> is not a valid container.</exception>
        /// <exception cref="InvalidOperationException">Unable to get or retrieve generic method of <see cref="IDialogContainerFactory{TDialog, TReturn, TParam}.Create{TView, THost, TContainer}"/>.</exception>
        /// <exception cref="InvalidOperationException">Unable to create container of type that specified on <paramref name="containerType"/>.</exception>
        public static IDialogContainer<TReturn, TParam> Create<TDialog, TReturn, TParam, TView, THost>(this IDialogContainerFactory<TDialog, TReturn, TParam> factory, TDialog dialog, TView dialogView, THost? host, Type containerType)
            where TDialog : class, IDialog<TReturn, TParam>
            where TView : class
            where THost : class
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogView is null)
            {
                throw new ArgumentNullException(nameof(dialogView));
            }

            if (containerType is null)
            {
                throw new ArgumentNullException(nameof(containerType));
            }

            if (!containerType.GetInterfaces().Any(p => p.IsGenericType && p.GetGenericTypeDefinition() == typeof(IDialogContainer<,>)))
            {
                throw new ArgumentException($"{nameof(containerType)} is not valid container.");
            }

            Type genericContainerType = containerType.MakeGenericType(typeof(TReturn), typeof(TParam));

            MethodInfo[] methodInfos = factory.GetType().GetMethods();

            MethodInfo? methodInfo = Array.Find(
                methodInfos,
                p => p.Name == nameof(factory.Create) &&
                p.ReflectedType?.GetInterfaceMap(typeof(IDialogContainerFactory<TDialog, TReturn, TParam>)).TargetMethods.Contains(p) == true);

            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to retrieve {nameof(IDialogContainerFactory<TDialog, TReturn, TParam>.Create)} method.");
            }

            MethodInfo? genericMethod = methodInfo.MakeGenericMethod(dialogView.GetType(), typeof(THost), genericContainerType);

            if (genericMethod == null)
            {
                throw new InvalidOperationException($"Unable to create generic method of {nameof(IDialogContainerFactory<TDialog, TReturn, TParam>.Create)}.");
            }

            if (genericMethod.Invoke(factory, new object?[] { dialog, dialogView, host }) is not IDialogContainer<TReturn, TParam> container)
            {
                throw new InvalidOperationException($"Unable to create container of type {genericContainerType.Name}.");
            }

            return container;
        }     
        /// <summary>
        /// Creates a dialog container for specified <paramref name="dialog" />, <paramref name="dialogView" />, <paramref name="host" /> and <paramref name="containerType"/>.
        /// </summary>
        /// <remarks>The <paramref name="containerType"/> is specific to target platform and should be
        /// specified on <see cref="DialogOptions"/> instance.</remarks>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TParam">The type used for the dialog parameter.</typeparam>
        /// <typeparam name="TView">The type used for the view of the dialog.</typeparam>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <param name="factory">The <see cref="IParamOnlyDialogContainerFactory{TDialog, TParam}"/> to create the container.</param>
        /// <param name="dialog">The dialog as the content.</param>
        /// <param name="dialogView">The view of the dialog.</param>
        /// <param name="host">A host of the dialog.</param>
        /// <param name="containerType">The <see cref="Type"/> of the container.</param>
        /// <returns>A container that has type of <paramref name="containerType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/>, <paramref name="dialog"/>, <paramref name="dialogView"/>, <paramref name="containerType"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="containerType"/> is not a valid container.</exception>
        /// <exception cref="InvalidOperationException">Unable to get or retrieve generic method of <see cref="IParamOnlyDialogContainerFactory{TDialog, TParam}.Create{TView, THost, TContainer}"/>.</exception>
        /// <exception cref="InvalidOperationException">Unable to create container of type that specified on <paramref name="containerType"/>.</exception>
        public static IParamOnlyDialogContainer<TParam> Create<TDialog, TParam, TView, THost>(
            this IParamOnlyDialogContainerFactory<TDialog, TParam> factory,
            TDialog dialog,
            TView dialogView,
            THost? host,
            Type containerType)
            where TDialog : class, IParamOnlyDialog<TParam>
            where TView : class
            where THost : class
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogView is null)
            {
                throw new ArgumentNullException(nameof(dialogView));
            }

            if (containerType is null)
            {
                throw new ArgumentNullException(nameof(containerType));
            }

            if (!containerType.GetInterfaces().Any(p => p.IsGenericType && p.GetGenericTypeDefinition() == typeof(IParamOnlyDialogContainer<>)))
            {
                throw new ArgumentException($"{nameof(containerType)} is not valid container.");
            }

            Type genericContainerType = containerType.MakeGenericType(typeof(TParam));

            MethodInfo[] methodInfos = factory.GetType().GetMethods();

            MethodInfo? methodInfo = Array.Find(
                methodInfos,
                p => p.Name == nameof(factory.Create) &&
                p.ReflectedType?.GetInterfaceMap(typeof(IParamOnlyDialogContainerFactory<TDialog, TParam>)).TargetMethods.Contains(p) == true);

            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to retrieve {nameof(IParamOnlyDialogContainerFactory<TDialog, TParam>.Create)} method.");
            }

            MethodInfo? genericMethod = methodInfo.MakeGenericMethod(dialogView.GetType(), typeof(THost), genericContainerType);

            if (genericMethod == null)
            {
                throw new InvalidOperationException($"Unable to create generic method of {nameof(IParamOnlyDialogContainerFactory<TDialog, TParam>.Create)}.");
            }

            if (genericMethod.Invoke(factory, new object?[] { dialog, dialogView, host }) is not IParamOnlyDialogContainer<TParam> container)
            {
                throw new InvalidOperationException($"Unable to create container of type {genericContainerType.Name}.");
            }

            return container;
        }       
        #endregion Public methods
    }
}
