using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
        public string Description { get; set; }
		public decimal Price {  get; set; }
		public int Stock { get; set; }

		public int CategoryId {  get; set; }
		public Category Category {  get; set; }
	}
}
