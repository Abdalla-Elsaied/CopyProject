namespace BLL;

public interface IBaseGetRepository<TEntity>
    where TEntity : ModelBase
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetByExprissionAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> GetAsync(int id);
}