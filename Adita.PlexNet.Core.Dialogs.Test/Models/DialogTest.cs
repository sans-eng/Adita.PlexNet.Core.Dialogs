namespace Adita.PlexNet.Core.Dialogs.Test.Models
{
    [TestClass]
    public class DialogTest
    {
        [TestMethod]
        public void CanCreateDialog()
        {
            DialogDummy dialog = new();

            DialogAction dialogAction = DialogAction.None;

            dialog.RequestClosing += (_, e) => dialogAction = e.DialogResult.Action;

            dialog.CallAccept();
            Assert.IsTrue(dialogAction == DialogAction.Accept);

            dialog.CallRefuse();
            Assert.IsTrue(dialogAction == DialogAction.Refuse);

            dialog.CallSubmit();
            Assert.IsTrue(dialogAction == DialogAction.Submit);

            dialog.CallCancel();
            Assert.IsTrue(dialogAction == DialogAction.Cancel);

            dialog.CallIgnore();
            Assert.IsTrue(dialogAction == DialogAction.Ignore);

            dialog.CallAbort();
            Assert.IsTrue(dialogAction == DialogAction.Abort);
        }

        [TestMethod]
        public void CanCreateDialogWithReturn()
        {
            DialogWithReturnDummy dialog = new();

            DialogAction dialogAction = DialogAction.None;
            double? returnValue = default;

            dialog.RequestClosing += (_, e) =>
            {
                dialogAction = e.DialogResult.Action;
                returnValue = e.DialogResult.Value;
            };

            dialog.CallAccept();
            Assert.IsTrue(dialogAction == DialogAction.Accept);
            Assert.IsNull(returnValue);

            dialog.CallRefuse();
            Assert.IsTrue(dialogAction == DialogAction.Refuse);
            Assert.IsNull(returnValue);

            dialog.CallSubmit(20);
            Assert.IsTrue(dialogAction == DialogAction.Submit);
            Assert.IsTrue(returnValue == 20);

            dialog.CallCancel();
            Assert.IsTrue(dialogAction == DialogAction.Cancel);
            Assert.IsNull(returnValue);

            dialog.CallIgnore();
            Assert.IsTrue(dialogAction == DialogAction.Ignore);
            Assert.IsNull(returnValue);

            dialog.CallAbort();
            Assert.IsTrue(dialogAction == DialogAction.Abort);
            Assert.IsNull(returnValue);
        }

        [TestMethod]
        public void CanCreateDialogWithReturnAndParam()
        {
            DialogWithReturnAndParamDummy dialog = new();
            dialog.Initialize("Test");

            DialogAction dialogAction = DialogAction.None;
            double? returnValue = default;

            dialog.RequestClosing += (_, e) =>
            {
                dialogAction = e.DialogResult.Action;
                returnValue = e.DialogResult.Value;
            };

            dialog.CallAccept();
            Assert.IsTrue(dialogAction == DialogAction.Accept);
            Assert.IsNull(returnValue);

            dialog.CallRefuse();
            Assert.IsTrue(dialogAction == DialogAction.Refuse);
            Assert.IsNull(returnValue);

            dialog.CallSubmit(20);
            Assert.IsTrue(dialogAction == DialogAction.Submit);
            Assert.IsTrue(returnValue == 20);

            dialog.CallCancel();
            Assert.IsTrue(dialogAction == DialogAction.Cancel);
            Assert.IsNull(returnValue);

            dialog.CallIgnore();
            Assert.IsTrue(dialogAction == DialogAction.Ignore);
            Assert.IsNull(returnValue);

            dialog.CallAbort();
            Assert.IsTrue(dialogAction == DialogAction.Abort);
            Assert.IsNull(returnValue);

            Assert.IsTrue(dialog.Parameter == "Test");
        }
    }
}
