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
        private readonly IUserRepository _users;
       
        public UnitOfWork(ChallengeContext context)
        {
            _context = context;
            _users = new UserRepository(_context);
        }

        IUserRepository IUnitOfWork.Users => _users;

        async Task<int> IUnitOfWork.Complete()
        {
            return await _context.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}
