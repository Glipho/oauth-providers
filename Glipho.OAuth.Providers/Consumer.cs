namespace Glipho.OAuth.Providers
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using DotNetOpenAuth.OAuth;
    using DotNetOpenAuth.OAuth.ChannelElements;

    public class Consumer : IConsumerDescription
    {
        public string Name { get; set; }

        public Uri Callback
        {
            get { throw new NotImplementedException(); }
        }

        public X509Certificate2 Certificate
        {
            get { throw new NotImplementedException(); }
        }

        public string Key
        {
            get { throw new NotImplementedException(); }
        }

        public string Secret
        {
            get { throw new NotImplementedException(); }
        }

        public VerificationCodeFormat VerificationCodeFormat
        {
            get { throw new NotImplementedException(); }
        }

        public int VerificationCodeLength
        {
            get { throw new NotImplementedException(); }
        }

        internal static IConsumerDescription FromDataConsumer(Database.Consumer consumer)
        {
            throw new NotImplementedException();
        }
    }
}
