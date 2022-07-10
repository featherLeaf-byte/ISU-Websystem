using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public int Year { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Video Name")]
        public string VideoName { get; set; }

        [Required]
        [NotMapped]
        [AllowedExtensions(new string[] { ".mp4"})]
        [DisplayName("Upload File")]
        public IFormFile VideoFile { get; set; }

        public Video()
        {
            Year = DateTime.Now.Year;
        }
    
    }
}
