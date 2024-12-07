using DAL.Models;

namespace AdminPl;

public interface IBaseController<TEntity, TViewModel>
    where TEntity : ModelBase
    where TViewModel : ModelViewBase
{

}
