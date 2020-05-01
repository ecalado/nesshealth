using challenge.Models;
using Challenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Persistence.Repositories
{
    interface IUserRepository : IRepository<User>
    {
        bool Exists(int id);
    }
}
