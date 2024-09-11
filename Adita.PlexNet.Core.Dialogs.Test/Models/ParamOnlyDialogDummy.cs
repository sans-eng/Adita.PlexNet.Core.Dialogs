using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Core.Dialogs.Test.Models
{
    public class ParamOnlyDialogDummy : ParamOnlyDialog<string>
    {
        public string Parameter { get; private set; } = string.Empty;

        public void CallAccept()
        {
            Accept();
        }
        public void CallRefuse()
        {
            Refuse();
        }
        public void CallSubmit()
        {
            Submit();
        }
        public void CallCancel()
        {
            Cancel();
        }
        public void CallIgnore()
        {
            Ignore();
        }
        public void CallAbort()
        {
            Abort();
        }

        public override async Task InitializeAsync(string parameter)
        {
            Parameter = parameter;

            await Task.CompletedTask;
        }
    }
}
