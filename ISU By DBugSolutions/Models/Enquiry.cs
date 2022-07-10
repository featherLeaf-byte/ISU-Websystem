using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Enquiry
    {
        [Key]
        public int EnquiryID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date Submitted")]
        public DateTime Date { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Details { get; set; }
        public string SearchTerm { get; set; }

        public Enquiry()
        {
            Date = DateTime.Now;
        }
    }
}
