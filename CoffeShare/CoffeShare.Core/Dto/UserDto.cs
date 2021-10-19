using System;

namespace CoffeeShare.Core.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
