using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task<AuthenticationResult> RegisterAsync(User user);
        Task<AuthenticationResult> LoginAsync(User user);
    }
}
