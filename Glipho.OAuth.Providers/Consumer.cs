namespace Glipho.OAuth.Providers
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using DotNetOpenAuth.OAuth;
    using DotNetOpenAuth.OAuth.ChannelElements;

    public class Consumer : IConsumerDescription
    {
        public string Name { get; set; }

        public Uri Callback { get; set; }

        public X509Certificate2 Certificate { get; set; }

        public string Key { get; set; }

        public string Secret { get; set; }

        public VerificationCodeFormat VerificationCodeFormat { get; set; }

        public int VerificationCodeLength { get; set; }
    }
}
