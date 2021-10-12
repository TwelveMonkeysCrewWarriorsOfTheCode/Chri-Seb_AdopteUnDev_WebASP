using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface IContractRepoLibrary
	{
		public IEnumerable<ContractModelDAL> GetContractAvailable();
		public IEnumerable<ContractModelDAL> GetContractAcceptedByDev(int id);
		public IEnumerable<ContractModelDAL> GetContractIssuedByClient(int id);
	}
}
