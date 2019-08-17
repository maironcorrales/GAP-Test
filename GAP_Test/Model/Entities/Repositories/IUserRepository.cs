using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        bool UserExist(string username, string password);
    }
}
