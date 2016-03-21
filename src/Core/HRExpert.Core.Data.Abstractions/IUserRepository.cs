﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IUserRepository: ExtCore.Data.Abstractions.IRepository
    {
        User GetByLoginAndSecret(string login, string secret);
    }
}
