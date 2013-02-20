using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers
{
    using DotNetOpenAuth.Messaging.Bindings;

    /// <summary>
    /// A database-backed nonce store for OAuth services.
    /// </summary>
    public class NonceDbStore : INonceStore
    {
        public bool StoreNonce(string context, string nonce, DateTime timestampUtc)
        {
            throw new NotImplementedException();
        }
    }
}
