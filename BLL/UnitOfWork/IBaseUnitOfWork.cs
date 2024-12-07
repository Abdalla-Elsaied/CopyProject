namespace BLL;

public interface IBaseUnitOfWork<TEntity, TWiewModel> : IBaseGetUnitOfWork<TEntity, TWiewModel>
    where TEntity : ModelBase
    where TWiewModel : ModelViewBase

{
    Task<TWiewModel> CreateAsync(TWiewModel tWiewModel);
    Task<TWiewModel> UpdateAsync(TWiewModel tWiewModel);
    Task<TWiewModel> DeleteAsync(int id);

}