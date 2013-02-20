using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers
{
    using System.Web;

    internal static class Utilities
    {
        /// <summary>
        /// Gets the full URI of the web application root.  Guaranteed to end in a slash.
        /// </summary>
        internal static Uri ApplicationRoot
        {
            get
            {
                string appRoot = HttpContext.Current.Request.ApplicationPath;
                if (!appRoot.EndsWith("/", StringComparison.Ordinal))
                {
                    appRoot += "/";
                }

                return new Uri(HttpContext.Current.Request.Url, appRoot);
            }
        }
    }
}
