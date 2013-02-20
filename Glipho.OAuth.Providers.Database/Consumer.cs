using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers.Database
{
    using System.Security.Cryptography.X509Certificates;

    public class Consumer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Uri Callback { get; set; }

        public string Secret { get; set; }

        public int VerificationCodeFormat { get; set; }

        public int VerificationCodeLength { get; set; }

        public X509Certificate2 Certificate { get; set; }
    }
}
