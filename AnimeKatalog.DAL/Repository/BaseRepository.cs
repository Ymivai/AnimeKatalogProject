using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.DAL.Repository
{
    public class BaseRepository<T> where T : class
    {
        DbSet<T> _table;
        DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _table;
        public Task<IEnumerable<T>> GetAllAsync => Task.Run(() => GetAll());
        public T Get(int id) => _table.Find(id);
        public void Save() => _context.SaveChanges();
        public void AddOrUppdate(T entity) => _table.AddOrUpdate(entity);
        public void Remove(T entity) => _table.Remove(entity); 
    }
}
