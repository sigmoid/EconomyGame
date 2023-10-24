using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyGame.Models
{
	public class Resource
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ResourceId { get; set; }
		[ForeignKey("ResourceTypeId")]
		public ResourceType ResourceType { get; set; }
		public int Quantity { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
	}
}
