using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.Models
{
	public class AgentConsumption
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AgentConsumptionId { get; set; }
		[ForeignKey("ResourceTypeId")]
		public ResourceType ResourceType { get; set; }

		[Column(TypeName ="decimal(20,4)")]
		public decimal AmountPerSecond { get; set; }
	}
}
