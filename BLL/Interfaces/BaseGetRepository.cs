namespace BLL;

public class BaseGetRepository<TEntity> : IBaseGetRepository<TEntity>
    where TEntity : ModelBase
{
    protected DbSet<TEntity> _table;

    public BaseGetRepository(AppDbContext dbContext)
    {
        _table = dbContext.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()=> await _table.ToListAsync();

    public virtual async Task<TEntity?> GetAsync(int id) => await _table.FirstOrDefaultAsync(e => e.Id == id) ;
   
    public virtual async Task<IEnumerable<TEntity>> GetByExprissionAsync(Expression<Func<TEntity, bool>> expression)=> await _table.Where(expression).ToListAsync();
    
}