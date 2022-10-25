namespace Adita.PlexNet.Core.Dialogs.Test.Models
{
    [TestClass]
    public class DialogResultTest
    {
        [TestMethod]
        public void CanCreate()
        {
            DialogResult dialogResult1 = new(DialogAction.None);
            DialogResult dialogResult2 = new(DialogAction.Accept);
            DialogResult dialogResult3 = new(DialogAction.Refuse);
            DialogResult dialogResult4 = new(DialogAction.Submit);
            DialogResult dialogResult5 = new(DialogAction.Cancel);
            DialogResult dialogResult6 = new(DialogAction.Ignore);
            DialogResult dialogResult7 = new(DialogAction.Abort);

            Assert.IsNotNull(dialogResult1);
            Assert.IsNotNull(dialogResult2);
            Assert.IsNotNull(dialogResult3);
            Assert.IsNotNull(dialogResult4);
            Assert.IsNotNull(dialogResult5);
            Assert.IsNotNull(dialogResult6);
            Assert.IsNotNull(dialogResult7);

            Assert.IsTrue(dialogResult1.Action == DialogAction.None);
            Assert.IsTrue(dialogResult2.Action == DialogAction.Accept);
            Assert.IsTrue(dialogResult3.Action == DialogAction.Refuse);
            Assert.IsTrue(dialogResult4.Action == DialogAction.Submit);
            Assert.IsTrue(dialogResult5.Action == DialogAction.Cancel);
            Assert.IsTrue(dialogResult6.Action == DialogAction.Ignore);
            Assert.IsTrue(dialogResult7.Action == DialogAction.Abort);
        }

        [TestMethod]
        public void CanCreateGeneric1()
        {
            DialogResult<double?> dialogResult1 = new(DialogAction.None);
            DialogResult<double?> dialogResult2 = new(DialogAction.Accept);
            DialogResult<double?> dialogResult3 = new(DialogAction.Refuse);
            DialogResult<double?> dialogResult4 = new(DialogAction.Submit, 20.1);
            DialogResult<double?> dialogResult5 = new(DialogAction.Cancel);
            DialogResult<double?> dialogResult6 = new(DialogAction.Ignore);
            DialogResult<double?> dialogResult7 = new(DialogAction.Abort);

            Assert.IsNotNull(dialogResult1);
            Assert.IsNotNull(dialogResult2);
            Assert.IsNotNull(dialogResult3);
            Assert.IsNotNull(dialogResult4);
            Assert.IsNotNull(dialogResult5);
            Assert.IsNotNull(dialogResult6);
            Assert.IsNotNull(dialogResult7);

            Assert.IsTrue(dialogResult1.Action == DialogAction.None);
            Assert.IsTrue(dialogResult2.Action == DialogAction.Accept);
            Assert.IsTrue(dialogResult3.Action == DialogAction.Refuse);
            Assert.IsTrue(dialogResult4.Action == DialogAction.Submit);
            Assert.IsTrue(dialogResult5.Action == DialogAction.Cancel);
            Assert.IsTrue(dialogResult6.Action == DialogAction.Ignore);
            Assert.IsTrue(dialogResult7.Action == DialogAction.Abort);

            Assert.IsTrue(dialogResult1.Value == null);
            Assert.IsTrue(dialogResult2.Value == null);
            Assert.IsTrue(dialogResult3.Value == null);
            Assert.IsTrue(dialogResult4.Value == 20.1);
            Assert.IsTrue(dialogResult5.Value == null);
            Assert.IsTrue(dialogResult6.Value == null);
            Assert.IsTrue(dialogResult7.Value == null);
        }
    }
}
