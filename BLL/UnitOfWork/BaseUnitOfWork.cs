
using Microsoft.EntityFrameworkCore;

namespace BLL;

public class BaseUnitOfWork<TEntity, TWiewModel> : BaseGetUnitOfWork<TEntity, TWiewModel>, IBaseUnitOfWork<TEntity, TWiewModel>
        where TEntity : ModelBase
    where TWiewModel : ModelViewBase
{
    protected readonly IBaseRepository<TEntity> _baseRepository;

    public BaseUnitOfWork(IBaseRepository<TEntity> baseRepository, IMapper mapper, AppDbContext dbContext) : base(baseRepository, mapper, dbContext)
    {
        _baseRepository = baseRepository;
    }


    public virtual async Task<TWiewModel> CreateAsync(TWiewModel tWiewModel)
    {
        var tEntity = _mapper.Map<TEntity>(tWiewModel);
        var tEntityFromDb = await _baseRepository.AddAsync(tEntity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<TWiewModel>(tEntityFromDb);
    }

    public virtual async Task<TWiewModel> DeleteAsync(int id)
    {

        var tEntityFromDb =  await _baseRepository.DeleteAsync(id);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<TWiewModel>(tEntityFromDb);
    }

    public virtual async Task<TWiewModel> UpdateAsync(TWiewModel tWiewModel)
    {
        var tEntity = _mapper.Map<TEntity>(tWiewModel);
        var tEntityFromDb = await _baseRepository.EditAsync(tEntity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<TWiewModel>(tEntityFromDb);
    }
}
