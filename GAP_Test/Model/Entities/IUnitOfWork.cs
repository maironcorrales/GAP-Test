using Model.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IClientRepository Clients { get; }
        IPolicyRepository Policies { get; }
        IClientHasPolicyRepository ClienHasPolicies { get; }
        int Complete();
    }
}
