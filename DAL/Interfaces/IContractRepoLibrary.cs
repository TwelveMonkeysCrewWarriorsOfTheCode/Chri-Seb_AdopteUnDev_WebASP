using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface IContractRepoLibrary
	{
		public IEnumerable<ContractModelDAL> GetContractAvailable();
	}
}
