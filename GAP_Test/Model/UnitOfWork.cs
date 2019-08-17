using Model.Entities;
using Model.Entities.Repositories;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GAPTestEntities _context;

        public UnitOfWork(GAPTestEntities context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Clients = new ClientRepository(_context);
            Policies = new PolicyRepository(_context);
            ClienHasPolicies = new ClientHasPolicyRepository(_context);
        }

        public IUserRepository Users { get; private set; }

        public IClientRepository Clients { get; private set; }

        public IPolicyRepository Policies { get; private set; }

        public IClientHasPolicyRepository ClienHasPolicies { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
