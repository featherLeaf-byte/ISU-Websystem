using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Register
    {
		[Key]
		public int RegisterId { get; set; }
		[Required]
		[EmailAddress]
		[DisplayName("Email Address")]
		[Remote(action: "IsEmailInUse", controller: "Account")]
		public string Email { get; set; }
		[Required]
		[DisplayName("Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[DisplayName("Confirm Password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
		public string ConfirmPassword { get; set; }
		[Required]
		[DisplayName("Name")]
		public string FirstName { get; set; }
		[Required]
		[DisplayName("Surname")]
		public string LastName { get; set; }
		[Required]
		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; }
		[Required]
		public char Gender { get; set; }
		[Required]
		[DisplayName("Marital Status")]
		public string MaritalStatus { get; set; }
		[Column(TypeName = "nvarchar(100)")]
		[DisplayName("Image Name")]
		public string ImageName { get; set; }
		[Required]
		[NotMapped]
		[DisplayName("Upload File")]
		public IFormFile ImageFile { get; set; }
	}
}

