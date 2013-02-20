using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers.Database
{
    public interface IConsumers
    {
        Consumer Get(string key);
    }
}
