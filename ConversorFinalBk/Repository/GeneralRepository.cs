using ConversorFinal_BE.Data;
using ConversorFinalBk.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConversorFinalBk.Repository
{
    public class GeneralRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ConversorContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GeneralRepository(ConversorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            _dbSet =  context.Set<TEntity>();
        }

        public bool Exist(object id)
        {
            return _dbSet.Find(id) != null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public bool Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            return Save();
        }

        public bool Update(TEntity entity)
        {
            _context.Update(entity);
            return Save();
        }

        public bool Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                return Save();
            }
            return false;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
