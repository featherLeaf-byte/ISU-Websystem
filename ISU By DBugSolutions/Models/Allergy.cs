using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Allergy
    {
        [Key]
        public int AllergyID { get; set; }
        [Required]
        [Display(Name = "Allergy Name")]
        public string AllergyName { get; set; }
        [Required]
        public string Description { get; set; }
        public string SearchTerm { get; set; }
    }
}
