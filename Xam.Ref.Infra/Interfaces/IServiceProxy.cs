using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Models;

namespace Xam.Ref.Infra.Interfaces
{
    public interface IServiceProxy : IDisposable
    {
        Task<IServiceResult<User>> AuthenticateUserAsync(LoginDetails loggedInUser);
    }
}
