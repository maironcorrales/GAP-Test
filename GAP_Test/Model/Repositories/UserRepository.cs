using Model.Entities;
using Model.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
   public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(GAPTestEntities context): base(context)
        {

        }

        public GAPTestEntities GAPTestEntities
        {
            get
            {
                return Context as GAPTestEntities;
            }
        }

        public bool UserExist(string username, string password)
        {
            bool flag = false;
            var user = GAPTestEntities.Users.Where(u => u.username == username && u.user_password == password).FirstOrDefault();
            if (user != null)
                flag = true;
            return flag;
        }
    }
}
