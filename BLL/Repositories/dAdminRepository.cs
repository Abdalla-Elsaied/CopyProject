using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
	public class dAdminRepository : GenericRepository<Admin>, IAdmin
	{
		public dAdminRepository(AppDbContext dbContext):base(dbContext)
		{
		}
	}
}
