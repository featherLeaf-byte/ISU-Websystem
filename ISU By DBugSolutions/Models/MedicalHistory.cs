using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class MedicalHistory
    {
        [Key]
        public int MedHistID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string PupilName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string PupilSurname { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
     
        [Display(Name = "Disease")]
        public string DiseaseName { get; set; }
        public IEnumerable<Disease> _DiseaseName{ get; set; }
    
        [Display(Name = "Surgery")]
        public string SurgeryName { get; set; }
        public IEnumerable<Surgery> _SurgeryName { get; set; }
    
        [Display(Name = "Allergy")]
        public string AllergyName { get; set; }
        public IEnumerable<Allergy> _AllergyName { get; set; }
    
        [Display(Name = "Doctor")]
        public string DoctorName { get; set; }
        public IEnumerable<Doctor> _DoctorName { get; set; }
      
        [Display(Name = "Medication")]
        public string MedicationName { get; set; }
        public IEnumerable<Medication> _MedicationName { get; set; }
        public string SearchTerm { get; set; }
    }
}
