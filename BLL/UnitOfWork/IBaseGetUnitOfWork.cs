namespace BLL;
public interface IBaseGetUnitOfWork<TEntity,TViewModel>
    where TEntity : ModelBase
    where TViewModel : ModelViewBase
{
    Task<IEnumerable<TViewModel>> ReadAllAsync();
    Task<TViewModel> ReadAsync(int id);
    Task<IEnumerable<TViewModel>> GetByExpressionAsync(Expression<Func<TEntity,bool>> expression);
    

}