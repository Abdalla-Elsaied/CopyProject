namespace BLL;

public class BaseGetUnitOfWork<TEntity, TViewModel> : IBaseGetUnitOfWork<TEntity, TViewModel>
    where TEntity : ModelBase
    where TViewModel : ModelViewBase
{
    private readonly IBaseGetRepository<TEntity> _baseGetRepository;
    protected readonly IMapper _mapper;
    protected readonly AppDbContext _dbContext;

    public BaseGetUnitOfWork(IBaseGetRepository<TEntity> baseGetRepository , IMapper mapper , AppDbContext dbContext)
    {

        _baseGetRepository = baseGetRepository;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public virtual async Task<IEnumerable<TViewModel>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        IEnumerable<TEntity>? tViewModels = await  _baseGetRepository.GetByExprissionAsync(expression);
        return _mapper.Map<List<TViewModel>>(tViewModels);
    }

    public virtual async Task<IEnumerable<TViewModel>> ReadAllAsync()
    {
        IEnumerable<TEntity>? tViewModels = await _baseGetRepository.GetAllAsync();
        return _mapper.Map<List<TViewModel>>(tViewModels);
    }

    public virtual async Task<TViewModel> ReadAsync(int id)
    {
        TEntity? tViewModel = await _baseGetRepository.GetAsync(id);
        return _mapper.Map<TViewModel>(tViewModel);
    }
}
