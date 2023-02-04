using ASPNETv2.Models.BaseEntity;

namespace ASPNETv2.Repository.GenericRepository
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        // Get all data
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllAsQueryable();

        // IQueryable - tine minte doar query-ul catre baza de date
        // IEnumerable - executa query-ul pe server, dar incarca si toate datele in memorie, iar apoi face filtrarile
        // List - doar tine date

        // Create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        // Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable <TEntity> entities);

        // Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable <TEntity> entities);

        // Find
        TEntity FindById(object id);
        Task <TEntity> FindByIdAsync(object id);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
