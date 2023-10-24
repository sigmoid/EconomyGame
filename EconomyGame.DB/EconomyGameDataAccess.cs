using EconomyGame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.DB
{
	public class EconomyGameDataAccess : IEconomyGameDataAccess
	{
		#region GET

		public IEnumerable<Agent> GetAgents()
		{
			using (EconomySimContext ctx = new EconomySimContext())
			{
				return ctx.Agents?.Where(x => x.IsDeleted == false).ToList();
			}
		}

		public IEnumerable<ResourceType> GetResourceTypes()
		{
			using (EconomySimContext ctx = new EconomySimContext())
			{
				return ctx.ResourceTypes?.Where(x => x.IsDeleted == false).ToList();
			}
		}

		public ResourceType GetResourceType(int resourceTypeId)
		{
			using (EconomySimContext ctx = new EconomySimContext())
			{
				return ctx.ResourceTypes.Where(x => x.IsDeleted == false && x.ResourceTypeId == resourceTypeId).ToList().FirstOrDefault();
			}
		}

		#endregion

		#region UPDATE

		public void UpdateResourceType(ResourceType resource, string userName)
		{
			using (EconomySimContext ctx = new EconomySimContext())
			{
				var dbRes = ctx.ResourceTypes.Where(x => x.ResourceTypeId == resource.ResourceTypeId).SingleOrDefault();

				if (dbRes == null)
				{
					InsertResourceType(resource, userName);
				}
				else
				{
					ctx.Entry(dbRes).CurrentValues.SetValues(resource);
					ctx.SaveChanges();
				}
			}
		}

		#endregion

		#region INSERT

		public void InsertAgent(Agent model, string userName)
		{
			model.ModifiedBy = userName;
			model.ModifiedOn = DateTime.Now;
			using (EconomySimContext ctx = new EconomySimContext())
			{
				ctx.Agents.Add(model);
				ctx.SaveChanges();
			}
		}

		public void InsertResourceType(ResourceType model, string userName)
		{
			model.ModifiedBy = userName;
			model.ModifiedOn = DateTime.Now;
			using (EconomySimContext ctx = new EconomySimContext())
			{
				ctx.ResourceTypes.Add(model);
				ctx.SaveChanges();
			}
		}

		#endregion
	}
}
