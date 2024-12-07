
using DAL;

namespace BLL;

public class AdminUnitOfWork : BaseUnitOfWork<Admin, AdminVM >, IAdminUnitOfWork
{
    private readonly IAdminRepository baseRepository;

    public AdminUnitOfWork(IAdminRepository baseRepository, IMapper mapper, AppDbContext dbContext) : base(baseRepository, mapper, dbContext)
    {
        this.baseRepository = baseRepository;
    }
    public bool SearchByEmail(string email)
    {
       
        return this.baseRepository.SearchByEmail(email);

    }
}
