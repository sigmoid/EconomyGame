using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.Models
{
	public class AgentSchematic
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AgentSchematicId { get; set; }
		public string Name { get; set; }
		
		[ForeignKey("AgentProduction")]
		public ICollection<AgentProduction> Productions { get; set; }
		[ForeignKey("AgentConsumption")]
		public ICollection<AgentConsumption> Consumptions { get; set; }
		[ForeignKey("AgentUtility")]
		public ICollection<AgentUtility> Utilities { get; set; }
	}
}
