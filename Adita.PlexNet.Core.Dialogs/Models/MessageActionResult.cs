using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Core.Dialogs
{
    /// <summary>
    /// Defines an action result of a message.
    /// </summary>
    public enum MessageActionResult
    {
        /// <summary>
        /// The message returns nothing.
        /// </summary>
        None = 0,
        /// <summary>
        /// The message returns <strong>OK</strong> result.
        /// </summary>
        Ok = 1,
        /// <summary>
        /// The message returns <strong>Cancel</strong> result.
        /// </summary>
        Cancel = 2,
        /// <summary>
        /// The message returns <strong>Abort</strong> result.
        /// </summary>
        Abort = 3,
        /// <summary>
        /// The message returns <strong>Ignore</strong> result.
        /// </summary>
        Ignore = 5,
        /// <summary>
        /// The message returns <strong>Yes</strong> result.
        /// </summary>
        Yes = 6,
        /// <summary>
        /// The message returns <strong>No</strong> result.
        /// </summary>
        No = 7
    }
}
