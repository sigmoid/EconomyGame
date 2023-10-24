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

		#region GET

		public IEnumerable<Agent> GetAgents()
		{
			return _dataAccess.GetAgents();
		}

		public IEnumerable<ResourceType> GetResourceTypes()
		{
			return _dataAccess.GetResourceTypes();
		}

		#endregion

		#region UPDATE

		public void UpdateResourceTypes(IEnumerable<ResourceType> resources, string userName)
		{
			foreach (var res in resources)
			{
				_dataAccess.UpdateResourceType(res, userName);
			}
		}

		#endregion

		#region INSERT

		public void InsertAgent(Agent agent, string userName)
		{
			_dataAccess.InsertAgent(agent, userName);
		}

		public void InsertResourceType(ResourceType resource, string userName)
		{
			_dataAccess.InsertResourceType(resource, userName);
		}

		#endregion

		#region DELETE
		public void DeleteResourceType(int resourceTypeId)
		{
			var model = _dataAccess.GetResourceType(resourceTypeId);

			if (model != null)
			{
				model.IsDeleted = true;

				_dataAccess.UpdateResourceType(model, "testUserName");
			}
		}

		#endregion
	}
}