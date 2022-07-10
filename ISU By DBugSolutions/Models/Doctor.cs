using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string FirstName { get; set; } 
        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        public string SearchTerm { get; set; }
    }
}
