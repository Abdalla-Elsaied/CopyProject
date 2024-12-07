using BLL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
	{
		private protected readonly AppDbContext _dbContext;   //when send it to employee will be private
		public GenericRepository(AppDbContext dbContext) => _dbContext = dbContext;      //object will create one time and CLR have its addresss
		public void Add(T entity) => _dbContext.Set<T>().Add(entity);


		public void Update(T entity) => _dbContext.Set<T>().Update(entity);

		public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);


		public T Get(int id)
		{
			return _dbContext.Set<T>().Find(id); 
		}

		public IEnumerable<T> GetAll()
		{
			if (typeof(T) == typeof(Company))
				return (IEnumerable<T>)_dbContext.Companies.Include(e => e.Travels).AsNoTracking().ToList();

			else
				return _dbContext.Set<T>().AsNoTracking().ToList();
		}
	}
}
