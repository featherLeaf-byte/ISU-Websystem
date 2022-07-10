using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class CreateRole
    {
        [Required]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
    }
}
