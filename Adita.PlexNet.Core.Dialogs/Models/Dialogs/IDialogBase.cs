using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides a mechanism for a dialog.
    /// </summary>
    public interface IDialogBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the title of the dialog.
        /// </summary>
        string Title { get; set; }
        #endregion Properties

    }
}
