using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShare.Core.Models
{
    public class UserRole : IdentityRole<int>
    {
    }
}
