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
    public class PictureBook
    {
        [Key]
        public int PictureBookId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Author { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Synopsis { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("BookFileName")]
        public string BookFileName { get; set; }

        [NotMapped]
        [AllowedExtensions(new string[] { ".pdf" })]
        [DisplayName("Upload Picture Book (PDF)")]
        [Required]
        public IFormFile BookFile { get; set; }
    }
}
