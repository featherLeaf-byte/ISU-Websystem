using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }
        [Required]
        [Display(Name = "Province")]
        public string ProvinceName { get; set; }
        public string SearchTerm { get; set; }
    }
}
