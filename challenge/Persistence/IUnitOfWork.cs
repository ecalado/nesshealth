﻿using Challenge.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get;}

        Task<int> Complete();
    }
}
