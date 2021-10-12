using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserIsClientModelDAL
    {
        public int? UserId { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }

        public bool? IsClient { get; set; }
    }
}
