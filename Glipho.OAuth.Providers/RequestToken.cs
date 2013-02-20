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
        public Uri Callback
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ConsumerKey
        {
            get { throw new NotImplementedException(); }
        }

        public Version ConsumerVersion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime CreatedOn
        {
            get { throw new NotImplementedException(); }
        }

        public string Token
        {
            get { throw new NotImplementedException(); }
        }

        public string VerificationCode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        internal static IServiceProviderRequestToken FromDataRequestToken(global::Glipho.OAuth.Providers.Database.RequestToken requestToken)
        {
            throw new NotImplementedException();
        }

        internal Database.RequestToken ToDataRequestToken()
        {
            throw new NotImplementedException();
        }
    }
}
