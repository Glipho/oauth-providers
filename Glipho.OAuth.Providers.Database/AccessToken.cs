using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers.Database
{
    public class AccessToken : IssuedToken
    {
        private string accessToken;
        private string accessTokenSecret;
        private string consumerKey;
        private IEnumerable<string> enumerable;
        private string p;

        public AccessToken()
        {
        }

        public AccessToken(string accessToken, string accessTokenSecret, string consumerKey, IEnumerable<string> enumerable, string p)
        {
            // TODO: Complete member initialization
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
            this.consumerKey = consumerKey;
            this.enumerable = enumerable;
            this.p = p;
        }
    }
}
