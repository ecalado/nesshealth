using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using challenge.Models;

namespace challenge.Data
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext (DbContextOptions<ChallengeContext> options)
            : base(options)
        {
        }

        public DbSet<challenge.Models.User> User { get; set; }
    }
}
