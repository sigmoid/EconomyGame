using EconomyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.DB
{
	public class EconomyGameDataAccess : IEconomyGameDataAccess
	{
		public IEnumerable<Agent> GetAgents()
		{
			using (EconomySimContext ctx = new EconomySimContext())
			{
				return ctx.Agents.ToList();
			}
		}

		public void InsertAgent(Agent model, string userName)
		{
			model.ModifiedBy = userName;
			model.DateModified = DateTime.Now;
			using (EconomySimContext ctx = new EconomySimContext())
			{
				ctx.Agents.Add(model);
				ctx.SaveChanges();
			}
		}
	}
}
