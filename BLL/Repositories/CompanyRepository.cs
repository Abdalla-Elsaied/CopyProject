using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
	public class CompanyRepository : GenericRepository<Company>, ICompany
	{
		public CompanyRepository(AppDbContext dbContext):base(dbContext)
		{
		}

        public Company GetWithTravles(int id)
        {
            return _dbContext.Companies.Include(x=>x.Travels).FirstOrDefault(x=>x.Id == id);   
            
        }

        public bool SearchByEmail(string email)
        {
            return _dbContext.Companies.SingleOrDefault(c=>c.Email==email) == null;
        }

        public IQueryable<Company> SearchByName(string name)
        {
            return _dbContext.Companies.Where(e => e.Name.ToLower().Contains(name));
        }

    }
}
