using EconomyGame.DB;
using EconomyGame.Models;

namespace EconomyGame.Logic
{
	public class EconomyGameManager : IEconomyGameManager
	{
		private readonly IEconomyGameDataAccess _dataAccess;
		public EconomyGameManager(IEconomyGameDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}
		public IEnumerable<Agent> GetAgents()
		{
			return _dataAccess.GetAgents();
		}

		public void InsertAgent(Agent agent, string userName)
		{
			_dataAccess.InsertAgent(agent, userName);
		}
	}
}