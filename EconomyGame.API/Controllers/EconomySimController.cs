using EconomyGame.Logic;
using EconomyGame.Models;
using Microsoft.AspNetCore.Mvc;

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

		[Route("GetResources")]
		[HttpGet]
		public IEnumerable<Resource> GetResources()
		{
			return null;
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

		[Route("InsertResource")]
		[HttpPost]
		public void InsertResource()
		{
			Resource resource = new Resource()
			{
			};

			
		}

		#endregion

		#region DELETE

		[Route("DeleteResource")]
		[HttpPost]
		public void DeleteResource(int resourceId)
		{ 
		}

		#endregion
	}
}
