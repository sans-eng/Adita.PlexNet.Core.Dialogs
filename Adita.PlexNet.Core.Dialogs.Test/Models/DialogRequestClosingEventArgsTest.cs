namespace Adita.PlexNet.Core.Dialogs.Test.Models
{
    [TestClass]
    public class DialogRequestClosingEventArgsTest
    {
        [TestMethod]
        public void CanCreateGeneric()
        {
            DialogResult dialogResult = new(DialogAction.Accept);
            DialogRequestClosingEventArgs args = new(dialogResult);

            Assert.IsNotNull(args);
            Assert.IsTrue(args.DialogResult == dialogResult);
        }

        [TestMethod]
        public void CanCreateGeneric1()
        {
            DialogResult<int> dialogResult = new(DialogAction.Accept);
            DialogRequestClosingEventArgs<int> args = new(dialogResult);

            Assert.IsNotNull(args);
            Assert.IsTrue(args.DialogResult == dialogResult);
        }
    }
}
