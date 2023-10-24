using EconomyGame.Models;

namespace EconomyGame.Logic
{
	public interface IEconomyGameManager
	{
		void DeleteResourceType(int resourceTypeId);
		IEnumerable<Agent> GetAgents();
		IEnumerable<ResourceType> GetResourceTypes();
		void InsertAgent(Agent agent, string userName);
		void InsertResourceType(ResourceType resource, string userName);
		void UpdateResourceTypes(IEnumerable<ResourceType> resources, string userName);
	}
}