using EconomyGame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.DB
{
	public class EconomySimContext : DbContext
	{ 
		public DbSet<Agent> Agents { get; set; }
		public DbSet<AgentProduction> AgentProductions { get; set; }
		public DbSet<AgentSchematic> AgentSchematics { get; set; }
		public DbSet<AgentUtility> AgentUtilities { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<ResourceType> ResourceTypes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(GetConnectionString);
		}

		private static string _connectionString;
		private static string GetConnectionString
		{
			get {

				string direc = Directory.GetCurrentDirectory();

				if (string.IsNullOrWhiteSpace(_connectionString))
				{
					var config = new ConfigurationBuilder().
						SetBasePath(Directory.GetCurrentDirectory())
						.AddJsonFile("appsettings.json")
						.Build();
					_connectionString = config.GetSection("ConnectionStrings")["EconomySimDbConnection"];
				}

				return _connectionString;
			}
		}
	}
}
