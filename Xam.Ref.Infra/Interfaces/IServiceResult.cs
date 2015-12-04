using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xam.Ref.Infra.Interfaces
{
    public interface IServiceResult<T>
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the return object.
        /// </summary>
        /// <value>The return object.</value>
        T Result { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>The status code.</value>
        string StatusCode { get; set; }
    }
}
