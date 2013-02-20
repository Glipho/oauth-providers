using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers.Database
{
    public class RequestToken : IssuedToken
    {
        private Uri uri;
        private string p1;
        private string p2;
        private string p3;
        private string scope;

        public RequestToken()
        {
        }

        public RequestToken(Uri uri, string p1, string p2, string p3, string scope)
        {
            // TODO: Complete member initialization
            this.uri = uri;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.scope = scope;
        }
        public bool Authorised { get; set; }

        public IEnumerable<string> Scope { get; set; }

        public string Username { get; set; }

        public int Id { get; set; }
    }
}
