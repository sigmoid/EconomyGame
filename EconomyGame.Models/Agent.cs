using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.Models
{
	public class Agent
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AgentId { get; set; }
		[ForeignKey("AgentSchematicId")]
		public AgentSchematic Schematic { get; set; }
		public string Color { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
		[ForeignKey("Resource")]
		public ICollection<Resource> Resources { get; set; }
	}
}
