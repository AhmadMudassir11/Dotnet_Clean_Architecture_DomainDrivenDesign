using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
