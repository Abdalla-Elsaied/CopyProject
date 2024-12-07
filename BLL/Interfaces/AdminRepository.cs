

using Microsoft.EntityFrameworkCore;

namespace BLL;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public bool SearchByEmail(string email)
    {
        return _table.SingleOrDefault(c => c.Email == email) == null;
    }
}
