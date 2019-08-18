using Model.Entities;
using Model.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class ClientHasPolicyRepository: Repository<Client_has_Policy> , IClientHasPolicyRepository
    {
        public ClientHasPolicyRepository(GAPTestEntities context) : base(context)
        {

        }

        public GAPTestEntities GAPTestEntities
        {
            get
            {
                return Context as GAPTestEntities;
            }
        }

        public IEnumerable<Client_has_Policy> GetAllPoliciesFromClient(int id)
        {
            return GAPTestEntities.Client_has_Policy.Where(c => c.client_id_client == id);
        }
    }
}
