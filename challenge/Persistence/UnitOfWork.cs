using challenge.Data;
using Challenge.Data;
using Challenge.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Challenge.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeContext _context;

        public UnitOfWork(ChallengeContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public IUserRepository Users { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
