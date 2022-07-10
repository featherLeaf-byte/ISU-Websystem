using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISU_By_DBugSolutions.Models
{
    public class ECDCManager
    {
        [Key]
        public int ECDCManagerID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        [Required]
        [Display(Name="Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime DateOfBirth{ get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        [NotMapped]
        [DisplayName("Upload File")]

        public IFormFile ImageFile { get; set; }       
        [Required]
        [Display(Name = "House No.")]
        public string houseNo { get; set; }
      
        [Required]
        [Display(Name = "Street")]
        public string streetName { get; set; }
        
        [Required]
        [Display(Name = "Suburb")]
        public string SuburbName { get; set; }
        
        [Required]
        [Display(Name = "City")]
        public string CityName { get; set; }
        
        [Required]
        [Display(Name ="Province")]
        public string ProvinceName { get; set; }
        public IEnumerable<Province> _ProvinceName { get; set; }
        public string SearchTerm { get; set; }
    }
}
