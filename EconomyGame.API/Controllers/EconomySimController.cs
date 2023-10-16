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

		[Route("GetAgents")]
		[HttpGet]
		public IEnumerable<Agent> GetAgents()
		{
			return _manager.GetAgents();
		}

		[Route("InsertAgent")]
		[HttpPost]
		public void InsertAgent(string color)
		{
			Agent agent = new Agent() {
				Color = color
			};

			_manager.InsertAgent(agent, "testUserName");
		}
	}
}
