namespace BLL;

public interface IAdminRepository : IBaseRepository<Admin>
{
    bool SearchByEmail(string email);
}