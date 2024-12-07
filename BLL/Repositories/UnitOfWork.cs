using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;


		public IAdmin AdminRepository { get ; set; }
		public ICompany CompanyRepository { get ; set ; }
		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext;
			AdminRepository=new dAdminRepository(_dbContext);
			CompanyRepository = new CompanyRepository(_dbContext);
		}

		public int Complete()
		{
			return _dbContext.SaveChanges();
		}
	}
}
