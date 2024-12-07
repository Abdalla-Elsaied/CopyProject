using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IUnitOfWork
	{
		public IAdmin AdminRepository { get; set; }
		public ICompany CompanyRepository { get; set; }
		int Complete();
	}
}
