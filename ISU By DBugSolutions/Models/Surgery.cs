using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Surgery
    {
        [Key]
        public int SurgeryID { get; set; }
        [Required]
        [Display(Name = "Surgery Name")]
        public string SurgeryName { get; set; }
        [Required]
        public string Description { get; set; }
        public string SearchTerm { get; set; }
    }
}
