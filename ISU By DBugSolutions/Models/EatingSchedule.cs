using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class EatingSchedule
    {
        [Key]
        public int EatingSchedID { get; set; }        
        [Required]
        [Display(Name = "Creche")]
  
        public string CrecheName { get; set; }
        public IEnumerable<Creche> _CrecheName { get; set; }
        
        [Display(Name = "Meal")]
        public string MealName { get; set; }
        public IEnumerable<Meal> _MealName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
    }
}
