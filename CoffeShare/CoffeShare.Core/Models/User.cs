﻿using System;


namespace CoffeeShare.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
