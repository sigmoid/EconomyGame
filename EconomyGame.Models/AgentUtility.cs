using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.Models
{
	public class AgentUtility
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AgentUtilityId { get; set; }
		[ForeignKey("AgentId")]
		public Agent Agent { get; set; }
		[ForeignKey("ResourceTypeId")]
		public ResourceType ResourceType { get; set; }

		[Column(TypeName = "decimal(20,4)")]
		public decimal Utility { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
	}
}
