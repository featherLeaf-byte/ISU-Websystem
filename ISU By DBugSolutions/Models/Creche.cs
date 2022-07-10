using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISU_By_DBugSolutions.Models
{
    public class Creche
    {
        [Key]
        public int CrecheID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "House No.")]
        public string HouseNo { get; set; }
        
        [Required]
        [DisplayName("Street")] 
        public string StreetName { get; set; }
        
        [Required]
        [Display(Name = "Suburb")]
        public string SuburbName { get; set; }
       
        [Display(Name = "City")]
        public string CityName { get; set; }
       
        [Required]
        [Display(Name = "Province")]
        public string ProvinceName { get; set; }
        public IEnumerable<Province> _ProvinceName { get; set; }
        public string SearchTerm { get; set; }
    }
}
