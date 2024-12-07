using DAL.Models;

namespace BLL.Interfaces;

public interface IGenericRepository <T> where T :ModelBase 
{
	IEnumerable<T> GetAll();

	T Get(int id);

	void Add(T entity);
	void Update(T entity);
	void Delete(T entity);
}
