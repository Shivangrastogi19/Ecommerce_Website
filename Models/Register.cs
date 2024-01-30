using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Register
	{
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
		public string Password { get; set; }
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
