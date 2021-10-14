using DataProject.Entities;
using DataProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject.Repositories.Realisation
{
    public class GenericRepository<T, KId> : IRepository<T, KId> where T : BaseEntity<KId>
    {
        protected List<T> _items;

        public void Create(T item)
        {
            _items.Add(item);
        }

        public void Delete(T item)
        {
            _items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            List<T> result = new List<T>();
            _items.ForEach(entity => result.Add(entity));
            return result;
        }

        public T GetById(KId id)
        {
            return _items.Where(item => item.Id.Equals(id)).FirstOrDefault();
        }

        public void Update(T item)
        {
        }
    }
}
