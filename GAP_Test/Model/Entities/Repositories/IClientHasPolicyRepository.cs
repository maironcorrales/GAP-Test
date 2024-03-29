﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities.Repositories
{
    public interface IClientHasPolicyRepository : IRepository<Client_has_Policy> 
    {
        IEnumerable<Client_has_Policy> GetAllPoliciesFromClient(int id);
    }
}
