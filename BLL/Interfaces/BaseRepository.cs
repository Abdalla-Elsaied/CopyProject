namespace BLL;

public class BaseRepository<TEntity> : BaseGetRepository<TEntity>, IBaseRepository<TEntity>
    where TEntity : ModelBase
{
    public BaseRepository(AppDbContext dbContext) : base(dbContext) { }

    public virtual async Task<TEntity> AddAsync(TEntity entity) => (await _table.AddAsync(entity)).Entity;

    public virtual async Task<TEntity> DeleteAsync(int id)
    {
        TEntity? entityFromDB = await GetAsync(id);
        if (entityFromDB is null)
            throw new Exception("Entity dosn't exist in database");

        _table.Remove(entityFromDB);

        return entityFromDB;

    }
    public virtual async Task<TEntity> EditAsync(TEntity entity)
    {
        TEntity? entityFromDB = await GetAsync(entity.Id);

        if (entityFromDB is null)
             throw new Exception("Entity dosn't exist in database");
        
        else
            return (_table.Update(entity)).Entity;
    }
}