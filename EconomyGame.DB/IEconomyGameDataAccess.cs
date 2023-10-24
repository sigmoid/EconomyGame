using EconomyGame.Models;

namespace EconomyGame.DB
{
	public interface IEconomyGameDataAccess
	{
		IEnumerable<Agent> GetAgents();
		ResourceType GetResourceType(int resourceTypeId);
		IEnumerable<ResourceType> GetResourceTypes();
		void InsertAgent(Agent model, string userName);
		void InsertResourceType(ResourceType model, string userName);
		void UpdateResourceType(ResourceType resource, string userName);
	}
}