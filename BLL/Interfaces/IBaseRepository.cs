namespace BLL;

public interface IBaseRepository<TEntity>: IBaseGetRepository<TEntity>
    where TEntity : ModelBase
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> EditAsync(TEntity entity);
    Task<TEntity> DeleteAsync(int id);
}