using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace Glipho.OAuth.Providers
{
    public class AccessToken : IServiceProviderAccessToken
    {
        public DateTime? ExpirationDate { get; set; }

        public string[] Roles { get; set; }

        public string Token { get; set; }

        public string Username { get; set; }
    }
}
