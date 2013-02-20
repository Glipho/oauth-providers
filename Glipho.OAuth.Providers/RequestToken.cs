using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace Glipho.OAuth.Providers
{
    public class RequestToken : IServiceProviderRequestToken
    {
        public Uri Callback { get; set; }

        public string ConsumerKey { get; set; }

        public Version ConsumerVersion { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Token { get; set; }

        public string VerificationCode { get; set; }
    }
}
