using EconomyGame.Models;

namespace EconomyGame.Logic
{
	public interface IEconomyGameManager
	{
		IEnumerable<Agent> GetAgents();
		void InsertAgent(Agent agent, string userName);
	}
}