using ASPNETv2.Data;
using ASPNETv2.Models.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ASPNETv2.Repository.GenericRepository
{
    public class GenericRepository <TEntity> : IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _table = _context.Set <TEntity> ();
        }

        // Get all
        public async Task<List<TEntity>> GetAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        }
        public IQueryable <TEntity> GetAllAsQueryable()
        {
            return _table.AsNoTracking();
        }

        // Create
        public void Create(TEntity entity)
        {
            entity.DateCreated = DateTime.Now;
            _table.Add(entity);
        }
        public async Task CreateAsync(TEntity entity)
        {
            entity.DateCreated = DateTime.Now;
            await _table.AddAsync(entity);
        }
        public void CreateRange(IEnumerable <TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DateCreated = DateTime.Now;
                _table.Add(entity);
            }
        }

        public async Task CreateRangeAsync(IEnumerable <TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DateCreated = DateTime.Now;
                await _table.AddAsync(entity);
            }
        }

        // Update

        public void Update(TEntity entity)
        {
            entity.DateModified = DateTime.Now;
            _table.Update(entity);
        }
        public void UpdateRange(IEnumerable <TEntity> entities)
        {
            foreach(var entity in entities)
            {
                entity.DateModified = DateTime.Now;
                _table.Update(entity);
            }
        }

        // Delete
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable <TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        // Find
        public TEntity FindById(object id)
        {
            return _table.Find(id);
            // return _table.FirstOrDefault(x => x.Id.Equals(id))
        }
        public async Task <TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        // Save
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        public async Task <bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
