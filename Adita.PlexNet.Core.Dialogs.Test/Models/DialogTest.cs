namespace Adita.PlexNet.Core.Dialogs.Test.Models
{
    [TestClass]
    public class DialogTest
    {
        [TestMethod]
        public void CanCreateDialog()
        {
            DialogDummy dialog = new();

            DialogActionResult dialogAction = DialogActionResult.None;

            dialog.RequestClosing += (_, e) => dialogAction = e.DialogResult.Action;

            dialog.CallAccept();
            Assert.IsTrue(dialogAction == DialogActionResult.Accept);

            dialog.CallRefuse();
            Assert.IsTrue(dialogAction == DialogActionResult.Refuse);

            dialog.CallSubmit();
            Assert.IsTrue(dialogAction == DialogActionResult.Submit);

            dialog.CallCancel();
            Assert.IsTrue(dialogAction == DialogActionResult.Cancel);

            dialog.CallIgnore();
            Assert.IsTrue(dialogAction == DialogActionResult.Ignore);

            dialog.CallAbort();
            Assert.IsTrue(dialogAction == DialogActionResult.Abort);
        }

        [TestMethod]
        public void CanCreateDialogWithReturn()
        {
            DialogWithReturnDummy dialog = new();

            DialogActionResult dialogAction = DialogActionResult.None;
            double? returnValue = default;

            dialog.RequestClosing += (_, e) =>
            {
                dialogAction = e.DialogResult.Action;
                returnValue = e.DialogResult.Value;
            };

            dialog.CallAccept();
            Assert.IsTrue(dialogAction == DialogActionResult.Accept);
            Assert.IsNull(returnValue);

            dialog.CallRefuse();
            Assert.IsTrue(dialogAction == DialogActionResult.Refuse);
            Assert.IsNull(returnValue);

            dialog.CallSubmit(20);
            Assert.IsTrue(dialogAction == DialogActionResult.Submit);
            Assert.IsTrue(returnValue == 20);

            dialog.CallCancel();
            Assert.IsTrue(dialogAction == DialogActionResult.Cancel);
            Assert.IsNull(returnValue);

            dialog.CallIgnore();
            Assert.IsTrue(dialogAction == DialogActionResult.Ignore);
            Assert.IsNull(returnValue);

            dialog.CallAbort();
            Assert.IsTrue(dialogAction == DialogActionResult.Abort);
            Assert.IsNull(returnValue);
        }

        [TestMethod]
        public void CanCreateDialogWithReturnAndParam()
        {
            DialogWithReturnAndParamDummy dialog = new();
            dialog.Initialize("Test");

            DialogActionResult dialogAction = DialogActionResult.None;
            double? returnValue = default;

            dialog.RequestClosing += (_, e) =>
            {
                dialogAction = e.DialogResult.Action;
                returnValue = e.DialogResult.Value;
            };

            dialog.CallAccept();
            Assert.IsTrue(dialogAction == DialogActionResult.Accept);
            Assert.IsNull(returnValue);

            dialog.CallRefuse();
            Assert.IsTrue(dialogAction == DialogActionResult.Refuse);
            Assert.IsNull(returnValue);

            dialog.CallSubmit(20);
            Assert.IsTrue(dialogAction == DialogActionResult.Submit);
            Assert.IsTrue(returnValue == 20);

            dialog.CallCancel();
            Assert.IsTrue(dialogAction == DialogActionResult.Cancel);
            Assert.IsNull(returnValue);

            dialog.CallIgnore();
            Assert.IsTrue(dialogAction == DialogActionResult.Ignore);
            Assert.IsNull(returnValue);

            dialog.CallAbort();
            Assert.IsTrue(dialogAction == DialogActionResult.Abort);
            Assert.IsNull(returnValue);

            Assert.IsTrue(dialog.Parameter == "Test");
        }

        [TestMethod]
        public void CanCreateParamOnlyDialog()
        {
            ParamOnlyDialogDummy dialog = new();
            dialog.Initialize("Test");

            DialogActionResult dialogAction = DialogActionResult.None;

            dialog.RequestClosing += (_, e) =>
            {
                dialogAction = e.DialogResult.Action;
            };

            dialog.CallAccept();
            Assert.IsTrue(dialogAction == DialogActionResult.Accept);

            dialog.CallRefuse();
            Assert.IsTrue(dialogAction == DialogActionResult.Refuse);

            dialog.CallSubmit();
            Assert.IsTrue(dialogAction == DialogActionResult.Submit);

            dialog.CallCancel();
            Assert.IsTrue(dialogAction == DialogActionResult.Cancel);

            dialog.CallIgnore();
            Assert.IsTrue(dialogAction == DialogActionResult.Ignore);

            dialog.CallAbort();
            Assert.IsTrue(dialogAction == DialogActionResult.Abort);

            Assert.IsTrue(dialog.Parameter == "Test");
        }
    }
}
