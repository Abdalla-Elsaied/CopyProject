using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface ICompany :IGenericRepository<Company>
	{
        IQueryable<Company> SearchByName(string name);
        bool SearchByEmail(string email);
        Company GetWithTravles(int id);
    }
}
