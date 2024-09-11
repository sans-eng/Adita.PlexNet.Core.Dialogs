namespace Adita.PlexNet.Core.Dialogs.Test.Tests
{
    [TestClass]
    public class DialogResultTest
    {
        [TestMethod]
        public void CanCreate()
        {
            DialogResult dialogResult1 = new(DialogActionResult.None);
            DialogResult dialogResult2 = new(DialogActionResult.Accept);
            DialogResult dialogResult3 = new(DialogActionResult.Refuse);
            DialogResult dialogResult4 = new(DialogActionResult.Submit);
            DialogResult dialogResult5 = new(DialogActionResult.Cancel);
            DialogResult dialogResult6 = new(DialogActionResult.Ignore);
            DialogResult dialogResult7 = new(DialogActionResult.Abort);

            Assert.IsNotNull(dialogResult1);
            Assert.IsNotNull(dialogResult2);
            Assert.IsNotNull(dialogResult3);
            Assert.IsNotNull(dialogResult4);
            Assert.IsNotNull(dialogResult5);
            Assert.IsNotNull(dialogResult6);
            Assert.IsNotNull(dialogResult7);

            Assert.IsTrue(dialogResult1.Action == DialogActionResult.None);
            Assert.IsTrue(dialogResult2.Action == DialogActionResult.Accept);
            Assert.IsTrue(dialogResult3.Action == DialogActionResult.Refuse);
            Assert.IsTrue(dialogResult4.Action == DialogActionResult.Submit);
            Assert.IsTrue(dialogResult5.Action == DialogActionResult.Cancel);
            Assert.IsTrue(dialogResult6.Action == DialogActionResult.Ignore);
            Assert.IsTrue(dialogResult7.Action == DialogActionResult.Abort);
        }

        [TestMethod]
        public void CanCreateGeneric1()
        {
            DialogResult<double?> dialogResult1 = new(DialogActionResult.None);
            DialogResult<double?> dialogResult2 = new(DialogActionResult.Accept);
            DialogResult<double?> dialogResult3 = new(DialogActionResult.Refuse);
            DialogResult<double?> dialogResult4 = new(DialogActionResult.Submit, 20.1);
            DialogResult<double?> dialogResult5 = new(DialogActionResult.Cancel);
            DialogResult<double?> dialogResult6 = new(DialogActionResult.Ignore);
            DialogResult<double?> dialogResult7 = new(DialogActionResult.Abort);

            Assert.IsNotNull(dialogResult1);
            Assert.IsNotNull(dialogResult2);
            Assert.IsNotNull(dialogResult3);
            Assert.IsNotNull(dialogResult4);
            Assert.IsNotNull(dialogResult5);
            Assert.IsNotNull(dialogResult6);
            Assert.IsNotNull(dialogResult7);

            Assert.IsTrue(dialogResult1.Action == DialogActionResult.None);
            Assert.IsTrue(dialogResult2.Action == DialogActionResult.Accept);
            Assert.IsTrue(dialogResult3.Action == DialogActionResult.Refuse);
            Assert.IsTrue(dialogResult4.Action == DialogActionResult.Submit);
            Assert.IsTrue(dialogResult5.Action == DialogActionResult.Cancel);
            Assert.IsTrue(dialogResult6.Action == DialogActionResult.Ignore);
            Assert.IsTrue(dialogResult7.Action == DialogActionResult.Abort);

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
