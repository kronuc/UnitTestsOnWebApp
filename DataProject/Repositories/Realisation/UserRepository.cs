using DataProject.Entities;
using DataProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject.Repositories.Realisation
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository()
        {
            _items = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                _items.Add(new User() { Id = i, Name = $"User {i}" });
            }
        }

        public List<User> GetUserRange(int start, int end)
        {
            return _items.Where(item => item.Id < end & item.Id >= start).ToList();
        }
    }
}
