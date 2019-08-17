using Model.Entities;
using Model.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    class ClientRepository: Repository<Client>, IClientRepository
    {
        public ClientRepository(GAPTestEntities context) : base(context)
        {

        }

        public GAPTestEntities GAPTestEntities
        {
            get
            {
                return Context as GAPTestEntities;
            }
        }
    }
}
