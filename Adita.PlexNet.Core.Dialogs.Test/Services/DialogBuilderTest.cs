using Adita.PlexNet.Core.Dialogs.Test.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.Core.Dialogs.Test.Services
{
    [TestClass]
    public class DialogBuilderTest
    {
        [TestMethod]
        public void CanRegisterDialogs()
        {
            IServiceCollection services = new ServiceCollection();

            DialogBuilder builder = new(services);

            builder.RegisterDialog<DialogDummy>()
                .RegisterDialog<DialogWithReturnDummy>()
                .RegisterDialog<DialogWithReturnAndParamDummy>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IDialog? dialog1 = serviceProvider.GetService<DialogDummy>();
            Assert.IsNotNull(dialog1);

            IDialog<double?>? dialog2 = serviceProvider.GetService<DialogWithReturnDummy>();
            Assert.IsNotNull(dialog2);

            IDialog<double?, string>? dialog3 = serviceProvider.GetService<DialogWithReturnAndParamDummy>();
            Assert.IsNotNull(dialog3);
        }
    }
}
