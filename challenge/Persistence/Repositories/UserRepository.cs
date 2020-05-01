using challenge.Data;
using challenge.Models;
using Challenge.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ChallengeContext context): base(context)
        {

        }

        public ChallengeContext ChallengeContext
        {
            get { return _context as ChallengeContext; }
        }

        public override void Add(User entity)
        {
            IsNameOrCPFAlreadyRegistered(entity.Name, entity.CPF);            

            base.Add(entity);
        }

        public override void Update(User entity)
        {
            IsNameOrCPFAlreadyRegistered(entity.Id, entity.Name, entity.CPF);

            base.Update(entity);
        }

        public bool Exists(int id)
        {
            return _context.Set<User>().Any(e => e.Id == id);
        }

        private void IsNameOrCPFAlreadyRegistered(string name, String cpf)
        {
            IsNameOrCPFAlreadyRegistered(null, name, cpf);
        }

        private void IsNameOrCPFAlreadyRegistered(int? id, string name, String cpf)
        {
            bool userAlreadyExists = false;

            if (id.HasValue)
            {
                userAlreadyExists = _context.Set<User>().Any(e => e.Id != id && (e.Name == name || e.CPF == cpf));
            }
            else
            {
                userAlreadyExists =  _context.Set<User>().Any(e => e.Name == name || e.CPF == cpf);
            }

            if (userAlreadyExists)
            {
                throw new ArgumentException("Já existe um Usuário com o mesmo Nome ou CPF.");
            }
        }
    }
}
