using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class UserClaims
    {
        public string UserId { get; set; }
        public List<UserClaim> Claims { get; set; }

        public UserClaims()
        {
            Claims = new List<UserClaim>();
        }
    }
}
