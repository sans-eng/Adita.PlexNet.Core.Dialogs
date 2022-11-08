using Adita.PlexNet.Core.Dialogs.Test.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adita.PlexNet.Core.Dialogs.Test.Services
{
    [TestClass]
    public class DialogProviderTest
    {
        [TestMethod]
        public void CanProvideDialog()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<DialogDummy>();
            services.AddScoped<IDialogProvider<DialogDummy>, DialogProvider<DialogDummy>>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IDialogProvider<DialogDummy>? dialogProvider = serviceProvider.GetService<IDialogProvider<DialogDummy>>();
            Assert.IsNotNull(dialogProvider);

            DialogDummy? dialog = dialogProvider.GetDialog();
            Assert.IsNotNull(dialog);
        }
    }
}
