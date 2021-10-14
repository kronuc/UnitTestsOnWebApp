using DataProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User ,int>
    {
        public IEnumerable<User> GetUserByName(string name);
    }
}
