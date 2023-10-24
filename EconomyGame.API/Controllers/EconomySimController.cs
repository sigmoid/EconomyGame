using EconomyGame.Logic;
using EconomyGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;

namespace EconomyGame.API.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class EconomySimController : Controller
	{
		private readonly IEconomyGameManager _manager;
		public EconomySimController(IEconomyGameManager manager) 
		{ 
			_manager = manager;
		}

		#region GET

		[Route("GetAgents")]
		[HttpGet]
		public IEnumerable<Agent> GetAgents()
		{
			return _manager.GetAgents();
		}

		[Route("GetResourceTypes")]
		[HttpGet]
		public IEnumerable<ResourceType> GetResourceTypes()
		{
			return _manager.GetResourceTypes();
		}

		#endregion

		#region UPDATE

		[Route("UpdateResourceTypes")]
		[HttpPost]
		public void UpdateResourceTypes(IEnumerable<ResourceType> resource)
		{
			_manager.UpdateResourceTypes(resource, "testUserName");
		}

		#endregion

		#region INSERT

		[Route("InsertAgent")]
		[HttpPost]
		public void InsertAgent(string color)
		{
			Agent agent = new Agent() {
				Color = color
			};

			_manager.InsertAgent(agent, "testUserName");
		}

		[Route("InsertResourceType")]
		[HttpPost]
		public void InsertResourceType()
		{
			ResourceType resource = new ResourceType()
			{
				Name=""
			};

			_manager.InsertResourceType(resource, "testUserName");
		}

		#endregion

		#region DELETE

		[Route("DeleteResourceType")]
		[HttpPost]
		public void DeleteResourceType(int resourceTypeId)
		{
			_manager.DeleteResourceType(resourceTypeId);
		}

		#endregion
	}
}
