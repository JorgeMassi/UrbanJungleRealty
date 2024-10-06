namespace UrbanJungleRealty.Application.Interfaces.Generics
{
    public interface IRepository<TEntity, TPrimaryKey>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(TPrimaryKey id);
        Task<TEntity> Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        Task<TEntity> Delete(TPrimaryKey id);
    }
}
