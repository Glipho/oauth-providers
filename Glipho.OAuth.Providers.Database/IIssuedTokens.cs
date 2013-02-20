﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers.Database
{
    public interface IIssuedTokens
    {
        bool Create(IssuedToken issuedToken);
        
        IssuedToken Get(string token);

        bool Remove(int id);

        bool Update(string token, IssuedToken updatedToken);
    }
}