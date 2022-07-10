using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Medication
    {
        [Key]
        public int MedicationID { get; set; }
        [Required]
        [Display(Name = "Medication Name")]
        public string MedicationName { get; set; }
        [Required]
        public string Description { get; set; }
        public string SearchTerm { get; set; }
    }
}
