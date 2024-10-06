using Microsoft.EntityFrameworkCore;
using UrbanJungleRealty.Application.Interfaces.Generics;



namespace UrbanJungleRealty.Infrastruture.Data.Repository.Generics
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(TId id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return DbSet.Update(entity).Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return DbSet.Remove(entity).Entity;
        }

        public async Task<TEntity> Delete(TId id)
        {
            var entity = await GetById(id);
            return Delete(entity);
        }
    }
}

