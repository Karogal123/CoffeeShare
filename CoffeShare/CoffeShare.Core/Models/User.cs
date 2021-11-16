using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShare.Core.Models
{
    public class User  : IdentityUser<int>
    {
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
