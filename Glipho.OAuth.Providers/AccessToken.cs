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
        public DateTime? ExpirationDate
        {
            get { throw new NotImplementedException(); }
        }

        public string[] Roles
        {
            get { throw new NotImplementedException(); }
        }

        public string Token
        {
            get { throw new NotImplementedException(); }
        }

        public string Username
        {
            get { throw new NotImplementedException(); }
        }

        internal static IServiceProviderAccessToken FromDataAccessToken(Database.AccessToken accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
