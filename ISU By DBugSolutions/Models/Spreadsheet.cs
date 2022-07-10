using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Spreadsheet
    {
        [Key]
        public int SpreadsheetID { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string SheetName { get; set; }
        [Display(Name = "Date of Upload")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfUpload { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string SpreadsheetName { get; set; }
        [Required]
        [NotMapped]
        [DisplayName("Upload Spreadsheet")]
        [AllowedExtensions(new string[] { ".xls",".xlsb",".xlsm",".xlsx"})]
        public IFormFile SpreadsheetFile { get; set; }

        public Spreadsheet()
        {
            DateOfUpload = DateTime.Now;
        }
    }
}
