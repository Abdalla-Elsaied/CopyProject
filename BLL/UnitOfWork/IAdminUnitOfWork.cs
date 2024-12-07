namespace BLL;

public interface IAdminUnitOfWork : IBaseUnitOfWork<Admin, AdminVM>
{
    bool SearchByEmail(string email);
}
