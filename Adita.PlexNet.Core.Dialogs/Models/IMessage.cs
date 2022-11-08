using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Provides an abstraction for a message.
    /// </summary>
    public interface IMessage
    {
        #region Properties
        /// <summary>
        /// Gets or sets a <see cref="MessageType"/> of the message dialog.
        /// </summary>
        MessageType Type { get; set; }
        /// <summary>
        ///  or sets a <see cref="MessageAction"/> of the message dialog.
        /// </summary>
        MessageAction Action { get; set; }
        /// <summary>
        /// Gets or sets the caption of the message.
        /// </summary>
        string Caption { get; set; }
        /// <summary>
        /// Gets  or setsthe header of the message.
        /// </summary>
        string Header { get; set; }
        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        string Content { get; set; }
        /// <summary>
        /// Gets or sets the details of the message.
        /// </summary>
        string Details { get; set; }
        /// <summary>
        /// Gets or sets the footer of the message.
        /// </summary>
        string Footer { get; set; }
        #endregion Properties
    }
}
