using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShare.Core.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
