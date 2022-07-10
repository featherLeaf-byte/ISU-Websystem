using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Disease
    {
        [Key]
        public int DiseaseID { get; set; }
        [Required]
        [Display(Name = "Disease Name")]
        public string DiseaseName { get; set; }
        [Required]
        public string Description { get; set; }
        public string SearchTerm { get; set; }

      
    }
}
