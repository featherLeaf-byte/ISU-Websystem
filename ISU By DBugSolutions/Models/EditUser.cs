using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class EditUser
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }

        public EditUser()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
    }
}
