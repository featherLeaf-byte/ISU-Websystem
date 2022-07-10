using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Login
    {
		[Required]
		[EmailAddress]
		[DisplayName("Email")]
		public string Email { get; set; }
		[Required]
		[DisplayName("Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }
	}
}
