using Adita.PlexNet.Core.Dialogs.Test.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.Core.Dialogs.Test.Services
{
    [TestClass]
    public class DialogProviderTest
    {
        [TestMethod]
        public void CanProvideDialog()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<DialogDummy>();
            services.AddScoped<IDialogProvider, DialogProvider>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IDialogProvider? dialogProvider = serviceProvider.GetService<IDialogProvider>();
            Assert.IsNotNull(dialogProvider);

            IDialog? dialog = dialogProvider.GetDialog<DialogDummy>();
            Assert.IsNotNull(dialog);
        }

        [TestMethod]
        public void CanProvideDialogWithReturn()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<DialogWithReturnDummy>();
            services.AddScoped<IDialogProvider, DialogProvider>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IDialogProvider? dialogProvider = serviceProvider.GetService<IDialogProvider>();
            Assert.IsNotNull(dialogProvider);

            IDialog<double?>? dialog = dialogProvider.GetDialog<DialogWithReturnDummy, double?>();
            Assert.IsNotNull(dialog);
        }

        [TestMethod]
        public void CanProvideDialogWithReturnAndParam()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<DialogWithReturnAndParamDummy>();
            services.AddScoped<IDialogProvider, DialogProvider>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IDialogProvider? dialogProvider = serviceProvider.GetService<IDialogProvider>();
            Assert.IsNotNull(dialogProvider);

            IDialog<double?, string>? dialog = dialogProvider.GetDialog<DialogWithReturnAndParamDummy, double?, string>();
            Assert.IsNotNull(dialog);
        }
    }
}
