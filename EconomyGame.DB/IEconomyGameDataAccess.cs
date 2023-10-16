using EconomyGame.Models;

namespace EconomyGame.DB
{
	public interface IEconomyGameDataAccess
	{
		IEnumerable<Agent> GetAgents();
		void InsertAgent(Agent model, string userName);
	}
}